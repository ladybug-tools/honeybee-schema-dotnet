
# HoneybeeDotNet.Model.EnergyWindowMaterialShade

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Name of the object. Must use only ASCII characters and exclude (, ; ! \\n \\t). It cannot be longer than 100 characters. | 
**Type** | **string** |  | [optional] [default to "EnergyWindowMaterialShade"]
**SolarTransmittance** | **double** | The transmittance averaged over the solar spectrum. It is assumed independent of incidence angle. Default value is 0.4. | [optional] [default to 0.4M]
**SolarReflectance** | **double** | The reflectance averaged over the solar spectrum. It us assumed same on both sides of shade and independent of incidence angle. Default value is 0.5 | [optional] [default to 0.5M]
**VisibleTransmittance** | **double** | The transmittance averaged over the solar spectrum and weighted by the response of the human eye. It is assumed independent of incidence angle. Default value is 0.4. | [optional] [default to 0.4M]
**VisibleReflectance** | **double** | The transmittance averaged over the solar spectrum and weighted by the response of the human eye. It is assumed independent of incidence angle. Default value is 0.4 | [optional] [default to 0.4M]
**Emissivity** | **double** | The effective long-wave infrared hemispherical emissivity. It is assumed same on both sides of shade. Default value is 0.9. | [optional] [default to 0.9M]
**InfraredTransmittance** | **double** | The effective long-wave transmittance. It is assumed independent of incidence angle. Default value is 0. | [optional] [default to 0M]
**Thickness** | **double** | The thickness of the shade material in meters. Default value is 0.005. | [optional] [default to 0.005M]
**Conductivity** | **double** | The conductivity of the shade material in W/(m-K). Default value is 0.1. | [optional] [default to 0.1M]
**DistanceToGlass** | **double** | The distance from shade to adjacent glass in meters. Default value is 0.05 | [optional] [default to 0.05M]
**TopOpeningMultiplier** | **double** | The effective area for air flow at the top of the shade, divided by the horizontal area between glass and shade. Default value is 0.5. | [optional] [default to 0.5M]
**BottomOpeningMultiplier** | **double** | The effective area for air flow at the bottom of the shade, divided by the horizontal area between glass and shade. Default value is 0.5. | [optional] [default to 0.5M]
**LeftOpeningMultiplier** | **double** | The effective area for air flow at the left side of the shade, divided by the vertical area between glass and shade. Default value is 0.5. | [optional] [default to 0.5M]
**RightOpeningMultiplier** | **double** | The effective area for air flow at the right side of the shade, divided by the vertical area between glass and shade. Default value is 0.5. | [optional] [default to 0.5M]
**AirflowPermeability** | **double** | The fraction of the shade surface that is open to air flow. If air cannot pass through the shade material, airflow_permeability &#x3D; 0. Default value is 0. | [optional] [default to 0M]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

