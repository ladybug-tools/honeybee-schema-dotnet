
# HoneybeeSchema.Model.EnergyWindowMaterialSimpleGlazSys

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**UFactor** | **double** | The overall heat transfer coefficient for window system in W/m2-K. Note that constructions with U-values above 5.8 cannot be assigned to skylights without EnergyPlus thorwing an error. | 
**Shgc** | **double** | Unitless quantity for the Solar Heat Gain Coefficient (solar transmittance + conduction) at normal incidence and vertical orientation. | 
**Type** | **string** |  | [optional] [readonly] [default to "EnergyWindowMaterialSimpleGlazSys"]
**Vt** | **double** | The fraction of visible light falling on the window that makes it through the glass at normal incidence. | [optional] [default to 0.54D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

