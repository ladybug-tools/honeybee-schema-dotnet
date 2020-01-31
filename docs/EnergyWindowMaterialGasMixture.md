
# HoneybeeDotNet.Model.EnergyWindowMaterialGasMixture

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Name of the object. Must use only ASCII characters and exclude (, ; ! \\n \\t). It cannot be longer than 100 characters. | 
**GasTypes** | **List&lt;string&gt;** | List of gases in the gas mixture. | 
**GasFractions** | **List&lt;double&gt;** | A list of fractional numbers describing the volumetric fractions of gas types in the mixture. This list must align with the gas_types list and must sum to 1. | 
**Type** | **string** |  | [optional] [default to "EnergyWindowMaterialGasMixture"]
**Thickness** | **double** | The thickness of the gas mixture layer in meters. | [optional] [default to 0.0125M]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

