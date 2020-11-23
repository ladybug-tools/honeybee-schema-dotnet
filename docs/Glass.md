
# HoneybeeSchema.Model.Glass

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "glass"]
**Identifier** | **string** | Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files. | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**Modifier** | [**AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror**](AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror.md) | Material modifier (default: Void). | [optional] 
**Dependencies** | [**List&lt;AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror&gt;**](AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror.md) | List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers (default: None). | [optional] 
**RTransmissivity** | **double** | A value between 0 and 1 for the red channel transmissivity (default: 0). | [optional] [default to 0.0D]
**GTransmissivity** | **double** | A value between 0 and 1 for the green channel transmissivity (default: 0). | [optional] [default to 0.0D]
**BTransmissivity** | **double** | A value between 0 and 1 for the blue channel transmissivity (default: 0). | [optional] [default to 0.0D]
**RefractionIndex** | **double** | A value between 0 and 1 for the index of refraction (default: 1.52). | [optional] [default to 1.52D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

