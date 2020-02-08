
# HoneybeeSchema.Model.SetpointAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Name of the object. Must use only ASCII characters and exclude (, ; ! \\n \\t). It cannot be longer than 100 characters. | 
**CoolingSchedule** | **string** | Name of the schedule for the cooling setpoint. The values in this schedule should be temperature in [C]. | 
**HeatingSchedule** | **string** | Name of the schedule for the heating setpoint. The values in this schedule should be temperature in [C]. | 
**Type** | **string** |  | [optional] [default to "SetpointAbridged"]
**HumidificationSchedule** | **string** | Name of the schedule for the humidification setpoint. The values in this schedule should be in [%]. | [optional] 
**DehumidificationSchedule** | **string** | Name of the schedule for the dehumidification setpoint. The values in this schedule should be in [%]. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

