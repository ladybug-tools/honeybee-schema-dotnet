
# HoneybeeDotNet.Model.ShadeConstruction

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Name of the object. Must use only ASCII characters and exclude (, ; ! \\n \\t). It cannot be longer than 100 characters. | 
**Type** | **string** |  | [optional] [default to "ShadeConstruction"]
**SolarReflectance** | **decimal** |  A number for the solar reflectance of the construction. | [optional] [default to 0.2M]
**VisibleReflectance** | **decimal** |  A number for the visible reflectance of the construction. | [optional] [default to 0.2M]
**IsSpecular** | **bool** | Boolean to note whether the reflection off the shade is diffuse (False) or specular (True). Set to True if the construction is representing a glass facade or a mirror material. | [optional] [default to false]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

