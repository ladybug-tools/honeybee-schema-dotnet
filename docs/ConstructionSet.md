
# HoneybeeSchema.Model.ConstructionSet

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "ConstructionSet"]
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

