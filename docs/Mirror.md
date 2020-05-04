
# HoneybeeSchema.Model.Mirror

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Modifier** | [**AnyOfPlasticGlassBSDFGlowLightTransVoidMirror**](AnyOfPlasticGlassBSDFGlowLightTransVoidMirror.md) | Material modifier (default: Void). | [optional] 
**Dependencies** | [**List&lt;AnyOfPlasticGlassBSDFGlowLightTransVoidMirror&gt;**](AnyOfPlasticGlassBSDFGlowLightTransVoidMirror.md) | List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers (default: []). | [optional] 
**RReflectance** | **double** | A value between 0 and 1 for the red channel reflectance (default: 1). | [optional] [default to 1D]
**GReflectance** | **double** | A value between 0 and 1 for the green channel reflectance (default: 1). | [optional] [default to 1D]
**BReflectance** | **double** | A value between 0 and 1 for the blue channel reflectance (default: 1). | [optional] [default to 1D]
**AlternateMaterial** | [**AnyOfPlasticGlassBSDFGlowLightTransVoidMirror**](AnyOfPlasticGlassBSDFGlowLightTransVoidMirror.md) | An optional material that may be used like the illum type to specify a different material to be used for shading non-source rays. If None, this will keep the alternat_material as mirror. If this alternate material is given as Void, then the mirror surface will be invisible. Using Void is only appropriate if the surface hides other (more detailed) geometry with the same overall reflectance (default: None). | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "mirror"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

