import { IsNumber, IsDefined, Min, IsString, IsOptional, Matches, Max, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { ScheduleFixedInterval } from "./ScheduleFixedInterval";
import { ScheduleRuleset } from "./ScheduleRuleset";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class ServiceHotWater extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    @Min(0)
    @Expose({ name: "flow_per_area" })
    /** Number for the total volume flow rate of water per unit area of floor [L/h-m2]. */
    flowPerArea!: number;
	
    @IsDefined()
    @Expose({ name: "schedule" })
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'ScheduleRuleset') return ScheduleRuleset.fromJS(item);
      else if (item?.type === 'ScheduleFixedInterval') return ScheduleFixedInterval.fromJS(item);
      else return item;
    })
    /** The schedule for the use of hot water over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the flow_per_area to yield a complete water usage profile. */
    schedule!: (ScheduleRuleset | ScheduleFixedInterval);
	
    @IsString()
    @IsOptional()
    @Matches(/^ServiceHotWater$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ServiceHotWater";
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "target_temperature" })
    /** Number for the target temperature of water out of the tap (C). This the temperature after hot water has been mixed with cold water from the water mains. The default is 60C, which essentially assumes that the flow_per_area on this object is only for water straight out of the water heater. */
    targetTemperature: number = 60;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "sensible_fraction" })
    /** A number between 0 and 1 for the fraction of the total hot water load given off as sensible heat in the zone. */
    sensibleFraction: number = 0.2;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "latent_fraction" })
    /** A number between 0 and 1 for the fraction of the total hot water load that is latent. */
    latentFraction: number = 0.05;
	

    constructor() {
        super();
        this.type = "ServiceHotWater";
        this.targetTemperature = 60;
        this.sensibleFraction = 0.2;
        this.latentFraction = 0.05;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(ServiceHotWater, _data);
        }
    }


    static override fromJS(data: any): ServiceHotWater {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ServiceHotWater();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["flow_per_area"] = this.flowPerArea;
        data["schedule"] = this.schedule;
        data["type"] = this.type ?? "ServiceHotWater";
        data["target_temperature"] = this.targetTemperature ?? 60;
        data["sensible_fraction"] = this.sensibleFraction ?? 0.2;
        data["latent_fraction"] = this.latentFraction ?? 0.05;
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
