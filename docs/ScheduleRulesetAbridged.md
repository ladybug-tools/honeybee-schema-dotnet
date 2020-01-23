
# HoneybeeDotNet.Model.ScheduleRulesetAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Name of the object. Must use only ASCII characters and exclude (, ; ! \\n \\t). It cannot be longer than 100 characters. | 
**DaySchedules** | [**List&lt;ScheduleDay&gt;**](ScheduleDay.md) | A list of ScheduleDays that are referenced in the other keys of this ScheduleRulesetAbridged. | 
**DefaultDaySchedule** | **string** | A name for the ScheduleDay that will be used for all days when no ScheduleRule is applied. This ScheduleDay must be in the day_schedules. | 
**Type** | **string** |  | [optional] [default to "ScheduleRulesetAbridged"]
**ScheduleRules** | [**List&lt;ScheduleRuleAbridged&gt;**](ScheduleRuleAbridged.md) | A list of ScheduleRuleAbridged that note exceptions to the default_day_schedule. These rules should be ordered from highest to lowest priority. | [optional] 
**SummerDesigndaySchedule** | **string** | A name for the ScheduleDay that will be used for the summer design day. This ScheduleDay must be in the day_schedules. | [optional] 
**WinterDesigndaySchedule** | **string** | A name for the ScheduleDay that will be used for the winter design day. This ScheduleDay must be in the day_schedules. | [optional] 
**ScheduleTypeLimit** | **string** | Name of a ScheduleTypeLimit that will be used to validate schedule values against upper/lower limits and assign units to the schedule values. If None, no validation will occur. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

