
# HoneybeeSchema.Model.Trans

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Modifier** | [**AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror**](AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror.md) | Material modifier. | [optional] 
**Dependencies** | [**List&lt;AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror&gt;**](AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror.md) | List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers. | [optional] 
**RReflectance** | **double** | A value between 0 and 1 for the red channel reflectance. | [optional] [default to 0.0D]
**GReflectance** | **double** | A value between 0 and 1 for the green channel reflectance. | [optional] [default to 0.0D]
**BReflectance** | **double** | A value between 0 and 1 for the blue channel reflectance. | [optional] [default to 0.0D]
**Specularity** | **double** | A value between 0 and 1 for the fraction of specularity. Specularity fractions greater than 0.1 are not realistic for non-metallic materials. | [optional] [default to 0D]
**Roughness** | **double** | A value between 0 and 1 for the roughness, specified as the RMS slope of surface facets. Roughness greater than 0.2 are not realistic. | [optional] [default to 0D]
**TransmittedDiff** | **double** | The fraction of transmitted light that is transmitted diffusely in a scattering fashion. | [optional] [default to 0D]
**TransmittedSpec** | **double** | The fraction of transmitted light that is not diffusely scattered. | [optional] [default to 0D]
**Type** | **string** |  | [optional] [readonly] [default to "Trans"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

