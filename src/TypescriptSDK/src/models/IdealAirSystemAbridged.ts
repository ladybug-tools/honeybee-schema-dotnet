import { IsString, IsOptional, Matches, IsEnum, IsBoolean, IsNumber, Min, Max, MinLength, MaxLength, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { Autosize } from "./Autosize";
import { EconomizerType } from "./EconomizerType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { NoLimit } from "./NoLimit";

/** Provides a model for an ideal HVAC system. */
export class IdealAirSystemAbridged extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^IdealAirSystemAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "IdealAirSystemAbridged";
	
    @IsEnum(EconomizerType)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "economizer_type" })
    /** Text to indicate the type of air-side economizer used on the ideal air system. Economizers will mix in a greater amount of outdoor air to cool the zone (rather than running the cooling system) when the zone needs cooling and the outdoor air is cooler than the zone. */
    economizerType: EconomizerType = EconomizerType.DifferentialDryBulb;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "demand_controlled_ventilation" })
    /** Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the zone. */
    demandControlledVentilation: boolean = false;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "sensible_heat_recovery" })
    /** A number between 0 and 1 for the effectiveness of sensible heat recovery within the system. */
    sensibleHeatRecovery: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "latent_heat_recovery" })
    /** A number between 0 and 1 for the effectiveness of latent heat recovery within the system. */
    latentHeatRecovery: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "heating_air_temperature" })
    /** A number for the maximum heating supply air temperature [C]. */
    heatingAirTemperature: number = 50;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "cooling_air_temperature" })
    /** A number for the minimum cooling supply air temperature [C]. */
    coolingAirTemperature: number = 13;
	
    @IsOptional()
    @Expose({ name: "heating_limit" })
    /** A number for the maximum heating capacity in Watts. This can also be an Autosize object to indicate that the capacity should be determined during the EnergyPlus sizing calculation. This can also be a NoLimit object to indicate no upper limit to the heating capacity. */
    heatingLimit: (Autosize | NoLimit | number) = new Autosize();
	
    @IsOptional()
    @Expose({ name: "cooling_limit" })
    /** A number for the maximum cooling capacity in Watts. This can also be an Autosize object to indicate that the capacity should be determined during the EnergyPlus sizing calculation. This can also be a NoLimit object to indicate no upper limit to the cooling capacity. */
    coolingLimit: (Autosize | NoLimit | number) = new Autosize();
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "heating_availability" })
    /** An optional identifier of a schedule to set the availability of heating over the course of the simulation. */
    heatingAvailability?: string;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "cooling_availability" })
    /** An optional identifier of a schedule to set the availability of cooling over the course of the simulation. */
    coolingAvailability?: string;
	

    constructor() {
        super();
        this.type = "IdealAirSystemAbridged";
        this.economizerType = EconomizerType.DifferentialDryBulb;
        this.demandControlledVentilation = false;
        this.sensibleHeatRecovery = 0;
        this.latentHeatRecovery = 0;
        this.heatingAirTemperature = 50;
        this.coolingAirTemperature = 13;
        this.heatingLimit = new Autosize();
        this.coolingLimit = new Autosize();
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(IdealAirSystemAbridged, _data);
        }
    }


    static override fromJS(data: any): IdealAirSystemAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new IdealAirSystemAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "IdealAirSystemAbridged";
        data["economizer_type"] = this.economizerType ?? EconomizerType.DifferentialDryBulb;
        data["demand_controlled_ventilation"] = this.demandControlledVentilation ?? false;
        data["sensible_heat_recovery"] = this.sensibleHeatRecovery ?? 0;
        data["latent_heat_recovery"] = this.latentHeatRecovery ?? 0;
        data["heating_air_temperature"] = this.heatingAirTemperature ?? 50;
        data["cooling_air_temperature"] = this.coolingAirTemperature ?? 13;
        data["heating_limit"] = this.heatingLimit ?? new Autosize();
        data["cooling_limit"] = this.coolingLimit ?? new Autosize();
        data["heating_availability"] = this.heatingAvailability;
        data["cooling_availability"] = this.coolingAvailability;
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
