
# HoneybeeSchema.Model.SkyCondition

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Date** | **List&lt;int&gt;** | A list of two integers for [month, day], representing the date for the day of the year on which the design day occurs. A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case). | 
**DaylightSavings** | **bool** | Boolean to indicate whether daylight savings time is active on the design day. | [optional] [default to false]
**Type** | **string** |  | [optional] [readonly] [default to "_SkyCondition"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

