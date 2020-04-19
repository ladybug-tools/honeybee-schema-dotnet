
# HoneybeeSchema.Model.EnergyMaterial

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**Thickness** | **double** | Thickness of the material layer in meters. | [optional] 
**Conductivity** | **double** | Thermal conductivity of the material layer in W/(m-K). | [optional] 
**Density** | **double** | Density of the material layer in kg/m3. | [optional] 
**SpecificHeat** | **double** | Specific heat of the material layer in J/(kg-K). | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "EnergyMaterial"]
**Roughness** | **string** |  | [optional] [default to RoughnessEnum.MediumRough]
**ThermalAbsorptance** | **double** | Fraction of incident long wavelength radiation that is absorbed by the material. Default value is 0.9. | [optional] [default to 0.9D]
**SolarAbsorptance** | **double** | Fraction of incident solar radiation absorbed by the material. Default value is 0.7. | [optional] [default to 0.7D]
**VisibleAbsorptance** | **double** | Fraction of incident visible wavelength radiation absorbed by the material. Default value is 0.7. | [optional] [default to 0.7D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

