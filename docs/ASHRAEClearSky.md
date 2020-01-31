
# HoneybeeDotNet.Model.ASHRAEClearSky

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Date** | **List&lt;int&gt;** | A list of two integers for [month, day], representing the date for the day of the year on which the design day occurs.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case). | 
**Clearness** | **double** | Value between 0 and 1.2 that will get multiplied by the irradinace to correct for factors like elevation above sea level. | 
**DaylightSavings** | **bool** | Boolean to indicate whether daylight savings time is active on the design day. | [optional] [default to false]
**Type** | **string** |  | [optional] [default to "ASHRAEClearSky"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

