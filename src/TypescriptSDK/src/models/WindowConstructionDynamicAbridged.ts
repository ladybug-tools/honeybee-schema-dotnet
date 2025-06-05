import { IsArray, IsInstance, ValidateNested, IsDefined, IsString, MinLength, MaxLength, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { WindowConstructionAbridged } from "./WindowConstructionAbridged";

/** Construction for window objects with an included shade layer. */
export class WindowConstructionDynamicAbridged extends IDdEnergyBaseModel {
    @IsArray()
    @IsInstance(WindowConstructionAbridged, { each: true })
    @Type(() => WindowConstructionAbridged)
    @ValidateNested({ each: true })
    @IsDefined()
    @Expose({ name: "constructions" })
    /** A list of WindowConstructionAbridged objects that define the various states that the dynamic window can assume. */
    constructions!: WindowConstructionAbridged[];
	
    @IsString()
    @IsDefined()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "schedule" })
    /** An identifier for a control schedule that dictates which constructions are active at given times throughout the simulation. The values of the schedule should be integers and range from 0 to one less then the number of constructions. Zero indicates that the first construction is active, one indicates that the second on is active, etc. The schedule type limits of this schedule should be ""Control Level."" If building custom schedule type limits that describe a particular range of states, the type limits should be ""Discrete"" and the unit type should be ""Mode,"" ""Control,"" or some other fractional unit. */
    schedule!: string;
	
    @IsString()
    @IsOptional()
    @Matches(/^WindowConstructionDynamicAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "WindowConstructionDynamicAbridged";
	

    constructor() {
        super();
        this.type = "WindowConstructionDynamicAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(WindowConstructionDynamicAbridged, _data, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
            this.constructions = obj.constructions;
            this.schedule = obj.schedule;
            this.type = obj.type ?? "WindowConstructionDynamicAbridged";
        }
    }


    static override fromJS(data: any): WindowConstructionDynamicAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new WindowConstructionDynamicAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["constructions"] = this.constructions;
        data["schedule"] = this.schedule;
        data["type"] = this.type ?? "WindowConstructionDynamicAbridged";
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
