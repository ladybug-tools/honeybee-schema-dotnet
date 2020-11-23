
# HoneybeeSchema.Model.Infiltration

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "Infiltration"]
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**FlowPerExteriorArea** | **double** | Number for the infiltration per exterior surface area in m3/s-m2. | 
**Schedule** | [**AnyOfScheduleRulesetScheduleFixedInterval**](AnyOfScheduleRulesetScheduleFixedInterval.md) | The schedule for the infiltration over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the flow_per_exterior_area to yield a complete infiltration profile. | 
**ConstantCoefficient** | **double** |  | [optional] [default to 1D]
**TemperatureCoefficient** | **double** |  | [optional] [default to 0D]
**VelocityCoefficient** | **double** |  | [optional] [default to 0D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

