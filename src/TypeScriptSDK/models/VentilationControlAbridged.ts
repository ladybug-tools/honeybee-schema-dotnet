import { IsString, IsOptional, Matches, IsNumber, Min, Max, MinLength, MaxLength, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects. */
export class VentilationControlAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^VentilationControlAbridged$/)
    type?: string;
	
    @IsNumber()
    @IsOptional()
    @Min(-100)
    @Max(100)
    /** A number for the minimum indoor temperature at which to ventilate in Celsius. Typically, this variable is used to initiate ventilation. */
    min_indoor_temperature?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(-100)
    @Max(100)
    /** A number for the maximum indoor temperature at which to ventilate in Celsius. This can be used to set a maximum temperature at which point ventilation is stopped and a cooling system is turned on. */
    max_indoor_temperature?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(-100)
    @Max(100)
    /** A number for the minimum outdoor temperature at which to ventilate in Celsius. This can be used to ensure ventilative cooling does not happen during the winter even if the Room is above the min_indoor_temperature. */
    min_outdoor_temperature?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(-100)
    @Max(100)
    /** A number for the maximum indoor temperature at which to ventilate in Celsius. This can be used to set a limit for when it is considered too hot outside for ventilative cooling. */
    max_outdoor_temperature?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(-100)
    @Max(100)
    /** A number for the temperature differential in Celsius between indoor and outdoor below which ventilation is shut off.  This should usually be a positive number so that ventilation only occurs when the outdoors is cooler than the indoors. Negative numbers indicate how much hotter the outdoors can be than the indoors before ventilation is stopped. */
    delta_temperature?: number;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
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
            const obj = plainToClass(VentilationControlAbridged, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.min_indoor_temperature = obj.min_indoor_temperature;
            this.max_indoor_temperature = obj.max_indoor_temperature;
            this.min_outdoor_temperature = obj.min_outdoor_temperature;
            this.max_outdoor_temperature = obj.max_outdoor_temperature;
            this.delta_temperature = obj.delta_temperature;
            this.schedule = obj.schedule;
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
        data["type"] = this.type;
        data["min_indoor_temperature"] = this.min_indoor_temperature;
        data["max_indoor_temperature"] = this.max_indoor_temperature;
        data["min_outdoor_temperature"] = this.min_outdoor_temperature;
        data["max_outdoor_temperature"] = this.max_outdoor_temperature;
        data["delta_temperature"] = this.delta_temperature;
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

