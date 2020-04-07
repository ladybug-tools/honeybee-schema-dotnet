
# HoneybeeSchema.Model.EnergyWindowMaterialGasMixture

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**GasTypes** | **List&lt;string&gt;** | List of gases in the gas mixture. | 
**GasFractions** | **List&lt;double&gt;** | A list of fractional numbers describing the volumetric fractions of gas types in the mixture. This list must align with the gas_types list and must sum to 1. | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**Type** | **string** |  | [optional] [default to "EnergyWindowMaterialGasMixture"]
**Thickness** | **double** | The thickness of the gas mixture layer in meters. | [optional] [default to 0.0125M]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

