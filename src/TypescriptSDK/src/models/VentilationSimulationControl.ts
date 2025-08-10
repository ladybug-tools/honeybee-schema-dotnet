import { IsString, IsOptional, Matches, IsEnum, IsNumber, Min, Max, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { BuildingType } from "./BuildingType";
import { VentilationControlType } from "./VentilationControlType";

/** The global parameters used in the ventilation simulation. */
export class VentilationSimulationControl extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^VentilationSimulationControl$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "VentilationSimulationControl";
	
    @IsEnum(VentilationControlType)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "vent_control_type" })
    /** Text indicating type of ventilation control. Choices are: SingleZone, MultiZoneWithDistribution, MultiZoneWithoutDistribution. The MultiZone options will model air flow with the AirflowNetwork model, which is generally more accurate then the SingleZone option, but will take considerably longer to simulate, and requires defining more ventilation parameters to explicitly account for weather and building-induced pressure differences, and the leakage geometry corresponding to specific windows, doors, and surface cracks. */
    ventControlType: VentilationControlType = VentilationControlType.SingleZone;
	
    @IsNumber()
    @IsOptional()
    @Min(-273.15)
    @Expose({ name: "reference_temperature" })
    /** Reference temperature measurement in Celsius under which the surface crack data were obtained. */
    referenceTemperature: number = 20;
	
    @IsNumber()
    @IsOptional()
    @Min(31000)
    @Max(120000)
    @Expose({ name: "reference_pressure" })
    /** Reference barometric pressure measurement in Pascals under which the surface crack data were obtained. */
    referencePressure: number = 101325;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "reference_humidity_ratio" })
    /** Reference humidity ratio measurement in kgWater/kgDryAir under which the surface crack data were obtained. */
    referenceHumidityRatio: number = 0;
	
    @IsEnum(BuildingType)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "building_type" })
    /** Text indicating relationship between building footprint and height used to calculate the wind pressure coefficients for exterior surfaces.Choices are: LowRise and HighRise. LowRise corresponds to rectangular building whose height is less then three times the width and length of the footprint. HighRise corresponds to a rectangular building whose height is more than three times the width and length of the footprint. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate. */
    buildingType: BuildingType = BuildingType.LowRise;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(180)
    @Expose({ name: "long_axis_angle" })
    /** The clockwise rotation in degrees from true North of the long axis of the building. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate. */
    longAxisAngle: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Max(1)
    @Expose({ name: "aspect_ratio" })
    /** Aspect ratio of a rectangular footprint, defined as the ratio of length of the short axis divided by the length of the long axis. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate. */
    aspectRatio: number = 1;
	

    constructor() {
        super();
        this.type = "VentilationSimulationControl";
        this.ventControlType = VentilationControlType.SingleZone;
        this.referenceTemperature = 20;
        this.referencePressure = 101325;
        this.referenceHumidityRatio = 0;
        this.buildingType = BuildingType.LowRise;
        this.longAxisAngle = 0;
        this.aspectRatio = 1;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(VentilationSimulationControl, _data);
            this.type = obj.type ?? "VentilationSimulationControl";
            this.ventControlType = obj.ventControlType ?? VentilationControlType.SingleZone;
            this.referenceTemperature = obj.referenceTemperature ?? 20;
            this.referencePressure = obj.referencePressure ?? 101325;
            this.referenceHumidityRatio = obj.referenceHumidityRatio ?? 0;
            this.buildingType = obj.buildingType ?? BuildingType.LowRise;
            this.longAxisAngle = obj.longAxisAngle ?? 0;
            this.aspectRatio = obj.aspectRatio ?? 1;
        }
    }


    static override fromJS(data: any): VentilationSimulationControl {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new VentilationSimulationControl();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "VentilationSimulationControl";
        data["vent_control_type"] = this.ventControlType ?? VentilationControlType.SingleZone;
        data["reference_temperature"] = this.referenceTemperature ?? 20;
        data["reference_pressure"] = this.referencePressure ?? 101325;
        data["reference_humidity_ratio"] = this.referenceHumidityRatio ?? 0;
        data["building_type"] = this.buildingType ?? BuildingType.LowRise;
        data["long_axis_angle"] = this.longAxisAngle ?? 0;
        data["aspect_ratio"] = this.aspectRatio ?? 1;
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
