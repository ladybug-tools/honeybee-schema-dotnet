
# HoneybeeSchema.Model.EnergyWindowMaterialGlazing

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "EnergyWindowMaterialGlazing"]
**Thickness** | **double** | The surface-to-surface thickness of the glass in meters. Default:  0.003. | [optional] [default to 0.003D]
**SolarTransmittance** | **double** | Transmittance of solar radiation through the glass at normal incidence. Default: 0.85 for clear glass. | [optional] [default to 0.85D]
**SolarReflectance** | **double** | Reflectance of solar radiation off of the front side of the glass at normal incidence, averaged over the solar spectrum. Default: 0.075 for clear glass. | [optional] [default to 0.075D]
**SolarReflectanceBack** | [**AnyOfAutocalculatedouble**](AnyOfAutocalculatedouble.md) | Reflectance of solar radiation off of the back side of the glass at normal incidence, averaged over the solar spectrum. | [optional] 
**VisibleTransmittance** | **double** | Transmittance of visible light through the glass at normal incidence. Default: 0.9 for clear glass. | [optional] [default to 0.9D]
**VisibleReflectance** | **double** | Reflectance of visible light off of the front side of the glass at normal incidence. Default: 0.075 for clear glass. | [optional] [default to 0.075D]
**VisibleReflectanceBack** | [**AnyOfAutocalculatedouble**](AnyOfAutocalculatedouble.md) | Reflectance of visible light off of the back side of the glass at normal incidence averaged over the solar spectrum and weighted by the response of the human eye. | [optional] 
**InfraredTransmittance** | **double** | Long-wave transmittance at normal incidence. | [optional] [default to 0D]
**Emissivity** | **double** | Infrared hemispherical emissivity of the front (outward facing) side of the glass.  Default: 0.84, which is typical for clear glass without a low-e coating. | [optional] [default to 0.84D]
**EmissivityBack** | **double** | Infrared hemispherical emissivity of the back (inward facing) side of the glass.  Default: 0.84, which is typical for clear glass without a low-e coating. | [optional] [default to 0.84D]
**Conductivity** | **double** | Thermal conductivity of the glass in W/(m-K). Default: 0.9, which is  typical for clear glass without a low-e coating. | [optional] [default to 0.9D]
**DirtCorrection** | **double** | Factor that corrects for the presence of dirt on the glass. A default value of 1 indicates the glass is clean. | [optional] [default to 1D]
**SolarDiffusing** | **bool** | If False (default), the beam solar radiation incident on the glass is transmitted as beam radiation with no diffuse component.If True, the beam  solar radiation incident on the glass is transmitted as hemispherical diffuse radiation with no beam component. | [optional] [default to false]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

