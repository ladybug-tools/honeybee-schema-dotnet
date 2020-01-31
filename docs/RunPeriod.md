
# HoneybeeDotNet.Model.RunPeriod

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [default to "RunPeriod"]
**StartDate** | **List&lt;int&gt;** | A list of two integers for [month, day], representing the date for the start of the run period. Must be before the end date. | [optional] 
**EndDate** | **List&lt;int&gt;** | A list of two integers for [month, day], representing the date for the end of the run period. Must be after the start date. | [optional] 
**StartDayOfWeek** | **string** | Text for the day of the week on which the simulation starts. | [optional] [default to StartDayOfWeekEnum.Sunday]
**Holidays** | **List&lt;List&lt;int&gt;&gt;** | A list of lists where each sub-list consists of two integers for [month, day], representing a date which is a holiday within the simulation. If None, no holidays are applied. | [optional] 
**DaylightSavingsTime** | [**DaylightSavingTime**](DaylightSavingTime.md) | A DaylightSavingTime to dictate the start and end dates of daylight saving time. If None, no daylight saving time is applied to the simulation. | [optional] 
**LeapYear** | **bool** | Boolean noting whether the simulation will be run for a leap year. | [optional] [default to false]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

