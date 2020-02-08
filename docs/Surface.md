
# HoneybeeSchema.Model.Surface

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**BoundaryConditionObjects** | **List&lt;string&gt;** | A list of up to 3 object names that are adjacent to this one. The first object is always the one that is immediately adjacet and is of the same object type (Face, Aperture, Door). When this boundary condition is applied to a Face, the second object in the tuple will be the parent Room of the adjacent object. When the boundary condition is applied to a sub-face (Door or Aperture), the second object will be the parent Face of the adjacent sub-face and the third object will be the parent Room of the adjacent sub-face. | 
**Type** | **string** |  | [optional] [default to "Surface"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

