
# HoneybeeSchema.Model.HumidityCondition

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**HumidityType** | **HumidityTypes** |  | 
**HumidityValue** | **double** | The value correcponding to the humidity_type. | 
**Type** | **string** |  | [optional] [readonly] [default to "HumidityCondition"]
**BarometricPressure** | **double** | Barometric air pressure on the design day [Pa]. | [optional] [default to 101325D]
**Rain** | **bool** | Boolean to indicate rain on the design day. | [optional] [default to false]
**SnowOnGround** | **bool** | Boolean to indicate snow on the ground during the design day. | [optional] [default to false]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

