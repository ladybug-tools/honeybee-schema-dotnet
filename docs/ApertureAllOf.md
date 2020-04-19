
# HoneybeeSchema.Model.ApertureAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "Aperture"]
**Geometry** | [**Face3D**](Face3D.md) | Planar Face3D for the geometry. | 
**BoundaryCondition** | [**AnyOfOutdoorsSurface**](AnyOfOutdoorsSurface.md) |  | 
**IsOperable** | **bool** | Boolean to note whether the Aperture can be opened for ventilation. | [optional] [default to false]
**IndoorShades** | [**List&lt;Shade&gt;**](Shade.md) | Shades assigned to the interior side of this object (eg. window sill, light shelf). | [optional] 
**OutdoorShades** | [**List&lt;Shade&gt;**](Shade.md) | Shades assigned to the exterior side of this object (eg. mullions, louvers). | [optional] 
**Properties** | [**AperturePropertiesAbridged**](AperturePropertiesAbridged.md) | Extension properties for particular simulation engines (Radiance, EnergyPlus). | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

