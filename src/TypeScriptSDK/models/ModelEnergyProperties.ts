import { IsString, IsOptional, IsInstance, ValidateNested, IsArray, validate, ValidationError } from 'class-validator';
import { GlobalConstructionSet } from "./GlobalConstructionSet";
import { ConstructionSetAbridged } from "./ConstructionSetAbridged";
import { ConstructionSet } from "./ConstructionSet";
import { OpaqueConstructionAbridged } from "./OpaqueConstructionAbridged";
import { WindowConstructionAbridged } from "./WindowConstructionAbridged";
import { WindowConstructionShadeAbridged } from "./WindowConstructionShadeAbridged";
import { AirBoundaryConstructionAbridged } from "./AirBoundaryConstructionAbridged";
import { OpaqueConstruction } from "./OpaqueConstruction";
import { WindowConstruction } from "./WindowConstruction";
import { WindowConstructionShade } from "./WindowConstructionShade";
import { WindowConstructionDynamicAbridged } from "./WindowConstructionDynamicAbridged";
import { WindowConstructionDynamic } from "./WindowConstructionDynamic";
import { AirBoundaryConstruction } from "./AirBoundaryConstruction";
import { ShadeConstruction } from "./ShadeConstruction";
import { EnergyMaterial } from "./EnergyMaterial";
import { EnergyMaterialNoMass } from "./EnergyMaterialNoMass";
import { EnergyMaterialVegetation } from "./EnergyMaterialVegetation";
import { EnergyWindowMaterialGlazing } from "./EnergyWindowMaterialGlazing";
import { EnergyWindowMaterialSimpleGlazSys } from "./EnergyWindowMaterialSimpleGlazSys";
import { EnergyWindowMaterialGas } from "./EnergyWindowMaterialGas";
import { EnergyWindowMaterialGasMixture } from "./EnergyWindowMaterialGasMixture";
import { EnergyWindowMaterialGasCustom } from "./EnergyWindowMaterialGasCustom";
import { EnergyWindowFrame } from "./EnergyWindowFrame";
import { EnergyWindowMaterialBlind } from "./EnergyWindowMaterialBlind";
import { EnergyWindowMaterialShade } from "./EnergyWindowMaterialShade";
import { IdealAirSystemAbridged } from "./IdealAirSystemAbridged";
import { VAV } from "./VAV";
import { PVAV } from "./PVAV";
import { PSZ } from "./PSZ";
import { PTAC } from "./PTAC";
import { ForcedAirFurnace } from "./ForcedAirFurnace";
import { FCUwithDOASAbridged } from "./FCUwithDOASAbridged";
import { WSHPwithDOASAbridged } from "./WSHPwithDOASAbridged";
import { VRFwithDOASAbridged } from "./VRFwithDOASAbridged";
import { RadiantwithDOASAbridged } from "./RadiantwithDOASAbridged";
import { FCU } from "./FCU";
import { WSHP } from "./WSHP";
import { VRF } from "./VRF";
import { Baseboard } from "./Baseboard";
import { EvaporativeCooler } from "./EvaporativeCooler";
import { Residential } from "./Residential";
import { WindowAC } from "./WindowAC";
import { GasUnitHeater } from "./GasUnitHeater";
import { Radiant } from "./Radiant";
import { DetailedHVAC } from "./DetailedHVAC";
import { SHWSystem } from "./SHWSystem";
import { ProgramTypeAbridged } from "./ProgramTypeAbridged";
import { ProgramType } from "./ProgramType";
import { ScheduleRulesetAbridged } from "./ScheduleRulesetAbridged";
import { ScheduleFixedIntervalAbridged } from "./ScheduleFixedIntervalAbridged";
import { ScheduleRuleset } from "./ScheduleRuleset";
import { ScheduleFixedInterval } from "./ScheduleFixedInterval";
import { ScheduleTypeLimit } from "./ScheduleTypeLimit";
import { VentilationSimulationControl } from "./VentilationSimulationControl";
import { ElectricLoadCenter } from "./ElectricLoadCenter";
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for all objects that are not extensible with additional keys.

This effectively includes all objects except for the Properties classes
that are assigned to geometry objects. */
export class ModelEnergyProperties extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsInstance(GlobalConstructionSet)
    @ValidateNested()
    @IsOptional()
    /** Global Energy construction set. */
    global_construction_set?: GlobalConstructionSet;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** List of all unique ConstructionSets in the Model. */
    construction_sets?: (ConstructionSetAbridged | ConstructionSet) [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of all unique constructions in the model. This includes constructions across all Faces, Apertures, Doors, Shades, Room ConstructionSets, and the global_construction_set. */
    constructions?: (OpaqueConstructionAbridged | WindowConstructionAbridged | WindowConstructionShadeAbridged | AirBoundaryConstructionAbridged | OpaqueConstruction | WindowConstruction | WindowConstructionShade | WindowConstructionDynamicAbridged | WindowConstructionDynamic | AirBoundaryConstruction | ShadeConstruction) [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of all unique materials in the model. This includes materials needed to make the Model constructions. */
    materials?: (EnergyMaterial | EnergyMaterialNoMass | EnergyMaterialVegetation | EnergyWindowMaterialGlazing | EnergyWindowMaterialSimpleGlazSys | EnergyWindowMaterialGas | EnergyWindowMaterialGasMixture | EnergyWindowMaterialGasCustom | EnergyWindowFrame | EnergyWindowMaterialBlind | EnergyWindowMaterialShade) [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** List of all unique HVAC systems in the Model. */
    hvacs?: (IdealAirSystemAbridged | VAV | PVAV | PSZ | PTAC | ForcedAirFurnace | FCUwithDOASAbridged | WSHPwithDOASAbridged | VRFwithDOASAbridged | RadiantwithDOASAbridged | FCU | WSHP | VRF | Baseboard | EvaporativeCooler | Residential | WindowAC | GasUnitHeater | Radiant | DetailedHVAC) [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** List of all unique Service Hot Water (SHW) systems in the Model. */
    shws?: SHWSystem [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** List of all unique ProgramTypes in the Model. */
    program_types?: (ProgramTypeAbridged | ProgramType) [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of all unique schedules in the model. This includes schedules across all HVAC systems, ProgramTypes, Rooms, and Shades. */
    schedules?: (ScheduleRulesetAbridged | ScheduleFixedIntervalAbridged | ScheduleRuleset | ScheduleFixedInterval) [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of all unique ScheduleTypeLimits in the model. This all ScheduleTypeLimits needed to make the Model schedules. */
    schedule_type_limits?: ScheduleTypeLimit [];
	
    @IsInstance(VentilationSimulationControl)
    @ValidateNested()
    @IsOptional()
    /** An optional parameter to define the global parameters for a ventilation cooling. */
    ventilation_simulation_control?: VentilationSimulationControl;
	
    @IsInstance(ElectricLoadCenter)
    @ValidateNested()
    @IsOptional()
    /** An optional parameter object that defines the properties of the model electric loads center that manages on site electricity generation and conversion. */
    electric_load_center?: ElectricLoadCenter;
	

    constructor() {
        super();
        this.type = "ModelEnergyProperties";
        this.global_construction_set = new GlobalConstructionSet();
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "ModelEnergyProperties";
            this.global_construction_set = _data["global_construction_set"] !== undefined ? _data["global_construction_set"] : new GlobalConstructionSet();
            this.construction_sets = _data["construction_sets"];
            this.constructions = _data["constructions"];
            this.materials = _data["materials"];
            this.hvacs = _data["hvacs"];
            this.shws = _data["shws"];
            this.program_types = _data["program_types"];
            this.schedules = _data["schedules"];
            this.schedule_type_limits = _data["schedule_type_limits"];
            this.ventilation_simulation_control = _data["ventilation_simulation_control"];
            this.electric_load_center = _data["electric_load_center"];
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
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

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
