
# HoneybeeSchema.Model.VentilationControlAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "VentilationControlAbridged"]
**MinIndoorTemperature** | **double** | A number for the minimum indoor temperature at which to ventilate in Celsius. Typically, this variable is used to initiate ventilation. | [optional] [default to -100D]
**MaxIndoorTemperature** | **double** | A number for the maximum indoor temperature at which to ventilate in Celsius. This can be used to set a maximum temperature at which point ventilation is stopped and a cooling system is turned on. | [optional] [default to 100D]
**MinOutdoorTemperature** | **double** | A number for the minimum outdoor temperature at which to ventilate in Celsius. This can be used to ensure ventilative cooling does not happen during the winter even if the Room is above the min_indoor_temperature. | [optional] [default to -100D]
**MaxOutdoorTemperature** | **double** | A number for the maximum indoor temperature at which to ventilate in Celsius. This can be used to set a limit for when it is considered too hot outside for ventilative cooling. | [optional] [default to 100D]
**DeltaTemperature** | **double** | A number for the temperature differential in Celsius between indoor and outdoor below which ventilation is shut off.  This should usually be a negative number so that ventilation only occurs when the outdoors is cooler than the indoors. Positive numbers indicate how much hotter the outdoors can be than the indoors before ventilation is stopped. | [optional] [default to -100D]
**Schedule** | **string** | Identifier of the schedule for the ventilation over the course of the year. Note that this is applied on top of any setpoints. The type of this schedule should be On/Off and values should be either 0 (no possibility of ventilation) or 1 (ventilation possible). | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

