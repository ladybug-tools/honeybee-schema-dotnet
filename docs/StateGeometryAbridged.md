
# HoneybeeSchema.Model.StateGeometryAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files. | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**Geometry** | [**Face3D**](Face3D.md) | A ladybug_geometry Face3D. | 
**Type** | **string** |  | [optional] [readonly] [default to "StateGeometryAbridged"]
**Modifier** | **string** | A string for a Honeybee Radiance Modifier identifier (default: None). | [optional] 
**ModifierDirect** | **string** | A string for Honeybee Radiance Modifier identifiers to be used in direct solar simulations and in isolation studies (assessingthe contribution of individual objects) (default: None). | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

