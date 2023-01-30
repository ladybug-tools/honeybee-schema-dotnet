
# HoneybeeSchema.Model.SHWSystem

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "SHWSystem"]
**EquipmentType** | **SHWEquipmentType** | Text to indicate the type of air-side economizer used on the ideal air system. Economizers will mix in a greater amount of outdoor air to cool the zone (rather than running the cooling system) when the zone needs cooling and the outdoor air is cooler than the zone. | [optional] 
**HeaterEfficiency** | [**AnyOfnumberAutocalculate**](AnyOfnumberAutocalculate.md) | A number for the efficiency of the heater within the system. For Gas systems, this is the efficiency of the burner. For HeatPump systems, this is the rated COP of the system. For electric systems, this should usually be set to 1. If set to Autocalculate, this value will automatically be set based on the equipment_type. Gas_WaterHeater - 0.8, Electric_WaterHeater - 1.0, HeatPump_WaterHeater - 3.5, Gas_TanklessHeater - 0.8, Electric_TanklessHeater - 1.0. | [optional] 
**AmbientCondition** | [**AnyOfnumberstring**](AnyOfnumberstring.md) | A number for the ambient temperature in which the hot water tank is located [C]. This can also be the identifier of a Room in which the tank is located. | [optional] 
**AmbientLossCoefficient** | **double** | A number for the loss of heat from the water heater tank to the surrounding ambient conditions [W/K]. | [optional] [default to 6D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

