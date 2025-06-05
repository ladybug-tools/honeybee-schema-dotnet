import { IsString, IsOptional, Matches, IsNumber, Min, Max, MinLength, MaxLength, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects. */
export class VentilationControlAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^VentilationControlAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "VentilationControlAbridged";
	
    @IsNumber()
    @IsOptional()
    @Min(-100)
    @Max(100)
    @Expose({ name: "min_indoor_temperature" })
    /** A number for the minimum indoor temperature at which to ventilate in Celsius. Typically, this variable is used to initiate ventilation. */
    minIndoorTemperature: number = -100;
	
    @IsNumber()
    @IsOptional()
    @Min(-100)
    @Max(100)
    @Expose({ name: "max_indoor_temperature" })
    /** A number for the maximum indoor temperature at which to ventilate in Celsius. This can be used to set a maximum temperature at which point ventilation is stopped and a cooling system is turned on. */
    maxIndoorTemperature: number = 100;
	
    @IsNumber()
    @IsOptional()
    @Min(-100)
    @Max(100)
    @Expose({ name: "min_outdoor_temperature" })
    /** A number for the minimum outdoor temperature at which to ventilate in Celsius. This can be used to ensure ventilative cooling does not happen during the winter even if the Room is above the min_indoor_temperature. */
    minOutdoorTemperature: number = -100;
	
    @IsNumber()
    @IsOptional()
    @Min(-100)
    @Max(100)
    @Expose({ name: "max_outdoor_temperature" })
    /** A number for the maximum indoor temperature at which to ventilate in Celsius. This can be used to set a limit for when it is considered too hot outside for ventilative cooling. */
    maxOutdoorTemperature: number = 100;
	
    @IsNumber()
    @IsOptional()
    @Min(-100)
    @Max(100)
    @Expose({ name: "delta_temperature" })
    /** A number for the temperature differential in Celsius between indoor and outdoor below which ventilation is shut off.  This should usually be a positive number so that ventilation only occurs when the outdoors is cooler than the indoors. Negative numbers indicate how much hotter the outdoors can be than the indoors before ventilation is stopped. */
    deltaTemperature: number = -100;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "schedule" })
    /** Identifier of the schedule for the ventilation over the course of the year. Note that this is applied on top of any setpoints. The type of this schedule should be On/Off and values should be either 0 (no possibility of ventilation) or 1 (ventilation possible). */
    schedule?: string;
	

    constructor() {
        super();
        this.type = "VentilationControlAbridged";
        this.minIndoorTemperature = -100;
        this.maxIndoorTemperature = 100;
        this.minOutdoorTemperature = -100;
        this.maxOutdoorTemperature = 100;
        this.deltaTemperature = -100;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(VentilationControlAbridged, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.type = obj.type ?? "VentilationControlAbridged";
            this.minIndoorTemperature = obj.minIndoorTemperature ?? -100;
            this.maxIndoorTemperature = obj.maxIndoorTemperature ?? 100;
            this.minOutdoorTemperature = obj.minOutdoorTemperature ?? -100;
            this.maxOutdoorTemperature = obj.maxOutdoorTemperature ?? 100;
            this.deltaTemperature = obj.deltaTemperature ?? -100;
            this.schedule = obj.schedule;
        }
    }


    static override fromJS(data: any): VentilationControlAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new VentilationControlAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "VentilationControlAbridged";
        data["min_indoor_temperature"] = this.minIndoorTemperature ?? -100;
        data["max_indoor_temperature"] = this.maxIndoorTemperature ?? 100;
        data["min_outdoor_temperature"] = this.minOutdoorTemperature ?? -100;
        data["max_outdoor_temperature"] = this.maxOutdoorTemperature ?? 100;
        data["delta_temperature"] = this.deltaTemperature ?? -100;
        data["schedule"] = this.schedule;
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
