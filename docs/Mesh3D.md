
# HoneybeeSchema.Model.Mesh3D

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "Mesh3D"]
**Vertices** | **List&lt;List&lt;double&gt;&gt;** | A list of points representing the vertices of the mesh. The list should include at least 3 points and each point should be a list of 3 (x, y, z) values. | 
**Faces** | **List&lt;List&lt;int&gt;&gt;** | A list of lists with each sub-list having either 3 or 4 integers. These integers correspond to indices within the list of vertices. | 
**Colors** | [**List&lt;Color&gt;**](Color.md) | An optional list of colors that correspond to either the faces of the mesh or the vertices of the mesh. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

