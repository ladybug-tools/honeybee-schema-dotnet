
# HoneybeeSchema.Model.EnergyMaterialAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "EnergyMaterial"]
**Roughness** | **string** |  | [optional] [default to RoughnessEnum.MediumRough]
**Thickness** | **double** | Thickness of the material layer in meters. | 
**Conductivity** | **double** | Thermal conductivity of the material layer in W/(m-K). | 
**Density** | **double** | Density of the material layer in kg/m3. | 
**SpecificHeat** | **double** | Specific heat of the material layer in J/(kg-K). | 
**ThermalAbsorptance** | **double** | Fraction of incident long wavelength radiation that is absorbed by the material. Default value is 0.9. | [optional] [default to 0.9D]
**SolarAbsorptance** | **double** | Fraction of incident solar radiation absorbed by the material. Default value is 0.7. | [optional] [default to 0.7D]
**VisibleAbsorptance** | **double** | Fraction of incident visible wavelength radiation absorbed by the material. Default value is 0.7. | [optional] [default to 0.7D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

