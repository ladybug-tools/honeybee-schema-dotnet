
# HoneybeeDotNet.Model.InfiltrationAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Name of the object. Must use only ASCII characters and exclude (, ; ! \\n \\t). It cannot be longer than 100 characters. | 
**FlowPerExteriorArea** | **decimal** | Number for the infiltration per exterior surface area in m3/s-m2. | 
**Schedule** | **string** | Name of the schedule for the infiltration over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the flow_per_exterior_area to yield a complete infiltration profile. | 
**Type** | **string** |  | [optional] [default to "InfiltrationAbridged"]
**ConstantCoefficient** | **decimal** |  | [optional] [default to 1M]
**TemperatureCoefficient** | **decimal** |  | [optional] [default to 0M]
**VelocityCoefficient** | **decimal** |  | [optional] [default to 0M]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

