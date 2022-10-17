
# HoneybeeSchema.Model.EnergyWindowMaterialSimpleGlazSys

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**UFactor** | **double** | The overall heat transfer coefficient for window system in W/m2-K. Note that constructions with U-values above 5.8 should not be assigned to skylights as this implies the resistance of the window is negative when air films are subtracted. | 
**Shgc** | **double** | Unit-less quantity for the Solar Heat Gain Coefficient (solar transmittance + conduction) at normal incidence and vertical orientation. | 
**Type** | **string** |  | [optional] [readonly] [default to "EnergyWindowMaterialSimpleGlazSys"]
**Vt** | **double** | The fraction of visible light falling on the window that makes it through the glass at normal incidence. | [optional] [default to 0.54D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

