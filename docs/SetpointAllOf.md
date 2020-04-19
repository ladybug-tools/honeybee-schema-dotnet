
# HoneybeeSchema.Model.SetpointAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "Setpoint"]
**CoolingSchedule** | [**AnyOfScheduleRulesetScheduleFixedInterval**](AnyOfScheduleRulesetScheduleFixedInterval.md) | Schedule for the cooling setpoint. The values in this schedule should be temperature in [C]. | 
**HeatingSchedule** | [**AnyOfScheduleRulesetScheduleFixedInterval**](AnyOfScheduleRulesetScheduleFixedInterval.md) | Schedule for the heating setpoint. The values in this schedule should be temperature in [C]. | 
**HumidifyingSchedule** | [**AnyOfScheduleRulesetScheduleFixedInterval**](AnyOfScheduleRulesetScheduleFixedInterval.md) | Schedule for the humidification setpoint. The values in this schedule should be in [%]. | [optional] 
**DehumidifyingSchedule** | [**AnyOfScheduleRulesetScheduleFixedInterval**](AnyOfScheduleRulesetScheduleFixedInterval.md) | Schedule for the dehumidification setpoint. The values in this schedule should be in [%]. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

