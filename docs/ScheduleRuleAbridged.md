
# HoneybeeSchema.Model.ScheduleRuleAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ScheduleDay** | **string** | The identifier of a ScheduleDay object associated with this rule. | 
**Type** | **string** |  | [optional] [default to "ScheduleRuleAbridged"]
**ApplySunday** | **bool** | Boolean noting whether to apply schedule_day on Sundays. | [optional] [default to false]
**ApplyMonday** | **bool** | Boolean noting whether to apply schedule_day on Mondays. | [optional] [default to false]
**ApplyTuesday** | **bool** | Boolean noting whether to apply schedule_day on Tuesdays. | [optional] [default to false]
**ApplyWednesday** | **bool** | Boolean noting whether to apply schedule_day on Wednesdays. | [optional] [default to false]
**ApplyThursday** | **bool** | Boolean noting whether to apply schedule_day on Thursdays. | [optional] [default to false]
**ApplyFriday** | **bool** | Boolean noting whether to apply schedule_day on Fridays. | [optional] [default to false]
**ApplySaturday** | **bool** | Boolean noting whether to apply schedule_day on Saturdays. | [optional] [default to false]
**StartDate** | **List&lt;int&gt;** | A list of two integers for [month, day], representing the start date of the period over which the schedule_day will be applied.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case). | [optional] 
**EndDate** | **List&lt;int&gt;** | A list of two integers for [month, day], representing the end date of the period over which the schedule_day will be applied.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case). | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

