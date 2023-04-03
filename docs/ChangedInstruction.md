
# HoneybeeSchema.Model.ChangedInstruction

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ElementType** | **GeometryObjectTypes** | Text for the type of object that has been changed. | 
**ElementId** | **string** | Text string for the unique object ID that has changed. | 
**ElementName** | **string** | Text string for the display name of the object that has changed. | [optional] 
**UpdateGeometry** | **bool** | A boolean to note whether the geometry of the object in the new/updated model should replace the base/existing geometry (True) or the existing geometry should be kept (False). | [optional] [default to true]
**UpdateEnergy** | **bool** | A boolean to note whether the energy properties of the object in the new/updated model should replace the base/existing energy properties (True) or the base/existing energy properties should be kept (False). | [optional] [default to true]
**UpdateRadiance** | **bool** | A boolean to note whether the radiance properties of the object in the new/updated model should replace the base/existing radiance properties (True) or the base/existing radiance properties should be kept (False). | [optional] [default to true]
**Type** | **string** |  | [optional] [readonly] [default to "ChangedInstruction"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

