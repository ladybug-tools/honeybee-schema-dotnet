import { IsNumber, IsDefined, IsString, IsEnum, ValidateNested, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { FuelTypes } from "./FuelTypes";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class ProcessAbridged extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    /** A number for the process load power in Watts. */
    watts!: number;
	
    @IsString()
    @IsDefined()
    /** Identifier of the schedule for the use of the process over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts to yield a complete equipment profile. */
    schedule!: string;
	
    @IsEnum(FuelTypes)
    @ValidateNested()
    @IsDefined()
    /** Text to denote the type of fuel consumed by the process. Using the ""None"" type indicates that no end uses will be associated with the process, only the zone gains. */
    fuel_type!: FuelTypes;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsString()
    @IsOptional()
    /** Text to indicate the end-use subcategory, which will identify the process load in the end use output. For example, “Cooking”, “Clothes Drying”, etc. A new meter for reporting is created for each unique subcategory. */
    end_use_category?: string;
	
    @IsNumber()
    @IsOptional()
    /** Number for the amount of long-wave radiation heat given off by the process load. Default value is 0. */
    radiant_fraction?: number;
	
    @IsNumber()
    @IsOptional()
    /** Number for the amount of latent heat given off by the process load. Default value is 0. */
    latent_fraction?: number;
	
    @IsNumber()
    @IsOptional()
    /** Number for the amount of “lost” heat being given off by the process load. The default value is 0. */
    lost_fraction?: number;
	

    constructor() {
        super();
        this.type = "ProcessAbridged";
        this.end_use_category = "Process";
        this.radiant_fraction = 0;
        this.latent_fraction = 0;
        this.lost_fraction = 0;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.watts = _data["watts"];
            this.schedule = _data["schedule"];
            this.fuel_type = _data["fuel_type"];
            this.type = _data["type"] !== undefined ? _data["type"] : "ProcessAbridged";
            this.end_use_category = _data["end_use_category"] !== undefined ? _data["end_use_category"] : "Process";
            this.radiant_fraction = _data["radiant_fraction"] !== undefined ? _data["radiant_fraction"] : 0;
            this.latent_fraction = _data["latent_fraction"] !== undefined ? _data["latent_fraction"] : 0;
            this.lost_fraction = _data["lost_fraction"] !== undefined ? _data["lost_fraction"] : 0;
        }
    }


    static override fromJS(data: any): ProcessAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new ProcessAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["watts"] = this.watts;
        data["schedule"] = this.schedule;
        data["fuel_type"] = this.fuel_type;
        data["type"] = this.type;
        data["end_use_category"] = this.end_use_category;
        data["radiant_fraction"] = this.radiant_fraction;
        data["latent_fraction"] = this.latent_fraction;
        data["lost_fraction"] = this.lost_fraction;
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
