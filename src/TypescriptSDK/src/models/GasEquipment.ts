import { IsNumber, IsDefined, Min, IsOptional, Max, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { ScheduleFixedInterval } from "./ScheduleFixedInterval";
import { ScheduleRuleset } from "./ScheduleRuleset";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class GasEquipment extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    @Min(0)
    @Expose({ name: "watts_per_area" })
    /** Equipment level per floor area as [W/m2]. */
    wattsPerArea!: number;
	
    @IsDefined()
    @Expose({ name: "schedule" })
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'ScheduleRuleset') return ScheduleRuleset.fromJS(item);
      else if (item?.type === 'ScheduleFixedInterval') return ScheduleFixedInterval.fromJS(item);
      else return item;
    })
    /** The schedule for the use of equipment over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts_per_area to yield a complete equipment profile. */
    schedule!: (ScheduleRuleset | ScheduleFixedInterval);
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "radiant_fraction" })
    /** Number for the amount of long-wave radiation heat given off by equipment. Default value is 0. */
    radiantFraction: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "latent_fraction" })
    /** Number for the amount of latent heat given off by equipment. Default value is 0. */
    latentFraction: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "lost_fraction" })
    /** Number for the amount of “lost” heat being given off by equipment. The default value is 0. */
    lostFraction: number = 0;
	
    @IsString()
    @IsOptional()
    @Matches(/^GasEquipment$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "GasEquipment";
	

    constructor() {
        super();
        this.radiantFraction = 0;
        this.latentFraction = 0;
        this.lostFraction = 0;
        this.type = "GasEquipment";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(GasEquipment, _data, { enableImplicitConversion: true });
            this.wattsPerArea = obj.wattsPerArea;
            this.schedule = obj.schedule;
            this.radiantFraction = obj.radiantFraction;
            this.latentFraction = obj.latentFraction;
            this.lostFraction = obj.lostFraction;
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): GasEquipment {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new GasEquipment();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["watts_per_area"] = this.wattsPerArea;
        data["schedule"] = this.schedule;
        data["radiant_fraction"] = this.radiantFraction;
        data["latent_fraction"] = this.latentFraction;
        data["lost_fraction"] = this.lostFraction;
        data["type"] = this.type;
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
