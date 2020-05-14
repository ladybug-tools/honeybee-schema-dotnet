
# HoneybeeSchema.Model.ModelRadianceProperties

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "ModelRadianceProperties"]
**Modifiers** | [**List&lt;AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror&gt;**](AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror.md) | A list of all unique modifiers in the model. This includes modifiers across all Faces, Apertures, Doors, Shades, Room ModifierSets, and the global_modifier_set (default: None). | [optional] 
**ModifierSets** | [**List&lt;AnyOfModifierSetModifierSetAbridged&gt;**](AnyOfModifierSetModifierSetAbridged.md) | A list of all unique Room-Assigned ModifierSets in the Model (default: None). | [optional] 
**GlobalModifierSet** | **string** | Identifier of a ModifierSet or ModifierSetAbridged object to be used as as a default object for all unassigned objects in the Model (default: None). | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

