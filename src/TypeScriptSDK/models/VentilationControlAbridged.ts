import { IsString, IsOptional, IsNumber, validate, ValidationError as TsValidationError } from 'class-validator';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for all objects that are not extensible with additional keys.

This effectively includes all objects except for the Properties classes
that are assigned to geometry objects. */
export class VentilationControlAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsNumber()
    @IsOptional()
    /** A number for the minimum indoor temperature at which to ventilate in Celsius. Typically, this variable is used to initiate ventilation. */
    min_indoor_temperature?: number;
	
    @IsNumber()
    @IsOptional()
    /** A number for the maximum indoor temperature at which to ventilate in Celsius. This can be used to set a maximum temperature at which point ventilation is stopped and a cooling system is turned on. */
    max_indoor_temperature?: number;
	
    @IsNumber()
    @IsOptional()
    /** A number for the minimum outdoor temperature at which to ventilate in Celsius. This can be used to ensure ventilative cooling does not happen during the winter even if the Room is above the min_indoor_temperature. */
    min_outdoor_temperature?: number;
	
    @IsNumber()
    @IsOptional()
    /** A number for the maximum indoor temperature at which to ventilate in Celsius. This can be used to set a limit for when it is considered too hot outside for ventilative cooling. */
    max_outdoor_temperature?: number;
	
    @IsNumber()
    @IsOptional()
    /** A number for the temperature differential in Celsius between indoor and outdoor below which ventilation is shut off.  This should usually be a positive number so that ventilation only occurs when the outdoors is cooler than the indoors. Negative numbers indicate how much hotter the outdoors can be than the indoors before ventilation is stopped. */
    delta_temperature?: number;
	
    @IsString()
    @IsOptional()
    /** Identifier of the schedule for the ventilation over the course of the year. Note that this is applied on top of any setpoints. The type of this schedule should be On/Off and values should be either 0 (no possibility of ventilation) or 1 (ventilation possible). */
    schedule?: string;
	

    constructor() {
        super();
        this.type = "VentilationControlAbridged";
        this.min_indoor_temperature = -100;
        this.max_indoor_temperature = 100;
        this.min_outdoor_temperature = -100;
        this.max_outdoor_temperature = 100;
        this.delta_temperature = -100;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "VentilationControlAbridged";
            this.min_indoor_temperature = _data["min_indoor_temperature"] !== undefined ? _data["min_indoor_temperature"] : -100;
            this.max_indoor_temperature = _data["max_indoor_temperature"] !== undefined ? _data["max_indoor_temperature"] : 100;
            this.min_outdoor_temperature = _data["min_outdoor_temperature"] !== undefined ? _data["min_outdoor_temperature"] : -100;
            this.max_outdoor_temperature = _data["max_outdoor_temperature"] !== undefined ? _data["max_outdoor_temperature"] : 100;
            this.delta_temperature = _data["delta_temperature"] !== undefined ? _data["delta_temperature"] : -100;
            this.schedule = _data["schedule"];
        }
    }


    static override fromJS(data: any): VentilationControlAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new VentilationControlAbridged();
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
        data["min_indoor_temperature"] = this.min_indoor_temperature;
        data["max_indoor_temperature"] = this.max_indoor_temperature;
        data["min_outdoor_temperature"] = this.min_outdoor_temperature;
        data["max_outdoor_temperature"] = this.max_outdoor_temperature;
        data["delta_temperature"] = this.delta_temperature;
        data["schedule"] = this.schedule;
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
