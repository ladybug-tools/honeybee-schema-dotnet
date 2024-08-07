﻿import { IsString, IsOptional, IsNumber, validate, ValidationError as TsValidationError } from 'class-validator';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { ScheduleFixedInterval } from "./ScheduleFixedInterval";
import { ScheduleRuleset } from "./ScheduleRuleset";

/** Construction for Air Boundary objects. */
export class AirBoundaryConstruction extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsNumber()
    @IsOptional()
    /** A positive number for the amount of air mixing between Rooms across the air boundary surface [m3/s-m2]. Default: 0.1 corresponds to average indoor air speeds of 0.1 m/s (roughly 20 fpm), which is typical of what would be induced by a HVAC system. */
    air_mixing_per_area?: number;
	
    @IsOptional()
    /** A fractional schedule as a ScheduleRuleset or ScheduleFixedInterval for the air mixing schedule across the construction. If unspecified, an Always On schedule will be assumed. */
    air_mixing_schedule?: (ScheduleRuleset | ScheduleFixedInterval);
	

    constructor() {
        super();
        this.type = "AirBoundaryConstruction";
        this.air_mixing_per_area = 0.1;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "AirBoundaryConstruction";
            this.air_mixing_per_area = _data["air_mixing_per_area"] !== undefined ? _data["air_mixing_per_area"] : 0.1;
            this.air_mixing_schedule = _data["air_mixing_schedule"];
        }
    }


    static override fromJS(data: any): AirBoundaryConstruction {
        data = typeof data === 'object' ? data : {};

        let result = new AirBoundaryConstruction();
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
        data["air_mixing_per_area"] = this.air_mixing_per_area;
        data["air_mixing_schedule"] = this.air_mixing_schedule;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
