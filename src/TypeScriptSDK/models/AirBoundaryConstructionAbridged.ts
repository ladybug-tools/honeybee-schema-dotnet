import { IsString, IsOptional, Matches, IsNumber, Min, MinLength, MaxLength, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Construction for Air Boundary objects. */
export class AirBoundaryConstructionAbridged extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^AirBoundaryConstructionAbridged$/)
    type?: string;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** A positive number for the amount of air mixing between Rooms across the air boundary surface [m3/s-m2]. Default: 0.1 corresponds to average indoor air speeds of 0.1 m/s (roughly 20 fpm), which is typical of what would be induced by a HVAC system. */
    air_mixing_per_area?: number;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    /** Identifier of a fractional schedule for the air mixing schedule across the construction. If unspecified, an Always On schedule will be assumed. */
    air_mixing_schedule?: string;
	

    constructor() {
        super();
        this.type = "AirBoundaryConstructionAbridged";
        this.air_mixing_per_area = 0.1;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(AirBoundaryConstructionAbridged, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.air_mixing_per_area = obj.air_mixing_per_area;
            this.air_mixing_schedule = obj.air_mixing_schedule;
        }
    }


    static override fromJS(data: any): AirBoundaryConstructionAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new AirBoundaryConstructionAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["air_mixing_per_area"] = this.air_mixing_per_area;
        data["air_mixing_schedule"] = this.air_mixing_schedule;
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

