import { IsString, IsOptional, IsEnum, ValidateNested, IsBoolean, IsNumber, validate, ValidationError as TsValidationError } from 'class-validator';
import { EconomizerType } from "./EconomizerType";
import { Autosize } from "./Autosize";
import { NoLimit } from "./NoLimit";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Provides a model for an ideal HVAC system. */
export class IdealAirSystemAbridged extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsEnum(EconomizerType)
    @ValidateNested()
    @IsOptional()
    /** Text to indicate the type of air-side economizer used on the ideal air system. Economizers will mix in a greater amount of outdoor air to cool the zone (rather than running the cooling system) when the zone needs cooling and the outdoor air is cooler than the zone. */
    economizer_type?: EconomizerType;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the zone. */
    demand_controlled_ventilation?: boolean;
	
    @IsNumber()
    @IsOptional()
    /** A number between 0 and 1 for the effectiveness of sensible heat recovery within the system. */
    sensible_heat_recovery?: number;
	
    @IsNumber()
    @IsOptional()
    /** A number between 0 and 1 for the effectiveness of latent heat recovery within the system. */
    latent_heat_recovery?: number;
	
    @IsNumber()
    @IsOptional()
    /** A number for the maximum heating supply air temperature [C]. */
    heating_air_temperature?: number;
	
    @IsNumber()
    @IsOptional()
    /** A number for the minimum cooling supply air temperature [C]. */
    cooling_air_temperature?: number;
	
    @IsOptional()
    /** A number for the maximum heating capacity in Watts. This can also be an Autosize object to indicate that the capacity should be determined during the EnergyPlus sizing calculation. This can also be a NoLimit object to indicate no upper limit to the heating capacity. */
    heating_limit?: (Autosize | NoLimit | number);
	
    @IsOptional()
    /** A number for the maximum cooling capacity in Watts. This can also be an Autosize object to indicate that the capacity should be determined during the EnergyPlus sizing calculation. This can also be a NoLimit object to indicate no upper limit to the cooling capacity. */
    cooling_limit?: (Autosize | NoLimit | number);
	
    @IsString()
    @IsOptional()
    /** An optional identifier of a schedule to set the availability of heating over the course of the simulation. */
    heating_availability?: string;
	
    @IsString()
    @IsOptional()
    /** An optional identifier of a schedule to set the availability of cooling over the course of the simulation. */
    cooling_availability?: string;
	

    constructor() {
        super();
        this.type = "IdealAirSystemAbridged";
        this.economizer_type = EconomizerType.DifferentialDryBulb;
        this.demand_controlled_ventilation = false;
        this.sensible_heat_recovery = 0;
        this.latent_heat_recovery = 0;
        this.heating_air_temperature = 50;
        this.cooling_air_temperature = 13;
        this.heating_limit = new Autosize();
        this.cooling_limit = new Autosize();
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "IdealAirSystemAbridged";
            this.economizer_type = _data["economizer_type"] !== undefined ? _data["economizer_type"] : EconomizerType.DifferentialDryBulb;
            this.demand_controlled_ventilation = _data["demand_controlled_ventilation"] !== undefined ? _data["demand_controlled_ventilation"] : false;
            this.sensible_heat_recovery = _data["sensible_heat_recovery"] !== undefined ? _data["sensible_heat_recovery"] : 0;
            this.latent_heat_recovery = _data["latent_heat_recovery"] !== undefined ? _data["latent_heat_recovery"] : 0;
            this.heating_air_temperature = _data["heating_air_temperature"] !== undefined ? _data["heating_air_temperature"] : 50;
            this.cooling_air_temperature = _data["cooling_air_temperature"] !== undefined ? _data["cooling_air_temperature"] : 13;
            this.heating_limit = _data["heating_limit"] !== undefined ? _data["heating_limit"] : new Autosize();
            this.cooling_limit = _data["cooling_limit"] !== undefined ? _data["cooling_limit"] : new Autosize();
            this.heating_availability = _data["heating_availability"];
            this.cooling_availability = _data["cooling_availability"];
        }
    }


    static override fromJS(data: any): IdealAirSystemAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new IdealAirSystemAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["type"] = this.type;
        data["economizer_type"] = this.economizer_type;
        data["demand_controlled_ventilation"] = this.demand_controlled_ventilation;
        data["sensible_heat_recovery"] = this.sensible_heat_recovery;
        data["latent_heat_recovery"] = this.latent_heat_recovery;
        data["heating_air_temperature"] = this.heating_air_temperature;
        data["cooling_air_temperature"] = this.cooling_air_temperature;
        data["heating_limit"] = this.heating_limit;
        data["cooling_limit"] = this.cooling_limit;
        data["heating_availability"] = this.heating_availability;
        data["cooling_availability"] = this.cooling_availability;
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
