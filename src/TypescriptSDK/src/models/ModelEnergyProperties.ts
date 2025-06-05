import { IsString, IsOptional, Matches, IsInstance, ValidateNested, IsArray, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
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
    @Expose({ name: "type" })
    /** type */
    type: string = "ModelEnergyProperties";
	
    @IsInstance(GlobalConstructionSet)
    @Type(() => GlobalConstructionSet)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "global_construction_set" })
    /** Global Energy construction set. */
    globalConstructionSet: GlobalConstructionSet = GlobalConstructionSet.fromJS({
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
	
    @IsArray()
    @IsOptional()
    @Expose({ name: "construction_sets" })
    @Transform(({ value }) => value.map((item: any) => {
      if (item?.type === 'ConstructionSetAbridged') return ConstructionSetAbridged.fromJS(item);
      else if (item?.type === 'ConstructionSet') return ConstructionSet.fromJS(item);
      else return item;
    }))
    /** List of all unique ConstructionSets in the Model. */
    constructionSets?: (ConstructionSetAbridged | ConstructionSet)[];
	
    @IsArray()
    @IsOptional()
    @Expose({ name: "constructions" })
    @Transform(({ value }) => value.map((item: any) => {
      if (item?.type === 'OpaqueConstructionAbridged') return OpaqueConstructionAbridged.fromJS(item);
      else if (item?.type === 'WindowConstructionAbridged') return WindowConstructionAbridged.fromJS(item);
      else if (item?.type === 'WindowConstructionShadeAbridged') return WindowConstructionShadeAbridged.fromJS(item);
      else if (item?.type === 'AirBoundaryConstructionAbridged') return AirBoundaryConstructionAbridged.fromJS(item);
      else if (item?.type === 'OpaqueConstruction') return OpaqueConstruction.fromJS(item);
      else if (item?.type === 'WindowConstruction') return WindowConstruction.fromJS(item);
      else if (item?.type === 'WindowConstructionShade') return WindowConstructionShade.fromJS(item);
      else if (item?.type === 'WindowConstructionDynamicAbridged') return WindowConstructionDynamicAbridged.fromJS(item);
      else if (item?.type === 'WindowConstructionDynamic') return WindowConstructionDynamic.fromJS(item);
      else if (item?.type === 'AirBoundaryConstruction') return AirBoundaryConstruction.fromJS(item);
      else if (item?.type === 'ShadeConstruction') return ShadeConstruction.fromJS(item);
      else return item;
    }))
    /** A list of all unique constructions in the model. This includes constructions across all Faces, Apertures, Doors, Shades, Room ConstructionSets, and the global_construction_set. */
    constructions?: (OpaqueConstructionAbridged | WindowConstructionAbridged | WindowConstructionShadeAbridged | AirBoundaryConstructionAbridged | OpaqueConstruction | WindowConstruction | WindowConstructionShade | WindowConstructionDynamicAbridged | WindowConstructionDynamic | AirBoundaryConstruction | ShadeConstruction)[];
	
    @IsArray()
    @IsOptional()
    @Expose({ name: "materials" })
    @Transform(({ value }) => value.map((item: any) => {
      if (item?.type === 'EnergyMaterial') return EnergyMaterial.fromJS(item);
      else if (item?.type === 'EnergyMaterialNoMass') return EnergyMaterialNoMass.fromJS(item);
      else if (item?.type === 'EnergyMaterialVegetation') return EnergyMaterialVegetation.fromJS(item);
      else if (item?.type === 'EnergyWindowMaterialGlazing') return EnergyWindowMaterialGlazing.fromJS(item);
      else if (item?.type === 'EnergyWindowMaterialSimpleGlazSys') return EnergyWindowMaterialSimpleGlazSys.fromJS(item);
      else if (item?.type === 'EnergyWindowMaterialGas') return EnergyWindowMaterialGas.fromJS(item);
      else if (item?.type === 'EnergyWindowMaterialGasMixture') return EnergyWindowMaterialGasMixture.fromJS(item);
      else if (item?.type === 'EnergyWindowMaterialGasCustom') return EnergyWindowMaterialGasCustom.fromJS(item);
      else if (item?.type === 'EnergyWindowFrame') return EnergyWindowFrame.fromJS(item);
      else if (item?.type === 'EnergyWindowMaterialBlind') return EnergyWindowMaterialBlind.fromJS(item);
      else if (item?.type === 'EnergyWindowMaterialShade') return EnergyWindowMaterialShade.fromJS(item);
      else return item;
    }))
    /** A list of all unique materials in the model. This includes materials needed to make the Model constructions. */
    materials?: (EnergyMaterial | EnergyMaterialNoMass | EnergyMaterialVegetation | EnergyWindowMaterialGlazing | EnergyWindowMaterialSimpleGlazSys | EnergyWindowMaterialGas | EnergyWindowMaterialGasMixture | EnergyWindowMaterialGasCustom | EnergyWindowFrame | EnergyWindowMaterialBlind | EnergyWindowMaterialShade)[];
	
    @IsArray()
    @IsOptional()
    @Expose({ name: "hvacs" })
    @Transform(({ value }) => value.map((item: any) => {
      if (item?.type === 'IdealAirSystemAbridged') return IdealAirSystemAbridged.fromJS(item);
      else if (item?.type === 'VAV') return VAV.fromJS(item);
      else if (item?.type === 'PVAV') return PVAV.fromJS(item);
      else if (item?.type === 'PSZ') return PSZ.fromJS(item);
      else if (item?.type === 'PTAC') return PTAC.fromJS(item);
      else if (item?.type === 'ForcedAirFurnace') return ForcedAirFurnace.fromJS(item);
      else if (item?.type === 'FCUwithDOASAbridged') return FCUwithDOASAbridged.fromJS(item);
      else if (item?.type === 'WSHPwithDOASAbridged') return WSHPwithDOASAbridged.fromJS(item);
      else if (item?.type === 'VRFwithDOASAbridged') return VRFwithDOASAbridged.fromJS(item);
      else if (item?.type === 'RadiantwithDOASAbridged') return RadiantwithDOASAbridged.fromJS(item);
      else if (item?.type === 'FCU') return FCU.fromJS(item);
      else if (item?.type === 'WSHP') return WSHP.fromJS(item);
      else if (item?.type === 'VRF') return VRF.fromJS(item);
      else if (item?.type === 'Baseboard') return Baseboard.fromJS(item);
      else if (item?.type === 'EvaporativeCooler') return EvaporativeCooler.fromJS(item);
      else if (item?.type === 'Residential') return Residential.fromJS(item);
      else if (item?.type === 'WindowAC') return WindowAC.fromJS(item);
      else if (item?.type === 'GasUnitHeater') return GasUnitHeater.fromJS(item);
      else if (item?.type === 'Radiant') return Radiant.fromJS(item);
      else if (item?.type === 'DetailedHVAC') return DetailedHVAC.fromJS(item);
      else return item;
    }))
    /** List of all unique HVAC systems in the Model. */
    hvacs?: (IdealAirSystemAbridged | VAV | PVAV | PSZ | PTAC | ForcedAirFurnace | FCUwithDOASAbridged | WSHPwithDOASAbridged | VRFwithDOASAbridged | RadiantwithDOASAbridged | FCU | WSHP | VRF | Baseboard | EvaporativeCooler | Residential | WindowAC | GasUnitHeater | Radiant | DetailedHVAC)[];
	
    @IsArray()
    @IsInstance(SHWSystem, { each: true })
    @Type(() => SHWSystem)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "shws" })
    /** List of all unique Service Hot Water (SHW) systems in the Model. */
    shws?: SHWSystem[];
	
    @IsArray()
    @IsOptional()
    @Expose({ name: "program_types" })
    @Transform(({ value }) => value.map((item: any) => {
      if (item?.type === 'ProgramTypeAbridged') return ProgramTypeAbridged.fromJS(item);
      else if (item?.type === 'ProgramType') return ProgramType.fromJS(item);
      else return item;
    }))
    /** List of all unique ProgramTypes in the Model. */
    programTypes?: (ProgramTypeAbridged | ProgramType)[];
	
    @IsArray()
    @IsOptional()
    @Expose({ name: "schedules" })
    @Transform(({ value }) => value.map((item: any) => {
      if (item?.type === 'ScheduleRulesetAbridged') return ScheduleRulesetAbridged.fromJS(item);
      else if (item?.type === 'ScheduleFixedIntervalAbridged') return ScheduleFixedIntervalAbridged.fromJS(item);
      else if (item?.type === 'ScheduleRuleset') return ScheduleRuleset.fromJS(item);
      else if (item?.type === 'ScheduleFixedInterval') return ScheduleFixedInterval.fromJS(item);
      else return item;
    }))
    /** A list of all unique schedules in the model. This includes schedules across all HVAC systems, ProgramTypes, Rooms, and Shades. */
    schedules?: (ScheduleRulesetAbridged | ScheduleFixedIntervalAbridged | ScheduleRuleset | ScheduleFixedInterval)[];
	
    @IsArray()
    @IsInstance(ScheduleTypeLimit, { each: true })
    @Type(() => ScheduleTypeLimit)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "schedule_type_limits" })
    /** A list of all unique ScheduleTypeLimits in the model. This all ScheduleTypeLimits needed to make the Model schedules. */
    scheduleTypeLimits?: ScheduleTypeLimit[];
	
    @IsInstance(VentilationSimulationControl)
    @Type(() => VentilationSimulationControl)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "ventilation_simulation_control" })
    /** An optional parameter to define the global parameters for a ventilation cooling. */
    ventilationSimulationControl?: VentilationSimulationControl;
	
    @IsInstance(ElectricLoadCenter)
    @Type(() => ElectricLoadCenter)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "electric_load_center" })
    /** An optional parameter object that defines the properties of the model electric loads center that manages on site electricity generation and conversion. */
    electricLoadCenter?: ElectricLoadCenter;
	

    constructor() {
        super();
        this.type = "ModelEnergyProperties";
        this.globalConstructionSet = GlobalConstructionSet.fromJS({
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
            const obj = plainToClass(ModelEnergyProperties, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.type = obj.type ?? "ModelEnergyProperties";
            this.globalConstructionSet = obj.globalConstructionSet ?? GlobalConstructionSet.fromJS({
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
            this.constructionSets = obj.constructionSets;
            this.constructions = obj.constructions;
            this.materials = obj.materials;
            this.hvacs = obj.hvacs;
            this.shws = obj.shws;
            this.programTypes = obj.programTypes;
            this.schedules = obj.schedules;
            this.scheduleTypeLimits = obj.scheduleTypeLimits;
            this.ventilationSimulationControl = obj.ventilationSimulationControl;
            this.electricLoadCenter = obj.electricLoadCenter;
        }
    }


    static override fromJS(data: any): ModelEnergyProperties {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ModelEnergyProperties();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "ModelEnergyProperties";
        data["global_construction_set"] = this.globalConstructionSet ?? GlobalConstructionSet.fromJS({
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
        data["construction_sets"] = this.constructionSets;
        data["constructions"] = this.constructions;
        data["materials"] = this.materials;
        data["hvacs"] = this.hvacs;
        data["shws"] = this.shws;
        data["program_types"] = this.programTypes;
        data["schedules"] = this.schedules;
        data["schedule_type_limits"] = this.scheduleTypeLimits;
        data["ventilation_simulation_control"] = this.ventilationSimulationControl;
        data["electric_load_center"] = this.electricLoadCenter;
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
