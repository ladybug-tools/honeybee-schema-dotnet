import { IsNumber, IsDefined, Min, IsString, MinLength, MaxLength, IsOptional, Matches, Max, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel.ts";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class ServiceHotWaterAbridged extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    @Min(0)
    /** Number for the total volume flow rate of water per unit area of floor [L/h-m2]. */
    flow_per_area!: number;
	
    @IsString()
    @IsDefined()
    @MinLength(1)
    @MaxLength(100)
    /** Identifier of the schedule for the hot water use over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the flow_per_area to yield a complete water usage profile. */
    schedule!: string;
	
    @IsString()
    @IsOptional()
    @Matches(/^ServiceHotWaterAbridged$/)
    type?: string;
	
    @IsNumber()
    @IsOptional()
    /** Number for the target temperature of water out of the tap (C). This the temperature after hot water has been mixed with cold water from the water mains. The default is 60C, which essentially assumes that the flow_per_area on this object is only for water straight out of the water heater. */
    target_temperature?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** A number between 0 and 1 for the fraction of the total hot water load given off as sensible heat in the zone. */
    sensible_fraction?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
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
            const obj = plainToClass(ServiceHotWaterAbridged, _data, { enableImplicitConversion: true });
            this.flow_per_area = obj.flow_per_area;
            this.schedule = obj.schedule;
            this.type = obj.type;
            this.target_temperature = obj.target_temperature;
            this.sensible_fraction = obj.sensible_fraction;
            this.latent_fraction = obj.latent_fraction;
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
        data["flow_per_area"] = this.flow_per_area;
        data["schedule"] = this.schedule;
        data["type"] = this.type;
        data["target_temperature"] = this.target_temperature;
        data["sensible_fraction"] = this.sensible_fraction;
        data["latent_fraction"] = this.latent_fraction;
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

