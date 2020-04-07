
# HoneybeeSchema.Model.EnergyWindowMaterialGas

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**Type** | **string** |  | [optional] [default to "EnergyWindowMaterialGas"]
**Thickness** | **double** | Thickness of the gas layer in meters. Default value is 0.0125. | [optional] [default to 0.0125M]
**GasType** | **string** |  | [optional] [default to GasTypeEnum.Air]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

