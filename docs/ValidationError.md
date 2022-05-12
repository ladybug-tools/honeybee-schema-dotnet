
# HoneybeeSchema.Model.ValidationError

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Code** | **string** | Text with 6 digits for the error code. The first two digits indicate whether the error is a core honeybee error (00) vs. an extension error (any non-zero number). The second two digits indicate the nature of the error (00 is an identifier error, 01 is a geometry error, 02 is an adjacency error). The third two digits are used to give a unique ID to each condition moving upwards from more specific/detailed objects/errors to coarser/more abstract objects/errors. | 
**ExtensionType** | **ExtensionTypes** | Text for the Honeybee extension from which the error originated (from the ExtensionTypes enumeration). | 
**ElementType** | **ObjectTypes** | Text for the type of object that caused the error. | 
**ElementId** | **string** | Text string for the unique object ID that caused the error. Note that this can be the identifier of a core object like a Room or a Face. Or it can be for an extension object like a SensorGrid or a Construction. | 
**Message** | **string** | Text for the error message with a detailed description of what exactly is ivalid about the element. | 
**Type** | **string** |  | [optional] [readonly] [default to "ValidationError"]
**ElementName** | **string** | Display name of the object that caused the error. | [optional] 
**Parents** | [**List&lt;ValidationParent&gt;**](ValidationParent.md) | A list of the parent objects for the objet that caused the error. This can be useful for locating the problematic object in the model. This will contain 1 item for a Face with a perant Room. It will contain 2 for an Aperture that has a parent Face with a parent Room. | [optional] 
**TopParents** | [**List&lt;ValidationParent&gt;**](ValidationParent.md) | A list of top-level parent objects for the specific case of duplicate child-object identifiers, where several top-level parents are involved. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

