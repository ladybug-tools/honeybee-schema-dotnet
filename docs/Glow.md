
# HoneybeeSchema.Model.Glow

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Modifier** | [**AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror**](AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror.md) | Material modifier (default: Void). | [optional] 
**Dependencies** | [**List&lt;AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror&gt;**](AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror.md) | List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers (default: None). | [optional] 
**REmittance** | **double** | A value between 0 and 1 for the red channel of the modifier (default: 0). | [optional] [default to 0.0D]
**GEmittance** | **double** | A value between 0 and 1 for the green channel of the modifier (default: 0). | [optional] [default to 0.0D]
**BEmittance** | **double** | A value between 0 and 1 for the blue channel of the modifier (default: 0). | [optional] [default to 0.0D]
**MaxRadius** | **double** | Maximum radius for shadow testing (default: 0). Surfaces with zero will never be tested for zero, although it may participate in interreflection calculation. Negative values will never contribute to scene illumination. | [optional] [default to 0D]
**Type** | **string** |  | [optional] [readonly] [default to "glow"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

