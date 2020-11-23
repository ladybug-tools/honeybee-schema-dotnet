
# HoneybeeSchema.Model.View

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "View"]
**Identifier** | **string** | Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files. | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**RoomIdentifier** | **string** | Optional text string for the Room identifier to which this object belongs. This will be used to narrow down the number of aperture groups that have to be run with this sensor grid. If None, the grid will be run with all aperture groups in the model. | [optional] 
**LightPath** | **List&lt;List&lt;string&gt;&gt;** | Get or set a list of lists for the light path from the object to the sky. Each sub-list contains identifiers of aperture groups through which light passes. (eg. [[\&quot;SouthWindow1\&quot;], [\&quot;static_apertures\&quot;, \&quot;NorthWindow2\&quot;]]).Setting this property will override any auto-calculation of the light path from the model and room_identifier upon export to the simulation. | [optional] 
**Position** | **List&lt;double&gt;** | The view position (-vp) as an array of (x, y, z) values.This is the focal point of a perspective view or the center of a parallel projection. | 
**Direction** | **List&lt;double&gt;** | The view direction (-vd) as an array of (x, y, z) values.The length of this vector indicates the focal distance as needed by the pixel depth of field (-pd) in rpict. | 
**UpVector** | **List&lt;double&gt;** | The view up (-vu) vector as an array of (x, y, z) values. | 
**ViewType** | **ViewType** |  | [optional] 
**HSize** | **double** | A number for the horizontal field of view in degrees (for all perspective projections including fisheye). For a parallel projection, this is the view width in world coordinates. | [optional] [default to 60D]
**VSize** | **double** | A number for the vertical field of view in degrees (for all perspective projections including fisheye). For a parallel projection, this is the view width in world coordinates. | [optional] [default to 60D]
**Shift** | **double** | The view shift (-vs). This is the amount the actual image will be shifted to the right of the specified view. This option is useful for generating skewed perspectives or rendering an image a piece at a time. A value of 1 means that the rendered image starts just to the right of the normal view. A value of -1 would be to the left. Larger or fractional values are permitted as well. | [optional] 
**Lift** | **double** | The view lift (-vl). This is the amount the actual image will be lifted up from the specified view. This option is useful for generating skewed perspectives or rendering an image a piece at a time. A value of 1 means that the rendered image starts just to the right of the normal view. A value of -1 would be to the left. Larger or fractional values are permitted as well. | [optional] 
**ForeClip** | **double** | View fore clip (-vo) at a distance from the view point.The plane will be perpendicular to the view direction for perspective and parallel view types. For fisheye view types, the clipping plane is actually a clipping sphere, centered on the view point with fore_clip radius. Objects in front of this imaginary surface will not be visible. | [optional] 
**AftClip** | **double** | View aft clip (-va) at a distance from the view point.Like the view fore plane, it will be perpendicular to the view direction for perspective and parallel view types. For fisheye view types, the clipping plane is actually a clipping sphere, centered on the view point with radius val. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

