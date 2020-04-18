
# HoneybeeSchema.Model.ElectricEquipmentAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**WattsPerArea** | **double** | Equipment level per floor area as [W/m2]. | 
**Schedule** | **string** | Identifier of the schedule for the use of equipment over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts_per_area to yield a complete equipment profile. | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**RadiantFraction** | **double** | Number for the amount of long-wave radiation heat given off by electric equipment. Default value is 0. | [optional] [default to 0D]
**LatentFraction** | **double** | Number for the amount of latent heat given off by electricequipment. Default value is 0. | [optional] [default to 0D]
**LostFraction** | **double** | Number for the amount of “lost” heat being given off by equipment. The default value is 0. | [optional] [default to 0D]
**Type** | **string** |  | [optional] [readonly] [default to "ElectricEquipmentAbridged"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

