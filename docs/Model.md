
# HoneybeeDotNet.Model.Model

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Name of the object used in all simulation engines. Must not contain spaces and use only letters, digits and underscores/dashes. It cannot be longer than 100 characters. | 
**Properties** | [**ModelProperties**](ModelProperties.md) | Extension properties for particular simulation engines (Radiance, EnergyPlus). | 
**DisplayName** | **string** | Display name of the object with no restrictions. | [optional] 
**Type** | **string** |  | [optional] [default to "Model"]
**Rooms** | [**List&lt;Room&gt;**](Room.md) | A list of Rooms in the model. | [optional] 
**OrphanedFaces** | [**List&lt;Face&gt;**](Face.md) | A list of Faces in the model that lack a parent Room. Note that orphaned Faces are not acceptable for Models that are to be exported for energy simulation. | [optional] 
**OrphanedShades** | [**List&lt;Shade&gt;**](Shade.md) | A list of Shades in the model that lack a parent. | [optional] 
**OrphanedApertures** | [**List&lt;Aperture&gt;**](Aperture.md) | A list of Apertures in the model that lack a parent Face. Note that orphaned Apertures are not acceptable for Models that are to be exported for energy simulation. | [optional] 
**OrphanedDoors** | [**List&lt;Door&gt;**](Door.md) | A list of Doors in the model that lack a parent Face. Note that orphaned Doors are not acceptable for Models that are to be exported for energy simulation. | [optional] 
**NorthAngle** | **double** | The clockwise north direction in degrees. | [optional] [default to 0M]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

