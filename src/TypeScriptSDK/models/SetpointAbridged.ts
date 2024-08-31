import { IsString, IsDefined, IsOptional, IsNumber, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Used to specify information about the setpoint schedule. */
export class SetpointAbridged extends IDdEnergyBaseModel {
    @IsString()
    @IsDefined()
    /** Identifier of the schedule for the cooling setpoint. The values in this schedule should be temperature in [C]. */
    cooling_schedule!: string;
	
    @IsString()
    @IsDefined()
    /** Identifier of the schedule for the heating setpoint. The values in this schedule should be temperature in [C]. */
    heating_schedule!: string;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier of the schedule for the humidification setpoint. The values in this schedule should be in [%]. */
    humidifying_schedule?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier of the schedule for the dehumidification setpoint. The values in this schedule should be in [%]. */
    dehumidifying_schedule?: string;
	
    @IsNumber()
    @IsOptional()
    /** An optional positive number for the temperature difference between the cutout temperature and the setpoint temperature. Specifying a non-zero number here is useful for modeling the throttling range associated with a given setup of setpoint controls and HVAC equipment. Throttling ranges describe the range where a zone is slightly over-cooled or over-heated beyond the thermostat setpoint. They are used to avoid situations where HVAC systems turn on only to turn off a few minutes later, thereby wearing out the parts of mechanical systems faster. They can have a minor impact on energy consumption and can often have significant impacts on occupant thermal comfort, though using the default value of zero will often yield results that are close enough when trying to estimate the annual heating/cooling energy use. Specifying a value of zero effectively assumes that the system will turn on whenever conditions are outside the setpoint range and will cut out as soon as the setpoint is reached. */
    setpoint_cutout_difference?: number;
	

    constructor() {
        super();
        this.type = "SetpointAbridged";
        this.setpoint_cutout_difference = 0;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(SetpointAbridged, _data);
            this.cooling_schedule = obj.cooling_schedule;
            this.heating_schedule = obj.heating_schedule;
            this.type = obj.type;
            this.humidifying_schedule = obj.humidifying_schedule;
            this.dehumidifying_schedule = obj.dehumidifying_schedule;
            this.setpoint_cutout_difference = obj.setpoint_cutout_difference;
        }
    }


    static override fromJS(data: any): SetpointAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new SetpointAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["cooling_schedule"] = this.cooling_schedule;
        data["heating_schedule"] = this.heating_schedule;
        data["type"] = this.type;
        data["humidifying_schedule"] = this.humidifying_schedule;
        data["dehumidifying_schedule"] = this.dehumidifying_schedule;
        data["setpoint_cutout_difference"] = this.setpoint_cutout_difference;
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
