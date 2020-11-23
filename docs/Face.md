
# HoneybeeSchema.Model.Face

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "Face"]
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, rad). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters and not contain any spaces or special characters. | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Geometry** | [**Face3D**](Face3D.md) | Planar Face3D for the geometry. | 
**FaceType** | **FaceType** |  | 
**BoundaryCondition** | [**AnyOfGroundOutdoorsAdiabaticSurface**](AnyOfGroundOutdoorsAdiabaticSurface.md) |  | 
**Properties** | [**FacePropertiesAbridged**](FacePropertiesAbridged.md) | Extension properties for particular simulation engines (Radiance, EnergyPlus). | 
**Apertures** | [**List&lt;Aperture&gt;**](Aperture.md) | Apertures assigned to this Face. Should be coplanar with this Face and completely within the boundary of the Face to be valid. | [optional] 
**Doors** | [**List&lt;Door&gt;**](Door.md) | Doors assigned to this Face. Should be coplanar with this Face and completely within the boundary of the Face to be valid. | [optional] 
**IndoorShades** | [**List&lt;Shade&gt;**](Shade.md) | Shades assigned to the interior side of this object. | [optional] 
**OutdoorShades** | [**List&lt;Shade&gt;**](Shade.md) | Shades assigned to the exterior side of this object (eg. balcony, overhang). | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

