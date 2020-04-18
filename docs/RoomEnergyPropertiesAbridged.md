
# HoneybeeSchema.Model.RoomEnergyPropertiesAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "RoomEnergyPropertiesAbridged"]
**ConstructionSet** | **string** | Identifier of a ConstructionSet to specify all default constructions for the Faces, Apertures, and Doors of the Room. If None, the Room will use the Model global_construction_set. | [optional] 
**ProgramType** | **string** | Identifier of a ProgramType to specify all default schedules and loads for the Room. If None, the Room will have no loads or setpoints. | [optional] 
**Hvac** | **string** | An optional identifier of a HVAC system (such as an IdealAirSystem) that specifies how the Room is conditioned. If None, it will be assumed that the Room is not conditioned. | [optional] 
**People** | [**PeopleAbridged**](PeopleAbridged.md) | People object to describe the occupancy of the Room. | [optional] 
**Lighting** | [**LightingAbridged**](LightingAbridged.md) | Lighting object to describe the lighting usage of the Room. | [optional] 
**ElectricEquipment** | [**ElectricEquipmentAbridged**](ElectricEquipmentAbridged.md) | ElectricEquipment object to describe the electric equipment usage. | [optional] 
**GasEquipment** | [**GasEquipmentAbridged**](GasEquipmentAbridged.md) | GasEquipment object to describe the gas equipment usage. | [optional] 
**Infiltration** | [**InfiltrationAbridged**](InfiltrationAbridged.md) | Infiltration object to to describe the outdoor air leakage. | [optional] 
**Ventilation** | [**VentilationAbridged**](VentilationAbridged.md) | Ventilation object for the minimum outdoor air requirement. | [optional] 
**Setpoint** | [**SetpointAbridged**](SetpointAbridged.md) | Setpoint object for the temperature setpoints of the Room. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

