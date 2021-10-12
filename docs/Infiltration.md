
# HoneybeeSchema.Model.Infiltration

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**FlowPerExteriorArea** | **double** | Number for the infiltration per exterior surface area in m3/s-m2. | 
**Schedule** | [**AnyOfScheduleRulesetScheduleFixedInterval**](AnyOfScheduleRulesetScheduleFixedInterval.md) | The schedule for the infiltration over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the flow_per_exterior_area to yield a complete infiltration profile. | 
**Type** | **string** |  | [optional] [readonly] [default to "Infiltration"]
**ConstantCoefficient** | **double** |  | [optional] [default to 1D]
**TemperatureCoefficient** | **double** |  | [optional] [default to 0D]
**VelocityCoefficient** | **double** |  | [optional] [default to 0D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

