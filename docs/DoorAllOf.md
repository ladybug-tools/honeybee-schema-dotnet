
# HoneybeeSchema.Model.DoorAllOf

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "Door"]
**Geometry** | [**Face3D**](Face3D.md) | Planar Face3D for the geometry. | 
**BoundaryCondition** | [**AnyOfOutdoorsSurface**](AnyOfOutdoorsSurface.md) |  | 
**IsGlass** | **bool** | Boolean to note whether this object is a glass door as opposed to an opaque door. | [optional] [default to false]
**IndoorShades** | [**List&lt;Shade&gt;**](Shade.md) | Shades assigned to the interior side of this object. | [optional] 
**OutdoorShades** | [**List&lt;Shade&gt;**](Shade.md) | Shades assigned to the exterior side of this object (eg. entryway awning). | [optional] 
**Properties** | [**DoorPropertiesAbridged**](DoorPropertiesAbridged.md) | Extension properties for particular simulation engines (Radiance, EnergyPlus). | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

