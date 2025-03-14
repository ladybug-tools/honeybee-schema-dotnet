﻿import { IsString, IsOptional, Matches, IsNumber, Min, MinLength, MaxLength, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class VentilationAbridged extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^VentilationAbridged$/)
    /** Type */
    type?: string;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** Intensity of ventilation in[] m3/s per person]. Note that setting this value does not mean that ventilation is varied based on real-time occupancy but rather that the design level of ventilation is determined using this value and the People object of the Room. */
    flow_per_person?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** Intensity of ventilation in [m3/s per m2 of floor area]. */
    flow_per_area?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** Intensity of ventilation in air changes per hour (ACH) for the entire Room. */
    air_changes_per_hour?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** Intensity of ventilation in m3/s for the entire Room. */
    flow_per_zone?: number;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    /** Identifier of the schedule for the ventilation over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the total design flow rate (determined from the sum of the other 4 fields) to yield a complete ventilation profile. */
    schedule?: string;
	

    constructor() {
        super();
        this.type = "VentilationAbridged";
        this.flow_per_person = 0;
        this.flow_per_area = 0;
        this.air_changes_per_hour = 0;
        this.flow_per_zone = 0;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(VentilationAbridged, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.flow_per_person = obj.flow_per_person;
            this.flow_per_area = obj.flow_per_area;
            this.air_changes_per_hour = obj.air_changes_per_hour;
            this.flow_per_zone = obj.flow_per_zone;
            this.schedule = obj.schedule;
        }
    }


    static override fromJS(data: any): VentilationAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new VentilationAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["flow_per_person"] = this.flow_per_person;
        data["flow_per_area"] = this.flow_per_area;
        data["air_changes_per_hour"] = this.air_changes_per_hour;
        data["flow_per_zone"] = this.flow_per_zone;
        data["schedule"] = this.schedule;
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

