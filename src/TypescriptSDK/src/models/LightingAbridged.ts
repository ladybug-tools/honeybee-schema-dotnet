import { IsNumber, IsDefined, Min, IsString, MinLength, MaxLength, IsOptional, Matches, Max, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class LightingAbridged extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    @Min(0)
    @Expose({ name: "watts_per_area" })
    /** Lighting per floor area as [W/m2]. */
    wattsPerArea!: number;
	
    @IsString()
    @IsDefined()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "schedule" })
    /** Identifier of the schedule for the use of lights over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts_per_area to yield a complete lighting profile. */
    schedule!: string;
	
    @IsString()
    @IsOptional()
    @Matches(/^LightingAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "LightingAbridged";
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "visible_fraction" })
    /** The fraction of heat from lights that goes into the zone as visible (short-wave) radiation. (Default: 0.25). */
    visibleFraction: number = 0.25;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "radiant_fraction" })
    /** The fraction of heat from lights that is long-wave radiation. (Default: 0.32). */
    radiantFraction: number = 0.32;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "return_air_fraction" })
    /** The fraction of the heat from lights that goes into the zone return air. (Default: 0). */
    returnAirFraction: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "baseline_watts_per_area" })
    /** The baseline lighting power density in [W/m2] of floor area. This baseline is useful to track how much better the installed lights are in comparison to a standard like ASHRAE 90.1. If set to None, it will default to 11.84029 W/m2, which is that ASHRAE 90.1-2004 baseline for an office. */
    baselineWattsPerArea: number = 11.84029;
	

    constructor() {
        super();
        this.type = "LightingAbridged";
        this.visibleFraction = 0.25;
        this.radiantFraction = 0.32;
        this.returnAirFraction = 0;
        this.baselineWattsPerArea = 11.84029;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(LightingAbridged, _data);
            this.wattsPerArea = obj.wattsPerArea;
            this.schedule = obj.schedule;
            this.type = obj.type ?? "LightingAbridged";
            this.visibleFraction = obj.visibleFraction ?? 0.25;
            this.radiantFraction = obj.radiantFraction ?? 0.32;
            this.returnAirFraction = obj.returnAirFraction ?? 0;
            this.baselineWattsPerArea = obj.baselineWattsPerArea ?? 11.84029;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
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
        data["watts_per_area"] = this.wattsPerArea;
        data["schedule"] = this.schedule;
        data["type"] = this.type ?? "LightingAbridged";
        data["visible_fraction"] = this.visibleFraction ?? 0.25;
        data["radiant_fraction"] = this.radiantFraction ?? 0.32;
        data["return_air_fraction"] = this.returnAirFraction ?? 0;
        data["baseline_watts_per_area"] = this.baselineWattsPerArea ?? 11.84029;
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
