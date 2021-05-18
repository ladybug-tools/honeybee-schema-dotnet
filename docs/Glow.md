
# HoneybeeSchema.Model.Glow

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Modifier** | [**AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror**](AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror.md) | Material modifier. | [optional] 
**Dependencies** | [**List&lt;AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror&gt;**](AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror.md) | List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers. | [optional] 
**REmittance** | **double** | A value between 0 and 1 for the red channel of the modifier. | [optional] [default to 0.0D]
**GEmittance** | **double** | A value between 0 and 1 for the green channel of the modifier. | [optional] [default to 0.0D]
**BEmittance** | **double** | A value between 0 and 1 for the blue channel of the modifier. | [optional] [default to 0.0D]
**MaxRadius** | **double** | Maximum radius for shadow testing. Objects with zero radius are permissable and may participate in interreflection calculation (though they are not representative of real light sources). Negative values will never contribute to scene illumination. | [optional] [default to 0D]
**Type** | **string** |  | [optional] [readonly] [default to "Glow"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

