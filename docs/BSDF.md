
# HoneybeeSchema.Model.BSDF

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**BsdfData** | **string** | A string with the contents of the BSDF XML file. | 
**Modifier** | [**AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror**](AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror.md) | Material modifier (default: Void). | [optional] 
**Dependencies** | [**List&lt;AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror&gt;**](AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror.md) | List of modifiers that this modifier depends on. This argument is only useful for defining advanced modifiers where the modifier is defined based on other modifiers (default: None). | [optional] 
**UpOrientation** | **List&lt;double&gt;** | Vector as sequence that sets the hemisphere that the BSDF material faces. (default: (0.01, 0.01, 1.00). | [optional] 
**Thickness** | **double** | Optional number to set the thickness of the BSDF material Sign of thickness indicates whether proxied geometry is behind the BSDF surface (when thickness is positive) or in front (when thickness is negative)(default: 0). | [optional] [default to 0D]
**FunctionFile** | **string** | Optional input for function file (default: \&quot;.\&quot;). | [optional] [default to "."]
**Transform** | **string** | Optional transform input to scale the thickness and reorient the up vector (default: None). | [optional] 
**FrontDiffuseReflectance** | **List&lt;double&gt;** | Optional additional front diffuse reflectance as sequence of numbers (default: None). | [optional] 
**BackDiffuseReflectance** | **List&lt;double&gt;** | Optional additional back diffuse reflectance as sequence of numbers (default: None). | [optional] 
**DiffuseTransmittance** | **List&lt;double&gt;** | Optional additional diffuse transmittance as sequence of numbers (default: None). | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "BSDF"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

