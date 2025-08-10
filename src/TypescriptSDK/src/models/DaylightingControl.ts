import { IsArray, IsNumber, IsDefined, IsString, IsOptional, Matches, Min, Max, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects. */
export class DaylightingControl extends _OpenAPIGenBaseModel {
    @IsArray()
    @IsNumber({},{ each: true })
    @IsDefined()
    @Expose({ name: "sensor_position" })
    /** A point as 3 (x, y, z) values for the position of the daylight sensor within the parent Room. This point should lie within the Room volume in order for the results to be meaningful. */
    sensorPosition!: number[];
	
    @IsString()
    @IsOptional()
    @Matches(/^DaylightingControl$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "DaylightingControl";
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "illuminance_setpoint" })
    /** A number for the illuminance setpoint in lux beyond which electric lights are dimmed if there is sufficient daylight. */
    illuminanceSetpoint: number = 300;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "control_fraction" })
    /** A number between 0 and 1 that represents the fraction of the Room lights that are dimmed when the illuminance at the sensor position is at the specified illuminance. 1 indicates that all lights are dim-able while 0 indicates that no lights are dim-able. Deeper rooms should have lower control fractions to account for the face that the lights in the back of the space do not dim in response to suitable daylight at the front of the room. */
    controlFraction: number = 1;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "min_power_input" })
    /** A number between 0 and 1 for the the lowest power the lighting system can dim down to, expressed as a fraction of maximum input power. */
    minPowerInput: number = 0.3;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "min_light_output" })
    /** A number between 0 and 1 the lowest lighting output the lighting system can dim down to, expressed as a fraction of maximum light output. */
    minLightOutput: number = 0.2;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "off_at_minimum" })
    /** Boolean to note whether lights should switch off completely when they get to the minimum power input. */
    offAtMinimum: boolean = false;
	

    constructor() {
        super();
        this.type = "DaylightingControl";
        this.illuminanceSetpoint = 300;
        this.controlFraction = 1;
        this.minPowerInput = 0.3;
        this.minLightOutput = 0.2;
        this.offAtMinimum = false;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(DaylightingControl, _data);
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
        data["sensor_position"] = this.sensorPosition;
        data["type"] = this.type ?? "DaylightingControl";
        data["illuminance_setpoint"] = this.illuminanceSetpoint ?? 300;
        data["control_fraction"] = this.controlFraction ?? 1;
        data["min_power_input"] = this.minPowerInput ?? 0.3;
        data["min_light_output"] = this.minLightOutput ?? 0.2;
        data["off_at_minimum"] = this.offAtMinimum ?? false;
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
