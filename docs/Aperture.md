
# HoneybeeSchema.Model.Aperture

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Name of the object used in all simulation engines. Must not contain spaces and use only letters, digits and underscores/dashes. It cannot be longer than 100 characters. | 
**Geometry** | [**Face3D**](Face3D.md) | Planar Face3D for the geometry. | 
**BoundaryCondition** | [**AnyOfOutdoorsSurface**](AnyOfOutdoorsSurface.md) |  | 
**Properties** | [**AperturePropertiesAbridged**](AperturePropertiesAbridged.md) | Extension properties for particular simulation engines (Radiance, EnergyPlus). | 
**DisplayName** | **string** | Display name of the object with no restrictions. | [optional] 
**Type** | **string** |  | [optional] [default to "Aperture"]
**IsOperable** | **bool** | Boolean to note whether the Aperture can be opened for ventilation. | [optional] [default to false]
**IndoorShades** | [**List&lt;Shade&gt;**](Shade.md) | Shades assigned to the interior side of this object (eg. window sill, light shelf). | [optional] 
**OutdoorShades** | [**List&lt;Shade&gt;**](Shade.md) | Shades assigned to the exterior side of this object (eg. mullions, louvers). | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

