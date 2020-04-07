
# HoneybeeSchema.Model.Setpoint

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**CoolingSchedule** | [**AnyOfobjectobject**](AnyOfobjectobject.md) | Schedule for the cooling setpoint. The values in this schedule should be temperature in [C]. | 
**HeatingSchedule** | [**AnyOfobjectobject**](AnyOfobjectobject.md) | Schedule for the heating setpoint. The values in this schedule should be temperature in [C]. | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**Type** | **string** |  | [optional] [default to "Setpoint"]
**HumidifyingSchedule** | [**AnyOfobjectobject**](AnyOfobjectobject.md) | Schedule for the humidification setpoint. The values in this schedule should be in [%]. | [optional] 
**DehumidifyingSchedule** | [**AnyOfobjectobject**](AnyOfobjectobject.md) | Schedule for the dehumidification setpoint. The values in this schedule should be in [%]. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

