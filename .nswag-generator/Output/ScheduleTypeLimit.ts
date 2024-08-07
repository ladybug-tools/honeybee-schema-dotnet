import { IsString, IsOptional, IsEnum, ValidateNested, validate, ValidationError } from 'class-validator';
import { NoLimit } from "./NoLimit";
import { ScheduleNumericType } from "./ScheduleNumericType";
import { ScheduleUnitType } from "./ScheduleUnitType";
import { EnergyBaseModel } from "./EnergyBaseModel";

/** Specifies the data types and limits for values contained in schedules. */
export class ScheduleTypeLimit extends EnergyBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsOptional()
    /** Lower limit for the schedule type or NoLimit. */
    lower_limit?: NoLimit | number;
	
    @IsOptional()
    /** Upper limit for the schedule type or NoLimit. */
    upper_limit?: NoLimit | number;
	
    @IsEnum(ScheduleNumericType)
    @ValidateNested()
    @IsOptional()
    numeric_type?: ScheduleNumericType;
	
    @IsEnum(ScheduleUnitType)
    @ValidateNested()
    @IsOptional()
    unit_type?: ScheduleUnitType;
	

    constructor() {
        super();
        this.type = "ScheduleTypeLimit";
        this.lower_limit = new NoLimit();;
        this.upper_limit = new NoLimit();;
        this.numeric_type = ScheduleNumericType.Continuous;
        this.unit_type = ScheduleUnitType.Dimensionless;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "ScheduleTypeLimit";
            this.lower_limit = _data["lower_limit"] !== undefined ? _data["lower_limit"] : new NoLimit();;
            this.upper_limit = _data["upper_limit"] !== undefined ? _data["upper_limit"] : new NoLimit();;
            this.numeric_type = _data["numeric_type"] !== undefined ? _data["numeric_type"] : ScheduleNumericType.Continuous;
            this.unit_type = _data["unit_type"] !== undefined ? _data["unit_type"] : ScheduleUnitType.Dimensionless;
        }
    }


    static override fromJS(data: any): ScheduleTypeLimit {
        data = typeof data === 'object' ? data : {};

        let result = new ScheduleTypeLimit();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["type"] = this.type;
        data["lower_limit"] = this.lower_limit;
        data["upper_limit"] = this.upper_limit;
        data["numeric_type"] = this.numeric_type;
        data["unit_type"] = this.unit_type;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: ValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
