
# HoneybeeSchema.Model.EnergyWindowMaterialGasMixture

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**GasTypes** | [**List&lt;GasType&gt;**](GasType.md) | List of gases in the gas mixture. | 
**GasFractions** | **List&lt;double&gt;** | A list of fractional numbers describing the volumetric fractions of gas types in the mixture. This list must align with the gas_types list and must sum to 1. | 
**Type** | **string** |  | [optional] [readonly] [default to "EnergyWindowMaterialGasMixture"]
**Thickness** | **double** | The thickness of the gas mixture layer in meters. | [optional] [default to 0.0125D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

