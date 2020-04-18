
# HoneybeeSchema.Model.Model

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, rad). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters and not contain any spaces or special characters. | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**UserData** | [**Object**](.md) | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "Model"]
**Rooms** | [**List&lt;Room&gt;**](Room.md) | A list of Rooms in the model. | [optional] 
**OrphanedFaces** | [**List&lt;Face&gt;**](Face.md) | A list of Faces in the model that lack a parent Room. Note that orphaned Faces are not acceptable for Models that are to be exported for energy simulation. | [optional] 
**OrphanedShades** | [**List&lt;Shade&gt;**](Shade.md) | A list of Shades in the model that lack a parent. | [optional] 
**OrphanedApertures** | [**List&lt;Aperture&gt;**](Aperture.md) | A list of Apertures in the model that lack a parent Face. Note that orphaned Apertures are not acceptable for Models that are to be exported for energy simulation. | [optional] 
**OrphanedDoors** | [**List&lt;Door&gt;**](Door.md) | A list of Doors in the model that lack a parent Face. Note that orphaned Doors are not acceptable for Models that are to be exported for energy simulation. | [optional] 
**NorthAngle** | **double** | The clockwise north direction in degrees. | [optional] [default to 0D]
**Units** | **string** | Text indicating the units in which the model geometry exists. This is used to scale the geometry to the correct units for simulation engines like EnergyPlus, which requires all geometry be in meters. | [optional] [default to UnitsEnum.Meters]
**Tolerance** | **double** | The maximum difference between x, y, and z values at which vertices are considered equivalent. This value should be in the Model units and it is used in a variety of checks, including checks for whether Room faces form a closed volume and subsequently correcting all face normals point outward from the Room. A value of 0 will result in no attempt to evaluate whether Room volumes are closed or check face direction. So it is recommended that this always be a positive number when such checks have not been performed on a Model. Typical tolerances for builing geometry range from 0.1 to 0.0001 depending on the units of the geometry. | [optional] [default to 0D]
**AngleTolerance** | **double** | The max angle difference in degrees that vertices are allowed to differ from one another in order to consider them colinear. This value is used in a variety of checks, including checks for whether Room faces form a closed volume and subsequently correcting all face normals point outward from the Room. A value of 0 will result in no attempt to evaluate whether the Room volumes is closed or check face direction. So it is recommended that this always be a positive number when such checks have not been performed on a given Model. Typical tolerances for builing geometry are often around 1 degree. | [optional] [default to 0D]
**Properties** | [**ModelProperties**](ModelProperties.md) | Extension properties for particular simulation engines (Radiance, EnergyPlus). | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

