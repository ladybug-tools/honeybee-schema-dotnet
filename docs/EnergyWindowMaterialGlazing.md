
# HoneybeeSchema.Model.EnergyWindowMaterialGlazing

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Name of the object. Must use only ASCII characters and exclude (, ; ! \\n \\t). It cannot be longer than 100 characters. | 
**Type** | **string** |  | [optional] [default to "EnergyWindowMaterialGlazing"]
**Thickness** | **double** | The surface-to-surface of the glass in meters. Default value is 0.003. | [optional] [default to 0.003M]
**SolarTransmittance** | **double** | Transmittance of solar radiation through the glass at normal incidence. Default value is 0.85 for clear glass. | [optional] [default to 0.85M]
**SolarReflectance** | **double** | Reflectance of solar radiation off of the front side of the glass at normal incidence, averaged over the solar spectrum. Default value is 0.075 for clear glass. | [optional] [default to 0.075M]
**SolarReflectanceBack** | **double** | Reflectance of solar radiation off of the back side of the glass at normal incidence, averaged over the solar spectrum. | [optional] 
**VisibleTransmittance** | **double** | Transmittance of visible light through the glass at normal incidence. Default value is 0.9 for clear glass. | [optional] [default to 0.9M]
**VisibleReflectance** | **double** | Reflectance of visible light off of the front side of the glass at normal incidence. Default value is 0.075 for clear glass. | [optional] [default to 0.075M]
**VisibleReflectanceBack** | **double** | Reflectance of visible light off of the back side of the glass at normal incidence averaged over the solar spectrum and weighted by the response of the human eye. | [optional] 
**InfraredTransmittance** | **double** | Long-wave transmittance at normal incidence. | [optional] [default to 0M]
**Emissivity** | **double** | Infrared hemispherical emissivity of the front (outward facing) side of the glass.  Default value is 0.84, which is typical for clear glass without a low-e coating. | [optional] [default to 0.84M]
**EmissivityBack** | **double** | Infrared hemispherical emissivity of the back (inward facing) side of the glass.  Default value is 0.84, which is typical for clear glass without a low-e coating. | [optional] [default to 0.84M]
**Conductivity** | **double** | Thermal conductivity of the glass in W/(m-K). Default value is 0.9, which is  typical for clear glass without a low-e coating. | [optional] [default to 0.9M]
**DirtCorrection** | **double** | Factor that corrects for the presence of dirt on the glass. A default value of 1 indicates the glass is clean. | [optional] [default to 1M]
**SolarDiffusing** | **bool** | Takes values True and False. If False (default), the beam solar radiation incident on the glass is transmitted as beam radiation with no diffuse component.If True, the beam  solar radiation incident on the glass is transmitted as hemispherical diffuse radiation with no beam component. | [optional] [default to false]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

