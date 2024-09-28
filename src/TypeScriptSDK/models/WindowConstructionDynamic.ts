import { IsArray, IsInstance, ValidateNested, IsDefined, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel.ts";
import { ScheduleFixedInterval } from "./ScheduleFixedInterval.ts";
import { ScheduleRuleset } from "./ScheduleRuleset.ts";
import { WindowConstruction } from "./WindowConstruction.ts";

/** Construction for window objects with an included shade layer. */
export class WindowConstructionDynamic extends IDdEnergyBaseModel {
    @IsArray()
    @IsInstance(WindowConstruction, { each: true })
    @Type(() => WindowConstruction)
    @ValidateNested({ each: true })
    @IsDefined()
    /** A list of WindowConstruction objects that define the various states that the dynamic window can assume. */
    constructions!: WindowConstruction [];
	
    @IsDefined()
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
    type?: string;
	

    constructor() {
        super();
        this.type = "WindowConstructionDynamic";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(WindowConstructionDynamic, _data, { enableImplicitConversion: true });
            this.constructions = obj.constructions;
            this.schedule = obj.schedule;
            this.type = obj.type;
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
        data["type"] = this.type;
        data = super.toJSON(data);
        return instanceToPlain(data);
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

