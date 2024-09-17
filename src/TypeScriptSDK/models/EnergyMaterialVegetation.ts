import { IsString, IsOptional, Matches, IsEnum, IsNumber, Max, Min, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { MoistureDiffusionModel } from "./MoistureDiffusionModel";
import { Roughness } from "./Roughness";

/** Material representing vegetation on the exterior of an opaque construction. */
export class EnergyMaterialVegetation extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^EnergyMaterialVegetation$/)
    type?: string;
	
    @IsEnum(Roughness)
    @Type(() => String)
    @IsOptional()
    roughness?: Roughness;
	
    @IsNumber()
    @IsOptional()
    @Max(3)
    /** Thickness of the soil layer in meters. */
    thickness?: number;
	
    @IsNumber()
    @IsOptional()
    /** Thermal conductivity of the dry soil in W/m-K. */
    conductivity?: number;
	
    @IsNumber()
    @IsOptional()
    /** Density of the dry soil in kg/m3. */
    density?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(100)
    /** Specific heat of the dry soil in J/kg-K. */
    specific_heat?: number;
	
    @IsNumber()
    @IsOptional()
    @Max(0.99999)
    /** Fraction of incident long wavelength radiation that is absorbed by the soil. Default: 0.9. */
    soil_thermal_absorptance?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** Fraction of incident solar radiation absorbed by the soil. Default: 0.7. */
    soil_solar_absorptance?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    /** Fraction of incident visible wavelength radiation absorbed by the material. Default: 0.7. */
    soil_visible_absorptance?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0.005)
    @Max(1.0)
    /** The height of plants in the vegetation in meters. */
    plant_height?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0.001)
    @Max(5.0)
    /** The projected leaf area per unit area of soil surface (aka. Leaf Area Index or LAI). Note that the fraction of vegetation cover is calculated directly from LAI using an empirical relation. */
    leaf_area_index?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0.005)
    @Max(0.5)
    /** The fraction of incident solar radiation that is reflected by the leaf surfaces. Solar radiation includes the visible spectrum as well as infrared and ultraviolet wavelengths. Typical values are 0.18 to 0.25. */
    leaf_reflectivity?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0.8)
    @Max(1.0)
    /** The ratio of thermal radiation emitted from leaf surfaces to that emitted by an ideal black body at the same temperature. */
    leaf_emissivity?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(50)
    @Max(300)
    /** The resistance of the plants to moisture transport [s/m]. Plants with low values of stomatal resistance will result in higher evapotranspiration rates than plants with high resistance. */
    min_stomatal_resist?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0.1)
    @Max(0.5)
    /** The saturation moisture content of the soil by volume. */
    sat_vol_moist_cont?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0.01)
    @Max(0.1)
    /** The residual moisture content of the soil by volume. */
    residual_vol_moist_cont?: number;
	
    @IsNumber()
    @IsOptional()
    @Min(0.05)
    @Max(0.5)
    /** The initial moisture content of the soil by volume. */
    init_vol_moist_cont?: number;
	
    @IsEnum(MoistureDiffusionModel)
    @Type(() => String)
    @IsOptional()
    moist_diff_model?: MoistureDiffusionModel;
	

    constructor() {
        super();
        this.type = "EnergyMaterialVegetation";
        this.roughness = Roughness.MediumRough;
        this.thickness = 0.1;
        this.conductivity = 0.35;
        this.density = 1100;
        this.specific_heat = 1200;
        this.soil_thermal_absorptance = 0.9;
        this.soil_solar_absorptance = 0.7;
        this.soil_visible_absorptance = 0.7;
        this.plant_height = 0.2;
        this.leaf_area_index = 1;
        this.leaf_reflectivity = 0.22;
        this.leaf_emissivity = 0.95;
        this.min_stomatal_resist = 180;
        this.sat_vol_moist_cont = 0.3;
        this.residual_vol_moist_cont = 0.01;
        this.init_vol_moist_cont = 0.01;
        this.moist_diff_model = MoistureDiffusionModel.Simple;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(EnergyMaterialVegetation, _data);
            this.type = obj.type;
            this.roughness = obj.roughness;
            this.thickness = obj.thickness;
            this.conductivity = obj.conductivity;
            this.density = obj.density;
            this.specific_heat = obj.specific_heat;
            this.soil_thermal_absorptance = obj.soil_thermal_absorptance;
            this.soil_solar_absorptance = obj.soil_solar_absorptance;
            this.soil_visible_absorptance = obj.soil_visible_absorptance;
            this.plant_height = obj.plant_height;
            this.leaf_area_index = obj.leaf_area_index;
            this.leaf_reflectivity = obj.leaf_reflectivity;
            this.leaf_emissivity = obj.leaf_emissivity;
            this.min_stomatal_resist = obj.min_stomatal_resist;
            this.sat_vol_moist_cont = obj.sat_vol_moist_cont;
            this.residual_vol_moist_cont = obj.residual_vol_moist_cont;
            this.init_vol_moist_cont = obj.init_vol_moist_cont;
            this.moist_diff_model = obj.moist_diff_model;
        }
    }


    static override fromJS(data: any): EnergyMaterialVegetation {
        data = typeof data === 'object' ? data : {};

        let result = new EnergyMaterialVegetation();
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
        data["roughness"] = this.roughness;
        data["thickness"] = this.thickness;
        data["conductivity"] = this.conductivity;
        data["density"] = this.density;
        data["specific_heat"] = this.specific_heat;
        data["soil_thermal_absorptance"] = this.soil_thermal_absorptance;
        data["soil_solar_absorptance"] = this.soil_solar_absorptance;
        data["soil_visible_absorptance"] = this.soil_visible_absorptance;
        data["plant_height"] = this.plant_height;
        data["leaf_area_index"] = this.leaf_area_index;
        data["leaf_reflectivity"] = this.leaf_reflectivity;
        data["leaf_emissivity"] = this.leaf_emissivity;
        data["min_stomatal_resist"] = this.min_stomatal_resist;
        data["sat_vol_moist_cont"] = this.sat_vol_moist_cont;
        data["residual_vol_moist_cont"] = this.residual_vol_moist_cont;
        data["init_vol_moist_cont"] = this.init_vol_moist_cont;
        data["moist_diff_model"] = this.moist_diff_model;
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
