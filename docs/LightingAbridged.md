
# HoneybeeSchema.Model.LightingAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**WattsPerArea** | **double** | Lighting per floor area as [W/m2]. | 
**Schedule** | **string** | Identifier of the schedule for the use of lights over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts_per_area to yield a complete lighting profile. | 
**Type** | **string** |  | [optional] [readonly] [default to "LightingAbridged"]
**VisibleFraction** | **double** | The fraction of heat from lights that goes into the zone as visible (short-wave) radiation. (Default: 0.25). | [optional] [default to 0.25D]
**RadiantFraction** | **double** | The fraction of heat from lights that is long-wave radiation. (Default: 0.32). | [optional] [default to 0.32D]
**ReturnAirFraction** | **double** | The fraction of the heat from lights that goes into the zone return air. (Default: 0). | [optional] [default to 0.0D]
**BaselineWattsPerArea** | **double** | The baseline lighting power density in [W/m2] of floor area. This baseline is useful to track how much better the installed lights are in comparison to a standard like ASHRAE 90.1. If set to None, it will default to 11.84029 W/m2, which is that ASHRAE 90.1-2004 baseline for an office. | [optional] [default to 11.84029D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

