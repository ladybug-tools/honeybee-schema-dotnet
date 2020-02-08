
# HoneybeeSchema.Model.EnergyWindowMaterialBlind

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Name of the object. Must use only ASCII characters and exclude (, ; ! \\n \\t). It cannot be longer than 100 characters. | 
**Type** | **string** |  | [optional] [default to "EnergyWindowMaterialBlind"]
**SlatOrientation** | **string** |  | [optional] [default to SlatOrientationEnum.Horizontal]
**SlatWidth** | **double** | The width of slat measured from edge to edge in meters. | [optional] [default to 0.025M]
**SlatSeparation** | **double** | The distance between the front of a slat and the back of the adjacent slat in meters. | [optional] [default to 0.01875M]
**SlatThickness** | **double** | The distance between the faces of a slat in meters. The default value is 0.001. | [optional] [default to 0.001M]
**SlatAngle** | **double** | The angle (degrees) between the glazing outward normal and the slat outward normal where the outward normal points away from the front face of the slat (degrees). The default value is 45. | [optional] [default to 45M]
**SlatConductivity** | **double** | The thermal conductivity of the slat in W/(m-K). Default value is 221. | [optional] [default to 221M]
**BeamSolarTransmittance** | **double** | The beam solar transmittance of the slat, assumed to be independent of angle of incidence on the slat. Any transmitted beam radiation is assumed to be 100% diffuse (i.e., slats are translucent). The default value is 0. | [optional] [default to 0M]
**BeamSolarReflectance** | **double** | The beam solar reflectance of the front side of the slat, it is assumed to be independent of the angle of incidence. Default value is 0.5. | [optional] [default to 0.5M]
**BeamSolarReflectanceBack** | **double** | The beam solar reflectance of the back side of the slat, it is assumed to be independent of the angle of incidence. Default value is 0.5. | [optional] [default to 0.5M]
**DiffuseSolarTransmittance** | **double** | The slat transmittance for hemisperically diffuse solar radiation. Default value is 0. | [optional] [default to 0M]
**DiffuseSolarReflectance** | **double** | The front-side slat reflectance for hemispherically diffuse solar radiation. Default value is 0.5. | [optional] [default to 0.5M]
**DiffuseSolarReflectanceBack** | **double** | The back-side slat reflectance for hemispherically diffuse solar radiation. Default value is 0.5. | [optional] [default to 0.5M]
**BeamVisibleTransmittance** | **double** | The beam visible transmittance of the slat, it is assumed to be independent of the angle of incidence. Default value is 0. | [optional] [default to 0M]
**BeamVisibleReflectance** | **double** | The beam visible reflectance on the front side of the slat, it is assumed to be independent of the angle of incidence. Default value is 0.5. | [optional] [default to 0.5M]
**BeamVisibleReflectanceBack** | **double** | The beam visible reflectance on the back side of the slat, it is assumed to be independent of the angle of incidence. Default value is 0.5. | [optional] [default to 0.5M]
**DiffuseVisibleTransmittance** | **double** | The slat transmittance for hemispherically diffuse visible radiation. This value should equal “Slat Beam Visible Transmittance.” | [optional] [default to 0M]
**DiffuseVisibleReflectance** | **double** | The front-side slat reflectance for hemispherically diffuse visible radiation. This value should equal “Front Side Slat Beam Visible Reflectance.” Default value is 0.5. | [optional] [default to 0.5M]
**DiffuseVisibleReflectanceBack** | **double** | The back-side slat reflectance for hemispherically diffuse visible radiation. This value should equal “Back Side Slat Beam Visible Reflectance. Default value is 0.5.” | [optional] [default to 0.5M]
**InfraredTransmittance** | **double** | The slat infrared hemispherical transmittance. It is zero for solid metallic, wooden or glass slats, but may be non-zero in some cases such as for thin plastic slats. The default value is 0. | [optional] [default to 0M]
**Emissivity** | **double** | Front side hemispherical emissivity of the slat. Default is 0.9 for most materials. The default value is 0.9. | [optional] [default to 0.9M]
**EmissivityBack** | **double** | Back side hemispherical emissivity of the slat. Default is 0.9 for most materials. The default value is 0.9. | [optional] [default to 0.9M]
**DistanceToGlass** | **double** | The distance from the mid-plane of the blind to the adjacent glass in meters. The default value is 0.05. | [optional] [default to 0.05M]
**TopOpeningMultiplier** | **double** | The effective area for air flow at the top of the shade, divided by the horizontal area between glass and shade. The default value is 0.5 | [optional] [default to 0.5M]
**BottomOpeningMultiplier** | **double** | The effective area for air flow at the bottom of the shade, divided by the horizontal area between glass and shade. The default value is 0. | [optional] [default to 0.5M]
**LeftOpeningMultiplier** | **double** | The effective area for air flow at the left side of the shade, divided by the vertical area between glass and shade. The default value is 0.5. | [optional] [default to 0.5M]
**RightOpeningMultiplier** | **double** | The effective area for air flow at the right side of the shade, divided by the vertical area between glass and shade. The default value is 0.5. | [optional] [default to 0.5M]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

