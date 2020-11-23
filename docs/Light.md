
# HoneybeeSchema.Model.Light

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "light"]
**Identifier** | **string** | Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files. | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**Modifier** | [**AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror**](AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror.md) | Material modifier (default: Void). | [optional] 
**Dependencies** | [**List&lt;AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror&gt;**](AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror.md) | List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers (default: None). | [optional] 
**REmittance** | **double** | A value between 0 and 1 for the red channel of the modifier (default: 0). | [optional] [default to 0.0D]
**GEmittance** | **double** | A value between 0 and 1 for the green channel of the modifier (default: 0). | [optional] [default to 0.0D]
**BEmittance** | **double** | A value between 0 and 1 for the blue channel of the modifier (default: 0). | [optional] [default to 0.0D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

