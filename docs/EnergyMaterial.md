
# HoneybeeSchema.Model.EnergyMaterial

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Thickness** | **double** | Thickness of the material layer in meters. | 
**Conductivity** | **double** | Thermal conductivity of the material layer in W/m-K. | 
**Density** | **double** | Density of the material layer in kg/m3. | 
**SpecificHeat** | **double** | Specific heat of the material layer in J/kg-K. | 
**Type** | **string** |  | [optional] [readonly] [default to "EnergyMaterial"]
**Roughness** | **Roughness** |  | [optional] 
**ThermalAbsorptance** | **double** | Fraction of incident long wavelength radiation that is absorbed by the material. Default: 0.9. | [optional] [default to 0.9D]
**SolarAbsorptance** | **double** | Fraction of incident solar radiation absorbed by the material. Default: 0.7. | [optional] [default to 0.7D]
**VisibleAbsorptance** | **double** | Fraction of incident visible wavelength radiation absorbed by the material. Default: 0.7. | [optional] [default to 0.7D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

