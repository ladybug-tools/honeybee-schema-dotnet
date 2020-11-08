
# HoneybeeSchema.Model.SizingParameter

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "SizingParameter"]
**DesignDays** | [**List&lt;DesignDay&gt;**](DesignDay.md) | A list of DesignDays that represent the criteria for which the HVAC systems will be sized. | [optional] 
**HeatingFactor** | **double** | A number that will be multiplied by the peak heating load for each zone in order to size the heating system. | [optional] [default to 1.25D]
**CoolingFactor** | **double** | A number that will be multiplied by the peak cooling load for each zone in order to size the heating system. | [optional] [default to 1.15D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

