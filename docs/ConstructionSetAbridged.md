
# HoneybeeSchema.Model.ConstructionSetAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
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

