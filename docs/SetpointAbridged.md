
# HoneybeeSchema.Model.SetpointAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**CoolingSchedule** | **string** | Identifier of the schedule for the cooling setpoint. The values in this schedule should be temperature in [C]. | 
**HeatingSchedule** | **string** | Identifier of the schedule for the heating setpoint. The values in this schedule should be temperature in [C]. | 
**Type** | **string** |  | [optional] [readonly] [default to "SetpointAbridged"]
**HumidifyingSchedule** | **string** | Identifier of the schedule for the humidification setpoint. The values in this schedule should be in [%]. | [optional] 
**DehumidifyingSchedule** | **string** | Identifier of the schedule for the dehumidification setpoint. The values in this schedule should be in [%]. | [optional] 
**SetpointCutoutDifference** | **double** | An optional positive number for the temperature difference between the cutout temperature and the setpoint temperature. Specifying a non-zero number here is useful for modeling the throttling range associated with a given setup of setpoint controls and HVAC equipment. Throttling ranges describe the range where a zone is slightly over-cooled or over-heated beyond the thermostat setpoint. They are used to avoid situations where HVAC systems turn on only to turn off a few minutes later, thereby wearing out the parts of mechanical systems faster. They can have a minor impact on energy consumption and can often have significant impacts on occupant thermal comfort, though using the default value of zero will often yield results that are close enough when trying to estimate the annual heating/cooling energy use. Specifying a value of zero effectively assumes that the system will turn on whenever conditions are outside the setpoint range and will cut out as soon as the setpoint is reached. | [optional] [default to 0D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

