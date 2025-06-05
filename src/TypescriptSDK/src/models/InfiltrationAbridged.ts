import { IsNumber, IsDefined, Min, IsString, MinLength, MaxLength, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class InfiltrationAbridged extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    @Min(0)
    @Expose({ name: "flow_per_exterior_area" })
    /** Number for the infiltration per exterior surface area in m3/s-m2. */
    flowPerExteriorArea!: number;
	
    @IsString()
    @IsDefined()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "schedule" })
    /** Identifier of the schedule for the infiltration over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the flow_per_exterior_area to yield a complete infiltration profile. */
    schedule!: string;
	
    @IsString()
    @IsOptional()
    @Matches(/^InfiltrationAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "InfiltrationAbridged";
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "constant_coefficient" })
    /** constantCoefficient */
    constantCoefficient: number = 1;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "temperature_coefficient" })
    /** temperatureCoefficient */
    temperatureCoefficient: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "velocity_coefficient" })
    /** velocityCoefficient */
    velocityCoefficient: number = 0;
	

    constructor() {
        super();
        this.type = "InfiltrationAbridged";
        this.constantCoefficient = 1;
        this.temperatureCoefficient = 0;
        this.velocityCoefficient = 0;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(InfiltrationAbridged, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.flowPerExteriorArea = obj.flowPerExteriorArea;
            this.schedule = obj.schedule;
            this.type = obj.type ?? "InfiltrationAbridged";
            this.constantCoefficient = obj.constantCoefficient ?? 1;
            this.temperatureCoefficient = obj.temperatureCoefficient ?? 0;
            this.velocityCoefficient = obj.velocityCoefficient ?? 0;
        }
    }


    static override fromJS(data: any): InfiltrationAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new InfiltrationAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["flow_per_exterior_area"] = this.flowPerExteriorArea;
        data["schedule"] = this.schedule;
        data["type"] = this.type ?? "InfiltrationAbridged";
        data["constant_coefficient"] = this.constantCoefficient ?? 1;
        data["temperature_coefficient"] = this.temperatureCoefficient ?? 0;
        data["velocity_coefficient"] = this.velocityCoefficient ?? 0;
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
