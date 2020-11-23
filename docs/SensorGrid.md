
# HoneybeeSchema.Model.SensorGrid

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "SensorGrid"]
**Identifier** | **string** | Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files. | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**RoomIdentifier** | **string** | Optional text string for the Room identifier to which this object belongs. This will be used to narrow down the number of aperture groups that have to be run with this sensor grid. If None, the grid will be run with all aperture groups in the model. | [optional] 
**LightPath** | **List&lt;List&lt;string&gt;&gt;** | Get or set a list of lists for the light path from the object to the sky. Each sub-list contains identifiers of aperture groups through which light passes. (eg. [[\&quot;SouthWindow1\&quot;], [\&quot;static_apertures\&quot;, \&quot;NorthWindow2\&quot;]]).Setting this property will override any auto-calculation of the light path from the model and room_identifier upon export to the simulation. | [optional] 
**Sensors** | [**List&lt;Sensor&gt;**](Sensor.md) | A list of sensors that belong to the grid. | 
**Mesh** | [**Mesh3D**](Mesh3D.md) | An optional Mesh3D that aligns with the sensors and can be used for visualization of the grid. Note that the number of sensors in the grid must match the number of faces or the number vertices within the Mesh3D. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

