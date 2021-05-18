
# HoneybeeSchema.Model.Mirror

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Modifier** | [**AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror**](AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror.md) | Material modifier. | [optional] 
**Dependencies** | [**List&lt;AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror&gt;**](AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror.md) | List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers. | [optional] 
**RReflectance** | **double** | A value between 0 and 1 for the red channel reflectance. | [optional] [default to 1D]
**GReflectance** | **double** | A value between 0 and 1 for the green channel reflectance. | [optional] [default to 1D]
**BReflectance** | **double** | A value between 0 and 1 for the blue channel reflectance. | [optional] [default to 1D]
**AlternateMaterial** | [**AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror**](AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror.md) | An optional material (like the illum type) that may be used to specify a different material to be used for shading non-source rays. If None, this will keep the alternat_material as mirror. If this alternate material is given as Void, then the mirror surface will be invisible. Using Void is only appropriate if the surface hides other (more detailed) geometry with the same overall reflectance. | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "Mirror"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

