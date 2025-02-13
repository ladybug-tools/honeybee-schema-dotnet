import { IsString, IsOptional, Matches, IsNumber, Min, Max, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { Autocalculate } from "./Autocalculate";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Describe a single glass pane corresponding to a layer in a window construction. */
export class EnergyWindowMaterialGlazing extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^EnergyWindowMaterialGlazing$/)
    /** Type */
    type?: string;
	
    @IsNumber()
    @IsOptional()
    /** The surface-to-surface thickness of the glass in meters. Default:  0.003. */
    thickness?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** Transmittance of solar radiation through the glass at normal incidence. Default: 0.85 for clear glass. */
    solar_transmittance?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** Reflectance of solar radiation off of the front side of the glass at normal incidence, averaged over the solar spectrum. Default: 0.075 for clear glass. */
    solar_reflectance?: number;
	
    @IsOptional()
    /** Reflectance of solar radiation off of the back side of the glass at normal incidence, averaged over the solar spectrum. */
    solar_reflectance_back?: (Autocalculate | number);
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** Transmittance of visible light through the glass at normal incidence. Default: 0.9 for clear glass. */
    visible_transmittance?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** Reflectance of visible light off of the front side of the glass at normal incidence. Default: 0.075 for clear glass. */
    visible_reflectance?: number;
	
    @IsOptional()
    /** Reflectance of visible light off of the back side of the glass at normal incidence averaged over the solar spectrum and weighted by the response of the human eye. */
    visible_reflectance_back?: (Autocalculate | number);
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** Long-wave transmittance at normal incidence. */
    infrared_transmittance?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** Infrared hemispherical emissivity of the front (outward facing) side of the glass.  Default: 0.84, which is typical for clear glass without a low-e coating. */
    emissivity?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
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
            const obj = plainToClass(EnergyWindowMaterialGlazing, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.thickness = obj.thickness;
            this.solar_transmittance = obj.solar_transmittance;
            this.solar_reflectance = obj.solar_reflectance;
            this.solar_reflectance_back = obj.solar_reflectance_back;
            this.visible_transmittance = obj.visible_transmittance;
            this.visible_reflectance = obj.visible_reflectance;
            this.visible_reflectance_back = obj.visible_reflectance_back;
            this.infrared_transmittance = obj.infrared_transmittance;
            this.emissivity = obj.emissivity;
            this.emissivity_back = obj.emissivity_back;
            this.conductivity = obj.conductivity;
            this.dirt_correction = obj.dirt_correction;
            this.solar_diffusing = obj.solar_diffusing;
        }
    }


    static override fromJS(data: any): EnergyWindowMaterialGlazing {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new EnergyWindowMaterialGlazing();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
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

