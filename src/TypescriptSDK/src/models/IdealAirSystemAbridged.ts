﻿import { IsString, IsOptional, Matches, IsEnum, IsBoolean, IsNumber, Min, Max, MinLength, MaxLength, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { Autosize } from "./Autosize";
import { EconomizerType } from "./EconomizerType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { NoLimit } from "./NoLimit";

/** Provides a model for an ideal HVAC system. */
export class IdealAirSystemAbridged extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^IdealAirSystemAbridged$/)
    /** Type */
    type?: string;
	
    @IsEnum(EconomizerType)
    @Type(() => String)
    @IsOptional()
    /** Text to indicate the type of air-side economizer used on the ideal air system. Economizers will mix in a greater amount of outdoor air to cool the zone (rather than running the cooling system) when the zone needs cooling and the outdoor air is cooler than the zone. */
    economizer_type?: EconomizerType;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the zone. */
    demand_controlled_ventilation?: boolean;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** A number between 0 and 1 for the effectiveness of sensible heat recovery within the system. */
    sensible_heat_recovery?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
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
    @MinLength(1)
    @MaxLength(100)
    /** An optional identifier of a schedule to set the availability of heating over the course of the simulation. */
    heating_availability?: string;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
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
            const obj = plainToClass(IdealAirSystemAbridged, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.economizer_type = obj.economizer_type;
            this.demand_controlled_ventilation = obj.demand_controlled_ventilation;
            this.sensible_heat_recovery = obj.sensible_heat_recovery;
            this.latent_heat_recovery = obj.latent_heat_recovery;
            this.heating_air_temperature = obj.heating_air_temperature;
            this.cooling_air_temperature = obj.cooling_air_temperature;
            this.heating_limit = obj.heating_limit;
            this.cooling_limit = obj.cooling_limit;
            this.heating_availability = obj.heating_availability;
            this.cooling_availability = obj.cooling_availability;
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

