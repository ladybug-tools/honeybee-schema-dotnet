
# HoneybeeSchema.Model.ElectricEquipment

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**WattsPerArea** | **double** | Equipment level per floor area as [W/m2]. | 
**Schedule** | [**AnyOfScheduleRulesetScheduleFixedInterval**](AnyOfScheduleRulesetScheduleFixedInterval.md) | The schedule for the use of equipment over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts_per_area to yield a complete equipment profile. | 
**RadiantFraction** | **double** | Number for the amount of long-wave radiation heat given off by equipment. Default value is 0. | [optional] [default to 0D]
**LatentFraction** | **double** | Number for the amount of latent heat given off by equipment. Default value is 0. | [optional] [default to 0D]
**LostFraction** | **double** | Number for the amount of “lost” heat being given off by equipment. The default value is 0. | [optional] [default to 0D]
**Type** | **string** |  | [optional] [readonly] [default to "ElectricEquipment"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

