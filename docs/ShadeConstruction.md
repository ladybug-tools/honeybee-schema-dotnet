
# HoneybeeSchema.Model.ShadeConstruction

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "ShadeConstruction"]
**SolarReflectance** | **double** | A number for the solar reflectance of the construction. | [optional] [default to 0.2D]
**VisibleReflectance** | **double** | A number for the visible reflectance of the construction. | [optional] [default to 0.2D]
**IsSpecular** | **bool** | Boolean to note whether the reflection off the shade is diffuse (False) or specular (True). Set to True if the construction is representing a glass facade or a mirror material. | [optional] [default to false]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

