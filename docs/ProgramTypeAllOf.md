
# HoneybeeSchema.Model.ProgramTypeAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "ProgramType"]
**People** | [**People**](People.md) | People to describe the occupancy of the program. If None, no occupancy will be assumed for the program. | [optional] 
**Lighting** | [**Lighting**](Lighting.md) | Lighting to describe the lighting usage of the program. If None, no lighting will be assumed for the program. | [optional] 
**ElectricEquipment** | [**ElectricEquipment**](ElectricEquipment.md) | ElectricEquipment to describe the usage of electric equipment within the program. If None, no electric equipment will be assumed. | [optional] 
**GasEquipment** | [**GasEquipment**](GasEquipment.md) | GasEquipment to describe the usage of gas equipment within the program. If None, no gas equipment will be assumed. | [optional] 
**Infiltration** | [**Infiltration**](Infiltration.md) | Infiltration to describe the outdoor air leakage of the program. If None, no infiltration will be assumed for the program. | [optional] 
**Ventilation** | [**Ventilation**](Ventilation.md) | Ventilation to describe the minimum outdoor air requirement of the program. If None, no ventilation requirement will be assumed. | [optional] 
**Setpoint** | [**Setpoint**](Setpoint.md) | Setpoint object to describe the temperature and humidity setpoints of the program.  If None, the ProgramType cannot be assigned to a Room that is conditioned. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

