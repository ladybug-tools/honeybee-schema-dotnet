import { IsString, IsOptional, IsNumber, IsBoolean, validate, ValidationError } from 'class-validator';
import { Autocalculate } from "./Autocalculate";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Describe a single glass pane corresponding to a layer in a window construction. */
export class EnergyWindowMaterialGlazing extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsNumber()
    @IsOptional()
    /** The surface-to-surface thickness of the glass in meters. Default:  0.003. */
    thickness?: number;
	
    @IsNumber()
    @IsOptional()
    /** Transmittance of solar radiation through the glass at normal incidence. Default: 0.85 for clear glass. */
    solar_transmittance?: number;
	
    @IsNumber()
    @IsOptional()
    /** Reflectance of solar radiation off of the front side of the glass at normal incidence, averaged over the solar spectrum. Default: 0.075 for clear glass. */
    solar_reflectance?: number;
	
    @IsOptional()
    /** Reflectance of solar radiation off of the back side of the glass at normal incidence, averaged over the solar spectrum. */
    solar_reflectance_back?: Autocalculate | number;
	
    @IsNumber()
    @IsOptional()
    /** Transmittance of visible light through the glass at normal incidence. Default: 0.9 for clear glass. */
    visible_transmittance?: number;
	
    @IsNumber()
    @IsOptional()
    /** Reflectance of visible light off of the front side of the glass at normal incidence. Default: 0.075 for clear glass. */
    visible_reflectance?: number;
	
    @IsOptional()
    /** Reflectance of visible light off of the back side of the glass at normal incidence averaged over the solar spectrum and weighted by the response of the human eye. */
    visible_reflectance_back?: Autocalculate | number;
	
    @IsNumber()
    @IsOptional()
    /** Long-wave transmittance at normal incidence. */
    infrared_transmittance?: number;
	
    @IsNumber()
    @IsOptional()
    /** Infrared hemispherical emissivity of the front (outward facing) side of the glass.  Default: 0.84, which is typical for clear glass without a low-e coating. */
    emissivity?: number;
	
    @IsNumber()
    @IsOptional()
    /** Infrared hemispherical emissivity of the back (inward facing) side of the glass.  Default: 0.84, which is typical for clear glass without a low-e coating. */
    emissivity_back?: number;
	
    @IsNumber()
    @IsOptional()
    /** Thermal conductivity of the glass in W/(m-K). Default: 0.9, which is  typical for clear glass without a low-e coating. */
    conductivity?: number;
	
    @IsNumber()
    @IsOptional()
    /** Factor that corrects for the presence of dirt on the glass. A default value of 1 indicates the glass is clean. */
    dirt_correction?: number;
	
    @IsBoolean()
    @IsOptional()
    /** If False (default), the beam solar radiation incident on the glass is transmitted as beam radiation with no diffuse component.If True, the beam  solar radiation incident on the glass is transmitted as hemispherical diffuse radiation with no beam component. */
    solar_diffusing?: boolean;
	

    constructor() {
        super();
        this.type = "EnergyWindowMaterialGlazing";
        this.thickness = 0.003;
        this.solar_transmittance = 0.85;
        this.solar_reflectance = 0.075;
        this.solar_reflectance_back = new Autocalculate();
        this.visible_transmittance = 0.9;
        this.visible_reflectance = 0.075;
        this.visible_reflectance_back = new Autocalculate();
        this.infrared_transmittance = 0;
        this.emissivity = 0.84;
        this.emissivity_back = 0.84;
        this.conductivity = 0.9;
        this.dirt_correction = 1;
        this.solar_diffusing = false;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "EnergyWindowMaterialGlazing";
            this.thickness = _data["thickness"] !== undefined ? _data["thickness"] : 0.003;
            this.solar_transmittance = _data["solar_transmittance"] !== undefined ? _data["solar_transmittance"] : 0.85;
            this.solar_reflectance = _data["solar_reflectance"] !== undefined ? _data["solar_reflectance"] : 0.075;
            this.solar_reflectance_back = _data["solar_reflectance_back"] !== undefined ? _data["solar_reflectance_back"] : new Autocalculate();
            this.visible_transmittance = _data["visible_transmittance"] !== undefined ? _data["visible_transmittance"] : 0.9;
            this.visible_reflectance = _data["visible_reflectance"] !== undefined ? _data["visible_reflectance"] : 0.075;
            this.visible_reflectance_back = _data["visible_reflectance_back"] !== undefined ? _data["visible_reflectance_back"] : new Autocalculate();
            this.infrared_transmittance = _data["infrared_transmittance"] !== undefined ? _data["infrared_transmittance"] : 0;
            this.emissivity = _data["emissivity"] !== undefined ? _data["emissivity"] : 0.84;
            this.emissivity_back = _data["emissivity_back"] !== undefined ? _data["emissivity_back"] : 0.84;
            this.conductivity = _data["conductivity"] !== undefined ? _data["conductivity"] : 0.9;
            this.dirt_correction = _data["dirt_correction"] !== undefined ? _data["dirt_correction"] : 1;
            this.solar_diffusing = _data["solar_diffusing"] !== undefined ? _data["solar_diffusing"] : false;
        }
    }


    static override fromJS(data: any): EnergyWindowMaterialGlazing {
        data = typeof data === 'object' ? data : {};

        let result = new EnergyWindowMaterialGlazing();
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
        data["thickness"] = this.thickness;
        data["solar_transmittance"] = this.solar_transmittance;
        data["solar_reflectance"] = this.solar_reflectance;
        data["solar_reflectance_back"] = this.solar_reflectance_back;
        data["visible_transmittance"] = this.visible_transmittance;
        data["visible_reflectance"] = this.visible_reflectance;
        data["visible_reflectance_back"] = this.visible_reflectance_back;
        data["infrared_transmittance"] = this.infrared_transmittance;
        data["emissivity"] = this.emissivity;
        data["emissivity_back"] = this.emissivity_back;
        data["conductivity"] = this.conductivity;
        data["dirt_correction"] = this.dirt_correction;
        data["solar_diffusing"] = this.solar_diffusing;
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
