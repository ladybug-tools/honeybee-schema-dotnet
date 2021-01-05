
# HoneybeeSchema.Model.Face3D

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Boundary** | **List&lt;List&lt;double&gt;&gt;** | A list of points representing the outer boundary vertices of the face. The list should include at least 3 points and each point should be a list of 3 (x, y, z) values. | 
**Type** | **string** |  | [optional] [readonly] [default to "Face3D"]
**Holes** | **List&lt;List&lt;List&lt;double&gt;&gt;&gt;** | Optional list of lists with one list for each hole in the face.Each hole should be a list of at least 3 points and each point a list of 3 (x, y, z) values. If None, it will be assumed that there are no holes in the face. | [optional] 
**Plane** | [**Plane**](Plane.md) | Optional Plane indicating the plane in which the face exists.If None, the plane will usually be derived from the boundary points. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

