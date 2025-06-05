import { IsString, IsOptional, Matches, IsNumber, Min, MinLength, MaxLength, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class VentilationAbridged extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^VentilationAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "VentilationAbridged";
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "flow_per_person" })
    /** Intensity of ventilation in[] m3/s per person]. Note that setting this value does not mean that ventilation is varied based on real-time occupancy but rather that the design level of ventilation is determined using this value and the People object of the Room. */
    flowPerPerson: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "flow_per_area" })
    /** Intensity of ventilation in [m3/s per m2 of floor area]. */
    flowPerArea: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "air_changes_per_hour" })
    /** Intensity of ventilation in air changes per hour (ACH) for the entire Room. */
    airChangesPerHour: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "flow_per_zone" })
    /** Intensity of ventilation in m3/s for the entire Room. */
    flowPerZone: number = 0;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "schedule" })
    /** Identifier of the schedule for the ventilation over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the total design flow rate (determined from the sum of the other 4 fields) to yield a complete ventilation profile. */
    schedule?: string;
	

    constructor() {
        super();
        this.type = "VentilationAbridged";
        this.flowPerPerson = 0;
        this.flowPerArea = 0;
        this.airChangesPerHour = 0;
        this.flowPerZone = 0;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(VentilationAbridged, _data, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
            this.type = obj.type ?? "VentilationAbridged";
            this.flowPerPerson = obj.flowPerPerson ?? 0;
            this.flowPerArea = obj.flowPerArea ?? 0;
            this.airChangesPerHour = obj.airChangesPerHour ?? 0;
            this.flowPerZone = obj.flowPerZone ?? 0;
            this.schedule = obj.schedule;
        }
    }


    static override fromJS(data: any): VentilationAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new VentilationAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "VentilationAbridged";
        data["flow_per_person"] = this.flowPerPerson ?? 0;
        data["flow_per_area"] = this.flowPerArea ?? 0;
        data["air_changes_per_hour"] = this.airChangesPerHour ?? 0;
        data["flow_per_zone"] = this.flowPerZone ?? 0;
        data["schedule"] = this.schedule;
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
