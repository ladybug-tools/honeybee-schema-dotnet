
# HoneybeeSchema.Model.SetpointAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**CoolingSchedule** | **string** | Identifier of the schedule for the cooling setpoint. The values in this schedule should be temperature in [C]. | 
**HeatingSchedule** | **string** | Identifier of the schedule for the heating setpoint. The values in this schedule should be temperature in [C]. | 
**Type** | **string** |  | [optional] [readonly] [default to "SetpointAbridged"]
**HumidifyingSchedule** | **string** | Identifier of the schedule for the humidification setpoint. The values in this schedule should be in [%]. | [optional] 
**DehumidifyingSchedule** | **string** | Identifier of the schedule for the dehumidification setpoint. The values in this schedule should be in [%]. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

