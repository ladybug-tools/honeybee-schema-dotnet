import { IsString, IsOptional, validate, ValidationError } from 'class-validator';
import { Void } from "./Void";
import { Mirror } from "./Mirror";
import { ModifierBase } from "./ModifierBase";
import { IDdRadianceBaseModel } from "./IDdRadianceBaseModel";
import { Plastic } from "./Plastic";
import { Glass } from "./Glass";
import { BSDF } from "./BSDF";
import { Glow } from "./Glow";
import { Light } from "./Light";
import { Trans } from "./Trans";
import { Metal } from "./Metal";
import { ApertureModifierSet } from "./ApertureModifierSet";
import { Plane } from "./Plane";
import { Face3D } from "./Face3D";
import { Autocalculate } from "./Autocalculate";
import { Outdoors } from "./Outdoors";
import { Surface } from "./Surface";
import { PVProperties } from "./PVProperties";
import { EnergyBaseModel } from "./EnergyBaseModel";
import { ShadeEnergyPropertiesAbridged } from "./ShadeEnergyPropertiesAbridged";
import { StateGeometryAbridged } from "./StateGeometryAbridged";
import { RadianceShadeStateAbridged } from "./RadianceShadeStateAbridged";
import { ShadeRadiancePropertiesAbridged } from "./ShadeRadiancePropertiesAbridged";
import { _PropertiesBaseAbridged } from "./_PropertiesBaseAbridged";
import { ShadePropertiesAbridged } from "./ShadePropertiesAbridged";
import { Shade } from "./Shade";
import { IDdBaseModel } from "./IDdBaseModel";
import { VentilationOpening } from "./VentilationOpening";
import { DoorEnergyPropertiesAbridged } from "./DoorEnergyPropertiesAbridged";
import { RadianceSubFaceStateAbridged } from "./RadianceSubFaceStateAbridged";
import { DoorRadiancePropertiesAbridged } from "./DoorRadiancePropertiesAbridged";
import { DoorPropertiesAbridged } from "./DoorPropertiesAbridged";
import { Door } from "./Door";
import { DetailedHVAC } from "./DetailedHVAC";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { RadiantwithDOASAbridged } from "./RadiantwithDOASAbridged";
import { Color } from "./Color";
import { WallModifierSetAbridged } from "./WallModifierSetAbridged";
import { BaseModifierSetAbridged } from "./BaseModifierSetAbridged";
import { FloorModifierSetAbridged } from "./FloorModifierSetAbridged";
import { RoofCeilingModifierSetAbridged } from "./RoofCeilingModifierSetAbridged";
import { ApertureModifierSetAbridged } from "./ApertureModifierSetAbridged";
import { DoorModifierSetAbridged } from "./DoorModifierSetAbridged";
import { ShadeModifierSetAbridged } from "./ShadeModifierSetAbridged";
import { ModifierSetAbridged } from "./ModifierSetAbridged";
import { WindowAC } from "./WindowAC";
import { NoLimit } from "./NoLimit";
import { ScheduleTypeLimit } from "./ScheduleTypeLimit";
import { ApertureEnergyPropertiesAbridged } from "./ApertureEnergyPropertiesAbridged";
import { Autosize } from "./Autosize";
import { IdealAirSystemAbridged } from "./IdealAirSystemAbridged";
import { ShadeConstruction } from "./ShadeConstruction";
import { ScheduleDay } from "./ScheduleDay";
import { AFNCrack } from "./AFNCrack";
import { FaceEnergyPropertiesAbridged } from "./FaceEnergyPropertiesAbridged";
import { OtherSideTemperature } from "./OtherSideTemperature";
import { ScheduleRuleAbridged } from "./ScheduleRuleAbridged";
import { DatedBaseModel } from "./DatedBaseModel";
import { ScheduleRuleset } from "./ScheduleRuleset";
import { ScheduleFixedInterval } from "./ScheduleFixedInterval";
import { People } from "./People";
import { Lighting } from "./Lighting";
import { ElectricEquipment } from "./ElectricEquipment";
import { GasEquipment } from "./GasEquipment";
import { ServiceHotWater } from "./ServiceHotWater";
import { Infiltration } from "./Infiltration";
import { Ventilation } from "./Ventilation";
import { Setpoint } from "./Setpoint";
import { ProgramType } from "./ProgramType";
import { PeopleAbridged } from "./PeopleAbridged";
import { VAV } from "./VAV";
import { FaceRadiancePropertiesAbridged } from "./FaceRadiancePropertiesAbridged";
import { FacePropertiesAbridged } from "./FacePropertiesAbridged";
import { EnergyMaterial } from "./EnergyMaterial";
import { EnergyMaterialNoMass } from "./EnergyMaterialNoMass";
import { EnergyMaterialVegetation } from "./EnergyMaterialVegetation";
import { OpaqueConstruction } from "./OpaqueConstruction";
import { WallConstructionSet } from "./WallConstructionSet";
import { FloorConstructionSet } from "./FloorConstructionSet";
import { RoofCeilingConstructionSet } from "./RoofCeilingConstructionSet";
import { EnergyWindowMaterialSimpleGlazSys } from "./EnergyWindowMaterialSimpleGlazSys";
import { EnergyWindowMaterialGlazing } from "./EnergyWindowMaterialGlazing";
import { EnergyWindowMaterialGas } from "./EnergyWindowMaterialGas";
import { EnergyWindowMaterialGasCustom } from "./EnergyWindowMaterialGasCustom";
import { EnergyWindowMaterialGasMixture } from "./EnergyWindowMaterialGasMixture";
import { EnergyWindowFrame } from "./EnergyWindowFrame";
import { WindowConstruction } from "./WindowConstruction";
import { EnergyWindowMaterialShade } from "./EnergyWindowMaterialShade";
import { EnergyWindowMaterialBlind } from "./EnergyWindowMaterialBlind";
import { WindowConstructionShade } from "./WindowConstructionShade";
import { WindowConstructionDynamic } from "./WindowConstructionDynamic";
import { ApertureConstructionSet } from "./ApertureConstructionSet";
import { DoorConstructionSet } from "./DoorConstructionSet";
import { AirBoundaryConstruction } from "./AirBoundaryConstruction";
import { ConstructionSet } from "./ConstructionSet";
import { PVAV } from "./PVAV";
import { RoomDoe2Properties } from "./RoomDoe2Properties";
import { WallModifierSet } from "./WallModifierSet";
import { Mesh3D } from "./Mesh3D";
import { ShadeMeshEnergyPropertiesAbridged } from "./ShadeMeshEnergyPropertiesAbridged";
import { ShadeMeshRadiancePropertiesAbridged } from "./ShadeMeshRadiancePropertiesAbridged";
import { ShadeMeshPropertiesAbridged } from "./ShadeMeshPropertiesAbridged";
import { ShadeMesh } from "./ShadeMesh";
import { Radiant } from "./Radiant";
import { GasEquipmentAbridged } from "./GasEquipmentAbridged";
import { _EquipmentBase } from "./_EquipmentBase";
import { ForcedAirFurnace } from "./ForcedAirFurnace";
import { RoofCeilingModifierSet } from "./RoofCeilingModifierSet";
import { VentilationAbridged } from "./VentilationAbridged";
import { OpaqueConstructionAbridged } from "./OpaqueConstructionAbridged";
import { WindowConstructionAbridged } from "./WindowConstructionAbridged";
import { AirBoundaryConstructionAbridged } from "./AirBoundaryConstructionAbridged";
import { WallConstructionSetAbridged } from "./WallConstructionSetAbridged";
import { _FaceSubSetAbridged } from "./_FaceSubSetAbridged";
import { FloorConstructionSetAbridged } from "./FloorConstructionSetAbridged";
import { RoofCeilingConstructionSetAbridged } from "./RoofCeilingConstructionSetAbridged";
import { ApertureConstructionSetAbridged } from "./ApertureConstructionSetAbridged";
import { DoorConstructionSetAbridged } from "./DoorConstructionSetAbridged";
import { GlobalConstructionSet } from "./GlobalConstructionSet";
import { ConstructionSetAbridged } from "./ConstructionSetAbridged";
import { WindowConstructionShadeAbridged } from "./WindowConstructionShadeAbridged";
import { WindowConstructionDynamicAbridged } from "./WindowConstructionDynamicAbridged";
import { PSZ } from "./PSZ";
import { PTAC } from "./PTAC";
import { FCUwithDOASAbridged } from "./FCUwithDOASAbridged";
import { WSHPwithDOASAbridged } from "./WSHPwithDOASAbridged";
import { VRFwithDOASAbridged } from "./VRFwithDOASAbridged";
import { FCU } from "./FCU";
import { WSHP } from "./WSHP";
import { VRF } from "./VRF";
import { Baseboard } from "./Baseboard";
import { EvaporativeCooler } from "./EvaporativeCooler";
import { Residential } from "./Residential";
import { GasUnitHeater } from "./GasUnitHeater";
import { SHWSystem } from "./SHWSystem";
import { LightingAbridged } from "./LightingAbridged";
import { ElectricEquipmentAbridged } from "./ElectricEquipmentAbridged";
import { ServiceHotWaterAbridged } from "./ServiceHotWaterAbridged";
import { InfiltrationAbridged } from "./InfiltrationAbridged";
import { SetpointAbridged } from "./SetpointAbridged";
import { ProgramTypeAbridged } from "./ProgramTypeAbridged";
import { ScheduleRulesetAbridged } from "./ScheduleRulesetAbridged";
import { ScheduleFixedIntervalAbridged } from "./ScheduleFixedIntervalAbridged";
import { VentilationSimulationControl } from "./VentilationSimulationControl";
import { ElectricLoadCenter } from "./ElectricLoadCenter";
import { ModelEnergyProperties } from "./ModelEnergyProperties";
import { RoomRadiancePropertiesAbridged } from "./RoomRadiancePropertiesAbridged";
import { GlobalModifierSet } from "./GlobalModifierSet";
import { FloorModifierSet } from "./FloorModifierSet";
import { DoorModifierSet } from "./DoorModifierSet";
import { ShadeModifierSet } from "./ShadeModifierSet";
import { ModifierSet } from "./ModifierSet";
import { Sensor } from "./Sensor";
import { SensorGrid } from "./SensorGrid";
import { _RadianceAsset } from "./_RadianceAsset";
import { View } from "./View";
import { ModelRadianceProperties } from "./ModelRadianceProperties";
import { Ground } from "./Ground";
import { ApertureRadiancePropertiesAbridged } from "./ApertureRadiancePropertiesAbridged";
import { AperturePropertiesAbridged } from "./AperturePropertiesAbridged";
import { Aperture } from "./Aperture";
import { DaylightingControl } from "./DaylightingControl";
import { VentilationControlAbridged } from "./VentilationControlAbridged";
import { VentilationFan } from "./VentilationFan";
import { ModelDoe2Properties } from "./ModelDoe2Properties";
import { Adiabatic } from "./Adiabatic";
import { Face } from "./Face";
import { InternalMassAbridged } from "./InternalMassAbridged";
import { ProcessAbridged } from "./ProcessAbridged";
import { RoomEnergyPropertiesAbridged } from "./RoomEnergyPropertiesAbridged";
import { RoomPropertiesAbridged } from "./RoomPropertiesAbridged";
import { Room } from "./Room";
import { ModelProperties } from "./ModelProperties";
import { Model } from "./Model";
import { _DOASBase } from "./_DOASBase";
import { _TemplateSystem } from "./_TemplateSystem";
import { _HeatCoolBase } from "./_HeatCoolBase";
import { _AllAirBase } from "./_AllAirBase";
import { BaseModifierSet } from "./BaseModifierSet";
import { _FaceSubSet } from "./_FaceSubSet";
import { SimulationOutput } from "./SimulationOutput";
import { DryBulbCondition } from "./DryBulbCondition";
import { ASHRAEClearSky } from "./ASHRAEClearSky";
import { _SkyCondition } from "./_SkyCondition";
import { DaylightSavingTime } from "./DaylightSavingTime";
import { RunPeriod } from "./RunPeriod";
import { SimulationControl } from "./SimulationControl";
import { ShadowCalculation } from "./ShadowCalculation";
import { HumidityCondition } from "./HumidityCondition";
import { WindCondition } from "./WindCondition";
import { ASHRAETau } from "./ASHRAETau";
import { DesignDay } from "./DesignDay";
import { SizingParameter } from "./SizingParameter";
import { SimulationParameter } from "./SimulationParameter";
import { AddedObject } from "./AddedObject";
import { DeletedObject } from "./DeletedObject";
import { ChangedObject } from "./ChangedObject";
import { ComparisonReport } from "./ComparisonReport";
import { _DiffObjectBase } from "./_DiffObjectBase";
import { ChangedInstruction } from "./ChangedInstruction";
import { DeletedInstruction } from "./DeletedInstruction";
import { AddedInstruction } from "./AddedInstruction";
import { SyncInstructions } from "./SyncInstructions";
import { Location } from "./Location";
import { ProjectInfo } from "./ProjectInfo";

export abstract class _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    /** A base class to use when there is no baseclass available to fall on. */
    type?: string;
	

    constructor() {
        this.type = "InvalidType";
    }


    init(_data?: any) {
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "InvalidType";
        }
    }


    static fromJS(data: any): _OpenAPIGenBaseModel {
        data = typeof data === 'object' ? data : {};

        if (data["type"] === "Void") {
            let result = new Void();
            result.init(data);
            return result;
        }
        if (data["type"] === "Mirror") {
            let result = new Mirror();
            result.init(data);
            return result;
        }
        if (data["type"] === "ModifierBase") {
            let result = new ModifierBase();
            result.init(data);
            return result;
        }
        if (data["type"] === "IDdRadianceBaseModel") {
            let result = new IDdRadianceBaseModel();
            result.init(data);
            return result;
        }
        if (data["type"] === "Plastic") {
            let result = new Plastic();
            result.init(data);
            return result;
        }
        if (data["type"] === "Glass") {
            let result = new Glass();
            result.init(data);
            return result;
        }
        if (data["type"] === "BSDF") {
            let result = new BSDF();
            result.init(data);
            return result;
        }
        if (data["type"] === "Glow") {
            let result = new Glow();
            result.init(data);
            return result;
        }
        if (data["type"] === "Light") {
            let result = new Light();
            result.init(data);
            return result;
        }
        if (data["type"] === "Trans") {
            let result = new Trans();
            result.init(data);
            return result;
        }
        if (data["type"] === "Metal") {
            let result = new Metal();
            result.init(data);
            return result;
        }
        if (data["type"] === "ApertureModifierSet") {
            let result = new ApertureModifierSet();
            result.init(data);
            return result;
        }
        if (data["type"] === "Plane") {
            let result = new Plane();
            result.init(data);
            return result;
        }
        if (data["type"] === "Face3D") {
            let result = new Face3D();
            result.init(data);
            return result;
        }
        if (data["type"] === "Autocalculate") {
            let result = new Autocalculate();
            result.init(data);
            return result;
        }
        if (data["type"] === "Outdoors") {
            let result = new Outdoors();
            result.init(data);
            return result;
        }
        if (data["type"] === "Surface") {
            let result = new Surface();
            result.init(data);
            return result;
        }
        if (data["type"] === "PVProperties") {
            let result = new PVProperties();
            result.init(data);
            return result;
        }
        if (data["type"] === "EnergyBaseModel") {
            let result = new EnergyBaseModel();
            result.init(data);
            return result;
        }
        if (data["type"] === "ShadeEnergyPropertiesAbridged") {
            let result = new ShadeEnergyPropertiesAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "StateGeometryAbridged") {
            let result = new StateGeometryAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "RadianceShadeStateAbridged") {
            let result = new RadianceShadeStateAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "ShadeRadiancePropertiesAbridged") {
            let result = new ShadeRadiancePropertiesAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "_PropertiesBaseAbridged") {
            let result = new _PropertiesBaseAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "ShadePropertiesAbridged") {
            let result = new ShadePropertiesAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "Shade") {
            let result = new Shade();
            result.init(data);
            return result;
        }
        if (data["type"] === "IDdBaseModel") {
            let result = new IDdBaseModel();
            result.init(data);
            return result;
        }
        if (data["type"] === "VentilationOpening") {
            let result = new VentilationOpening();
            result.init(data);
            return result;
        }
        if (data["type"] === "DoorEnergyPropertiesAbridged") {
            let result = new DoorEnergyPropertiesAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "RadianceSubFaceStateAbridged") {
            let result = new RadianceSubFaceStateAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "DoorRadiancePropertiesAbridged") {
            let result = new DoorRadiancePropertiesAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "DoorPropertiesAbridged") {
            let result = new DoorPropertiesAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "Door") {
            let result = new Door();
            result.init(data);
            return result;
        }
        if (data["type"] === "DetailedHVAC") {
            let result = new DetailedHVAC();
            result.init(data);
            return result;
        }
        if (data["type"] === "IDdEnergyBaseModel") {
            let result = new IDdEnergyBaseModel();
            result.init(data);
            return result;
        }
        if (data["type"] === "RadiantwithDOASAbridged") {
            let result = new RadiantwithDOASAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "Color") {
            let result = new Color();
            result.init(data);
            return result;
        }
        if (data["type"] === "WallModifierSetAbridged") {
            let result = new WallModifierSetAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "BaseModifierSetAbridged") {
            let result = new BaseModifierSetAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "FloorModifierSetAbridged") {
            let result = new FloorModifierSetAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "RoofCeilingModifierSetAbridged") {
            let result = new RoofCeilingModifierSetAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "ApertureModifierSetAbridged") {
            let result = new ApertureModifierSetAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "DoorModifierSetAbridged") {
            let result = new DoorModifierSetAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "ShadeModifierSetAbridged") {
            let result = new ShadeModifierSetAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "ModifierSetAbridged") {
            let result = new ModifierSetAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "WindowAC") {
            let result = new WindowAC();
            result.init(data);
            return result;
        }
        if (data["type"] === "NoLimit") {
            let result = new NoLimit();
            result.init(data);
            return result;
        }
        if (data["type"] === "ScheduleTypeLimit") {
            let result = new ScheduleTypeLimit();
            result.init(data);
            return result;
        }
        if (data["type"] === "ApertureEnergyPropertiesAbridged") {
            let result = new ApertureEnergyPropertiesAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "Autosize") {
            let result = new Autosize();
            result.init(data);
            return result;
        }
        if (data["type"] === "IdealAirSystemAbridged") {
            let result = new IdealAirSystemAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "ShadeConstruction") {
            let result = new ShadeConstruction();
            result.init(data);
            return result;
        }
        if (data["type"] === "ScheduleDay") {
            let result = new ScheduleDay();
            result.init(data);
            return result;
        }
        if (data["type"] === "AFNCrack") {
            let result = new AFNCrack();
            result.init(data);
            return result;
        }
        if (data["type"] === "FaceEnergyPropertiesAbridged") {
            let result = new FaceEnergyPropertiesAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "OtherSideTemperature") {
            let result = new OtherSideTemperature();
            result.init(data);
            return result;
        }
        if (data["type"] === "ScheduleRuleAbridged") {
            let result = new ScheduleRuleAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "DatedBaseModel") {
            let result = new DatedBaseModel();
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
        if (data["type"] === "PeopleAbridged") {
            let result = new PeopleAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "VAV") {
            let result = new VAV();
            result.init(data);
            return result;
        }
        if (data["type"] === "FaceRadiancePropertiesAbridged") {
            let result = new FaceRadiancePropertiesAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "FacePropertiesAbridged") {
            let result = new FacePropertiesAbridged();
            result.init(data);
            return result;
        }
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
        if (data["type"] === "WallConstructionSet") {
            let result = new WallConstructionSet();
            result.init(data);
            return result;
        }
        if (data["type"] === "FloorConstructionSet") {
            let result = new FloorConstructionSet();
            result.init(data);
            return result;
        }
        if (data["type"] === "RoofCeilingConstructionSet") {
            let result = new RoofCeilingConstructionSet();
            result.init(data);
            return result;
        }
        if (data["type"] === "EnergyWindowMaterialSimpleGlazSys") {
            let result = new EnergyWindowMaterialSimpleGlazSys();
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
        if (data["type"] === "ApertureConstructionSet") {
            let result = new ApertureConstructionSet();
            result.init(data);
            return result;
        }
        if (data["type"] === "DoorConstructionSet") {
            let result = new DoorConstructionSet();
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
        if (data["type"] === "PVAV") {
            let result = new PVAV();
            result.init(data);
            return result;
        }
        if (data["type"] === "RoomDoe2Properties") {
            let result = new RoomDoe2Properties();
            result.init(data);
            return result;
        }
        if (data["type"] === "WallModifierSet") {
            let result = new WallModifierSet();
            result.init(data);
            return result;
        }
        if (data["type"] === "Mesh3D") {
            let result = new Mesh3D();
            result.init(data);
            return result;
        }
        if (data["type"] === "ShadeMeshEnergyPropertiesAbridged") {
            let result = new ShadeMeshEnergyPropertiesAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "ShadeMeshRadiancePropertiesAbridged") {
            let result = new ShadeMeshRadiancePropertiesAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "ShadeMeshPropertiesAbridged") {
            let result = new ShadeMeshPropertiesAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "ShadeMesh") {
            let result = new ShadeMesh();
            result.init(data);
            return result;
        }
        if (data["type"] === "Radiant") {
            let result = new Radiant();
            result.init(data);
            return result;
        }
        if (data["type"] === "GasEquipmentAbridged") {
            let result = new GasEquipmentAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "_EquipmentBase") {
            let result = new _EquipmentBase();
            result.init(data);
            return result;
        }
        if (data["type"] === "ForcedAirFurnace") {
            let result = new ForcedAirFurnace();
            result.init(data);
            return result;
        }
        if (data["type"] === "RoofCeilingModifierSet") {
            let result = new RoofCeilingModifierSet();
            result.init(data);
            return result;
        }
        if (data["type"] === "VentilationAbridged") {
            let result = new VentilationAbridged();
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
        if (data["type"] === "AirBoundaryConstructionAbridged") {
            let result = new AirBoundaryConstructionAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "WallConstructionSetAbridged") {
            let result = new WallConstructionSetAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "_FaceSubSetAbridged") {
            let result = new _FaceSubSetAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "FloorConstructionSetAbridged") {
            let result = new FloorConstructionSetAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "RoofCeilingConstructionSetAbridged") {
            let result = new RoofCeilingConstructionSetAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "ApertureConstructionSetAbridged") {
            let result = new ApertureConstructionSetAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "DoorConstructionSetAbridged") {
            let result = new DoorConstructionSetAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "GlobalConstructionSet") {
            let result = new GlobalConstructionSet();
            result.init(data);
            return result;
        }
        if (data["type"] === "ConstructionSetAbridged") {
            let result = new ConstructionSetAbridged();
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
        if (data["type"] === "GasUnitHeater") {
            let result = new GasUnitHeater();
            result.init(data);
            return result;
        }
        if (data["type"] === "SHWSystem") {
            let result = new SHWSystem();
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
        if (data["type"] === "VentilationSimulationControl") {
            let result = new VentilationSimulationControl();
            result.init(data);
            return result;
        }
        if (data["type"] === "ElectricLoadCenter") {
            let result = new ElectricLoadCenter();
            result.init(data);
            return result;
        }
        if (data["type"] === "ModelEnergyProperties") {
            let result = new ModelEnergyProperties();
            result.init(data);
            return result;
        }
        if (data["type"] === "RoomRadiancePropertiesAbridged") {
            let result = new RoomRadiancePropertiesAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "GlobalModifierSet") {
            let result = new GlobalModifierSet();
            result.init(data);
            return result;
        }
        if (data["type"] === "FloorModifierSet") {
            let result = new FloorModifierSet();
            result.init(data);
            return result;
        }
        if (data["type"] === "DoorModifierSet") {
            let result = new DoorModifierSet();
            result.init(data);
            return result;
        }
        if (data["type"] === "ShadeModifierSet") {
            let result = new ShadeModifierSet();
            result.init(data);
            return result;
        }
        if (data["type"] === "ModifierSet") {
            let result = new ModifierSet();
            result.init(data);
            return result;
        }
        if (data["type"] === "Sensor") {
            let result = new Sensor();
            result.init(data);
            return result;
        }
        if (data["type"] === "SensorGrid") {
            let result = new SensorGrid();
            result.init(data);
            return result;
        }
        if (data["type"] === "_RadianceAsset") {
            let result = new _RadianceAsset();
            result.init(data);
            return result;
        }
        if (data["type"] === "View") {
            let result = new View();
            result.init(data);
            return result;
        }
        if (data["type"] === "ModelRadianceProperties") {
            let result = new ModelRadianceProperties();
            result.init(data);
            return result;
        }
        if (data["type"] === "Ground") {
            let result = new Ground();
            result.init(data);
            return result;
        }
        if (data["type"] === "ApertureRadiancePropertiesAbridged") {
            let result = new ApertureRadiancePropertiesAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "AperturePropertiesAbridged") {
            let result = new AperturePropertiesAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "Aperture") {
            let result = new Aperture();
            result.init(data);
            return result;
        }
        if (data["type"] === "DaylightingControl") {
            let result = new DaylightingControl();
            result.init(data);
            return result;
        }
        if (data["type"] === "VentilationControlAbridged") {
            let result = new VentilationControlAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "VentilationFan") {
            let result = new VentilationFan();
            result.init(data);
            return result;
        }
        if (data["type"] === "ModelDoe2Properties") {
            let result = new ModelDoe2Properties();
            result.init(data);
            return result;
        }
        if (data["type"] === "Adiabatic") {
            let result = new Adiabatic();
            result.init(data);
            return result;
        }
        if (data["type"] === "Face") {
            let result = new Face();
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
        if (data["type"] === "RoomEnergyPropertiesAbridged") {
            let result = new RoomEnergyPropertiesAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "RoomPropertiesAbridged") {
            let result = new RoomPropertiesAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "Room") {
            let result = new Room();
            result.init(data);
            return result;
        }
        if (data["type"] === "ModelProperties") {
            let result = new ModelProperties();
            result.init(data);
            return result;
        }
        if (data["type"] === "Model") {
            let result = new Model();
            result.init(data);
            return result;
        }
        if (data["type"] === "_DOASBase") {
            let result = new _DOASBase();
            result.init(data);
            return result;
        }
        if (data["type"] === "_TemplateSystem") {
            let result = new _TemplateSystem();
            result.init(data);
            return result;
        }
        if (data["type"] === "_HeatCoolBase") {
            let result = new _HeatCoolBase();
            result.init(data);
            return result;
        }
        if (data["type"] === "_AllAirBase") {
            let result = new _AllAirBase();
            result.init(data);
            return result;
        }
        if (data["type"] === "BaseModifierSet") {
            let result = new BaseModifierSet();
            result.init(data);
            return result;
        }
        if (data["type"] === "_FaceSubSet") {
            let result = new _FaceSubSet();
            result.init(data);
            return result;
        }
        if (data["type"] === "SimulationOutput") {
            let result = new SimulationOutput();
            result.init(data);
            return result;
        }
        if (data["type"] === "DryBulbCondition") {
            let result = new DryBulbCondition();
            result.init(data);
            return result;
        }
        if (data["type"] === "ASHRAEClearSky") {
            let result = new ASHRAEClearSky();
            result.init(data);
            return result;
        }
        if (data["type"] === "_SkyCondition") {
            let result = new _SkyCondition();
            result.init(data);
            return result;
        }
        if (data["type"] === "DaylightSavingTime") {
            let result = new DaylightSavingTime();
            result.init(data);
            return result;
        }
        if (data["type"] === "RunPeriod") {
            let result = new RunPeriod();
            result.init(data);
            return result;
        }
        if (data["type"] === "SimulationControl") {
            let result = new SimulationControl();
            result.init(data);
            return result;
        }
        if (data["type"] === "ShadowCalculation") {
            let result = new ShadowCalculation();
            result.init(data);
            return result;
        }
        if (data["type"] === "HumidityCondition") {
            let result = new HumidityCondition();
            result.init(data);
            return result;
        }
        if (data["type"] === "WindCondition") {
            let result = new WindCondition();
            result.init(data);
            return result;
        }
        if (data["type"] === "ASHRAETau") {
            let result = new ASHRAETau();
            result.init(data);
            return result;
        }
        if (data["type"] === "DesignDay") {
            let result = new DesignDay();
            result.init(data);
            return result;
        }
        if (data["type"] === "SizingParameter") {
            let result = new SizingParameter();
            result.init(data);
            return result;
        }
        if (data["type"] === "SimulationParameter") {
            let result = new SimulationParameter();
            result.init(data);
            return result;
        }
        if (data["type"] === "AddedObject") {
            let result = new AddedObject();
            result.init(data);
            return result;
        }
        if (data["type"] === "DeletedObject") {
            let result = new DeletedObject();
            result.init(data);
            return result;
        }
        if (data["type"] === "ChangedObject") {
            let result = new ChangedObject();
            result.init(data);
            return result;
        }
        if (data["type"] === "ComparisonReport") {
            let result = new ComparisonReport();
            result.init(data);
            return result;
        }
        if (data["type"] === "_DiffObjectBase") {
            let result = new _DiffObjectBase();
            result.init(data);
            return result;
        }
        if (data["type"] === "ChangedInstruction") {
            let result = new ChangedInstruction();
            result.init(data);
            return result;
        }
        if (data["type"] === "DeletedInstruction") {
            let result = new DeletedInstruction();
            result.init(data);
            return result;
        }
        if (data["type"] === "AddedInstruction") {
            let result = new AddedInstruction();
            result.init(data);
            return result;
        }
        if (data["type"] === "SyncInstructions") {
            let result = new SyncInstructions();
            result.init(data);
            return result;
        }
        if (data["type"] === "Location") {
            let result = new Location();
            result.init(data);
            return result;
        }
        if (data["type"] === "ProjectInfo") {
            let result = new ProjectInfo();
            result.init(data);
            return result;
        }
        throw new Error("The abstract class '_OpenAPIGenBaseModel' cannot be instantiated.");
    }

	toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["type"] = this.type;
        return data;
    }

}
