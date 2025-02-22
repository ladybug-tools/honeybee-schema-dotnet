﻿import { IsString, IsOptional, Matches, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { EnergyBaseModel } from "./EnergyBaseModel";
import { NoLimit } from "./NoLimit";
import { ScheduleNumericType } from "./ScheduleNumericType";
import { ScheduleUnitType } from "./ScheduleUnitType";

/** Specifies the data types and limits for values contained in schedules. */
export class ScheduleTypeLimit extends EnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^ScheduleTypeLimit$/)
    /** Type */
    type?: string;
	
    @IsOptional()
    /** Lower limit for the schedule type or NoLimit. */
    lower_limit?: (NoLimit | number);
	
    @IsOptional()
    /** Upper limit for the schedule type or NoLimit. */
    upper_limit?: (NoLimit | number);
	
    @IsEnum(ScheduleNumericType)
    @Type(() => String)
    @IsOptional()
    /** NumericType */
    numeric_type?: ScheduleNumericType;
	
    @IsEnum(ScheduleUnitType)
    @Type(() => String)
    @IsOptional()
    /** UnitType */
    unit_type?: ScheduleUnitType;
	

    constructor() {
        super();
        this.type = "ScheduleTypeLimit";
        this.lower_limit = new NoLimit();
        this.upper_limit = new NoLimit();
        this.numeric_type = ScheduleNumericType.Continuous;
        this.unit_type = ScheduleUnitType.Dimensionless;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ScheduleTypeLimit, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.lower_limit = obj.lower_limit;
            this.upper_limit = obj.upper_limit;
            this.numeric_type = obj.numeric_type;
            this.unit_type = obj.unit_type;
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
        data["type"] = this.type;
        data["lower_limit"] = this.lower_limit;
        data["upper_limit"] = this.upper_limit;
        data["numeric_type"] = this.numeric_type;
        data["unit_type"] = this.unit_type;
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

