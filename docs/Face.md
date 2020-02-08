
# HoneybeeSchema.Model.Face

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Name of the object used in all simulation engines. Must not contain spaces and use only letters, digits and underscores/dashes. It cannot be longer than 100 characters. | 
**Geometry** | [**Face3D**](Face3D.md) | Planar Face3D for the geometry. | 
**FaceType** | **string** |  | 
**BoundaryCondition** | [**AnyOfGroundOutdoorsAdiabaticSurface**](AnyOfGroundOutdoorsAdiabaticSurface.md) |  | 
**Properties** | [**FacePropertiesAbridged**](FacePropertiesAbridged.md) | Extension properties for particular simulation engines (Radiance, EnergyPlus). | 
**DisplayName** | **string** | Display name of the object with no restrictions. | [optional] 
**Type** | **string** |  | [optional] [default to "Face"]
**Apertures** | [**List&lt;Aperture&gt;**](Aperture.md) | Apertures assigned to this Face. Should be coplanar with this Face and completely within the boundary of the Face to be valid. | [optional] 
**Doors** | [**List&lt;Door&gt;**](Door.md) | Doors assigned to this Face. Should be coplanar with this Face and completely within the boundary of the Face to be valid. | [optional] 
**IndoorShades** | [**List&lt;Shade&gt;**](Shade.md) | Shades assigned to the interior side of this object. | [optional] 
**OutdoorShades** | [**List&lt;Shade&gt;**](Shade.md) | Shades assigned to the exterior side of this object (eg. balcony, overhang). | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

