
# HoneybeeSchema.Model.AirBoundaryConstructionAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "AirBoundaryConstruction"]
**AirMixingPerArea** | **double** | A positive number for the amount of air mixing between Rooms across the air boundary surface [m3/s-m2]. Default: 0.1 corresponds to average indoor air speeds of 0.1 m/s (roughly 20 fpm), which is typical of what would be induced by a HVAC system. | [optional] [default to 0.1D]
**AirMixingSchedule** | [**AnyOfScheduleRulesetScheduleFixedInterval**](AnyOfScheduleRulesetScheduleFixedInterval.md) | A fractional schedule as a ScheduleRuleset or ScheduleFixedInterval for the air mixing schedule across the construction. | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

