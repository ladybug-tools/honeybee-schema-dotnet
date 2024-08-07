import { IsString, IsOptional, IsNumber, validate, ValidationError } from 'class-validator';
import { ScheduleRuleset } from "./ScheduleRuleset";
import { ScheduleFixedInterval } from "./ScheduleFixedInterval";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class Ventilation extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsNumber()
    @IsOptional()
    /** Intensity of ventilation in[] m3/s per person]. Note that setting this value does not mean that ventilation is varied based on real-time occupancy but rather that the design level of ventilation is determined using this value and the People object of the Room. */
    flow_per_person?: number;
	
    @IsNumber()
    @IsOptional()
    /** Intensity of ventilation in [m3/s per m2 of floor area]. */
    flow_per_area?: number;
	
    @IsNumber()
    @IsOptional()
    /** Intensity of ventilation in air changes per hour (ACH) for the entire Room. */
    air_changes_per_hour?: number;
	
    @IsNumber()
    @IsOptional()
    /** Intensity of ventilation in m3/s for the entire Room. */
    flow_per_zone?: number;
	
    @IsOptional()
    /** Schedule for the ventilation over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the total design flow rate (determined from the sum of the other 4 fields) to yield a complete ventilation profile. */
    schedule?: ScheduleRuleset | ScheduleFixedInterval;
	

    constructor() {
        super();
        this.type = "Ventilation";
        this.flow_per_person = 0;
        this.flow_per_area = 0;
        this.air_changes_per_hour = 0;
        this.flow_per_zone = 0;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "Ventilation";
            this.flow_per_person = _data["flow_per_person"] !== undefined ? _data["flow_per_person"] : 0;
            this.flow_per_area = _data["flow_per_area"] !== undefined ? _data["flow_per_area"] : 0;
            this.air_changes_per_hour = _data["air_changes_per_hour"] !== undefined ? _data["air_changes_per_hour"] : 0;
            this.flow_per_zone = _data["flow_per_zone"] !== undefined ? _data["flow_per_zone"] : 0;
            this.schedule = _data["schedule"];
        }
    }


    static override fromJS(data: any): Ventilation {
        data = typeof data === 'object' ? data : {};

        let result = new Ventilation();
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
        data["flow_per_person"] = this.flow_per_person;
        data["flow_per_area"] = this.flow_per_area;
        data["air_changes_per_hour"] = this.air_changes_per_hour;
        data["flow_per_zone"] = this.flow_per_zone;
        data["schedule"] = this.schedule;
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
