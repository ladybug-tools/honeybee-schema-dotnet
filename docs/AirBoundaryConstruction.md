
# HoneybeeSchema.Model.AirBoundaryConstruction

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**AirMixingSchedule** | [**AnyOfScheduleRulesetScheduleFixedInterval**](AnyOfScheduleRulesetScheduleFixedInterval.md) | A fractional schedule as a ScheduleRuleset or ScheduleFixedInterval for the air mixing schedule across the construction. | 
**Type** | **string** |  | [optional] [readonly] [default to "AirBoundaryConstruction"]
**AirMixingPerArea** | **double** | A positive number for the amount of air mixing between Rooms across the air boundary surface [m3/s-m2]. Default: 0.1 corresponds to average indoor air speeds of 0.1 m/s (roughly 20 fpm), which is typical of what would be induced by a HVAC system. | [optional] [default to 0.1D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

