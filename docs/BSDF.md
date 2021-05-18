
# HoneybeeSchema.Model.BSDF

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**BsdfData** | **string** | A string with the contents of the BSDF XML file. | 
**Modifier** | [**AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror**](AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror.md) | Material modifier. | [optional] 
**Dependencies** | [**List&lt;AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror&gt;**](AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror.md) | List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers. | [optional] 
**UpOrientation** | **List&lt;double&gt;** | Vector as sequence that sets the hemisphere that the BSDF material faces. | [optional] 
**Thickness** | **double** | Optional number to set the thickness of the BSDF material Sign of thickness indicates whether proxied geometry is behind the BSDF surface (when thickness is positive) or in front (when thickness is negative). | [optional] [default to 0D]
**FunctionFile** | **string** | Optional input for function file. Using \&quot;.\&quot; will ensure that BSDF data is written to the root of wherever a given study is run. | [optional] [default to "."]
**Transform** | **string** | Optional transform input to scale the thickness and reorient the up vector. | [optional] 
**FrontDiffuseReflectance** | **List&lt;double&gt;** | Optional additional front diffuse reflectance as sequence of three RGB numbers. | [optional] 
**BackDiffuseReflectance** | **List&lt;double&gt;** | Optional additional back diffuse reflectance as sequence of three RGB numbers. | [optional] 
**DiffuseTransmittance** | **List&lt;double&gt;** | Optional additional diffuse transmittance as sequence of three RGB numbers. | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "BSDF"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

