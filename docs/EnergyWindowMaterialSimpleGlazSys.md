
# HoneybeeSchema.Model.EnergyWindowMaterialSimpleGlazSys

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**UFactor** | **double** | Used to describe the value for window system U-Factor, or overall heat transfer coefficient in W/(m2-K). | 
**Shgc** | **double** | Unitless  quantity describing Solar Heat Gain Coefficient for normal incidence and vertical orientation. | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "EnergyWindowMaterialSimpleGlazSys"]
**Vt** | **double** | The fraction of visible light falling on the window that makes it through the glass at normal incidence. | [optional] [default to 0.54D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

