
# HoneybeeSchema.Model.DaylightingControl

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**SensorPosition** | **List&lt;double&gt;** | A point as 3 (x, y, z) values for the position of the daylight sensor within the parent Room. This point should lie within the Room volume in order for the results to be meaningful. | 
**Type** | **string** |  | [optional] [readonly] [default to "DaylightingControl"]
**IlluminanceSetpoint** | **double** | A number for the illuminance setpoint in lux beyond which electric lights are dimmed if there is sufficient daylight. | [optional] [default to 300D]
**ControlFraction** | **double** | A number between 0 and 1 that represents the fraction of the Room lights that are dimmed when the illuminance at the sensor position is at the specified illuminance. 1 indicates that all lights are dim-able while 0 indicates that no lights are dim-able. Deeper rooms should have lower control fractions to account for the face that the lights in the back of the space do not dim in response to suitable daylight at the front of the room. | [optional] [default to 1D]
**MinPowerInput** | **double** | A number between 0 and 1 for the the lowest power the lighting system can dim down to, expressed as a fraction of maximum input power. | [optional] [default to 0.3D]
**MinLightOutput** | **double** | A number between 0 and 1 the lowest lighting output the lighting system can dim down to, expressed as a fraction of maximum light output. | [optional] [default to 0.2D]
**OffAtMinimum** | **bool** | Boolean to note whether lights should switch off completely when they get to the minimum power input. | [optional] [default to false]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

