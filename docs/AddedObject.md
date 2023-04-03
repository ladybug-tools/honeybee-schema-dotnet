
# HoneybeeSchema.Model.AddedObject

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ElementType** | **GeometryObjectTypes** | Text for the type of object that has been changed. | 
**ElementId** | **string** | Text string for the unique object ID that has changed. | 
**Geometry** | **List&lt;Object&gt;** | A list of DisplayFace3D dictionaries for the added geometry. The schema of DisplayFace3D can be found in the ladybug-display-schema documentation (https://www.ladybug.tools/ladybug-display-schema) and these objects can be used to generate visualizations of individual objects that have been added. | 
**ElementName** | **string** | Text string for the display name of the object that has changed. | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "AddedObject"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

