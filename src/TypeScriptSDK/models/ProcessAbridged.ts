import { IsNumber, IsDefined, Min, IsString, MinLength, MaxLength, IsEnum, IsOptional, Matches, Max, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { FuelTypes } from "./FuelTypes";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class ProcessAbridged extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    @Min(0)
    /** A number for the process load power in Watts. */
    watts!: number;
	
    @IsString()
    @IsDefined()
    @MinLength(1)
    @MaxLength(100)
    /** Identifier of the schedule for the use of the process over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts to yield a complete equipment profile. */
    schedule!: string;
	
    @IsEnum(FuelTypes)
    @Type(() => String)
    @IsDefined()
    /** Text to denote the type of fuel consumed by the process. Using the ""None"" type indicates that no end uses will be associated with the process, only the zone gains. */
    fuel_type!: FuelTypes;
	
    @IsString()
    @IsOptional()
    @Matches(/^ProcessAbridged$/)
    type?: string;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    /** Text to indicate the end-use subcategory, which will identify the process load in the end use output. For example, “Cooking”, “Clothes Drying”, etc. A new meter for reporting is created for each unique subcategory. */
    end_use_category?: string;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** Number for the amount of long-wave radiation heat given off by the process load. Default value is 0. */
    radiant_fraction?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** Number for the amount of latent heat given off by the process load. Default value is 0. */
    latent_fraction?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
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
            const obj = plainToClass(ProcessAbridged, _data);
            this.watts = obj.watts;
            this.schedule = obj.schedule;
            this.fuel_type = obj.fuel_type;
            this.type = obj.type;
            this.end_use_category = obj.end_use_category;
            this.radiant_fraction = obj.radiant_fraction;
            this.latent_fraction = obj.latent_fraction;
            this.lost_fraction = obj.lost_fraction;
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
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || [error]).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
