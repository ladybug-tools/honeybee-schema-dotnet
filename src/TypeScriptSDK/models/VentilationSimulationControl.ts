import { IsString, IsOptional, IsEnum, ValidateNested, IsNumber, validate, ValidationError as TsValidationError } from 'class-validator';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { BuildingType } from "./BuildingType";
import { VentilationControlType } from "./VentilationControlType";

/** The global parameters used in the ventilation simulation. */
export class VentilationSimulationControl extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsEnum(VentilationControlType)
    @ValidateNested()
    @IsOptional()
    /** Text indicating type of ventilation control. Choices are: SingleZone, MultiZoneWithDistribution, MultiZoneWithoutDistribution. The MultiZone options will model air flow with the AirflowNetwork model, which is generally more accurate then the SingleZone option, but will take considerably longer to simulate, and requires defining more ventilation parameters to explicitly account for weather and building-induced pressure differences, and the leakage geometry corresponding to specific windows, doors, and surface cracks. */
    vent_control_type?: VentilationControlType;
	
    @IsNumber()
    @IsOptional()
    /** Reference temperature measurement in Celsius under which the surface crack data were obtained. */
    reference_temperature?: number;
	
    @IsNumber()
    @IsOptional()
    /** Reference barometric pressure measurement in Pascals under which the surface crack data were obtained. */
    reference_pressure?: number;
	
    @IsNumber()
    @IsOptional()
    /** Reference humidity ratio measurement in kgWater/kgDryAir under which the surface crack data were obtained. */
    reference_humidity_ratio?: number;
	
    @IsEnum(BuildingType)
    @ValidateNested()
    @IsOptional()
    /** Text indicating relationship between building footprint and height used to calculate the wind pressure coefficients for exterior surfaces.Choices are: LowRise and HighRise. LowRise corresponds to rectangular building whose height is less then three times the width and length of the footprint. HighRise corresponds to a rectangular building whose height is more than three times the width and length of the footprint. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate. */
    building_type?: BuildingType;
	
    @IsNumber()
    @IsOptional()
    /** The clockwise rotation in degrees from true North of the long axis of the building. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate. */
    long_axis_angle?: number;
	
    @IsNumber()
    @IsOptional()
    /** Aspect ratio of a rectangular footprint, defined as the ratio of length of the short axis divided by the length of the long axis. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate. */
    aspect_ratio?: number;
	

    constructor() {
        super();
        this.type = "VentilationSimulationControl";
        this.vent_control_type = VentilationControlType.SingleZone;
        this.reference_temperature = 20;
        this.reference_pressure = 101325;
        this.reference_humidity_ratio = 0;
        this.building_type = BuildingType.LowRise;
        this.long_axis_angle = 0;
        this.aspect_ratio = 1;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "VentilationSimulationControl";
            this.vent_control_type = _data["vent_control_type"] !== undefined ? _data["vent_control_type"] : VentilationControlType.SingleZone;
            this.reference_temperature = _data["reference_temperature"] !== undefined ? _data["reference_temperature"] : 20;
            this.reference_pressure = _data["reference_pressure"] !== undefined ? _data["reference_pressure"] : 101325;
            this.reference_humidity_ratio = _data["reference_humidity_ratio"] !== undefined ? _data["reference_humidity_ratio"] : 0;
            this.building_type = _data["building_type"] !== undefined ? _data["building_type"] : BuildingType.LowRise;
            this.long_axis_angle = _data["long_axis_angle"] !== undefined ? _data["long_axis_angle"] : 0;
            this.aspect_ratio = _data["aspect_ratio"] !== undefined ? _data["aspect_ratio"] : 1;
        }
    }


    static override fromJS(data: any): VentilationSimulationControl {
        data = typeof data === 'object' ? data : {};

        let result = new VentilationSimulationControl();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["type"] = this.type;
        data["vent_control_type"] = this.vent_control_type;
        data["reference_temperature"] = this.reference_temperature;
        data["reference_pressure"] = this.reference_pressure;
        data["reference_humidity_ratio"] = this.reference_humidity_ratio;
        data["building_type"] = this.building_type;
        data["long_axis_angle"] = this.long_axis_angle;
        data["aspect_ratio"] = this.aspect_ratio;
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
