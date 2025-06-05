import { IsNumber, IsDefined, Min, IsString, IsOptional, Matches, Max, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { ScheduleFixedInterval } from "./ScheduleFixedInterval";
import { ScheduleRuleset } from "./ScheduleRuleset";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class Lighting extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    @Min(0)
    @Expose({ name: "watts_per_area" })
    /** Lighting per floor area as [W/m2]. */
    wattsPerArea!: number;
	
    @IsDefined()
    @Expose({ name: "schedule" })
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'ScheduleRuleset') return ScheduleRuleset.fromJS(item);
      else if (item?.type === 'ScheduleFixedInterval') return ScheduleFixedInterval.fromJS(item);
      else return item;
    })
    /** The schedule for the use of lights over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts_per_area to yield a complete lighting profile. */
    schedule!: (ScheduleRuleset | ScheduleFixedInterval);
	
    @IsString()
    @IsOptional()
    @Matches(/^Lighting$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "Lighting";
	
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
        this.type = "Lighting";
        this.visibleFraction = 0.25;
        this.radiantFraction = 0.32;
        this.returnAirFraction = 0;
        this.baselineWattsPerArea = 11.84029;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(Lighting, _data, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
            this.wattsPerArea = obj.wattsPerArea;
            this.schedule = obj.schedule;
            this.type = obj.type ?? "Lighting";
            this.visibleFraction = obj.visibleFraction ?? 0.25;
            this.radiantFraction = obj.radiantFraction ?? 0.32;
            this.returnAirFraction = obj.returnAirFraction ?? 0;
            this.baselineWattsPerArea = obj.baselineWattsPerArea ?? 11.84029;
        }
    }


    static override fromJS(data: any): Lighting {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new Lighting();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["watts_per_area"] = this.wattsPerArea;
        data["schedule"] = this.schedule;
        data["type"] = this.type ?? "Lighting";
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
