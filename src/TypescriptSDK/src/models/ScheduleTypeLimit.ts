import { IsString, IsOptional, Matches, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { EnergyBaseModel } from "./EnergyBaseModel";
import { NoLimit } from "./NoLimit";
import { ScheduleNumericType } from "./ScheduleNumericType";
import { ScheduleUnitType } from "./ScheduleUnitType";

/** Specifies the data types and limits for values contained in schedules. */
export class ScheduleTypeLimit extends EnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^ScheduleTypeLimit$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ScheduleTypeLimit";
	
    @IsOptional()
    @Expose({ name: "lower_limit" })
    /** Lower limit for the schedule type or NoLimit. */
    lowerLimit: (NoLimit | number) = new NoLimit();
	
    @IsOptional()
    @Expose({ name: "upper_limit" })
    /** Upper limit for the schedule type or NoLimit. */
    upperLimit: (NoLimit | number) = new NoLimit();
	
    @IsEnum(ScheduleNumericType)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "numeric_type" })
    /** numericType */
    numericType: ScheduleNumericType = ScheduleNumericType.Continuous;
	
    @IsEnum(ScheduleUnitType)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "unit_type" })
    /** unitType */
    unitType: ScheduleUnitType = ScheduleUnitType.Dimensionless;
	

    constructor() {
        super();
        this.type = "ScheduleTypeLimit";
        this.lowerLimit = new NoLimit();
        this.upperLimit = new NoLimit();
        this.numericType = ScheduleNumericType.Continuous;
        this.unitType = ScheduleUnitType.Dimensionless;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ScheduleTypeLimit, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.type = obj.type ?? "ScheduleTypeLimit";
            this.lowerLimit = obj.lowerLimit ?? new NoLimit();
            this.upperLimit = obj.upperLimit ?? new NoLimit();
            this.numericType = obj.numericType ?? ScheduleNumericType.Continuous;
            this.unitType = obj.unitType ?? ScheduleUnitType.Dimensionless;
        }
    }


    static override fromJS(data: any): ScheduleTypeLimit {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ScheduleTypeLimit();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "ScheduleTypeLimit";
        data["lower_limit"] = this.lowerLimit ?? new NoLimit();
        data["upper_limit"] = this.upperLimit ?? new NoLimit();
        data["numeric_type"] = this.numericType ?? ScheduleNumericType.Continuous;
        data["unit_type"] = this.unitType ?? ScheduleUnitType.Dimensionless;
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
