
# HoneybeeSchema.Model.EnergyMaterialVegetation

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "EnergyMaterialVegetation"]
**Roughness** | **Roughness** |  | [optional] 
**Thickness** | **double** | Thickness of the soil layer in meters. | [optional] [default to 0.1D]
**Conductivity** | **double** | Thermal conductivity of the dry soil in W/m-K. | [optional] [default to 0.35D]
**Density** | **double** | Density of the dry soil in kg/m3. | [optional] [default to 1100D]
**SpecificHeat** | **double** | Specific heat of the dry soil in J/kg-K. | [optional] [default to 1200D]
**SoilThermalAbsorptance** | **double** | Fraction of incident long wavelength radiation that is absorbed by the soil. Default: 0.9. | [optional] [default to 0.9D]
**SoilSolarAbsorptance** | **double** | Fraction of incident solar radiation absorbed by the soil. Default: 0.7. | [optional] [default to 0.7D]
**SoilVisibleAbsorptance** | **double** | Fraction of incident visible wavelength radiation absorbed by the material. Default: 0.7. | [optional] [default to 0.7D]
**PlantHeight** | **double** | The height of plants in the vegetation in meters. | [optional] [default to 0.2D]
**LeafAreaIndex** | **double** | The projected leaf area per unit area of soil surface (aka. Leaf Area Index or LAI). Note that the fraction of vegetation cover is calculated directly from LAI using an empirical relation. | [optional] [default to 1.0D]
**LeafReflectivity** | **double** | The fraction of incident solar radiation that is reflected by the leaf surfaces. Solar radiation includes the visible spectrum as well as infrared and ultraviolet wavelengths. Typical values are 0.18 to 0.25. | [optional] [default to 0.22D]
**LeafEmissivity** | **double** | The ratio of thermal radiation emitted from leaf surfaces to that emitted by an ideal black body at the same temperature. | [optional] [default to 0.95D]
**MinStomatalResist** | **double** | The resistance of the plants to moisture transport [s/m]. Plants with low values of stomatal resistance will result in higher evapotranspiration rates than plants with high resistance. | [optional] [default to 180D]
**SatVolMoistCont** | **double** | The saturation moisture content of the soil by volume. | [optional] [default to 0.3D]
**ResidualVolMoistCont** | **double** | The residual moisture content of the soil by volume. | [optional] [default to 0.01D]
**InitVolMoistCont** | **double** | The initial moisture content of the soil by volume. | [optional] [default to 0.01D]
**MoistDiffModel** | **MoistureDiffusionModel** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

