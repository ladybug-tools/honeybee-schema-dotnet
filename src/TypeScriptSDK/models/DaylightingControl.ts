import { IsArray, ValidateNested, IsDefined, IsString, IsOptional, IsNumber, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { OpenAPIGenBaseModel } from "./OpenAPIGenBaseModel";

/** Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects. */
export class DaylightingControl extends OpenAPIGenBaseModel {
    @IsArray()
    @ValidateNested({ each: true })
    @IsDefined()
    /** A point as 3 (x, y, z) values for the position of the daylight sensor within the parent Room. This point should lie within the Room volume in order for the results to be meaningful. */
    sensor_position!: number [];
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsNumber()
    @IsOptional()
    /** A number for the illuminance setpoint in lux beyond which electric lights are dimmed if there is sufficient daylight. */
    illuminance_setpoint?: number;
	
    @IsNumber()
    @IsOptional()
    /** A number between 0 and 1 that represents the fraction of the Room lights that are dimmed when the illuminance at the sensor position is at the specified illuminance. 1 indicates that all lights are dim-able while 0 indicates that no lights are dim-able. Deeper rooms should have lower control fractions to account for the face that the lights in the back of the space do not dim in response to suitable daylight at the front of the room. */
    control_fraction?: number;
	
    @IsNumber()
    @IsOptional()
    /** A number between 0 and 1 for the the lowest power the lighting system can dim down to, expressed as a fraction of maximum input power. */
    min_power_input?: number;
	
    @IsNumber()
    @IsOptional()
    /** A number between 0 and 1 the lowest lighting output the lighting system can dim down to, expressed as a fraction of maximum light output. */
    min_light_output?: number;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean to note whether lights should switch off completely when they get to the minimum power input. */
    off_at_minimum?: boolean;
	

    constructor() {
        super();
        this.type = "DaylightingControl";
        this.illuminance_setpoint = 300;
        this.control_fraction = 1;
        this.min_power_input = 0.3;
        this.min_light_output = 0.2;
        this.off_at_minimum = false;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.sensor_position = _data["sensor_position"];
            this.type = _data["type"] !== undefined ? _data["type"] : "DaylightingControl";
            this.illuminance_setpoint = _data["illuminance_setpoint"] !== undefined ? _data["illuminance_setpoint"] : 300;
            this.control_fraction = _data["control_fraction"] !== undefined ? _data["control_fraction"] : 1;
            this.min_power_input = _data["min_power_input"] !== undefined ? _data["min_power_input"] : 0.3;
            this.min_light_output = _data["min_light_output"] !== undefined ? _data["min_light_output"] : 0.2;
            this.off_at_minimum = _data["off_at_minimum"] !== undefined ? _data["off_at_minimum"] : false;
        }
    }


    static override fromJS(data: any): DaylightingControl {
        data = typeof data === 'object' ? data : {};

        let result = new DaylightingControl();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["sensor_position"] = this.sensor_position;
        data["type"] = this.type;
        data["illuminance_setpoint"] = this.illuminance_setpoint;
        data["control_fraction"] = this.control_fraction;
        data["min_power_input"] = this.min_power_input;
        data["min_light_output"] = this.min_light_output;
        data["off_at_minimum"] = this.off_at_minimum;
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
