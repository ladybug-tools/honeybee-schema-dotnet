
# HoneybeeSchema.Model.ModifierSet

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files. | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "ModifierSet"]
**WallSet** | [**WallModifierSet**](WallModifierSet.md) | An optional WallModifierSet object for this ModifierSet. (default: None). | [optional] 
**FloorSet** | [**FloorModifierSet**](FloorModifierSet.md) | An optional FloorModifierSet object for this ModifierSet. (default: None). | [optional] 
**RoofCeilingSet** | [**RoofCeilingModifierSet**](RoofCeilingModifierSet.md) | An optional RoofCeilingModifierSet object for this ModifierSet. (default: None). | [optional] 
**ApertureSet** | [**ApertureModifierSet**](ApertureModifierSet.md) | An optional ApertureModifierSet object for this ModifierSet. (default: None). | [optional] 
**DoorSet** | [**DoorModifierSet**](DoorModifierSet.md) | An optional DoorModifierSet object for this ModifierSet. (default: None). | [optional] 
**ShadeSet** | [**ShadeModifierSet**](ShadeModifierSet.md) | An optional ShadeModifierSet object for this ModifierSet. (default: None). | [optional] 
**AirBoundaryModifier** | [**AnyOfPlasticGlassBSDFGlowLightTransVoidMirror**](AnyOfPlasticGlassBSDFGlowLightTransVoidMirror.md) | An optional Modifier to be used for all Faces with an AirBoundary face type. If None, it will be the honyebee generic air wall modifier. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

