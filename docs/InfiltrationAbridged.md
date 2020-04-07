
# HoneybeeSchema.Model.InfiltrationAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**FlowPerExteriorArea** | **double** | Number for the infiltration per exterior surface area in m3/s-m2. | 
**Schedule** | **string** | Identifier of the schedule for the infiltration over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the flow_per_exterior_area to yield a complete infiltration profile. | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**Type** | **string** |  | [optional] [default to "InfiltrationAbridged"]
**ConstantCoefficient** | **double** |  | [optional] [default to 1M]
**TemperatureCoefficient** | **double** |  | [optional] [default to 0M]
**VelocityCoefficient** | **double** |  | [optional] [default to 0M]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

