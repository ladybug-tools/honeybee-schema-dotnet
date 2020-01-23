
# HoneybeeDotNet.Model.GasEquipmentAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Name of the object. Must use only ASCII characters and exclude (, ; ! \\n \\t). It cannot be longer than 100 characters. | 
**WattsPerArea** | **decimal** | Equipment level per floor area as [W/m2]. | 
**Schedule** | **string** | Name of the schedule for the use of equipment over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts_per_area to yield a complete equipment profile. | 
**RadiantFraction** | **decimal** | Number for the amount of long-wave radiation heat given off by electric equipment. Default value is 0. | [optional] [default to 0M]
**LatentFraction** | [**AnyOfnumberstring**](AnyOfnumberstring.md) | Number for the amount of latent heat given off by electricequipment. Default value is 0. | [optional] 
**LostFraction** | **decimal** | Number for the amount of “lost” heat being given off by equipment. The default value is 0. | [optional] [default to 0M]
**Type** | **string** |  | [optional] [default to "GasEquipmentAbridged"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

