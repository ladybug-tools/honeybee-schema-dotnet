[![Build](https://github.com/ladybug-tools/honeybee-schema-dotnet/workflows/CD/badge.svg)](https://github.com/ladybug-tools/honeybee-schema-dotnet/actions) [![NuGet Version and Downloads count](https://buildstats.info/nuget/HoneybeeSchema?dWidth=50)](https://www.nuget.org/packages/HoneybeeSchema)
# HoneybeeSchema - the C# library for the Honeybee Model Schema

This is the documentation for Honeybee model schema.

This C# SDK is automatically generated by the [OpenAPI Generator](https://openapi-generator.tech) project:

- API version: 1.38.1
- SDK version: 1.38.1
- Build package: org.openapitools.codegen.languages.CSharpClientCodegen
    For more information, please visit [https://github.com/ladybug-tools/honeybee-schema](https://github.com/ladybug-tools/honeybee-schema)

## Frameworks supported


- .NET 4.5 or later

## Dependencies


- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 7.0.0 or later

The DLLs included in the package may not be the latest version. We recommend using [NuGet](https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:

```
Install-Package Newtonsoft.Json
```


## Installation

Run the following command to generate the DLL

- [Mac/Linux] `/bin/sh build.sh`
- [Windows] `build.bat`

Then include the DLL (under the `bin` folder) in the C# project, and use the namespaces:

```csharp
using HoneybeeSchema;

```


## Packaging

A `.nuspec` is included with the project. You can follow the Nuget quickstart to [create](https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package#create-the-package) and [publish](https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package#publish-the-package) packages.

This `.nuspec` uses placeholders from the `.csproj`, so build the `.csproj` directly:

```
nuget pack -Build -OutputDirectory out HoneybeeSchema.csproj
```

Then, publish to a [local feed](https://docs.microsoft.com/en-us/nuget/hosting-packages/local-feeds) or [other host](https://docs.microsoft.com/en-us/nuget/hosting-packages/overview) and consume the new package via Nuget as usual.


## Getting Started

```csharp
using System.Collections.Generic;
using System.Diagnostics;
using HoneybeeSchema;

namespace Example
{
    public class Example
    {
        public static void Main()
        {

        }
    }
}
```

## Documentation for API Endpoints

All URIs are relative to *http://localhost*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------


## Documentation for Models

 - [Model.AFNCrack](docs/AFNCrack.md)
 - [Model.Adiabatic](docs/Adiabatic.md)
 - [Model.AirBoundaryConstruction](docs/AirBoundaryConstruction.md)
 - [Model.AirBoundaryConstructionAbridged](docs/AirBoundaryConstructionAbridged.md)
 - [Model.AirBoundaryConstructionAbridgedAllOf](docs/AirBoundaryConstructionAbridgedAllOf.md)
 - [Model.AirBoundaryConstructionAllOf](docs/AirBoundaryConstructionAllOf.md)
 - [Model.AllAirBase](docs/AllAirBase.md)
 - [Model.AllAirBaseAllOf](docs/AllAirBaseAllOf.md)
 - [Model.AllAirEconomizerType](docs/AllAirEconomizerType.md)
 - [Model.Aperture](docs/Aperture.md)
 - [Model.ApertureAllOf](docs/ApertureAllOf.md)
 - [Model.ApertureConstructionSet](docs/ApertureConstructionSet.md)
 - [Model.ApertureConstructionSetAbridged](docs/ApertureConstructionSetAbridged.md)
 - [Model.ApertureEnergyPropertiesAbridged](docs/ApertureEnergyPropertiesAbridged.md)
 - [Model.ApertureModifierSet](docs/ApertureModifierSet.md)
 - [Model.ApertureModifierSetAbridged](docs/ApertureModifierSetAbridged.md)
 - [Model.AperturePropertiesAbridged](docs/AperturePropertiesAbridged.md)
 - [Model.ApertureRadiancePropertiesAbridged](docs/ApertureRadiancePropertiesAbridged.md)
 - [Model.ApertureRadiancePropertiesAbridgedAllOf](docs/ApertureRadiancePropertiesAbridgedAllOf.md)
 - [Model.Autocalculate](docs/Autocalculate.md)
 - [Model.Autosize](docs/Autosize.md)
 - [Model.BSDF](docs/BSDF.md)
 - [Model.BSDFAllOf](docs/BSDFAllOf.md)
 - [Model.BaseModifierSet](docs/BaseModifierSet.md)
 - [Model.BaseModifierSetAbridged](docs/BaseModifierSetAbridged.md)
 - [Model.Baseboard](docs/Baseboard.md)
 - [Model.BaseboardAllOf](docs/BaseboardAllOf.md)
 - [Model.BaseboardEquipmentType](docs/BaseboardEquipmentType.md)
 - [Model.BuildingType](docs/BuildingType.md)
 - [Model.Color](docs/Color.md)
 - [Model.ConstructionSet](docs/ConstructionSet.md)
 - [Model.ConstructionSetAbridged](docs/ConstructionSetAbridged.md)
 - [Model.ConstructionSetAbridgedAllOf](docs/ConstructionSetAbridgedAllOf.md)
 - [Model.ConstructionSetAllOf](docs/ConstructionSetAllOf.md)
 - [Model.ControlType](docs/ControlType.md)
 - [Model.DOASBase](docs/DOASBase.md)
 - [Model.DOASBaseAllOf](docs/DOASBaseAllOf.md)
 - [Model.DatedBaseModel](docs/DatedBaseModel.md)
 - [Model.Door](docs/Door.md)
 - [Model.DoorAllOf](docs/DoorAllOf.md)
 - [Model.DoorConstructionSet](docs/DoorConstructionSet.md)
 - [Model.DoorConstructionSetAbridged](docs/DoorConstructionSetAbridged.md)
 - [Model.DoorEnergyPropertiesAbridged](docs/DoorEnergyPropertiesAbridged.md)
 - [Model.DoorModifierSet](docs/DoorModifierSet.md)
 - [Model.DoorModifierSetAbridged](docs/DoorModifierSetAbridged.md)
 - [Model.DoorModifierSetAbridgedAllOf](docs/DoorModifierSetAbridgedAllOf.md)
 - [Model.DoorPropertiesAbridged](docs/DoorPropertiesAbridged.md)
 - [Model.DoorRadiancePropertiesAbridged](docs/DoorRadiancePropertiesAbridged.md)
 - [Model.DoorRadiancePropertiesAbridgedAllOf](docs/DoorRadiancePropertiesAbridgedAllOf.md)
 - [Model.EconomizerType](docs/EconomizerType.md)
 - [Model.ElectricEquipment](docs/ElectricEquipment.md)
 - [Model.ElectricEquipmentAbridged](docs/ElectricEquipmentAbridged.md)
 - [Model.ElectricEquipmentAbridgedAllOf](docs/ElectricEquipmentAbridgedAllOf.md)
 - [Model.ElectricEquipmentAllOf](docs/ElectricEquipmentAllOf.md)
 - [Model.EnergyMaterial](docs/EnergyMaterial.md)
 - [Model.EnergyMaterialAllOf](docs/EnergyMaterialAllOf.md)
 - [Model.EnergyMaterialNoMass](docs/EnergyMaterialNoMass.md)
 - [Model.EnergyMaterialNoMassAllOf](docs/EnergyMaterialNoMassAllOf.md)
 - [Model.EnergyWindowMaterialBlind](docs/EnergyWindowMaterialBlind.md)
 - [Model.EnergyWindowMaterialBlindAllOf](docs/EnergyWindowMaterialBlindAllOf.md)
 - [Model.EnergyWindowMaterialGas](docs/EnergyWindowMaterialGas.md)
 - [Model.EnergyWindowMaterialGasAllOf](docs/EnergyWindowMaterialGasAllOf.md)
 - [Model.EnergyWindowMaterialGasCustom](docs/EnergyWindowMaterialGasCustom.md)
 - [Model.EnergyWindowMaterialGasCustomAllOf](docs/EnergyWindowMaterialGasCustomAllOf.md)
 - [Model.EnergyWindowMaterialGasMixture](docs/EnergyWindowMaterialGasMixture.md)
 - [Model.EnergyWindowMaterialGasMixtureAllOf](docs/EnergyWindowMaterialGasMixtureAllOf.md)
 - [Model.EnergyWindowMaterialGlazing](docs/EnergyWindowMaterialGlazing.md)
 - [Model.EnergyWindowMaterialGlazingAllOf](docs/EnergyWindowMaterialGlazingAllOf.md)
 - [Model.EnergyWindowMaterialShade](docs/EnergyWindowMaterialShade.md)
 - [Model.EnergyWindowMaterialShadeAllOf](docs/EnergyWindowMaterialShadeAllOf.md)
 - [Model.EnergyWindowMaterialSimpleGlazSys](docs/EnergyWindowMaterialSimpleGlazSys.md)
 - [Model.EnergyWindowMaterialSimpleGlazSysAllOf](docs/EnergyWindowMaterialSimpleGlazSysAllOf.md)
 - [Model.EquipmentBase](docs/EquipmentBase.md)
 - [Model.EquipmentBaseAllOf](docs/EquipmentBaseAllOf.md)
 - [Model.EvaporativeCooler](docs/EvaporativeCooler.md)
 - [Model.EvaporativeCoolerAllOf](docs/EvaporativeCoolerAllOf.md)
 - [Model.EvaporativeCoolerEquipmentType](docs/EvaporativeCoolerEquipmentType.md)
 - [Model.FCU](docs/FCU.md)
 - [Model.FCUAllOf](docs/FCUAllOf.md)
 - [Model.FCUEquipmentType](docs/FCUEquipmentType.md)
 - [Model.FCUwithDOAS](docs/FCUwithDOAS.md)
 - [Model.FCUwithDOASAllOf](docs/FCUwithDOASAllOf.md)
 - [Model.FCUwithDOASEquipmentType](docs/FCUwithDOASEquipmentType.md)
 - [Model.Face](docs/Face.md)
 - [Model.Face3D](docs/Face3D.md)
 - [Model.FaceAllOf](docs/FaceAllOf.md)
 - [Model.FaceEnergyPropertiesAbridged](docs/FaceEnergyPropertiesAbridged.md)
 - [Model.FacePropertiesAbridged](docs/FacePropertiesAbridged.md)
 - [Model.FaceRadiancePropertiesAbridged](docs/FaceRadiancePropertiesAbridged.md)
 - [Model.FaceRadiancePropertiesAbridgedAllOf](docs/FaceRadiancePropertiesAbridgedAllOf.md)
 - [Model.FaceSubSet](docs/FaceSubSet.md)
 - [Model.FaceSubSetAbridged](docs/FaceSubSetAbridged.md)
 - [Model.FaceType](docs/FaceType.md)
 - [Model.FloorConstructionSet](docs/FloorConstructionSet.md)
 - [Model.FloorConstructionSetAbridged](docs/FloorConstructionSetAbridged.md)
 - [Model.FloorConstructionSetAbridgedAllOf](docs/FloorConstructionSetAbridgedAllOf.md)
 - [Model.FloorModifierSet](docs/FloorModifierSet.md)
 - [Model.FloorModifierSetAbridged](docs/FloorModifierSetAbridged.md)
 - [Model.FloorModifierSetAbridgedAllOf](docs/FloorModifierSetAbridgedAllOf.md)
 - [Model.ForcedAirFurnace](docs/ForcedAirFurnace.md)
 - [Model.ForcedAirFurnaceAllOf](docs/ForcedAirFurnaceAllOf.md)
 - [Model.FurnaceEquipmentType](docs/FurnaceEquipmentType.md)
 - [Model.GasEquipment](docs/GasEquipment.md)
 - [Model.GasEquipmentAbridged](docs/GasEquipmentAbridged.md)
 - [Model.GasEquipmentAbridgedAllOf](docs/GasEquipmentAbridgedAllOf.md)
 - [Model.GasEquipmentAllOf](docs/GasEquipmentAllOf.md)
 - [Model.GasType](docs/GasType.md)
 - [Model.GasUnitHeater](docs/GasUnitHeater.md)
 - [Model.GasUnitHeaterAllOf](docs/GasUnitHeaterAllOf.md)
 - [Model.GasUnitHeaterEquipmentType](docs/GasUnitHeaterEquipmentType.md)
 - [Model.Glass](docs/Glass.md)
 - [Model.GlassAllOf](docs/GlassAllOf.md)
 - [Model.Glow](docs/Glow.md)
 - [Model.GlowAllOf](docs/GlowAllOf.md)
 - [Model.Ground](docs/Ground.md)
 - [Model.HeatCoolBase](docs/HeatCoolBase.md)
 - [Model.HeatCoolBaseAllOf](docs/HeatCoolBaseAllOf.md)
 - [Model.IDdBaseModel](docs/IDdBaseModel.md)
 - [Model.IDdEnergyBaseModel](docs/IDdEnergyBaseModel.md)
 - [Model.IDdRadianceBaseModel](docs/IDdRadianceBaseModel.md)
 - [Model.IdealAirSystemAbridged](docs/IdealAirSystemAbridged.md)
 - [Model.IdealAirSystemAbridgedAllOf](docs/IdealAirSystemAbridgedAllOf.md)
 - [Model.Infiltration](docs/Infiltration.md)
 - [Model.InfiltrationAbridged](docs/InfiltrationAbridged.md)
 - [Model.InfiltrationAbridgedAllOf](docs/InfiltrationAbridgedAllOf.md)
 - [Model.InfiltrationAllOf](docs/InfiltrationAllOf.md)
 - [Model.Light](docs/Light.md)
 - [Model.LightAllOf](docs/LightAllOf.md)
 - [Model.Lighting](docs/Lighting.md)
 - [Model.LightingAbridged](docs/LightingAbridged.md)
 - [Model.LightingAbridgedAllOf](docs/LightingAbridgedAllOf.md)
 - [Model.LightingAllOf](docs/LightingAllOf.md)
 - [Model.Mesh3D](docs/Mesh3D.md)
 - [Model.Metal](docs/Metal.md)
 - [Model.MetalAllOf](docs/MetalAllOf.md)
 - [Model.Mirror](docs/Mirror.md)
 - [Model.MirrorAllOf](docs/MirrorAllOf.md)
 - [Model.Model](docs/Model.md)
 - [Model.ModelAllOf](docs/ModelAllOf.md)
 - [Model.ModelEnergyProperties](docs/ModelEnergyProperties.md)
 - [Model.ModelProperties](docs/ModelProperties.md)
 - [Model.ModelRadianceProperties](docs/ModelRadianceProperties.md)
 - [Model.ModifierBase](docs/ModifierBase.md)
 - [Model.ModifierBaseAllOf](docs/ModifierBaseAllOf.md)
 - [Model.ModifierSet](docs/ModifierSet.md)
 - [Model.ModifierSetAbridged](docs/ModifierSetAbridged.md)
 - [Model.ModifierSetAbridgedAllOf](docs/ModifierSetAbridgedAllOf.md)
 - [Model.ModifierSetAllOf](docs/ModifierSetAllOf.md)
 - [Model.NoLimit](docs/NoLimit.md)
 - [Model.OpaqueConstruction](docs/OpaqueConstruction.md)
 - [Model.OpaqueConstructionAbridged](docs/OpaqueConstructionAbridged.md)
 - [Model.OpaqueConstructionAbridgedAllOf](docs/OpaqueConstructionAbridgedAllOf.md)
 - [Model.OpaqueConstructionAllOf](docs/OpaqueConstructionAllOf.md)
 - [Model.Outdoors](docs/Outdoors.md)
 - [Model.PSZ](docs/PSZ.md)
 - [Model.PSZAllOf](docs/PSZAllOf.md)
 - [Model.PSZEquipmentType](docs/PSZEquipmentType.md)
 - [Model.PTAC](docs/PTAC.md)
 - [Model.PTACAllOf](docs/PTACAllOf.md)
 - [Model.PTACEquipmentType](docs/PTACEquipmentType.md)
 - [Model.PVAV](docs/PVAV.md)
 - [Model.PVAVAllOf](docs/PVAVAllOf.md)
 - [Model.PVAVEquipmentType](docs/PVAVEquipmentType.md)
 - [Model.People](docs/People.md)
 - [Model.PeopleAbridged](docs/PeopleAbridged.md)
 - [Model.PeopleAbridgedAllOf](docs/PeopleAbridgedAllOf.md)
 - [Model.PeopleAllOf](docs/PeopleAllOf.md)
 - [Model.Plane](docs/Plane.md)
 - [Model.Plastic](docs/Plastic.md)
 - [Model.PlasticAllOf](docs/PlasticAllOf.md)
 - [Model.ProgramType](docs/ProgramType.md)
 - [Model.ProgramTypeAbridged](docs/ProgramTypeAbridged.md)
 - [Model.ProgramTypeAbridgedAllOf](docs/ProgramTypeAbridgedAllOf.md)
 - [Model.ProgramTypeAllOf](docs/ProgramTypeAllOf.md)
 - [Model.PropertiesBaseAbridged](docs/PropertiesBaseAbridged.md)
 - [Model.RadianceAsset](docs/RadianceAsset.md)
 - [Model.RadianceAssetAllOf](docs/RadianceAssetAllOf.md)
 - [Model.RadianceShadeStateAbridged](docs/RadianceShadeStateAbridged.md)
 - [Model.RadianceSubFaceStateAbridged](docs/RadianceSubFaceStateAbridged.md)
 - [Model.RadianceSubFaceStateAbridgedAllOf](docs/RadianceSubFaceStateAbridgedAllOf.md)
 - [Model.Residential](docs/Residential.md)
 - [Model.ResidentialAllOf](docs/ResidentialAllOf.md)
 - [Model.ResidentialEquipmentType](docs/ResidentialEquipmentType.md)
 - [Model.RoofCeilingConstructionSet](docs/RoofCeilingConstructionSet.md)
 - [Model.RoofCeilingConstructionSetAbridged](docs/RoofCeilingConstructionSetAbridged.md)
 - [Model.RoofCeilingConstructionSetAbridgedAllOf](docs/RoofCeilingConstructionSetAbridgedAllOf.md)
 - [Model.RoofCeilingModifierSet](docs/RoofCeilingModifierSet.md)
 - [Model.RoofCeilingModifierSetAbridged](docs/RoofCeilingModifierSetAbridged.md)
 - [Model.RoofCeilingModifierSetAbridgedAllOf](docs/RoofCeilingModifierSetAbridgedAllOf.md)
 - [Model.Room](docs/Room.md)
 - [Model.RoomAllOf](docs/RoomAllOf.md)
 - [Model.RoomEnergyPropertiesAbridged](docs/RoomEnergyPropertiesAbridged.md)
 - [Model.RoomPropertiesAbridged](docs/RoomPropertiesAbridged.md)
 - [Model.RoomRadiancePropertiesAbridged](docs/RoomRadiancePropertiesAbridged.md)
 - [Model.Roughness](docs/Roughness.md)
 - [Model.ScheduleDay](docs/ScheduleDay.md)
 - [Model.ScheduleDayAllOf](docs/ScheduleDayAllOf.md)
 - [Model.ScheduleFixedInterval](docs/ScheduleFixedInterval.md)
 - [Model.ScheduleFixedIntervalAbridged](docs/ScheduleFixedIntervalAbridged.md)
 - [Model.ScheduleFixedIntervalAbridgedAllOf](docs/ScheduleFixedIntervalAbridgedAllOf.md)
 - [Model.ScheduleFixedIntervalAllOf](docs/ScheduleFixedIntervalAllOf.md)
 - [Model.ScheduleNumericType](docs/ScheduleNumericType.md)
 - [Model.ScheduleRuleAbridged](docs/ScheduleRuleAbridged.md)
 - [Model.ScheduleRuleAbridgedAllOf](docs/ScheduleRuleAbridgedAllOf.md)
 - [Model.ScheduleRuleset](docs/ScheduleRuleset.md)
 - [Model.ScheduleRulesetAbridged](docs/ScheduleRulesetAbridged.md)
 - [Model.ScheduleRulesetAbridgedAllOf](docs/ScheduleRulesetAbridgedAllOf.md)
 - [Model.ScheduleRulesetAllOf](docs/ScheduleRulesetAllOf.md)
 - [Model.ScheduleTypeLimit](docs/ScheduleTypeLimit.md)
 - [Model.ScheduleTypeLimitAllOf](docs/ScheduleTypeLimitAllOf.md)
 - [Model.ScheduleUnitType](docs/ScheduleUnitType.md)
 - [Model.Sensor](docs/Sensor.md)
 - [Model.SensorGrid](docs/SensorGrid.md)
 - [Model.SensorGridAllOf](docs/SensorGridAllOf.md)
 - [Model.Setpoint](docs/Setpoint.md)
 - [Model.SetpointAbridged](docs/SetpointAbridged.md)
 - [Model.SetpointAbridgedAllOf](docs/SetpointAbridgedAllOf.md)
 - [Model.SetpointAllOf](docs/SetpointAllOf.md)
 - [Model.Shade](docs/Shade.md)
 - [Model.ShadeAllOf](docs/ShadeAllOf.md)
 - [Model.ShadeConstruction](docs/ShadeConstruction.md)
 - [Model.ShadeConstructionAllOf](docs/ShadeConstructionAllOf.md)
 - [Model.ShadeEnergyPropertiesAbridged](docs/ShadeEnergyPropertiesAbridged.md)
 - [Model.ShadeLocation](docs/ShadeLocation.md)
 - [Model.ShadeModifierSet](docs/ShadeModifierSet.md)
 - [Model.ShadeModifierSetAbridged](docs/ShadeModifierSetAbridged.md)
 - [Model.ShadeModifierSetAbridgedAllOf](docs/ShadeModifierSetAbridgedAllOf.md)
 - [Model.ShadePropertiesAbridged](docs/ShadePropertiesAbridged.md)
 - [Model.ShadeRadiancePropertiesAbridged](docs/ShadeRadiancePropertiesAbridged.md)
 - [Model.ShadeRadiancePropertiesAbridgedAllOf](docs/ShadeRadiancePropertiesAbridgedAllOf.md)
 - [Model.SlatOrientation](docs/SlatOrientation.md)
 - [Model.StateGeometryAbridged](docs/StateGeometryAbridged.md)
 - [Model.StateGeometryAbridgedAllOf](docs/StateGeometryAbridgedAllOf.md)
 - [Model.Surface](docs/Surface.md)
 - [Model.TemplateSystem](docs/TemplateSystem.md)
 - [Model.TemplateSystemAllOf](docs/TemplateSystemAllOf.md)
 - [Model.Trans](docs/Trans.md)
 - [Model.TransAllOf](docs/TransAllOf.md)
 - [Model.Units](docs/Units.md)
 - [Model.VAV](docs/VAV.md)
 - [Model.VAVAllOf](docs/VAVAllOf.md)
 - [Model.VAVEquipmentType](docs/VAVEquipmentType.md)
 - [Model.VRF](docs/VRF.md)
 - [Model.VRFAllOf](docs/VRFAllOf.md)
 - [Model.VRFEquipmentType](docs/VRFEquipmentType.md)
 - [Model.VRFwithDOAS](docs/VRFwithDOAS.md)
 - [Model.VRFwithDOASAllOf](docs/VRFwithDOASAllOf.md)
 - [Model.VRFwithDOASEquipmentType](docs/VRFwithDOASEquipmentType.md)
 - [Model.Ventilation](docs/Ventilation.md)
 - [Model.VentilationAbridged](docs/VentilationAbridged.md)
 - [Model.VentilationAbridgedAllOf](docs/VentilationAbridgedAllOf.md)
 - [Model.VentilationAllOf](docs/VentilationAllOf.md)
 - [Model.VentilationControlAbridged](docs/VentilationControlAbridged.md)
 - [Model.VentilationControlType](docs/VentilationControlType.md)
 - [Model.VentilationOpening](docs/VentilationOpening.md)
 - [Model.VentilationSimulationControl](docs/VentilationSimulationControl.md)
 - [Model.View](docs/View.md)
 - [Model.ViewAllOf](docs/ViewAllOf.md)
 - [Model.ViewType](docs/ViewType.md)
 - [Model.Vintages](docs/Vintages.md)
 - [Model.Void](docs/Void.md)
 - [Model.WSHP](docs/WSHP.md)
 - [Model.WSHPAllOf](docs/WSHPAllOf.md)
 - [Model.WSHPEquipmentType](docs/WSHPEquipmentType.md)
 - [Model.WSHPwithDOAS](docs/WSHPwithDOAS.md)
 - [Model.WSHPwithDOASAllOf](docs/WSHPwithDOASAllOf.md)
 - [Model.WSHPwithDOASEquipmentType](docs/WSHPwithDOASEquipmentType.md)
 - [Model.WallConstructionSet](docs/WallConstructionSet.md)
 - [Model.WallConstructionSetAbridged](docs/WallConstructionSetAbridged.md)
 - [Model.WallConstructionSetAbridgedAllOf](docs/WallConstructionSetAbridgedAllOf.md)
 - [Model.WallModifierSet](docs/WallModifierSet.md)
 - [Model.WallModifierSetAbridged](docs/WallModifierSetAbridged.md)
 - [Model.WallModifierSetAbridgedAllOf](docs/WallModifierSetAbridgedAllOf.md)
 - [Model.WindowAC](docs/WindowAC.md)
 - [Model.WindowACAllOf](docs/WindowACAllOf.md)
 - [Model.WindowACEquipmentType](docs/WindowACEquipmentType.md)
 - [Model.WindowConstruction](docs/WindowConstruction.md)
 - [Model.WindowConstructionAbridged](docs/WindowConstructionAbridged.md)
 - [Model.WindowConstructionAbridgedAllOf](docs/WindowConstructionAbridgedAllOf.md)
 - [Model.WindowConstructionAllOf](docs/WindowConstructionAllOf.md)
 - [Model.WindowConstructionShade](docs/WindowConstructionShade.md)
 - [Model.WindowConstructionShadeAbridged](docs/WindowConstructionShadeAbridged.md)
 - [Model.WindowConstructionShadeAbridgedAllOf](docs/WindowConstructionShadeAbridgedAllOf.md)
 - [Model.WindowConstructionShadeAllOf](docs/WindowConstructionShadeAllOf.md)


## Documentation for Authorization

All endpoints do not require authorization.
