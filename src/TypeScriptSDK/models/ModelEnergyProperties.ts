import { IsString, IsOptional, Matches, IsInstance, ValidateNested, IsArray, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel.ts";
import { AirBoundaryConstruction } from "./AirBoundaryConstruction.ts";
import { AirBoundaryConstructionAbridged } from "./AirBoundaryConstructionAbridged.ts";
import { Baseboard } from "./Baseboard.ts";
import { ConstructionSet } from "./ConstructionSet.ts";
import { ConstructionSetAbridged } from "./ConstructionSetAbridged.ts";
import { DetailedHVAC } from "./DetailedHVAC.ts";
import { ElectricLoadCenter } from "./ElectricLoadCenter.ts";
import { EnergyMaterial } from "./EnergyMaterial.ts";
import { EnergyMaterialNoMass } from "./EnergyMaterialNoMass.ts";
import { EnergyMaterialVegetation } from "./EnergyMaterialVegetation.ts";
import { EnergyWindowFrame } from "./EnergyWindowFrame.ts";
import { EnergyWindowMaterialBlind } from "./EnergyWindowMaterialBlind.ts";
import { EnergyWindowMaterialGas } from "./EnergyWindowMaterialGas.ts";
import { EnergyWindowMaterialGasCustom } from "./EnergyWindowMaterialGasCustom.ts";
import { EnergyWindowMaterialGasMixture } from "./EnergyWindowMaterialGasMixture.ts";
import { EnergyWindowMaterialGlazing } from "./EnergyWindowMaterialGlazing.ts";
import { EnergyWindowMaterialShade } from "./EnergyWindowMaterialShade.ts";
import { EnergyWindowMaterialSimpleGlazSys } from "./EnergyWindowMaterialSimpleGlazSys.ts";
import { EvaporativeCooler } from "./EvaporativeCooler.ts";
import { FCU } from "./FCU.ts";
import { FCUwithDOASAbridged } from "./FCUwithDOASAbridged.ts";
import { ForcedAirFurnace } from "./ForcedAirFurnace.ts";
import { GasUnitHeater } from "./GasUnitHeater.ts";
import { GlobalConstructionSet } from "./GlobalConstructionSet.ts";
import { IdealAirSystemAbridged } from "./IdealAirSystemAbridged.ts";
import { OpaqueConstruction } from "./OpaqueConstruction.ts";
import { OpaqueConstructionAbridged } from "./OpaqueConstructionAbridged.ts";
import { ProgramType } from "./ProgramType.ts";
import { ProgramTypeAbridged } from "./ProgramTypeAbridged.ts";
import { PSZ } from "./PSZ.ts";
import { PTAC } from "./PTAC.ts";
import { PVAV } from "./PVAV.ts";
import { Radiant } from "./Radiant.ts";
import { RadiantwithDOASAbridged } from "./RadiantwithDOASAbridged.ts";
import { Residential } from "./Residential.ts";
import { ScheduleFixedInterval } from "./ScheduleFixedInterval.ts";
import { ScheduleFixedIntervalAbridged } from "./ScheduleFixedIntervalAbridged.ts";
import { ScheduleRuleset } from "./ScheduleRuleset.ts";
import { ScheduleRulesetAbridged } from "./ScheduleRulesetAbridged.ts";
import { ScheduleTypeLimit } from "./ScheduleTypeLimit.ts";
import { ShadeConstruction } from "./ShadeConstruction.ts";
import { SHWSystem } from "./SHWSystem.ts";
import { VAV } from "./VAV.ts";
import { VentilationSimulationControl } from "./VentilationSimulationControl.ts";
import { VRF } from "./VRF.ts";
import { VRFwithDOASAbridged } from "./VRFwithDOASAbridged.ts";
import { WindowAC } from "./WindowAC.ts";
import { WindowConstruction } from "./WindowConstruction.ts";
import { WindowConstructionAbridged } from "./WindowConstructionAbridged.ts";
import { WindowConstructionDynamic } from "./WindowConstructionDynamic.ts";
import { WindowConstructionDynamicAbridged } from "./WindowConstructionDynamicAbridged.ts";
import { WindowConstructionShade } from "./WindowConstructionShade.ts";
import { WindowConstructionShadeAbridged } from "./WindowConstructionShadeAbridged.ts";
import { WSHP } from "./WSHP.ts";
import { WSHPwithDOASAbridged } from "./WSHPwithDOASAbridged.ts";

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
    @Transform(({ value }) => value.map((item: any) => {
      if (item?.type === 'ConstructionSetAbridged') return ConstructionSetAbridged.fromJS(item);
      else if (item?.type === 'ConstructionSet') return ConstructionSet.fromJS(item);
      else return item;
    }))
    /** List of all unique ConstructionSets in the Model. */
    construction_sets?: (ConstructionSetAbridged | ConstructionSet) [];
	
    @IsArray()
    @IsOptional()
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
    constructions?: (OpaqueConstructionAbridged | WindowConstructionAbridged | WindowConstructionShadeAbridged | AirBoundaryConstructionAbridged | OpaqueConstruction | WindowConstruction | WindowConstructionShade | WindowConstructionDynamicAbridged | WindowConstructionDynamic | AirBoundaryConstruction | ShadeConstruction) [];
	
    @IsArray()
    @IsOptional()
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
    materials?: (EnergyMaterial | EnergyMaterialNoMass | EnergyMaterialVegetation | EnergyWindowMaterialGlazing | EnergyWindowMaterialSimpleGlazSys | EnergyWindowMaterialGas | EnergyWindowMaterialGasMixture | EnergyWindowMaterialGasCustom | EnergyWindowFrame | EnergyWindowMaterialBlind | EnergyWindowMaterialShade) [];
	
    @IsArray()
    @IsOptional()
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
    @Transform(({ value }) => value.map((item: any) => {
      if (item?.type === 'ProgramTypeAbridged') return ProgramTypeAbridged.fromJS(item);
      else if (item?.type === 'ProgramType') return ProgramType.fromJS(item);
      else return item;
    }))
    /** List of all unique ProgramTypes in the Model. */
    program_types?: (ProgramTypeAbridged | ProgramType) [];
	
    @IsArray()
    @IsOptional()
    @Transform(({ value }) => value.map((item: any) => {
      if (item?.type === 'ScheduleRulesetAbridged') return ScheduleRulesetAbridged.fromJS(item);
      else if (item?.type === 'ScheduleFixedIntervalAbridged') return ScheduleFixedIntervalAbridged.fromJS(item);
      else if (item?.type === 'ScheduleRuleset') return ScheduleRuleset.fromJS(item);
      else if (item?.type === 'ScheduleFixedInterval') return ScheduleFixedInterval.fromJS(item);
      else return item;
    }))
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

