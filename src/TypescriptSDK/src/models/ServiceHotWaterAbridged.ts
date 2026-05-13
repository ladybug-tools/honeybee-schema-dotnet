import { IsNumber, IsDefined, Min, IsString, IsOptional, Equals, MinLength, MaxLength, Max, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

export class ServiceHotWaterAbridged extends IDdEnergyBaseModel {
    @Type(() => Number)
    @IsNumber()
    @IsDefined()
    @Min(0)
    @Expose({ name: "flow_per_area" })
    /** Number for the total volume flow rate of water per unit area of floor [L/h-m2]. */
    flowPerArea!: number;
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("ServiceHotWaterAbridged")
    @Expose({ name: "type" })
    /** type */
    type: string = "ServiceHotWaterAbridged";
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "schedule" })
    /** Identifier of the schedule for the hot water use over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the flow_per_area to yield a complete water usage profile. If None, an Always On schedule will be used. */
    schedule?: string;
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Expose({ name: "target_temperature" })
    /** Number for the target temperature of water out of the tap (C). This the temperature after hot water has been mixed with cold water from the water mains. The default is 60C, which essentially assumes that the flow_per_area on this object is only for water straight out of the water heater. */
    targetTemperature: number = 60;
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "sensible_fraction" })
    /** A number between 0 and 1 for the fraction of the total hot water load given off as sensible heat in the zone. */
    sensibleFraction: number = 0.2;
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "latent_fraction" })
    /** A number between 0 and 1 for the fraction of the total hot water load that is latent. */
    latentFraction: number = 0.05;
	

    constructor() {
        super();
        this.type = "ServiceHotWaterAbridged";
        this.targetTemperature = 60;
        this.sensibleFraction = 0.2;
        this.latentFraction = 0.05;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(ServiceHotWaterAbridged, _data);
            this.flowPerArea = obj.flowPerArea;
            this.type = obj.type ?? "ServiceHotWaterAbridged";
            this.schedule = obj.schedule;
            this.targetTemperature = obj.targetTemperature ?? 60;
            this.sensibleFraction = obj.sensibleFraction ?? 0.2;
            this.latentFraction = obj.latentFraction ?? 0.05;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static override fromJS(data: any): ServiceHotWaterAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ServiceHotWaterAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["flow_per_area"] = this.flowPerArea;
        data["type"] = this.type ?? "ServiceHotWaterAbridged";
        data["schedule"] = this.schedule;
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
