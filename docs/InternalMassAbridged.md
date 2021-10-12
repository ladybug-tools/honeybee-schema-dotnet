
# HoneybeeSchema.Model.InternalMassAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Construction** | **string** | Identifier for an OpaqueConstruction that represents the material that the internal thermal mass is composed of. | 
**Area** | **double** | A number representing the surface area of the internal mass that is exposed to the Room air. This value should always be in square meters regardless of what units system the parent model is a part of. | 
**Type** | **string** |  | [optional] [readonly] [default to "InternalMassAbridged"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

