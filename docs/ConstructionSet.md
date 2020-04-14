
# HoneybeeSchema.Model.ConstructionSet

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**Type** | **string** |  | [optional] [default to "ConstructionSet"]
**WallSet** | [**WallConstructionSet**](WallConstructionSet.md) | A WallConstructionSet object for this ConstructionSet. | [optional] 
**FloorSet** | [**FloorConstructionSet**](FloorConstructionSet.md) | A FloorConstructionSet object for this ConstructionSet. | [optional] 
**RoofCeilingSet** | [**RoofCeilingConstructionSet**](RoofCeilingConstructionSet.md) | A RoofCeilingConstructionSet object for this ConstructionSet. | [optional] 
**ApertureSet** | [**ApertureConstructionSet**](ApertureConstructionSet.md) | A ApertureConstructionSet object for this ConstructionSet. | [optional] 
**DoorSet** | [**DoorConstructionSet**](DoorConstructionSet.md) | A DoorConstructionSet object for this ConstructionSet. | [optional] 
**ShadeConstruction** | [**ShadeConstruction**](ShadeConstruction.md) | A ShadeConstruction to set the reflectance properties of all outdoor shades of all objects to which this ConstructionSet is assigned. | [optional] 
**AirBoundaryConstruction** | [**AirBoundaryConstruction**](AirBoundaryConstruction.md) | An AirBoundaryConstruction to set the properties of Faces with an AirBoundary type. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

