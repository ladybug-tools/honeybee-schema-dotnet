
# HoneybeeSchema.Model.ScheduleRuleset

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**DaySchedules** | [**List&lt;ScheduleDay&gt;**](ScheduleDay.md) | A list of ScheduleDays that are referenced in the other keys of this ScheduleRulesetAbridged. | [optional] 
**DefaultDaySchedule** | **string** | An identifier for the ScheduleDay that will be used for all days when no ScheduleRule is applied. This ScheduleDay must be in the day_schedules. | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "ScheduleRuleset"]
**ScheduleRules** | [**List&lt;ScheduleRuleAbridged&gt;**](ScheduleRuleAbridged.md) | A list of ScheduleRuleAbridged that note exceptions to the default_day_schedule. These rules should be ordered from highest to lowest priority. | [optional] 
**HolidaySchedule** | **string** | An identifier for the ScheduleDay that will be used for holidays. This ScheduleDay must be in the day_schedules. | [optional] 
**SummerDesigndaySchedule** | **string** | An identifier for the ScheduleDay that will be used for the summer design day. This ScheduleDay must be in the day_schedules. | [optional] 
**WinterDesigndaySchedule** | **string** | An identifier for the ScheduleDay that will be used for the winter design day. This ScheduleDay must be in the day_schedules. | [optional] 
**ScheduleTypeLimit** | [**ScheduleTypeLimit**](ScheduleTypeLimit.md) | ScheduleTypeLimit object that will be used to validate schedule values against upper/lower limits and assign units to the schedule values. If None, no validation will occur. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

