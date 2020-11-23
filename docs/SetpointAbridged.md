
# HoneybeeSchema.Model.SetpointAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "SetpointAbridged"]
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**CoolingSchedule** | **string** | Identifier of the schedule for the cooling setpoint. The values in this schedule should be temperature in [C]. | 
**HeatingSchedule** | **string** | Identifier of the schedule for the heating setpoint. The values in this schedule should be temperature in [C]. | 
**HumidifyingSchedule** | **string** | Identifier of the schedule for the humidification setpoint. The values in this schedule should be in [%]. | [optional] 
**DehumidifyingSchedule** | **string** | Identifier of the schedule for the dehumidification setpoint. The values in this schedule should be in [%]. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

