import { IsArray, IsNumber, IsDefined, IsString, IsOptional, Matches, Min, Max, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel.ts";

/** Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects. */
export class DaylightingControl extends _OpenAPIGenBaseModel {
    @IsArray()
    @IsNumber({},{ each: true })
    @IsDefined()
    /** A point as 3 (x, y, z) values for the position of the daylight sensor within the parent Room. This point should lie within the Room volume in order for the results to be meaningful. */
    sensor_position!: number [];
	
    @IsString()
    @IsOptional()
    @Matches(/^DaylightingControl$/)
    type?: string;
	
    @IsNumber()
    @IsOptional()
    /** A number for the illuminance setpoint in lux beyond which electric lights are dimmed if there is sufficient daylight. */
    illuminance_setpoint?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** A number between 0 and 1 that represents the fraction of the Room lights that are dimmed when the illuminance at the sensor position is at the specified illuminance. 1 indicates that all lights are dim-able while 0 indicates that no lights are dim-able. Deeper rooms should have lower control fractions to account for the face that the lights in the back of the space do not dim in response to suitable daylight at the front of the room. */
    control_fraction?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** A number between 0 and 1 for the the lowest power the lighting system can dim down to, expressed as a fraction of maximum input power. */
    min_power_input?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
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
            const obj = plainToClass(DaylightingControl, _data, { enableImplicitConversion: true });
            this.sensor_position = obj.sensor_position;
            this.type = obj.type;
            this.illuminance_setpoint = obj.illuminance_setpoint;
            this.control_fraction = obj.control_fraction;
            this.min_power_input = obj.min_power_input;
            this.min_light_output = obj.min_light_output;
            this.off_at_minimum = obj.off_at_minimum;
        }
    }


    static override fromJS(data: any): DaylightingControl {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new DaylightingControl();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["sensor_position"] = this.sensor_position;
        data["type"] = this.type;
        data["illuminance_setpoint"] = this.illuminance_setpoint;
        data["control_fraction"] = this.control_fraction;
        data["min_power_input"] = this.min_power_input;
        data["min_light_output"] = this.min_light_output;
        data["off_at_minimum"] = this.off_at_minimum;
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

