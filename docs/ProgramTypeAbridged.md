
# HoneybeeSchema.Model.ProgramTypeAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "ProgramTypeAbridged"]
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**People** | [**PeopleAbridged**](PeopleAbridged.md) | People to describe the occupancy of the program. If None, no occupancy will be assumed for the program. | [optional] 
**Lighting** | [**LightingAbridged**](LightingAbridged.md) | Lighting to describe the lighting usage of the program. If None, no lighting will be assumed for the program. | [optional] 
**ElectricEquipment** | [**ElectricEquipmentAbridged**](ElectricEquipmentAbridged.md) | ElectricEquipment to describe the usage of electric equipment within the program. If None, no electric equipment will be assumed. | [optional] 
**GasEquipment** | [**GasEquipmentAbridged**](GasEquipmentAbridged.md) | GasEquipment to describe the usage of gas equipment within the program. If None, no gas equipment will be assumed. | [optional] 
**Infiltration** | [**InfiltrationAbridged**](InfiltrationAbridged.md) | Infiltration to describe the outdoor air leakage of the program. If None, no infiltration will be assumed for the program. | [optional] 
**Ventilation** | [**VentilationAbridged**](VentilationAbridged.md) | Ventilation to describe the minimum outdoor air requirement of the program. If None, no ventilation requirement will be assumed. | [optional] 
**Setpoint** | [**SetpointAbridged**](SetpointAbridged.md) | Setpoint object to describe the temperature and humidity setpoints of the program.  If None, the ProgramType cannot be assigned to a Room that is conditioned. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

