import { IsString, IsOptional, Matches, IsInstance, ValidateNested, IsArray, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { AirBoundaryConstruction } from "./AirBoundaryConstruction";
import { AirBoundaryConstructionAbridged } from "./AirBoundaryConstructionAbridged";
import { Baseboard } from "./Baseboard";
import { ConstructionSet } from "./ConstructionSet";
import { ConstructionSetAbridged } from "./ConstructionSetAbridged";
import { DetailedHVAC } from "./DetailedHVAC";
import { ElectricLoadCenter } from "./ElectricLoadCenter";
import { EnergyMaterial } from "./EnergyMaterial";
import { EnergyMaterialNoMass } from "./EnergyMaterialNoMass";
import { EnergyMaterialVegetation } from "./EnergyMaterialVegetation";
import { EnergyWindowFrame } from "./EnergyWindowFrame";
import { EnergyWindowMaterialBlind } from "./EnergyWindowMaterialBlind";
import { EnergyWindowMaterialGas } from "./EnergyWindowMaterialGas";
import { EnergyWindowMaterialGasCustom } from "./EnergyWindowMaterialGasCustom";
import { EnergyWindowMaterialGasMixture } from "./EnergyWindowMaterialGasMixture";
import { EnergyWindowMaterialGlazing } from "./EnergyWindowMaterialGlazing";
import { EnergyWindowMaterialShade } from "./EnergyWindowMaterialShade";
import { EnergyWindowMaterialSimpleGlazSys } from "./EnergyWindowMaterialSimpleGlazSys";
import { EvaporativeCooler } from "./EvaporativeCooler";
import { FCU } from "./FCU";
import { FCUwithDOASAbridged } from "./FCUwithDOASAbridged";
import { ForcedAirFurnace } from "./ForcedAirFurnace";
import { GasUnitHeater } from "./GasUnitHeater";
import { GlobalConstructionSet } from "./GlobalConstructionSet";
import { IdealAirSystemAbridged } from "./IdealAirSystemAbridged";
import { OpaqueConstruction } from "./OpaqueConstruction";
import { OpaqueConstructionAbridged } from "./OpaqueConstructionAbridged";
import { ProgramType } from "./ProgramType";
import { ProgramTypeAbridged } from "./ProgramTypeAbridged";
import { PSZ } from "./PSZ";
import { PTAC } from "./PTAC";
import { PVAV } from "./PVAV";
import { Radiant } from "./Radiant";
import { RadiantwithDOASAbridged } from "./RadiantwithDOASAbridged";
import { Residential } from "./Residential";
import { ScheduleFixedInterval } from "./ScheduleFixedInterval";
import { ScheduleFixedIntervalAbridged } from "./ScheduleFixedIntervalAbridged";
import { ScheduleRuleset } from "./ScheduleRuleset";
import { ScheduleRulesetAbridged } from "./ScheduleRulesetAbridged";
import { ScheduleTypeLimit } from "./ScheduleTypeLimit";
import { ShadeConstruction } from "./ShadeConstruction";
import { SHWSystem } from "./SHWSystem";
import { VAV } from "./VAV";
import { VentilationSimulationControl } from "./VentilationSimulationControl";
import { VRF } from "./VRF";
import { VRFwithDOASAbridged } from "./VRFwithDOASAbridged";
import { WindowAC } from "./WindowAC";
import { WindowConstruction } from "./WindowConstruction";
import { WindowConstructionAbridged } from "./WindowConstructionAbridged";
import { WindowConstructionDynamic } from "./WindowConstructionDynamic";
import { WindowConstructionDynamicAbridged } from "./WindowConstructionDynamicAbridged";
import { WindowConstructionShade } from "./WindowConstructionShade";
import { WindowConstructionShadeAbridged } from "./WindowConstructionShadeAbridged";
import { WSHP } from "./WSHP";
import { WSHPwithDOASAbridged } from "./WSHPwithDOASAbridged";

/** Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects. */
export class ModelEnergyProperties extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^ModelEnergyProperties$/)
    type?: string;
	
    @IsInstance(GlobalConstructionSet)
    @Type(() => GlobalConstructionSet)
    @ValidateNested()
    @IsOptional()
    /** Global Energy construction set. */
    global_construction_set?: GlobalConstructionSet;
	
    @IsArray()
    @IsOptional()
    /** List of all unique ConstructionSets in the Model. */
    construction_sets?: (ConstructionSetAbridged | ConstructionSet) [];
	
    @IsArray()
    @IsOptional()
    /** A list of all unique constructions in the model. This includes constructions across all Faces, Apertures, Doors, Shades, Room ConstructionSets, and the global_construction_set. */
    constructions?: (OpaqueConstructionAbridged | WindowConstructionAbridged | WindowConstructionShadeAbridged | AirBoundaryConstructionAbridged | OpaqueConstruction | WindowConstruction | WindowConstructionShade | WindowConstructionDynamicAbridged | WindowConstructionDynamic | AirBoundaryConstruction | ShadeConstruction) [];
	
    @IsArray()
    @IsOptional()
    /** A list of all unique materials in the model. This includes materials needed to make the Model constructions. */
    materials?: (EnergyMaterial | EnergyMaterialNoMass | EnergyMaterialVegetation | EnergyWindowMaterialGlazing | EnergyWindowMaterialSimpleGlazSys | EnergyWindowMaterialGas | EnergyWindowMaterialGasMixture | EnergyWindowMaterialGasCustom | EnergyWindowFrame | EnergyWindowMaterialBlind | EnergyWindowMaterialShade) [];
	
    @IsArray()
    @IsOptional()
    /** List of all unique HVAC systems in the Model. */
    hvacs?: (IdealAirSystemAbridged | VAV | PVAV | PSZ | PTAC | ForcedAirFurnace | FCUwithDOASAbridged | WSHPwithDOASAbridged | VRFwithDOASAbridged | RadiantwithDOASAbridged | FCU | WSHP | VRF | Baseboard | EvaporativeCooler | Residential | WindowAC | GasUnitHeater | Radiant | DetailedHVAC) [];
	
    @IsArray()
    @IsInstance(SHWSystem, { each: true })
    @Type(() => SHWSystem)
    @ValidateNested({ each: true })
    @IsOptional()
    /** List of all unique Service Hot Water (SHW) systems in the Model. */
    shws?: SHWSystem [];
	
    @IsArray()
    @IsOptional()
    /** List of all unique ProgramTypes in the Model. */
    program_types?: (ProgramTypeAbridged | ProgramType) [];
	
    @IsArray()
    @IsOptional()
    /** A list of all unique schedules in the model. This includes schedules across all HVAC systems, ProgramTypes, Rooms, and Shades. */
    schedules?: (ScheduleRulesetAbridged | ScheduleFixedIntervalAbridged | ScheduleRuleset | ScheduleFixedInterval) [];
	
    @IsArray()
    @IsInstance(ScheduleTypeLimit, { each: true })
    @Type(() => ScheduleTypeLimit)
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of all unique ScheduleTypeLimits in the model. This all ScheduleTypeLimits needed to make the Model schedules. */
    schedule_type_limits?: ScheduleTypeLimit [];
	
    @IsInstance(VentilationSimulationControl)
    @Type(() => VentilationSimulationControl)
    @ValidateNested()
    @IsOptional()
    /** An optional parameter to define the global parameters for a ventilation cooling. */
    ventilation_simulation_control?: VentilationSimulationControl;
	
    @IsInstance(ElectricLoadCenter)
    @Type(() => ElectricLoadCenter)
    @ValidateNested()
    @IsOptional()
    /** An optional parameter object that defines the properties of the model electric loads center that manages on site electricity generation and conversion. */
    electric_load_center?: ElectricLoadCenter;
	

    constructor() {
        super();
        this.type = "ModelEnergyProperties";
        this.global_construction_set = GlobalConstructionSet.fromJS({
  "type": "GlobalConstructionSet",
  "materials": [
    {
      "identifier": "Generic Roof Membrane",
      "display_name": null,
      "user_data": null,
      "type": "EnergyMaterial",
      "roughness": "MediumRough",
      "thickness": 0.01,
      "conductivity": 0.16,
      "density": 1120.0,
      "specific_heat": 1460.0,
      "thermal_absorptance": 0.9,
      "solar_absorptance": 0.65,
      "visible_absorptance": 0.65
    },
    {
      "identifier": "Generic Acoustic Tile",
      "display_name": null,
      "user_data": null,
      "type": "EnergyMaterial",
      "roughness": "MediumSmooth",
      "thickness": 0.02,
      "conductivity": 0.06,
      "density": 368.0,
      "specific_heat": 590.0,
      "thermal_absorptance": 0.9,
      "solar_absorptance": 0.2,
      "visible_absorptance": 0.2
    },
    {
      "identifier": "Generic 25mm Wood",
      "display_name": null,
      "user_data": null,
      "type": "EnergyMaterial",
      "roughness": "MediumSmooth",
      "thickness": 0.0254,
      "conductivity": 0.15,
      "density": 608.0,
      "specific_heat": 1630.0,
      "thermal_absorptance": 0.9,
      "solar_absorptance": 0.5,
      "visible_absorptance": 0.5
    },
    {
      "identifier": "Generic HW Concrete",
      "display_name": null,
      "user_data": null,
      "type": "EnergyMaterial",
      "roughness": "MediumRough",
      "thickness": 0.2,
      "conductivity": 1.95,
      "density": 2240.0,
      "specific_heat": 900.0,
      "thermal_absorptance": 0.9,
      "solar_absorptance": 0.8,
      "visible_absorptance": 0.8
    },
    {
      "identifier": "Generic Window Air Gap",
      "display_name": null,
      "user_data": null,
      "type": "EnergyWindowMaterialGas",
      "thickness": 0.0127,
      "gas_type": "Air"
    },
    {
      "identifier": "Generic Gypsum Board",
      "display_name": null,
      "user_data": null,
      "type": "EnergyMaterial",
      "roughness": "MediumSmooth",
      "thickness": 0.0127,
      "conductivity": 0.16,
      "density": 800.0,
      "specific_heat": 1090.0,
      "thermal_absorptance": 0.9,
      "solar_absorptance": 0.5,
      "visible_absorptance": 0.5
    },
    {
      "identifier": "Generic Wall Air Gap",
      "display_name": null,
      "user_data": null,
      "type": "EnergyMaterial",
      "roughness": "Smooth",
      "thickness": 0.1,
      "conductivity": 0.667,
      "density": 1.28,
      "specific_heat": 1000.0,
      "thermal_absorptance": 0.9,
      "solar_absorptance": 0.7,
      "visible_absorptance": 0.7
    },
    {
      "identifier": "Generic Ceiling Air Gap",
      "display_name": null,
      "user_data": null,
      "type": "EnergyMaterial",
      "roughness": "Smooth",
      "thickness": 0.1,
      "conductivity": 0.556,
      "density": 1.28,
      "specific_heat": 1000.0,
      "thermal_absorptance": 0.9,
      "solar_absorptance": 0.7,
      "visible_absorptance": 0.7
    },
    {
      "identifier": "Generic Brick",
      "display_name": null,
      "user_data": null,
      "type": "EnergyMaterial",
      "roughness": "MediumRough",
      "thickness": 0.1,
      "conductivity": 0.9,
      "density": 1920.0,
      "specific_heat": 790.0,
      "thermal_absorptance": 0.9,
      "solar_absorptance": 0.65,
      "visible_absorptance": 0.65
    },
    {
      "identifier": "Generic 50mm Insulation",
      "display_name": null,
      "user_data": null,
      "type": "EnergyMaterial",
      "roughness": "MediumRough",
      "thickness": 0.05,
      "conductivity": 0.03,
      "density": 43.0,
      "specific_heat": 1210.0,
      "thermal_absorptance": 0.9,
      "solar_absorptance": 0.7,
      "visible_absorptance": 0.7
    },
    {
      "identifier": "Generic Low-e Glass",
      "display_name": null,
      "user_data": null,
      "type": "EnergyWindowMaterialGlazing",
      "thickness": 0.006,
      "solar_transmittance": 0.45,
      "solar_reflectance": 0.36,
      "solar_reflectance_back": 0.36,
      "visible_transmittance": 0.71,
      "visible_reflectance": 0.21,
      "visible_reflectance_back": 0.21,
      "infrared_transmittance": 0.0,
      "emissivity": 0.84,
      "emissivity_back": 0.047,
      "conductivity": 1.0,
      "dirt_correction": 1.0,
      "solar_diffusing": false
    },
    {
      "identifier": "Generic Painted Metal",
      "display_name": null,
      "user_data": null,
      "type": "EnergyMaterial",
      "roughness": "Smooth",
      "thickness": 0.0015,
      "conductivity": 45.0,
      "density": 7690.0,
      "specific_heat": 410.0,
      "thermal_absorptance": 0.9,
      "solar_absorptance": 0.5,
      "visible_absorptance": 0.5
    },
    {
      "identifier": "Generic LW Concrete",
      "display_name": null,
      "user_data": null,
      "type": "EnergyMaterial",
      "roughness": "MediumRough",
      "thickness": 0.1,
      "conductivity": 0.53,
      "density": 1280.0,
      "specific_heat": 840.0,
      "thermal_absorptance": 0.9,
      "solar_absorptance": 0.8,
      "visible_absorptance": 0.8
    },
    {
      "identifier": "Generic 25mm Insulation",
      "display_name": null,
      "user_data": null,
      "type": "EnergyMaterial",
      "roughness": "MediumRough",
      "thickness": 0.025,
      "conductivity": 0.03,
      "density": 43.0,
      "specific_heat": 1210.0,
      "thermal_absorptance": 0.9,
      "solar_absorptance": 0.7,
      "visible_absorptance": 0.7
    },
    {
      "identifier": "Generic Clear Glass",
      "display_name": null,
      "user_data": null,
      "type": "EnergyWindowMaterialGlazing",
      "thickness": 0.006,
      "solar_transmittance": 0.77,
      "solar_reflectance": 0.07,
      "solar_reflectance_back": 0.07,
      "visible_transmittance": 0.88,
      "visible_reflectance": 0.08,
      "visible_reflectance_back": 0.08,
      "infrared_transmittance": 0.0,
      "emissivity": 0.84,
      "emissivity_back": 0.84,
      "conductivity": 1.0,
      "dirt_correction": 1.0,
      "solar_diffusing": false
    }
  ],
  "constructions": [
    {
      "identifier": "Generic Interior Door",
      "display_name": null,
      "user_data": null,
      "type": "OpaqueConstructionAbridged",
      "materials": [
        "Generic 25mm Wood"
      ]
    },
    {
      "identifier": "Generic Single Pane",
      "display_name": null,
      "user_data": null,
      "type": "WindowConstructionAbridged",
      "materials": [
        "Generic Clear Glass"
      ],
      "frame": null
    },
    {
      "identifier": "Generic Shade",
      "display_name": null,
      "user_data": null,
      "type": "ShadeConstruction",
      "solar_reflectance": 0.35,
      "visible_reflectance": 0.35,
      "is_specular": false
    },
    {
      "identifier": "Generic Context",
      "display_name": null,
      "user_data": null,
      "type": "ShadeConstruction",
      "solar_reflectance": 0.2,
      "visible_reflectance": 0.2,
      "is_specular": false
    },
    {
      "identifier": "Generic Interior Ceiling",
      "display_name": null,
      "user_data": null,
      "type": "OpaqueConstructionAbridged",
      "materials": [
        "Generic LW Concrete",
        "Generic Ceiling Air Gap",
        "Generic Acoustic Tile"
      ]
    },
    {
      "identifier": "Generic Interior Wall",
      "display_name": null,
      "user_data": null,
      "type": "OpaqueConstructionAbridged",
      "materials": [
        "Generic Gypsum Board",
        "Generic Wall Air Gap",
        "Generic Gypsum Board"
      ]
    },
    {
      "identifier": "Generic Exposed Floor",
      "display_name": null,
      "user_data": null,
      "type": "OpaqueConstructionAbridged",
      "materials": [
        "Generic Painted Metal",
        "Generic Ceiling Air Gap",
        "Generic 50mm Insulation",
        "Generic LW Concrete"
      ]
    },
    {
      "identifier": "Generic Interior Floor",
      "display_name": null,
      "user_data": null,
      "type": "OpaqueConstructionAbridged",
      "materials": [
        "Generic Acoustic Tile",
        "Generic Ceiling Air Gap",
        "Generic LW Concrete"
      ]
    },
    {
      "identifier": "Generic Ground Slab",
      "display_name": null,
      "user_data": null,
      "type": "OpaqueConstructionAbridged",
      "materials": [
        "Generic 50mm Insulation",
        "Generic HW Concrete"
      ]
    },
    {
      "identifier": "Generic Roof",
      "display_name": null,
      "user_data": null,
      "type": "OpaqueConstructionAbridged",
      "materials": [
        "Generic Roof Membrane",
        "Generic 50mm Insulation",
        "Generic LW Concrete",
        "Generic Ceiling Air Gap",
        "Generic Acoustic Tile"
      ]
    },
    {
      "identifier": "Generic Exterior Wall",
      "display_name": null,
      "user_data": null,
      "type": "OpaqueConstructionAbridged",
      "materials": [
        "Generic Brick",
        "Generic LW Concrete",
        "Generic 50mm Insulation",
        "Generic Wall Air Gap",
        "Generic Gypsum Board"
      ]
    },
    {
      "identifier": "Generic Underground Wall",
      "display_name": null,
      "user_data": null,
      "type": "OpaqueConstructionAbridged",
      "materials": [
        "Generic 50mm Insulation",
        "Generic HW Concrete",
        "Generic Wall Air Gap",
        "Generic Gypsum Board"
      ]
    },
    {
      "identifier": "Generic Air Boundary",
      "display_name": null,
      "user_data": null,
      "type": "AirBoundaryConstructionAbridged",
      "air_mixing_per_area": 0.1,
      "air_mixing_schedule": "Always On"
    },
    {
      "identifier": "Generic Underground Roof",
      "display_name": null,
      "user_data": null,
      "type": "OpaqueConstructionAbridged",
      "materials": [
        "Generic 50mm Insulation",
        "Generic HW Concrete",
        "Generic Ceiling Air Gap",
        "Generic Acoustic Tile"
      ]
    },
    {
      "identifier": "Generic Double Pane",
      "display_name": null,
      "user_data": null,
      "type": "WindowConstructionAbridged",
      "materials": [
        "Generic Low-e Glass",
        "Generic Window Air Gap",
        "Generic Clear Glass"
      ],
      "frame": null
    },
    {
      "identifier": "Generic Exterior Door",
      "display_name": null,
      "user_data": null,
      "type": "OpaqueConstructionAbridged",
      "materials": [
        "Generic Painted Metal",
        "Generic 25mm Insulation",
        "Generic Painted Metal"
      ]
    }
  ],
  "wall_set": {
    "interior_construction": "Generic Interior Wall",
    "exterior_construction": "Generic Exterior Wall",
    "ground_construction": "Generic Underground Wall",
    "type": "WallConstructionSetAbridged"
  },
  "floor_set": {
    "interior_construction": "Generic Interior Floor",
    "exterior_construction": "Generic Exposed Floor",
    "ground_construction": "Generic Ground Slab",
    "type": "FloorConstructionSetAbridged"
  },
  "roof_ceiling_set": {
    "interior_construction": "Generic Interior Ceiling",
    "exterior_construction": "Generic Roof",
    "ground_construction": "Generic Underground Roof",
    "type": "RoofCeilingConstructionSetAbridged"
  },
  "aperture_set": {
    "type": "ApertureConstructionSetAbridged",
    "interior_construction": "Generic Single Pane",
    "window_construction": "Generic Double Pane",
    "skylight_construction": "Generic Double Pane",
    "operable_construction": "Generic Double Pane"
  },
  "door_set": {
    "type": "DoorConstructionSetAbridged",
    "interior_construction": "Generic Interior Door",
    "exterior_construction": "Generic Exterior Door",
    "overhead_construction": "Generic Exterior Door",
    "exterior_glass_construction": "Generic Double Pane",
    "interior_glass_construction": "Generic Single Pane"
  },
  "shade_construction": "Generic Shade",
  "context_construction": "Generic Context",
  "air_boundary_construction": "Generic Air Boundary"
});
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ModelEnergyProperties, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.global_construction_set = obj.global_construction_set;
            this.construction_sets = obj.construction_sets;
            this.constructions = obj.constructions;
            this.materials = obj.materials;
            this.hvacs = obj.hvacs;
            this.shws = obj.shws;
            this.program_types = obj.program_types;
            this.schedules = obj.schedules;
            this.schedule_type_limits = obj.schedule_type_limits;
            this.ventilation_simulation_control = obj.ventilation_simulation_control;
            this.electric_load_center = obj.electric_load_center;
        }
    }


    static override fromJS(data: any): ModelEnergyProperties {
        data = typeof data === 'object' ? data : {};

        let result = new ModelEnergyProperties();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["global_construction_set"] = this.global_construction_set;
        data["construction_sets"] = this.construction_sets;
        data["constructions"] = this.constructions;
        data["materials"] = this.materials;
        data["hvacs"] = this.hvacs;
        data["shws"] = this.shws;
        data["program_types"] = this.program_types;
        data["schedules"] = this.schedules;
        data["schedule_type_limits"] = this.schedule_type_limits;
        data["ventilation_simulation_control"] = this.ventilation_simulation_control;
        data["electric_load_center"] = this.electric_load_center;
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

