
# HoneybeeSchema.Model.GlobalConstructionSet

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "GlobalConstructionSet"]
**Materials** | [**List&lt;AnyOfEnergyMaterialEnergyMaterialNoMassEnergyWindowMaterialGlazingEnergyWindowMaterialGas&gt;**](AnyOfEnergyMaterialEnergyMaterialNoMassEnergyWindowMaterialGlazingEnergyWindowMaterialGas.md) | Global Honeybee Energy materials. | [optional] [readonly] 
**Constructions** | [**List&lt;AnyOfOpaqueConstructionAbridgedWindowConstructionAbridgedShadeConstructionAirBoundaryConstructionAbridged&gt;**](AnyOfOpaqueConstructionAbridgedWindowConstructionAbridgedShadeConstructionAirBoundaryConstructionAbridged.md) | Global Honeybee Energy constructions. | [optional] [readonly] 
**WallSet** | [**WallConstructionSetAbridged**](WallConstructionSetAbridged.md) | Global Honeybee WallConstructionSet. | [optional] [readonly] 
**FloorSet** | [**FloorConstructionSetAbridged**](FloorConstructionSetAbridged.md) | Global Honeybee FloorConstructionSet. | [optional] [readonly] 
**RoofCeilingSet** | [**RoofCeilingConstructionSetAbridged**](RoofCeilingConstructionSetAbridged.md) | Global Honeybee RoofCeilingConstructionSet. | [optional] [readonly] 
**ApertureSet** | [**ApertureConstructionSetAbridged**](ApertureConstructionSetAbridged.md) | Global Honeybee ApertureConstructionSet. | [optional] [readonly] 
**DoorSet** | [**DoorConstructionSetAbridged**](DoorConstructionSetAbridged.md) | Global Honeybee DoorConstructionSet. | [optional] [readonly] 
**ShadeConstruction** | **string** | Global Honeybee Construction for Shades. | [optional] [readonly] [default to "Generic Shade"]
**AirBoundaryConstruction** | **string** | Global Honeybee Construction for AirBoundary Faces. | [optional] [readonly] [default to "Generic Air Boundary"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

