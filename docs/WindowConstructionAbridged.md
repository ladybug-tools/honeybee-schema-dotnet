
# HoneybeeSchema.Model.WindowConstructionAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Materials** | **List&lt;string&gt;** | List of strings for glazing or gas material identifiers. The order of the materials is from exterior to interior. If a SimpleGlazSys material is used, it must be the only material in the construction. For multi-layered constructions, adjacent glass layers must be separated by one and only one gas layer. | 
**Type** | **string** |  | [optional] [readonly] [default to "WindowConstructionAbridged"]
**Frame** | **string** | An optional identifier for a frame material that surrounds the window construction. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

