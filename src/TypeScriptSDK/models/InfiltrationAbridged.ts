import { IsNumber, IsDefined, IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class InfiltrationAbridged extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    /** Number for the infiltration per exterior surface area in m3/s-m2. */
    flow_per_exterior_area!: number;
	
    @IsString()
    @IsDefined()
    /** Identifier of the schedule for the infiltration over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the flow_per_exterior_area to yield a complete infiltration profile. */
    schedule!: string;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsNumber()
    @IsOptional()
    constant_coefficient?: number;
	
    @IsNumber()
    @IsOptional()
    temperature_coefficient?: number;
	
    @IsNumber()
    @IsOptional()
    velocity_coefficient?: number;
	

    constructor() {
        super();
        this.type = "InfiltrationAbridged";
        this.constant_coefficient = 1;
        this.temperature_coefficient = 0;
        this.velocity_coefficient = 0;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(InfiltrationAbridged, _data);
            this.flow_per_exterior_area = obj.flow_per_exterior_area;
            this.schedule = obj.schedule;
            this.type = obj.type;
            this.constant_coefficient = obj.constant_coefficient;
            this.temperature_coefficient = obj.temperature_coefficient;
            this.velocity_coefficient = obj.velocity_coefficient;
        }
    }


    static override fromJS(data: any): InfiltrationAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new InfiltrationAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["flow_per_exterior_area"] = this.flow_per_exterior_area;
        data["schedule"] = this.schedule;
        data["type"] = this.type;
        data["constant_coefficient"] = this.constant_coefficient;
        data["temperature_coefficient"] = this.temperature_coefficient;
        data["velocity_coefficient"] = this.velocity_coefficient;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || [error.property]).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
