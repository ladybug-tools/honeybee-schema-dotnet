import { IsString, IsOptional, IsNumber, validate, ValidationError } from 'class-validator';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** This object specifies the properties of window shade materials. */
export class EnergyWindowMaterialShade extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsNumber()
    @IsOptional()
    /** The transmittance averaged over the solar spectrum. It is assumed independent of incidence angle. Default: 0.4. */
    solar_transmittance?: number;
	
    @IsNumber()
    @IsOptional()
    /** The reflectance averaged over the solar spectrum. It us assumed same on both sides of shade and independent of incidence angle. Default value is 0.5 */
    solar_reflectance?: number;
	
    @IsNumber()
    @IsOptional()
    /** The transmittance averaged over the solar spectrum and weighted by the response of the human eye. It is assumed independent of incidence angle. Default: 0.4. */
    visible_transmittance?: number;
	
    @IsNumber()
    @IsOptional()
    /** The transmittance averaged over the solar spectrum and weighted by the response of the human eye. It is assumed independent of incidence angle. Default: 0.4 */
    visible_reflectance?: number;
	
    @IsNumber()
    @IsOptional()
    /** The effective long-wave infrared hemispherical emissivity. It is assumed same on both sides of shade. Default: 0.9. */
    emissivity?: number;
	
    @IsNumber()
    @IsOptional()
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
    /** The distance from shade to adjacent glass in meters. Default value is 0.05 */
    distance_to_glass?: number;
	
    @IsNumber()
    @IsOptional()
    /** The effective area for air flow at the top of the shade, divided by the horizontal area between glass and shade. Default: 0.5. */
    top_opening_multiplier?: number;
	
    @IsNumber()
    @IsOptional()
    /** The effective area for air flow at the bottom of the shade, divided by the horizontal area between glass and shade. Default: 0.5. */
    bottom_opening_multiplier?: number;
	
    @IsNumber()
    @IsOptional()
    /** The effective area for air flow at the left side of the shade, divided by the vertical area between glass and shade. Default: 0.5. */
    left_opening_multiplier?: number;
	
    @IsNumber()
    @IsOptional()
    /** The effective area for air flow at the right side of the shade, divided by the vertical area between glass and shade. Default: 0.5. */
    right_opening_multiplier?: number;
	
    @IsNumber()
    @IsOptional()
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
            this.type = _data["type"] !== undefined ? _data["type"] : "EnergyWindowMaterialShade";
            this.solar_transmittance = _data["solar_transmittance"] !== undefined ? _data["solar_transmittance"] : 0.4;
            this.solar_reflectance = _data["solar_reflectance"] !== undefined ? _data["solar_reflectance"] : 0.5;
            this.visible_transmittance = _data["visible_transmittance"] !== undefined ? _data["visible_transmittance"] : 0.4;
            this.visible_reflectance = _data["visible_reflectance"] !== undefined ? _data["visible_reflectance"] : 0.4;
            this.emissivity = _data["emissivity"] !== undefined ? _data["emissivity"] : 0.9;
            this.infrared_transmittance = _data["infrared_transmittance"] !== undefined ? _data["infrared_transmittance"] : 0;
            this.thickness = _data["thickness"] !== undefined ? _data["thickness"] : 0.005;
            this.conductivity = _data["conductivity"] !== undefined ? _data["conductivity"] : 0.1;
            this.distance_to_glass = _data["distance_to_glass"] !== undefined ? _data["distance_to_glass"] : 0.05;
            this.top_opening_multiplier = _data["top_opening_multiplier"] !== undefined ? _data["top_opening_multiplier"] : 0.5;
            this.bottom_opening_multiplier = _data["bottom_opening_multiplier"] !== undefined ? _data["bottom_opening_multiplier"] : 0.5;
            this.left_opening_multiplier = _data["left_opening_multiplier"] !== undefined ? _data["left_opening_multiplier"] : 0.5;
            this.right_opening_multiplier = _data["right_opening_multiplier"] !== undefined ? _data["right_opening_multiplier"] : 0.5;
            this.airflow_permeability = _data["airflow_permeability"] !== undefined ? _data["airflow_permeability"] : 0;
        }
    }


    static override fromJS(data: any): EnergyWindowMaterialShade {
        data = typeof data === 'object' ? data : {};

        let result = new EnergyWindowMaterialShade();
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
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: ValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
