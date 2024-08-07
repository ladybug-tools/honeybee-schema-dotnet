import { IsNumber, IsDefined, IsString, IsOptional, validate, ValidationError } from 'class-validator';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class ServiceHotWaterAbridged extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    /** Number for the total volume flow rate of water per unit area of floor [L/h-m2]. */
    flow_per_area!: number;
	
    @IsString()
    @IsDefined()
    /** Identifier of the schedule for the hot water use over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the flow_per_area to yield a complete water usage profile. */
    schedule!: string;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsNumber()
    @IsOptional()
    /** Number for the target temperature of water out of the tap (C). This the temperature after hot water has been mixed with cold water from the water mains. The default is 60C, which essentially assumes that the flow_per_area on this object is only for water straight out of the water heater. */
    target_temperature?: number;
	
    @IsNumber()
    @IsOptional()
    /** A number between 0 and 1 for the fraction of the total hot water load given off as sensible heat in the zone. */
    sensible_fraction?: number;
	
    @IsNumber()
    @IsOptional()
    /** A number between 0 and 1 for the fraction of the total hot water load that is latent. */
    latent_fraction?: number;
	

    constructor() {
        super();
        this.type = "ServiceHotWaterAbridged";
        this.target_temperature = 60;
        this.sensible_fraction = 0.2;
        this.latent_fraction = 0.05;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.flow_per_area = _data["flow_per_area"];
            this.schedule = _data["schedule"];
            this.type = _data["type"] !== undefined ? _data["type"] : "ServiceHotWaterAbridged";
            this.target_temperature = _data["target_temperature"] !== undefined ? _data["target_temperature"] : 60;
            this.sensible_fraction = _data["sensible_fraction"] !== undefined ? _data["sensible_fraction"] : 0.2;
            this.latent_fraction = _data["latent_fraction"] !== undefined ? _data["latent_fraction"] : 0.05;
        }
    }


    static override fromJS(data: any): ServiceHotWaterAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new ServiceHotWaterAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["flow_per_area"] = this.flow_per_area;
        data["schedule"] = this.schedule;
        data["type"] = this.type;
        data["target_temperature"] = this.target_temperature;
        data["sensible_fraction"] = this.sensible_fraction;
        data["latent_fraction"] = this.latent_fraction;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: ValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
