
# HoneybeeSchema.Model.ConstructionSetAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**Type** | **string** |  | [optional] [default to "ConstructionSetAbridged"]
**WallSet** | [**WallSetAbridged**](WallSetAbridged.md) | A WallSet object for this ConstructionSet. | [optional] 
**FloorSet** | [**FloorSetAbridged**](FloorSetAbridged.md) | A FloorSet object for this ConstructionSet. | [optional] 
**RoofCeilingSet** | [**RoofCeilingSetAbridged**](RoofCeilingSetAbridged.md) | A RoofCeilingSet object for this ConstructionSet. | [optional] 
**ApertureSet** | [**ApertureSetAbridged**](ApertureSetAbridged.md) | A ApertureSet object for this ConstructionSet. | [optional] 
**DoorSet** | [**DoorSetAbridged**](DoorSetAbridged.md) | A DoorSet object for this ConstructionSet. | [optional] 
**ShadeConstruction** | **string** | The identifier of a ShadeConstruction to set the reflectance properties of all outdoor shades of all objects to which this ConstructionSet is assigned. | [optional] 
**AirBoundaryConstruction** | **string** | The identifier of an AirBoundaryConstruction to set the properties of Faces with an AirBoundary type. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

