
# HoneybeeSchema.Model.InfiltrationAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "Infiltration"]
**FlowPerExteriorArea** | **double** | Number for the infiltration per exterior surface area in m3/s-m2. | 
**Schedule** | [**AnyOfScheduleRulesetScheduleFixedInterval**](AnyOfScheduleRulesetScheduleFixedInterval.md) | The schedule for the infiltration over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the flow_per_exterior_area to yield a complete infiltration profile. | 
**ConstantCoefficient** | **double** |  | [optional] [default to 1D]
**TemperatureCoefficient** | **double** |  | [optional] [default to 0D]
**VelocityCoefficient** | **double** |  | [optional] [default to 0D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

