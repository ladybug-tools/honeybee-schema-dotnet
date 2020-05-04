
# HoneybeeSchema.Model.LightingAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**WattsPerArea** | **double** | Lighting per floor area as [W/m2]. | 
**Schedule** | **string** | Identifier of the schedule for the use of lights over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts_per_area to yield a complete lighting profile. | 
**Type** | **string** |  | [optional] [readonly] [default to "LightingAbridged"]
**VisibleFraction** | **double** | The fraction of heat from lights that goes into the zone as visible (short-wave) radiation. The default value is &#x60;0.25&#x60;. | [optional] [default to 0.25D]
**RadiantFraction** | **double** | The fraction of heat from lights that is long-wave radiation. Default value is &#x60;0.32&#x60;. | [optional] [default to 0.32D]
**ReturnAirFraction** | **double** | The fraction of the heat from lights that goes into the zone return air. Default value is &#x60;0&#x60;. | [optional] [default to 0.0D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

