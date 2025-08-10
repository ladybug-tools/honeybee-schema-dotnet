import { IsArray, IsInstance, ValidateNested, IsDefined, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { ScheduleFixedInterval } from "./ScheduleFixedInterval";
import { ScheduleRuleset } from "./ScheduleRuleset";
import { WindowConstruction } from "./WindowConstruction";

/** Construction for window objects with an included shade layer. */
export class WindowConstructionDynamic extends IDdEnergyBaseModel {
    @IsArray()
    @IsInstance(WindowConstruction, { each: true })
    @Type(() => WindowConstruction)
    @ValidateNested({ each: true })
    @IsDefined()
    @Expose({ name: "constructions" })
    /** A list of WindowConstruction objects that define the various states that the dynamic window can assume. */
    constructions!: WindowConstruction[];
	
    @IsDefined()
    @Expose({ name: "schedule" })
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'ScheduleRuleset') return ScheduleRuleset.fromJS(item);
      else if (item?.type === 'ScheduleFixedInterval') return ScheduleFixedInterval.fromJS(item);
      else return item;
    })
    /** A control schedule that dictates which constructions are active at given times throughout the simulation. The values of the schedule should be integers and range from 0 to one less then the number of constructions. Zero indicates that the first construction is active, one indicates that the second on is active, etc. The schedule type limits of this schedule should be ""Control Level."" If building custom schedule type limits that describe a particular range of states, the type limits should be ""Discrete"" and the unit type should be ""Mode,"" ""Control,"" or some other fractional unit. */
    schedule!: (ScheduleRuleset | ScheduleFixedInterval);
	
    @IsString()
    @IsOptional()
    @Matches(/^WindowConstructionDynamic$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "WindowConstructionDynamic";
	

    constructor() {
        super();
        this.type = "WindowConstructionDynamic";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(WindowConstructionDynamic, _data);
        }
    }


    static override fromJS(data: any): WindowConstructionDynamic {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new WindowConstructionDynamic();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["constructions"] = this.constructions;
        data["schedule"] = this.schedule;
        data["type"] = this.type ?? "WindowConstructionDynamic";
        data = super.toJSON(data);
        return instanceToPlain(data, { exposeUnsetFields: false });
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || [error]).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
