
# HoneybeeSchema.Model.VentilationAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**Type** | **string** |  | [optional] [default to "VentilationAbridged"]
**FlowPerPerson** | **double** | Intensity of ventilation in[] m3/s per person]. Note that setting this value does not mean that ventilation is varied based on real-time occupancy but rather that the design level of ventilation is determined using this value and the People object of the Room. | [optional] [default to 0M]
**FlowPerArea** | **double** | Intensity of ventilation in [m3/s per m2 of floor area]. | [optional] [default to 0M]
**AirChangesPerHour** | **double** | Intensity of ventilation in air changes per hour (ACH) for the entire Room. | [optional] [default to 0M]
**FlowPerZone** | **double** | Intensity of ventilation in m3/s for the entire Room. | [optional] [default to 0M]
**Schedule** | **string** | Identifier of the schedule for the ventilation over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the total design flow rate (determined from the sum of the other 4 fields) to yield a complete ventilation profile. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

