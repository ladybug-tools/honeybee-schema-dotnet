import { IsNumber, IsDefined, IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class LightingAbridged extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    /** Lighting per floor area as [W/m2]. */
    watts_per_area!: number;
	
    @IsString()
    @IsDefined()
    /** Identifier of the schedule for the use of lights over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts_per_area to yield a complete lighting profile. */
    schedule!: string;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsNumber()
    @IsOptional()
    /** The fraction of heat from lights that goes into the zone as visible (short-wave) radiation. (Default: 0.25). */
    visible_fraction?: number;
	
    @IsNumber()
    @IsOptional()
    /** The fraction of heat from lights that is long-wave radiation. (Default: 0.32). */
    radiant_fraction?: number;
	
    @IsNumber()
    @IsOptional()
    /** The fraction of the heat from lights that goes into the zone return air. (Default: 0). */
    return_air_fraction?: number;
	
    @IsNumber()
    @IsOptional()
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
            this.watts_per_area = _data["watts_per_area"];
            this.schedule = _data["schedule"];
            this.type = _data["type"] !== undefined ? _data["type"] : "LightingAbridged";
            this.visible_fraction = _data["visible_fraction"] !== undefined ? _data["visible_fraction"] : 0.25;
            this.radiant_fraction = _data["radiant_fraction"] !== undefined ? _data["radiant_fraction"] : 0.32;
            this.return_air_fraction = _data["return_air_fraction"] !== undefined ? _data["return_air_fraction"] : 0;
            this.baseline_watts_per_area = _data["baseline_watts_per_area"] !== undefined ? _data["baseline_watts_per_area"] : 11.84029;
        }
    }


    static override fromJS(data: any): LightingAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new LightingAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["watts_per_area"] = this.watts_per_area;
        data["schedule"] = this.schedule;
        data["type"] = this.type;
        data["visible_fraction"] = this.visible_fraction;
        data["radiant_fraction"] = this.radiant_fraction;
        data["return_air_fraction"] = this.return_air_fraction;
        data["baseline_watts_per_area"] = this.baseline_watts_per_area;
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
