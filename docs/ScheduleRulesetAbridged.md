
# HoneybeeSchema.Model.ScheduleRulesetAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**DaySchedules** | [**List&lt;ScheduleDay&gt;**](ScheduleDay.md) | A list of ScheduleDays that are referenced in the other keys of this ScheduleRulesetAbridged. | 
**DefaultDaySchedule** | **string** | An identifier for the ScheduleDay that will be used for all days when no ScheduleRule is applied. This ScheduleDay must be in the day_schedules. | 
**Type** | **string** |  | [optional] [readonly] [default to "ScheduleRulesetAbridged"]
**ScheduleRules** | [**List&lt;ScheduleRuleAbridged&gt;**](ScheduleRuleAbridged.md) | A list of ScheduleRuleAbridged that note exceptions to the default_day_schedule. These rules should be ordered from highest to lowest priority. | [optional] 
**HolidaySchedule** | **string** | An identifier for the ScheduleDay that will be used for holidays. This ScheduleDay must be in the day_schedules. | [optional] 
**SummerDesigndaySchedule** | **string** | An identifier for the ScheduleDay that will be used for the summer design day. This ScheduleDay must be in the day_schedules. | [optional] 
**WinterDesigndaySchedule** | **string** | An identifier for the ScheduleDay that will be used for the winter design day. This ScheduleDay must be in the day_schedules. | [optional] 
**ScheduleTypeLimit** | **string** | Identifier of a ScheduleTypeLimit that will be used to validate schedule values against upper/lower limits and assign units to the schedule values. If None, no validation will occur. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

