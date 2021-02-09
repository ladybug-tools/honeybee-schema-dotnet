
# HoneybeeSchema.Model.SensorGrid

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Sensors** | [**List&lt;Sensor&gt;**](Sensor.md) | A list of sensors that belong to the grid. | 
**Type** | **string** |  | [optional] [readonly] [default to "SensorGrid"]
**Mesh** | [**Mesh3D**](Mesh3D.md) | An optional Mesh3D that aligns with the sensors and can be used for visualization of the grid. Note that the number of sensors in the grid must match the number of faces or the number vertices within the Mesh3D. | [optional] 
**BaseGeometry** | [**List&lt;Face3D&gt;**](Face3D.md) | An optional array of Face3D used to represent the grid. There are no restrictions on how this property relates to the sensors and it is provided only to assist with the display of the grid when the number of sensors or the mesh is too large to be practically visualized. | [optional] 
**GroupIdentifier** | **string** | An optional string to note the sensor grid group &#39;             &#39;to which the sensor is a part of. Grids sharing the same &#39;             &#39;group_identifier will be written to the same subfolder in Radiance &#39;             &#39;folder (default: None). | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

