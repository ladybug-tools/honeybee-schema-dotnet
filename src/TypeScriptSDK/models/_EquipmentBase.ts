import { IsNumber, IsDefined, Min, IsString, MinLength, MaxLength, IsOptional, Max, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel.ts";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class _EquipmentBase extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    @Min(0)
    /** Equipment level per floor area as [W/m2]. */
    watts_per_area!: number;
	
    @IsString()
    @IsDefined()
    @MinLength(1)
    @MaxLength(100)
    /** Identifier of the schedule for the use of equipment over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts_per_area to yield a complete equipment profile. */
    schedule!: string;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** Number for the amount of long-wave radiation heat given off by equipment. Default value is 0. */
    radiant_fraction?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** Number for the amount of latent heat given off by equipment. Default value is 0. */
    latent_fraction?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** Number for the amount of “lost” heat being given off by equipment. The default value is 0. */
    lost_fraction?: number;
	
    @IsString()
    @IsOptional()
    @Matches(/^_EquipmentBase$/)
    type?: string;
	

    constructor() {
        super();
        this.radiant_fraction = 0;
        this.latent_fraction = 0;
        this.lost_fraction = 0;
        this.type = "_EquipmentBase";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(_EquipmentBase, _data, { enableImplicitConversion: true });
            this.watts_per_area = obj.watts_per_area;
            this.schedule = obj.schedule;
            this.radiant_fraction = obj.radiant_fraction;
            this.latent_fraction = obj.latent_fraction;
            this.lost_fraction = obj.lost_fraction;
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): _EquipmentBase {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new _EquipmentBase();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["watts_per_area"] = this.watts_per_area;
        data["schedule"] = this.schedule;
        data["radiant_fraction"] = this.radiant_fraction;
        data["latent_fraction"] = this.latent_fraction;
        data["lost_fraction"] = this.lost_fraction;
        data["type"] = this.type;
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

