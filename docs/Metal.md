
# HoneybeeSchema.Model.Metal

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Modifier** | [**AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror**](AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror.md) | Material modifier (default: Void). | [optional] 
**Dependencies** | [**List&lt;AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror&gt;**](AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror.md) | List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers (default: None). | [optional] 
**RReflectance** | **double** | A value between 0 and 1 for the red channel reflectance (default: 0). | [optional] [default to 0.0D]
**GReflectance** | **double** | A value between 0 and 1 for the green channel reflectance (default: 0). | [optional] [default to 0.0D]
**BReflectance** | **double** | A value between 0 and 1 for the blue channel reflectance (default: 0). | [optional] [default to 0.0D]
**Specularity** | **double** | A value between 0 and 1 for the fraction of specularity. Specularity fractions lower than 0.9 are not realistic for metallic materials. (default: 0.9). | [optional] [default to 0.9D]
**Roughness** | **double** | A value between 0 and 1 for the roughness, specified as the rms slope of surface facets. Roughness greater than 0.2 are not realistic (default: 0). | [optional] [default to 0D]
**Type** | **string** |  | [optional] [readonly] [default to "metal"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

