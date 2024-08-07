import { IsString, IsOptional, IsEnum, ValidateNested, IsNumber, validate, ValidationError } from 'class-validator';
import { Roughness } from "./Roughness";
import { MoistureDiffusionModel } from "./MoistureDiffusionModel";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Material representing vegetation on the exterior of an opaque construction. */
export class EnergyMaterialVegetation extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsEnum(Roughness)
    @ValidateNested()
    @IsOptional()
    roughness?: Roughness;
	
    @IsNumber()
    @IsOptional()
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
    /** Specific heat of the dry soil in J/kg-K. */
    specific_heat?: number;
	
    @IsNumber()
    @IsOptional()
    /** Fraction of incident long wavelength radiation that is absorbed by the soil. Default: 0.9. */
    soil_thermal_absorptance?: number;
	
    @IsNumber()
    @IsOptional()
    /** Fraction of incident solar radiation absorbed by the soil. Default: 0.7. */
    soil_solar_absorptance?: number;
	
    @IsNumber()
    @IsOptional()
    /** Fraction of incident visible wavelength radiation absorbed by the material. Default: 0.7. */
    soil_visible_absorptance?: number;
	
    @IsNumber()
    @IsOptional()
    /** The height of plants in the vegetation in meters. */
    plant_height?: number;
	
    @IsNumber()
    @IsOptional()
    /** The projected leaf area per unit area of soil surface (aka. Leaf Area Index or LAI). Note that the fraction of vegetation cover is calculated directly from LAI using an empirical relation. */
    leaf_area_index?: number;
	
    @IsNumber()
    @IsOptional()
    /** The fraction of incident solar radiation that is reflected by the leaf surfaces. Solar radiation includes the visible spectrum as well as infrared and ultraviolet wavelengths. Typical values are 0.18 to 0.25. */
    leaf_reflectivity?: number;
	
    @IsNumber()
    @IsOptional()
    /** The ratio of thermal radiation emitted from leaf surfaces to that emitted by an ideal black body at the same temperature. */
    leaf_emissivity?: number;
	
    @IsNumber()
    @IsOptional()
    /** The resistance of the plants to moisture transport [s/m]. Plants with low values of stomatal resistance will result in higher evapotranspiration rates than plants with high resistance. */
    min_stomatal_resist?: number;
	
    @IsNumber()
    @IsOptional()
    /** The saturation moisture content of the soil by volume. */
    sat_vol_moist_cont?: number;
	
    @IsNumber()
    @IsOptional()
    /** The residual moisture content of the soil by volume. */
    residual_vol_moist_cont?: number;
	
    @IsNumber()
    @IsOptional()
    /** The initial moisture content of the soil by volume. */
    init_vol_moist_cont?: number;
	
    @IsEnum(MoistureDiffusionModel)
    @ValidateNested()
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
            this.type = _data["type"] !== undefined ? _data["type"] : "EnergyMaterialVegetation";
            this.roughness = _data["roughness"] !== undefined ? _data["roughness"] : Roughness.MediumRough;
            this.thickness = _data["thickness"] !== undefined ? _data["thickness"] : 0.1;
            this.conductivity = _data["conductivity"] !== undefined ? _data["conductivity"] : 0.35;
            this.density = _data["density"] !== undefined ? _data["density"] : 1100;
            this.specific_heat = _data["specific_heat"] !== undefined ? _data["specific_heat"] : 1200;
            this.soil_thermal_absorptance = _data["soil_thermal_absorptance"] !== undefined ? _data["soil_thermal_absorptance"] : 0.9;
            this.soil_solar_absorptance = _data["soil_solar_absorptance"] !== undefined ? _data["soil_solar_absorptance"] : 0.7;
            this.soil_visible_absorptance = _data["soil_visible_absorptance"] !== undefined ? _data["soil_visible_absorptance"] : 0.7;
            this.plant_height = _data["plant_height"] !== undefined ? _data["plant_height"] : 0.2;
            this.leaf_area_index = _data["leaf_area_index"] !== undefined ? _data["leaf_area_index"] : 1;
            this.leaf_reflectivity = _data["leaf_reflectivity"] !== undefined ? _data["leaf_reflectivity"] : 0.22;
            this.leaf_emissivity = _data["leaf_emissivity"] !== undefined ? _data["leaf_emissivity"] : 0.95;
            this.min_stomatal_resist = _data["min_stomatal_resist"] !== undefined ? _data["min_stomatal_resist"] : 180;
            this.sat_vol_moist_cont = _data["sat_vol_moist_cont"] !== undefined ? _data["sat_vol_moist_cont"] : 0.3;
            this.residual_vol_moist_cont = _data["residual_vol_moist_cont"] !== undefined ? _data["residual_vol_moist_cont"] : 0.01;
            this.init_vol_moist_cont = _data["init_vol_moist_cont"] !== undefined ? _data["init_vol_moist_cont"] : 0.01;
            this.moist_diff_model = _data["moist_diff_model"] !== undefined ? _data["moist_diff_model"] : MoistureDiffusionModel.Simple;
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
