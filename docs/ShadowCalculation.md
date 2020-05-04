
# HoneybeeSchema.Model.ShadowCalculation

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "ShadowCalculation"]
**SolarDistribution** | **string** |  | [optional] [default to SolarDistributionEnum.FullExteriorWithReflections]
**CalculationFrequency** | **int** | Integer for the number of days in each period for which a unique shadow calculation will be performed. This field is only used if the AverageOverDaysInFrequency calculation_method is used. | [optional] [default to 30]
**CalculationMethod** | **string** |  | [optional] [default to CalculationMethodEnum.AverageOverDaysInFrequency]
**MaximumFigures** | **int** | Number of allowable figures in shadow overlap calculations. | [optional] [default to 15000]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

