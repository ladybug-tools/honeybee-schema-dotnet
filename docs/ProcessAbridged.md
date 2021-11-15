
# HoneybeeSchema.Model.ProcessAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Watts** | **double** | A number for the process load power in Watts. | 
**Schedule** | **string** | Identifier of the schedule for the use of the process over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the watts to yield a complete equipment profile. | 
**FuelType** | **FuelTypes** | Text to denote the type of fuel consumed by the process. Using the \&quot;None\&quot; type indicates that no end uses will be associated with the process, only the zone gains. | 
**Type** | **string** |  | [optional] [readonly] [default to "ProcessAbridged"]
**EndUseCategory** | **string** | Text to indicate the end-use subcategory, which will identify the process load in the end use output. For example, “Cooking”, “Clothes Drying”, etc. A new meter for reporting is created for each unique subcategory. | [optional] [default to "Process"]
**RadiantFraction** | **double** | Number for the amount of long-wave radiation heat given off by the process load. Default value is 0. | [optional] [default to 0D]
**LatentFraction** | **double** | Number for the amount of latent heat given off by the process load. Default value is 0. | [optional] [default to 0D]
**LostFraction** | **double** | Number for the amount of “lost” heat being given off by the process load. The default value is 0. | [optional] [default to 0D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

