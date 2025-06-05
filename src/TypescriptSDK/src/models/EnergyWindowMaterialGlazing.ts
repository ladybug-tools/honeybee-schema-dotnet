import { IsString, IsOptional, Matches, IsNumber, Min, Max, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { Autocalculate } from "./Autocalculate";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Describe a single glass pane corresponding to a layer in a window construction. */
export class EnergyWindowMaterialGlazing extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^EnergyWindowMaterialGlazing$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "EnergyWindowMaterialGlazing";
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "thickness" })
    /** The surface-to-surface thickness of the glass in meters. Default:  0.003. */
    thickness: number = 0.003;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "solar_transmittance" })
    /** Transmittance of solar radiation through the glass at normal incidence. Default: 0.85 for clear glass. */
    solarTransmittance: number = 0.85;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "solar_reflectance" })
    /** Reflectance of solar radiation off of the front side of the glass at normal incidence, averaged over the solar spectrum. Default: 0.075 for clear glass. */
    solarReflectance: number = 0.075;
	
    @IsOptional()
    @Expose({ name: "solar_reflectance_back" })
    /** Reflectance of solar radiation off of the back side of the glass at normal incidence, averaged over the solar spectrum. */
    solarReflectanceBack: (Autocalculate | number) = new Autocalculate();
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "visible_transmittance" })
    /** Transmittance of visible light through the glass at normal incidence. Default: 0.9 for clear glass. */
    visibleTransmittance: number = 0.9;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "visible_reflectance" })
    /** Reflectance of visible light off of the front side of the glass at normal incidence. Default: 0.075 for clear glass. */
    visibleReflectance: number = 0.075;
	
    @IsOptional()
    @Expose({ name: "visible_reflectance_back" })
    /** Reflectance of visible light off of the back side of the glass at normal incidence averaged over the solar spectrum and weighted by the response of the human eye. */
    visibleReflectanceBack: (Autocalculate | number) = new Autocalculate();
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "infrared_transmittance" })
    /** Long-wave transmittance at normal incidence. */
    infraredTransmittance: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "emissivity" })
    /** Infrared hemispherical emissivity of the front (outward facing) side of the glass.  Default: 0.84, which is typical for clear glass without a low-e coating. */
    emissivity: number = 0.84;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "emissivity_back" })
    /** Infrared hemispherical emissivity of the back (inward facing) side of the glass.  Default: 0.84, which is typical for clear glass without a low-e coating. */
    emissivityBack: number = 0.84;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "conductivity" })
    /** Thermal conductivity of the glass in W/(m-K). Default: 0.9, which is  typical for clear glass without a low-e coating. */
    conductivity: number = 0.9;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "dirt_correction" })
    /** Factor that corrects for the presence of dirt on the glass. A default value of 1 indicates the glass is clean. */
    dirtCorrection: number = 1;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "solar_diffusing" })
    /** If False (default), the beam solar radiation incident on the glass is transmitted as beam radiation with no diffuse component.If True, the beam  solar radiation incident on the glass is transmitted as hemispherical diffuse radiation with no beam component. */
    solarDiffusing: boolean = false;
	

    constructor() {
        super();
        this.type = "EnergyWindowMaterialGlazing";
        this.thickness = 0.003;
        this.solarTransmittance = 0.85;
        this.solarReflectance = 0.075;
        this.solarReflectanceBack = new Autocalculate();
        this.visibleTransmittance = 0.9;
        this.visibleReflectance = 0.075;
        this.visibleReflectanceBack = new Autocalculate();
        this.infraredTransmittance = 0;
        this.emissivity = 0.84;
        this.emissivityBack = 0.84;
        this.conductivity = 0.9;
        this.dirtCorrection = 1;
        this.solarDiffusing = false;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(EnergyWindowMaterialGlazing, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.thickness = obj.thickness;
            this.solarTransmittance = obj.solarTransmittance;
            this.solarReflectance = obj.solarReflectance;
            this.solarReflectanceBack = obj.solarReflectanceBack;
            this.visibleTransmittance = obj.visibleTransmittance;
            this.visibleReflectance = obj.visibleReflectance;
            this.visibleReflectanceBack = obj.visibleReflectanceBack;
            this.infraredTransmittance = obj.infraredTransmittance;
            this.emissivity = obj.emissivity;
            this.emissivityBack = obj.emissivityBack;
            this.conductivity = obj.conductivity;
            this.dirtCorrection = obj.dirtCorrection;
            this.solarDiffusing = obj.solarDiffusing;
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
        data["solar_transmittance"] = this.solarTransmittance;
        data["solar_reflectance"] = this.solarReflectance;
        data["solar_reflectance_back"] = this.solarReflectanceBack;
        data["visible_transmittance"] = this.visibleTransmittance;
        data["visible_reflectance"] = this.visibleReflectance;
        data["visible_reflectance_back"] = this.visibleReflectanceBack;
        data["infrared_transmittance"] = this.infraredTransmittance;
        data["emissivity"] = this.emissivity;
        data["emissivity_back"] = this.emissivityBack;
        data["conductivity"] = this.conductivity;
        data["dirt_correction"] = this.dirtCorrection;
        data["solar_diffusing"] = this.solarDiffusing;
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
