import { IsString, IsDefined, MinLength, MaxLength, IsOptional, Matches, IsNumber, Min, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Used to specify information about the setpoint schedule. */
export class SetpointAbridged extends IDdEnergyBaseModel {
    @IsString()
    @IsDefined()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "cooling_schedule" })
    /** Identifier of the schedule for the cooling setpoint. The values in this schedule should be temperature in [C]. */
    coolingSchedule!: string;
	
    @IsString()
    @IsDefined()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "heating_schedule" })
    /** Identifier of the schedule for the heating setpoint. The values in this schedule should be temperature in [C]. */
    heatingSchedule!: string;
	
    @IsString()
    @IsOptional()
    @Matches(/^SetpointAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "SetpointAbridged";
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "humidifying_schedule" })
    /** Identifier of the schedule for the humidification setpoint. The values in this schedule should be in [%]. */
    humidifyingSchedule?: string;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "dehumidifying_schedule" })
    /** Identifier of the schedule for the dehumidification setpoint. The values in this schedule should be in [%]. */
    dehumidifyingSchedule?: string;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "setpoint_cutout_difference" })
    /** An optional positive number for the temperature difference between the cutout temperature and the setpoint temperature. Specifying a non-zero number here is useful for modeling the throttling range associated with a given setup of setpoint controls and HVAC equipment. Throttling ranges describe the range where a zone is slightly over-cooled or over-heated beyond the thermostat setpoint. They are used to avoid situations where HVAC systems turn on only to turn off a few minutes later, thereby wearing out the parts of mechanical systems faster. They can have a minor impact on energy consumption and can often have significant impacts on occupant thermal comfort, though using the default value of zero will often yield results that are close enough when trying to estimate the annual heating/cooling energy use. Specifying a value of zero effectively assumes that the system will turn on whenever conditions are outside the setpoint range and will cut out as soon as the setpoint is reached. */
    setpointCutoutDifference: number = 0;
	

    constructor() {
        super();
        this.type = "SetpointAbridged";
        this.setpointCutoutDifference = 0;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(SetpointAbridged, _data);
        }
    }


    static override fromJS(data: any): SetpointAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new SetpointAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["cooling_schedule"] = this.coolingSchedule;
        data["heating_schedule"] = this.heatingSchedule;
        data["type"] = this.type ?? "SetpointAbridged";
        data["humidifying_schedule"] = this.humidifyingSchedule;
        data["dehumidifying_schedule"] = this.dehumidifyingSchedule;
        data["setpoint_cutout_difference"] = this.setpointCutoutDifference ?? 0;
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
