
# HoneybeeSchema.Model.EnergyWindowMaterialShade

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "EnergyWindowMaterialShade"]
**SolarTransmittance** | **double** | The transmittance averaged over the solar spectrum. It is assumed independent of incidence angle. Default: 0.4. | [optional] [default to 0.4D]
**SolarReflectance** | **double** | The reflectance averaged over the solar spectrum. It us assumed same on both sides of shade and independent of incidence angle. Default value is 0.5 | [optional] [default to 0.5D]
**VisibleTransmittance** | **double** | The transmittance averaged over the solar spectrum and weighted by the response of the human eye. It is assumed independent of incidence angle. Default: 0.4. | [optional] [default to 0.4D]
**VisibleReflectance** | **double** | The transmittance averaged over the solar spectrum and weighted by the response of the human eye. It is assumed independent of incidence angle. Default: 0.4 | [optional] [default to 0.4D]
**Emissivity** | **double** | The effective long-wave infrared hemispherical emissivity. It is assumed same on both sides of shade. Default: 0.9. | [optional] [default to 0.9D]
**InfraredTransmittance** | **double** | The effective long-wave transmittance. It is assumed independent of incidence angle. Default: 0. | [optional] [default to 0D]
**Thickness** | **double** | The thickness of the shade material in meters. Default: 0.005. | [optional] [default to 0.005D]
**Conductivity** | **double** | The conductivity of the shade material in W/(m-K). Default value is 0.1. | [optional] [default to 0.1D]
**DistanceToGlass** | **double** | The distance from shade to adjacent glass in meters. Default value is 0.05 | [optional] [default to 0.05D]
**TopOpeningMultiplier** | **double** | The effective area for air flow at the top of the shade, divided by the horizontal area between glass and shade. Default: 0.5. | [optional] [default to 0.5D]
**BottomOpeningMultiplier** | **double** | The effective area for air flow at the bottom of the shade, divided by the horizontal area between glass and shade. Default: 0.5. | [optional] [default to 0.5D]
**LeftOpeningMultiplier** | **double** | The effective area for air flow at the left side of the shade, divided by the vertical area between glass and shade. Default: 0.5. | [optional] [default to 0.5D]
**RightOpeningMultiplier** | **double** | The effective area for air flow at the right side of the shade, divided by the vertical area between glass and shade. Default: 0.5. | [optional] [default to 0.5D]
**AirflowPermeability** | **double** | The fraction of the shade surface that is open to air flow. If air cannot pass through the shade material, airflow_permeability &#x3D; 0. Default: 0. | [optional] [default to 0D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

