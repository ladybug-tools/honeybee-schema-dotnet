﻿import { IsOptional, IsString, validate, ValidationError as TsValidationError } from 'class-validator';
import { _AllAirBase } from "./_AllAirBase";
import { _DOASBase } from "./_DOASBase";
import { _EquipmentBase } from "./_EquipmentBase";
import { _HeatCoolBase } from "./_HeatCoolBase";
import { _TemplateSystem } from "./_TemplateSystem";
import { AirBoundaryConstruction } from "./AirBoundaryConstruction";
import { AirBoundaryConstructionAbridged } from "./AirBoundaryConstructionAbridged";
import { Baseboard } from "./Baseboard";
import { ConstructionSet } from "./ConstructionSet";
import { ConstructionSetAbridged } from "./ConstructionSetAbridged";
import { DetailedHVAC } from "./DetailedHVAC";
import { ElectricEquipment } from "./ElectricEquipment";
import { ElectricEquipmentAbridged } from "./ElectricEquipmentAbridged";
import { EnergyBaseModel } from "./EnergyBaseModel";
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
import { GasEquipment } from "./GasEquipment";
import { GasEquipmentAbridged } from "./GasEquipmentAbridged";
import { GasUnitHeater } from "./GasUnitHeater";
import { IdealAirSystemAbridged } from "./IdealAirSystemAbridged";
import { Infiltration } from "./Infiltration";
import { InfiltrationAbridged } from "./InfiltrationAbridged";
import { InternalMassAbridged } from "./InternalMassAbridged";
import { Lighting } from "./Lighting";
import { LightingAbridged } from "./LightingAbridged";
import { OpaqueConstruction } from "./OpaqueConstruction";
import { OpaqueConstructionAbridged } from "./OpaqueConstructionAbridged";
import { People } from "./People";
import { PeopleAbridged } from "./PeopleAbridged";
import { ProcessAbridged } from "./ProcessAbridged";
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
import { ServiceHotWater } from "./ServiceHotWater";
import { ServiceHotWaterAbridged } from "./ServiceHotWaterAbridged";
import { Setpoint } from "./Setpoint";
import { SetpointAbridged } from "./SetpointAbridged";
import { ShadeConstruction } from "./ShadeConstruction";
import { SHWSystem } from "./SHWSystem";
import { VAV } from "./VAV";
import { Ventilation } from "./Ventilation";
import { VentilationAbridged } from "./VentilationAbridged";
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

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class IDdEnergyBaseModel extends EnergyBaseModel {
    @IsOptional()
    /** Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). */
    user_data?: Object;
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.type = "IDdEnergyBaseModel";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.user_data = _data["user_data"];
            this.type = _data["type"] !== undefined ? _data["type"] : "IDdEnergyBaseModel";
        }
    }


    static override fromJS(data: any): IDdEnergyBaseModel {
        data = typeof data === 'object' ? data : {};

        if (data["type"] === "EnergyMaterial") {
            let result = new EnergyMaterial();
            result.init(data);
            return result;
        }
        if (data["type"] === "EnergyMaterialNoMass") {
            let result = new EnergyMaterialNoMass();
            result.init(data);
            return result;
        }
        if (data["type"] === "EnergyWindowMaterialGlazing") {
            let result = new EnergyWindowMaterialGlazing();
            result.init(data);
            return result;
        }
        if (data["type"] === "EnergyWindowMaterialGas") {
            let result = new EnergyWindowMaterialGas();
            result.init(data);
            return result;
        }
        if (data["type"] === "OpaqueConstructionAbridged") {
            let result = new OpaqueConstructionAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "WindowConstructionAbridged") {
            let result = new WindowConstructionAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "ShadeConstruction") {
            let result = new ShadeConstruction();
            result.init(data);
            return result;
        }
        if (data["type"] === "AirBoundaryConstructionAbridged") {
            let result = new AirBoundaryConstructionAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "ConstructionSetAbridged") {
            let result = new ConstructionSetAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "EnergyMaterialVegetation") {
            let result = new EnergyMaterialVegetation();
            result.init(data);
            return result;
        }
        if (data["type"] === "OpaqueConstruction") {
            let result = new OpaqueConstruction();
            result.init(data);
            return result;
        }
        if (data["type"] === "EnergyWindowMaterialSimpleGlazSys") {
            let result = new EnergyWindowMaterialSimpleGlazSys();
            result.init(data);
            return result;
        }
        if (data["type"] === "EnergyWindowMaterialGasCustom") {
            let result = new EnergyWindowMaterialGasCustom();
            result.init(data);
            return result;
        }
        if (data["type"] === "EnergyWindowMaterialGasMixture") {
            let result = new EnergyWindowMaterialGasMixture();
            result.init(data);
            return result;
        }
        if (data["type"] === "EnergyWindowFrame") {
            let result = new EnergyWindowFrame();
            result.init(data);
            return result;
        }
        if (data["type"] === "WindowConstruction") {
            let result = new WindowConstruction();
            result.init(data);
            return result;
        }
        if (data["type"] === "EnergyWindowMaterialShade") {
            let result = new EnergyWindowMaterialShade();
            result.init(data);
            return result;
        }
        if (data["type"] === "EnergyWindowMaterialBlind") {
            let result = new EnergyWindowMaterialBlind();
            result.init(data);
            return result;
        }
        if (data["type"] === "ScheduleRuleset") {
            let result = new ScheduleRuleset();
            result.init(data);
            return result;
        }
        if (data["type"] === "ScheduleFixedInterval") {
            let result = new ScheduleFixedInterval();
            result.init(data);
            return result;
        }
        if (data["type"] === "WindowConstructionShade") {
            let result = new WindowConstructionShade();
            result.init(data);
            return result;
        }
        if (data["type"] === "WindowConstructionDynamic") {
            let result = new WindowConstructionDynamic();
            result.init(data);
            return result;
        }
        if (data["type"] === "AirBoundaryConstruction") {
            let result = new AirBoundaryConstruction();
            result.init(data);
            return result;
        }
        if (data["type"] === "ConstructionSet") {
            let result = new ConstructionSet();
            result.init(data);
            return result;
        }
        if (data["type"] === "WindowConstructionShadeAbridged") {
            let result = new WindowConstructionShadeAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "WindowConstructionDynamicAbridged") {
            let result = new WindowConstructionDynamicAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "IdealAirSystemAbridged") {
            let result = new IdealAirSystemAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "VAV") {
            let result = new VAV();
            result.init(data);
            return result;
        }
        if (data["type"] === "PVAV") {
            let result = new PVAV();
            result.init(data);
            return result;
        }
        if (data["type"] === "PSZ") {
            let result = new PSZ();
            result.init(data);
            return result;
        }
        if (data["type"] === "PTAC") {
            let result = new PTAC();
            result.init(data);
            return result;
        }
        if (data["type"] === "ForcedAirFurnace") {
            let result = new ForcedAirFurnace();
            result.init(data);
            return result;
        }
        if (data["type"] === "FCUwithDOASAbridged") {
            let result = new FCUwithDOASAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "WSHPwithDOASAbridged") {
            let result = new WSHPwithDOASAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "VRFwithDOASAbridged") {
            let result = new VRFwithDOASAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "RadiantwithDOASAbridged") {
            let result = new RadiantwithDOASAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "FCU") {
            let result = new FCU();
            result.init(data);
            return result;
        }
        if (data["type"] === "WSHP") {
            let result = new WSHP();
            result.init(data);
            return result;
        }
        if (data["type"] === "VRF") {
            let result = new VRF();
            result.init(data);
            return result;
        }
        if (data["type"] === "Baseboard") {
            let result = new Baseboard();
            result.init(data);
            return result;
        }
        if (data["type"] === "EvaporativeCooler") {
            let result = new EvaporativeCooler();
            result.init(data);
            return result;
        }
        if (data["type"] === "Residential") {
            let result = new Residential();
            result.init(data);
            return result;
        }
        if (data["type"] === "WindowAC") {
            let result = new WindowAC();
            result.init(data);
            return result;
        }
        if (data["type"] === "GasUnitHeater") {
            let result = new GasUnitHeater();
            result.init(data);
            return result;
        }
        if (data["type"] === "Radiant") {
            let result = new Radiant();
            result.init(data);
            return result;
        }
        if (data["type"] === "DetailedHVAC") {
            let result = new DetailedHVAC();
            result.init(data);
            return result;
        }
        if (data["type"] === "SHWSystem") {
            let result = new SHWSystem();
            result.init(data);
            return result;
        }
        if (data["type"] === "PeopleAbridged") {
            let result = new PeopleAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "LightingAbridged") {
            let result = new LightingAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "ElectricEquipmentAbridged") {
            let result = new ElectricEquipmentAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "_EquipmentBase") {
            let result = new _EquipmentBase();
            result.init(data);
            return result;
        }
        if (data["type"] === "GasEquipmentAbridged") {
            let result = new GasEquipmentAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "ServiceHotWaterAbridged") {
            let result = new ServiceHotWaterAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "InfiltrationAbridged") {
            let result = new InfiltrationAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "VentilationAbridged") {
            let result = new VentilationAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "SetpointAbridged") {
            let result = new SetpointAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "ProgramTypeAbridged") {
            let result = new ProgramTypeAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "People") {
            let result = new People();
            result.init(data);
            return result;
        }
        if (data["type"] === "Lighting") {
            let result = new Lighting();
            result.init(data);
            return result;
        }
        if (data["type"] === "ElectricEquipment") {
            let result = new ElectricEquipment();
            result.init(data);
            return result;
        }
        if (data["type"] === "GasEquipment") {
            let result = new GasEquipment();
            result.init(data);
            return result;
        }
        if (data["type"] === "ServiceHotWater") {
            let result = new ServiceHotWater();
            result.init(data);
            return result;
        }
        if (data["type"] === "Infiltration") {
            let result = new Infiltration();
            result.init(data);
            return result;
        }
        if (data["type"] === "Ventilation") {
            let result = new Ventilation();
            result.init(data);
            return result;
        }
        if (data["type"] === "Setpoint") {
            let result = new Setpoint();
            result.init(data);
            return result;
        }
        if (data["type"] === "ProgramType") {
            let result = new ProgramType();
            result.init(data);
            return result;
        }
        if (data["type"] === "ScheduleRulesetAbridged") {
            let result = new ScheduleRulesetAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "ScheduleFixedIntervalAbridged") {
            let result = new ScheduleFixedIntervalAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "InternalMassAbridged") {
            let result = new InternalMassAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "ProcessAbridged") {
            let result = new ProcessAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "_HeatCoolBase") {
            let result = new _HeatCoolBase();
            result.init(data);
            return result;
        }
        if (data["type"] === "_TemplateSystem") {
            let result = new _TemplateSystem();
            result.init(data);
            return result;
        }
        if (data["type"] === "_DOASBase") {
            let result = new _DOASBase();
            result.init(data);
            return result;
        }
        if (data["type"] === "_AllAirBase") {
            let result = new _AllAirBase();
            result.init(data);
            return result;
        }
        let result = new IDdEnergyBaseModel();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["user_data"] = this.user_data;
        data["type"] = this.type;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
