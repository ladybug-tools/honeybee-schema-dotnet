
# HoneybeeDotNet.Model.LightingAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Name of the object. Must use only ASCII characters and exclude (, ; ! \\n \\t). It cannot be longer than 100 characters. | 
**WattsPerArea** | **decimal** | Lighting per floor area as [W/m2]. | 
**Schedule** | **string** | Name of the schedule for the use of lights over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts_per_area to yield a complete lighting profile. | 
**Type** | **string** |  | [optional] [default to "LightingAbridged"]
**VisibleFraction** | **decimal** | The fraction of heat from lights that goes into the zone as visible (short-wave) radiation. The default value is &#x60;0.25&#x60;. | [optional] [default to 0.25M]
**RadiantFraction** | **decimal** | The fraction of heat from lights that is long-wave radiation. Default value is &#x60;0.32&#x60;. | [optional] [default to 0.32M]
**ReturnAirFraction** | **decimal** | The fraction of the heat from lights that goes into the zone return air. Default value is &#x60;0&#x60;. | [optional] [default to 0.0M]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

