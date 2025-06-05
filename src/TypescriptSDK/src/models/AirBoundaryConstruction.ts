import { IsString, IsOptional, Matches, IsNumber, Min, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { ScheduleFixedInterval } from "./ScheduleFixedInterval";
import { ScheduleRuleset } from "./ScheduleRuleset";

/** Construction for Air Boundary objects. */
export class AirBoundaryConstruction extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^AirBoundaryConstruction$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "AirBoundaryConstruction";
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "air_mixing_per_area" })
    /** A positive number for the amount of air mixing between Rooms across the air boundary surface [m3/s-m2]. Default: 0.1 corresponds to average indoor air speeds of 0.1 m/s (roughly 20 fpm), which is typical of what would be induced by a HVAC system. */
    airMixingPerArea: number = 0.1;
	
    @IsOptional()
    @Expose({ name: "air_mixing_schedule" })
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'ScheduleRuleset') return ScheduleRuleset.fromJS(item);
      else if (item?.type === 'ScheduleFixedInterval') return ScheduleFixedInterval.fromJS(item);
      else return item;
    })
    /** A fractional schedule as a ScheduleRuleset or ScheduleFixedInterval for the air mixing schedule across the construction. If unspecified, an Always On schedule will be assumed. */
    airMixingSchedule?: (ScheduleRuleset | ScheduleFixedInterval);
	

    constructor() {
        super();
        this.type = "AirBoundaryConstruction";
        this.airMixingPerArea = 0.1;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(AirBoundaryConstruction, _data, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
            this.type = obj.type ?? "AirBoundaryConstruction";
            this.airMixingPerArea = obj.airMixingPerArea ?? 0.1;
            this.airMixingSchedule = obj.airMixingSchedule;
        }
    }


    static override fromJS(data: any): AirBoundaryConstruction {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new AirBoundaryConstruction();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "AirBoundaryConstruction";
        data["air_mixing_per_area"] = this.airMixingPerArea ?? 0.1;
        data["air_mixing_schedule"] = this.airMixingSchedule;
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
