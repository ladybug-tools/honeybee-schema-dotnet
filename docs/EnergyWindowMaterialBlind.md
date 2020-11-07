
# HoneybeeSchema.Model.EnergyWindowMaterialBlind

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "EnergyWindowMaterialBlind"]
**SlatOrientation** | **SlatOrientation** |  | [optional] 
**SlatWidth** | **double** | The width of slat measured from edge to edge in meters. | [optional] [default to 0.025D]
**SlatSeparation** | **double** | The distance between the front of a slat and the back of the adjacent slat in meters. | [optional] [default to 0.01875D]
**SlatThickness** | **double** | The distance between the faces of a slat in meters. The default value is 0.001. | [optional] [default to 0.001D]
**SlatAngle** | **double** | The angle (degrees) between the glazing outward normal and the slat outward normal where the outward normal points away from the front face of the slat (degrees). The default value is 45. | [optional] [default to 45D]
**SlatConductivity** | **double** | The thermal conductivity of the slat in W/(m-K). Default value is 221. | [optional] [default to 221D]
**BeamSolarTransmittance** | **double** | The beam solar transmittance of the slat, assumed to be independent of angle of incidence on the slat. Any transmitted beam radiation is assumed to be 100% diffuse (i.e., slats are translucent). The default value is 0. | [optional] [default to 0D]
**BeamSolarReflectance** | **double** | The beam solar reflectance of the front side of the slat, it is assumed to be independent of the angle of incidence. Default value is 0.5. | [optional] [default to 0.5D]
**BeamSolarReflectanceBack** | **double** | The beam solar reflectance of the back side of the slat, it is assumed to be independent of the angle of incidence. Default value is 0.5. | [optional] [default to 0.5D]
**DiffuseSolarTransmittance** | **double** | The slat transmittance for hemisperically diffuse solar radiation. Default value is 0. | [optional] [default to 0D]
**DiffuseSolarReflectance** | **double** | The front-side slat reflectance for hemispherically diffuse solar radiation. Default value is 0.5. | [optional] [default to 0.5D]
**DiffuseSolarReflectanceBack** | **double** | The back-side slat reflectance for hemispherically diffuse solar radiation. Default value is 0.5. | [optional] [default to 0.5D]
**BeamVisibleTransmittance** | **double** | The beam visible transmittance of the slat, it is assumed to be independent of the angle of incidence. Default value is 0. | [optional] [default to 0D]
**BeamVisibleReflectance** | **double** | The beam visible reflectance on the front side of the slat, it is assumed to be independent of the angle of incidence. Default value is 0.5. | [optional] [default to 0.5D]
**BeamVisibleReflectanceBack** | **double** | The beam visible reflectance on the back side of the slat, it is assumed to be independent of the angle of incidence. Default value is 0.5. | [optional] [default to 0.5D]
**DiffuseVisibleTransmittance** | **double** | The slat transmittance for hemispherically diffuse visible radiation. This value should equal “Slat Beam Visible Transmittance.” | [optional] [default to 0D]
**DiffuseVisibleReflectance** | **double** | The front-side slat reflectance for hemispherically diffuse visible radiation. This value should equal “Front Side Slat Beam Visible Reflectance.” Default value is 0.5. | [optional] [default to 0.5D]
**DiffuseVisibleReflectanceBack** | **double** | The back-side slat reflectance for hemispherically diffuse visible radiation. This value should equal “Back Side Slat Beam Visible Reflectance. Default value is 0.5.” | [optional] [default to 0.5D]
**InfraredTransmittance** | **double** | The slat infrared hemispherical transmittance. It is zero for solid metallic, wooden or glass slats, but may be non-zero in some cases such as for thin plastic slats. The default value is 0. | [optional] [default to 0D]
**Emissivity** | **double** | Front side hemispherical emissivity of the slat. Default is 0.9 for most materials. The default value is 0.9. | [optional] [default to 0.9D]
**EmissivityBack** | **double** | Back side hemispherical emissivity of the slat. Default is 0.9 for most materials. The default value is 0.9. | [optional] [default to 0.9D]
**DistanceToGlass** | **double** | The distance from the mid-plane of the blind to the adjacent glass in meters. The default value is 0.05. | [optional] [default to 0.05D]
**TopOpeningMultiplier** | **double** | The effective area for air flow at the top of the shade, divided by the horizontal area between glass and shade. The default value is 0.5 | [optional] [default to 0.5D]
**BottomOpeningMultiplier** | **double** | The effective area for air flow at the bottom of the shade, divided by the horizontal area between glass and shade. The default value is 0. | [optional] [default to 0.5D]
**LeftOpeningMultiplier** | **double** | The effective area for air flow at the left side of the shade, divided by the vertical area between glass and shade. The default value is 0.5. | [optional] [default to 0.5D]
**RightOpeningMultiplier** | **double** | The effective area for air flow at the right side of the shade, divided by the vertical area between glass and shade. The default value is 0.5. | [optional] [default to 0.5D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

