import { IsNumber, IsDefined, Min, IsString, MinLength, MaxLength, IsOptional, Matches, Max, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class LightingAbridged extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    @Min(0)
    /** Lighting per floor area as [W/m2]. */
    watts_per_area!: number;
	
    @IsString()
    @IsDefined()
    @MinLength(1)
    @MaxLength(100)
    /** Identifier of the schedule for the use of lights over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts_per_area to yield a complete lighting profile. */
    schedule!: string;
	
    @IsString()
    @IsOptional()
    @Matches(/^LightingAbridged$/)
    /** Type */
    type?: string;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** The fraction of heat from lights that goes into the zone as visible (short-wave) radiation. (Default: 0.25). */
    visible_fraction?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** The fraction of heat from lights that is long-wave radiation. (Default: 0.32). */
    radiant_fraction?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** The fraction of the heat from lights that goes into the zone return air. (Default: 0). */
    return_air_fraction?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** The baseline lighting power density in [W/m2] of floor area. This baseline is useful to track how much better the installed lights are in comparison to a standard like ASHRAE 90.1. If set to None, it will default to 11.84029 W/m2, which is that ASHRAE 90.1-2004 baseline for an office. */
    baseline_watts_per_area?: number;
	

    constructor() {
        super();
        this.type = "LightingAbridged";
        this.visible_fraction = 0.25;
        this.radiant_fraction = 0.32;
        this.return_air_fraction = 0;
        this.baseline_watts_per_area = 11.84029;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(LightingAbridged, _data, { enableImplicitConversion: true });
            this.watts_per_area = obj.watts_per_area;
            this.schedule = obj.schedule;
            this.type = obj.type;
            this.visible_fraction = obj.visible_fraction;
            this.radiant_fraction = obj.radiant_fraction;
            this.return_air_fraction = obj.return_air_fraction;
            this.baseline_watts_per_area = obj.baseline_watts_per_area;
        }
    }


    static override fromJS(data: any): LightingAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new LightingAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["watts_per_area"] = this.watts_per_area;
        data["schedule"] = this.schedule;
        data["type"] = this.type;
        data["visible_fraction"] = this.visible_fraction;
        data["radiant_fraction"] = this.radiant_fraction;
        data["return_air_fraction"] = this.return_air_fraction;
        data["baseline_watts_per_area"] = this.baseline_watts_per_area;
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

