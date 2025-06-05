import { IsNumber, IsDefined, Min, IsString, MinLength, MaxLength, IsEnum, IsOptional, Matches, Max, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { FuelTypes } from "./FuelTypes";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class ProcessAbridged extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    @Min(0)
    @Expose({ name: "watts" })
    /** A number for the process load power in Watts. */
    watts!: number;
	
    @IsString()
    @IsDefined()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "schedule" })
    /** Identifier of the schedule for the use of the process over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts to yield a complete equipment profile. */
    schedule!: string;
	
    @IsEnum(FuelTypes)
    @Type(() => String)
    @IsDefined()
    @Expose({ name: "fuel_type" })
    /** Text to denote the type of fuel consumed by the process. Using the ""None"" type indicates that no end uses will be associated with the process, only the zone gains. */
    fuelType!: FuelTypes;
	
    @IsString()
    @IsOptional()
    @Matches(/^ProcessAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ProcessAbridged";
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "end_use_category" })
    /** Text to indicate the end-use subcategory, which will identify the process load in the end use output. For example, “Cooking”, “Clothes Drying”, etc. A new meter for reporting is created for each unique subcategory. */
    endUseCategory: string = "Process";
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "radiant_fraction" })
    /** Number for the amount of long-wave radiation heat given off by the process load. Default value is 0. */
    radiantFraction: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "latent_fraction" })
    /** Number for the amount of latent heat given off by the process load. Default value is 0. */
    latentFraction: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "lost_fraction" })
    /** Number for the amount of “lost” heat being given off by the process load. The default value is 0. */
    lostFraction: number = 0;
	

    constructor() {
        super();
        this.type = "ProcessAbridged";
        this.endUseCategory = "Process";
        this.radiantFraction = 0;
        this.latentFraction = 0;
        this.lostFraction = 0;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ProcessAbridged, _data, { enableImplicitConversion: true });
            this.watts = obj.watts;
            this.schedule = obj.schedule;
            this.fuelType = obj.fuelType;
            this.type = obj.type;
            this.endUseCategory = obj.endUseCategory;
            this.radiantFraction = obj.radiantFraction;
            this.latentFraction = obj.latentFraction;
            this.lostFraction = obj.lostFraction;
        }
    }


    static override fromJS(data: any): ProcessAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ProcessAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["watts"] = this.watts;
        data["schedule"] = this.schedule;
        data["fuel_type"] = this.fuelType;
        data["type"] = this.type;
        data["end_use_category"] = this.endUseCategory;
        data["radiant_fraction"] = this.radiantFraction;
        data["latent_fraction"] = this.latentFraction;
        data["lost_fraction"] = this.lostFraction;
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
