
# HoneybeeSchema.Model.ConstructionSetAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "ConstructionSetAbridged"]
**WallSet** | [**WallConstructionSetAbridged**](WallConstructionSetAbridged.md) | A WallConstructionSetAbridged object for this ConstructionSet. | [optional] 
**FloorSet** | [**FloorConstructionSetAbridged**](FloorConstructionSetAbridged.md) | A FloorConstructionSetAbridged object for this ConstructionSet. | [optional] 
**RoofCeilingSet** | [**RoofCeilingConstructionSetAbridged**](RoofCeilingConstructionSetAbridged.md) | A RoofCeilingConstructionSetAbridged object for this ConstructionSet. | [optional] 
**ApertureSet** | [**ApertureConstructionSetAbridged**](ApertureConstructionSetAbridged.md) | A ApertureConstructionSetAbridged object for this ConstructionSet. | [optional] 
**DoorSet** | [**DoorConstructionSetAbridged**](DoorConstructionSetAbridged.md) | A DoorConstructionSetAbridged object for this ConstructionSet. | [optional] 
**ShadeConstruction** | **string** | The identifier of a ShadeConstruction to set the reflectance properties of all outdoor shades of all objects to which this ConstructionSet is assigned. | [optional] 
**AirBoundaryConstruction** | **string** | The identifier of an AirBoundaryConstruction to set the properties of Faces with an AirBoundary type. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

