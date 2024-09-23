import { IsString, IsOptional, Matches, IsEnum, IsNumber, Min, Max, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { BuildingType } from "./BuildingType";
import { VentilationControlType } from "./VentilationControlType";

/** The global parameters used in the ventilation simulation. */
export class VentilationSimulationControl extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^VentilationSimulationControl$/)
    type?: string;
	
    @IsEnum(VentilationControlType)
    @Type(() => String)
    @IsOptional()
    /** Text indicating type of ventilation control. Choices are: SingleZone, MultiZoneWithDistribution, MultiZoneWithoutDistribution. The MultiZone options will model air flow with the AirflowNetwork model, which is generally more accurate then the SingleZone option, but will take considerably longer to simulate, and requires defining more ventilation parameters to explicitly account for weather and building-induced pressure differences, and the leakage geometry corresponding to specific windows, doors, and surface cracks. */
    vent_control_type?: VentilationControlType;
	
    @IsNumber()
    @IsOptional()
    @Min(-273.15)
    /** Reference temperature measurement in Celsius under which the surface crack data were obtained. */
    reference_temperature?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(31000)
    @Max(120000)
    /** Reference barometric pressure measurement in Pascals under which the surface crack data were obtained. */
    reference_pressure?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** Reference humidity ratio measurement in kgWater/kgDryAir under which the surface crack data were obtained. */
    reference_humidity_ratio?: number;
	
    @IsEnum(BuildingType)
    @Type(() => String)
    @IsOptional()
    /** Text indicating relationship between building footprint and height used to calculate the wind pressure coefficients for exterior surfaces.Choices are: LowRise and HighRise. LowRise corresponds to rectangular building whose height is less then three times the width and length of the footprint. HighRise corresponds to a rectangular building whose height is more than three times the width and length of the footprint. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate. */
    building_type?: BuildingType;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(180)
    /** The clockwise rotation in degrees from true North of the long axis of the building. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate. */
    long_axis_angle?: number;
	
    @IsNumber()
    @IsOptional()
    @Max(1)
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
            const obj = plainToClass(VentilationSimulationControl, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.vent_control_type = obj.vent_control_type;
            this.reference_temperature = obj.reference_temperature;
            this.reference_pressure = obj.reference_pressure;
            this.reference_humidity_ratio = obj.reference_humidity_ratio;
            this.building_type = obj.building_type;
            this.long_axis_angle = obj.long_axis_angle;
            this.aspect_ratio = obj.aspect_ratio;
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
        data["type"] = this.type;
        data["vent_control_type"] = this.vent_control_type;
        data["reference_temperature"] = this.reference_temperature;
        data["reference_pressure"] = this.reference_pressure;
        data["reference_humidity_ratio"] = this.reference_humidity_ratio;
        data["building_type"] = this.building_type;
        data["long_axis_angle"] = this.long_axis_angle;
        data["aspect_ratio"] = this.aspect_ratio;
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

