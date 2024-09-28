import { IsString, IsOptional, Matches, IsNumber, Min, Max, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel.ts";

/** This object specifies the properties of window shade materials. */
export class EnergyWindowMaterialShade extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^EnergyWindowMaterialShade$/)
    type?: string;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** The transmittance averaged over the solar spectrum. It is assumed independent of incidence angle. Default: 0.4. */
    solar_transmittance?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** The reflectance averaged over the solar spectrum. It us assumed same on both sides of shade and independent of incidence angle. Default value is 0.5 */
    solar_reflectance?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** The transmittance averaged over the solar spectrum and weighted by the response of the human eye. It is assumed independent of incidence angle. Default: 0.4. */
    visible_transmittance?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** The transmittance averaged over the solar spectrum and weighted by the response of the human eye. It is assumed independent of incidence angle. Default: 0.4 */
    visible_reflectance?: number;
	
    @IsNumber()
    @IsOptional()
    /** The effective long-wave infrared hemispherical emissivity. It is assumed same on both sides of shade. Default: 0.9. */
    emissivity?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    /** The effective long-wave transmittance. It is assumed independent of incidence angle. Default: 0. */
    infrared_transmittance?: number;
	
    @IsNumber()
    @IsOptional()
    /** The thickness of the shade material in meters. Default: 0.005. */
    thickness?: number;
	
    @IsNumber()
    @IsOptional()
    /** The conductivity of the shade material in W/(m-K). Default value is 0.1. */
    conductivity?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0.001)
    @Max(1)
    /** The distance from shade to adjacent glass in meters. Default value is 0.05 */
    distance_to_glass?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** The effective area for air flow at the top of the shade, divided by the horizontal area between glass and shade. Default: 0.5. */
    top_opening_multiplier?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** The effective area for air flow at the bottom of the shade, divided by the horizontal area between glass and shade. Default: 0.5. */
    bottom_opening_multiplier?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** The effective area for air flow at the left side of the shade, divided by the vertical area between glass and shade. Default: 0.5. */
    left_opening_multiplier?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** The effective area for air flow at the right side of the shade, divided by the vertical area between glass and shade. Default: 0.5. */
    right_opening_multiplier?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(0.8)
    /** The fraction of the shade surface that is open to air flow. If air cannot pass through the shade material, airflow_permeability = 0. Default: 0. */
    airflow_permeability?: number;
	

    constructor() {
        super();
        this.type = "EnergyWindowMaterialShade";
        this.solar_transmittance = 0.4;
        this.solar_reflectance = 0.5;
        this.visible_transmittance = 0.4;
        this.visible_reflectance = 0.4;
        this.emissivity = 0.9;
        this.infrared_transmittance = 0;
        this.thickness = 0.005;
        this.conductivity = 0.1;
        this.distance_to_glass = 0.05;
        this.top_opening_multiplier = 0.5;
        this.bottom_opening_multiplier = 0.5;
        this.left_opening_multiplier = 0.5;
        this.right_opening_multiplier = 0.5;
        this.airflow_permeability = 0;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(EnergyWindowMaterialShade, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.solar_transmittance = obj.solar_transmittance;
            this.solar_reflectance = obj.solar_reflectance;
            this.visible_transmittance = obj.visible_transmittance;
            this.visible_reflectance = obj.visible_reflectance;
            this.emissivity = obj.emissivity;
            this.infrared_transmittance = obj.infrared_transmittance;
            this.thickness = obj.thickness;
            this.conductivity = obj.conductivity;
            this.distance_to_glass = obj.distance_to_glass;
            this.top_opening_multiplier = obj.top_opening_multiplier;
            this.bottom_opening_multiplier = obj.bottom_opening_multiplier;
            this.left_opening_multiplier = obj.left_opening_multiplier;
            this.right_opening_multiplier = obj.right_opening_multiplier;
            this.airflow_permeability = obj.airflow_permeability;
        }
    }


    static override fromJS(data: any): EnergyWindowMaterialShade {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new EnergyWindowMaterialShade();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["solar_transmittance"] = this.solar_transmittance;
        data["solar_reflectance"] = this.solar_reflectance;
        data["visible_transmittance"] = this.visible_transmittance;
        data["visible_reflectance"] = this.visible_reflectance;
        data["emissivity"] = this.emissivity;
        data["infrared_transmittance"] = this.infrared_transmittance;
        data["thickness"] = this.thickness;
        data["conductivity"] = this.conductivity;
        data["distance_to_glass"] = this.distance_to_glass;
        data["top_opening_multiplier"] = this.top_opening_multiplier;
        data["bottom_opening_multiplier"] = this.bottom_opening_multiplier;
        data["left_opening_multiplier"] = this.left_opening_multiplier;
        data["right_opening_multiplier"] = this.right_opening_multiplier;
        data["airflow_permeability"] = this.airflow_permeability;
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

