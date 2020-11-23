
# HoneybeeSchema.Model.ModifierSetAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "ModifierSetAbridged"]
**Identifier** | **string** | Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files. | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**WallSet** | [**WallModifierSetAbridged**](WallModifierSetAbridged.md) | Optional WallModifierSet object for this ModifierSet (default: None). | [optional] 
**FloorSet** | [**FloorModifierSetAbridged**](FloorModifierSetAbridged.md) | Optional FloorModifierSet object for this ModifierSet (default: None). | [optional] 
**RoofCeilingSet** | [**RoofCeilingModifierSetAbridged**](RoofCeilingModifierSetAbridged.md) | Optional RoofCeilingModifierSet object for this ModifierSet (default: None). | [optional] 
**ApertureSet** | [**ApertureModifierSetAbridged**](ApertureModifierSetAbridged.md) | Optional ApertureModifierSet object for this ModifierSet (default: None). | [optional] 
**DoorSet** | [**DoorModifierSetAbridged**](DoorModifierSetAbridged.md) | Optional DoorModifierSet object for this ModifierSet (default: None). | [optional] 
**ShadeSet** | [**ShadeModifierSetAbridged**](ShadeModifierSetAbridged.md) | Optional ShadeModifierSet object for this ModifierSet (default: None). | [optional] 
**AirBoundaryModifier** | **string** | Optional Modifier to be used for all Faces with an AirBoundary face type. If None, it will be the honeybee generic air wall modifier. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

