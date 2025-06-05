import { IsString, IsOptional, Matches, IsEnum, IsNumber, Max, Min, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { MoistureDiffusionModel } from "./MoistureDiffusionModel";
import { Roughness } from "./Roughness";

/** Material representing vegetation on the exterior of an opaque construction. */
export class EnergyMaterialVegetation extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^EnergyMaterialVegetation$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "EnergyMaterialVegetation";
	
    @IsEnum(Roughness)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "roughness" })
    /** roughness */
    roughness: Roughness = Roughness.MediumRough;
	
    @IsNumber()
    @IsOptional()
    @Max(3)
    @Expose({ name: "thickness" })
    /** Thickness of the soil layer in meters. */
    thickness: number = 0.1;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "conductivity" })
    /** Thermal conductivity of the dry soil in W/m-K. */
    conductivity: number = 0.35;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "density" })
    /** Density of the dry soil in kg/m3. */
    density: number = 1100;
	
    @IsNumber()
    @IsOptional()
    @Min(100)
    @Expose({ name: "specific_heat" })
    /** Specific heat of the dry soil in J/kg-K. */
    specificHeat: number = 1200;
	
    @IsNumber()
    @IsOptional()
    @Max(0.99999)
    @Expose({ name: "soil_thermal_absorptance" })
    /** Fraction of incident long wavelength radiation that is absorbed by the soil. Default: 0.9. */
    soilThermalAbsorptance: number = 0.9;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "soil_solar_absorptance" })
    /** Fraction of incident solar radiation absorbed by the soil. Default: 0.7. */
    soilSolarAbsorptance: number = 0.7;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "soil_visible_absorptance" })
    /** Fraction of incident visible wavelength radiation absorbed by the material. Default: 0.7. */
    soilVisibleAbsorptance: number = 0.7;
	
    @IsNumber()
    @IsOptional()
    @Min(0.005)
    @Max(1.0)
    @Expose({ name: "plant_height" })
    /** The height of plants in the vegetation in meters. */
    plantHeight: number = 0.2;
	
    @IsNumber()
    @IsOptional()
    @Min(0.001)
    @Max(5.0)
    @Expose({ name: "leaf_area_index" })
    /** The projected leaf area per unit area of soil surface (aka. Leaf Area Index or LAI). Note that the fraction of vegetation cover is calculated directly from LAI using an empirical relation. */
    leafAreaIndex: number = 1;
	
    @IsNumber()
    @IsOptional()
    @Min(0.005)
    @Max(0.5)
    @Expose({ name: "leaf_reflectivity" })
    /** The fraction of incident solar radiation that is reflected by the leaf surfaces. Solar radiation includes the visible spectrum as well as infrared and ultraviolet wavelengths. Typical values are 0.18 to 0.25. */
    leafReflectivity: number = 0.22;
	
    @IsNumber()
    @IsOptional()
    @Min(0.8)
    @Max(1.0)
    @Expose({ name: "leaf_emissivity" })
    /** The ratio of thermal radiation emitted from leaf surfaces to that emitted by an ideal black body at the same temperature. */
    leafEmissivity: number = 0.95;
	
    @IsNumber()
    @IsOptional()
    @Min(50)
    @Max(300)
    @Expose({ name: "min_stomatal_resist" })
    /** The resistance of the plants to moisture transport [s/m]. Plants with low values of stomatal resistance will result in higher evapotranspiration rates than plants with high resistance. */
    minStomatalResist: number = 180;
	
    @IsNumber()
    @IsOptional()
    @Min(0.1)
    @Max(0.5)
    @Expose({ name: "sat_vol_moist_cont" })
    /** The saturation moisture content of the soil by volume. */
    satVolMoistCont: number = 0.3;
	
    @IsNumber()
    @IsOptional()
    @Min(0.01)
    @Max(0.1)
    @Expose({ name: "residual_vol_moist_cont" })
    /** The residual moisture content of the soil by volume. */
    residualVolMoistCont: number = 0.01;
	
    @IsNumber()
    @IsOptional()
    @Min(0.05)
    @Max(0.5)
    @Expose({ name: "init_vol_moist_cont" })
    /** The initial moisture content of the soil by volume. */
    initVolMoistCont: number = 0.01;
	
    @IsEnum(MoistureDiffusionModel)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "moist_diff_model" })
    /** moistDiffModel */
    moistDiffModel: MoistureDiffusionModel = MoistureDiffusionModel.Simple;
	

    constructor() {
        super();
        this.type = "EnergyMaterialVegetation";
        this.roughness = Roughness.MediumRough;
        this.thickness = 0.1;
        this.conductivity = 0.35;
        this.density = 1100;
        this.specificHeat = 1200;
        this.soilThermalAbsorptance = 0.9;
        this.soilSolarAbsorptance = 0.7;
        this.soilVisibleAbsorptance = 0.7;
        this.plantHeight = 0.2;
        this.leafAreaIndex = 1;
        this.leafReflectivity = 0.22;
        this.leafEmissivity = 0.95;
        this.minStomatalResist = 180;
        this.satVolMoistCont = 0.3;
        this.residualVolMoistCont = 0.01;
        this.initVolMoistCont = 0.01;
        this.moistDiffModel = MoistureDiffusionModel.Simple;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(EnergyMaterialVegetation, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.roughness = obj.roughness;
            this.thickness = obj.thickness;
            this.conductivity = obj.conductivity;
            this.density = obj.density;
            this.specificHeat = obj.specificHeat;
            this.soilThermalAbsorptance = obj.soilThermalAbsorptance;
            this.soilSolarAbsorptance = obj.soilSolarAbsorptance;
            this.soilVisibleAbsorptance = obj.soilVisibleAbsorptance;
            this.plantHeight = obj.plantHeight;
            this.leafAreaIndex = obj.leafAreaIndex;
            this.leafReflectivity = obj.leafReflectivity;
            this.leafEmissivity = obj.leafEmissivity;
            this.minStomatalResist = obj.minStomatalResist;
            this.satVolMoistCont = obj.satVolMoistCont;
            this.residualVolMoistCont = obj.residualVolMoistCont;
            this.initVolMoistCont = obj.initVolMoistCont;
            this.moistDiffModel = obj.moistDiffModel;
        }
    }


    static override fromJS(data: any): EnergyMaterialVegetation {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new EnergyMaterialVegetation();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["roughness"] = this.roughness;
        data["thickness"] = this.thickness;
        data["conductivity"] = this.conductivity;
        data["density"] = this.density;
        data["specific_heat"] = this.specificHeat;
        data["soil_thermal_absorptance"] = this.soilThermalAbsorptance;
        data["soil_solar_absorptance"] = this.soilSolarAbsorptance;
        data["soil_visible_absorptance"] = this.soilVisibleAbsorptance;
        data["plant_height"] = this.plantHeight;
        data["leaf_area_index"] = this.leafAreaIndex;
        data["leaf_reflectivity"] = this.leafReflectivity;
        data["leaf_emissivity"] = this.leafEmissivity;
        data["min_stomatal_resist"] = this.minStomatalResist;
        data["sat_vol_moist_cont"] = this.satVolMoistCont;
        data["residual_vol_moist_cont"] = this.residualVolMoistCont;
        data["init_vol_moist_cont"] = this.initVolMoistCont;
        data["moist_diff_model"] = this.moistDiffModel;
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
