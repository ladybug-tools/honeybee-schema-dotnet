
# HoneybeeSchema.Model.ConstructionSetAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Name of the object. Must use only ASCII characters and exclude (, ; ! \\n \\t). It cannot be longer than 100 characters. | 
**Type** | **string** |  | [optional] [default to "ConstructionSetAbridged"]
**WallSet** | [**WallSetAbridged**](WallSetAbridged.md) | A WallSet object for this ConstructionSet. | [optional] 
**FloorSet** | [**FloorSetAbridged**](FloorSetAbridged.md) | A FloorSet object for this ConstructionSet. | [optional] 
**RoofCeilingSet** | [**RoofCeilingSetAbridged**](RoofCeilingSetAbridged.md) | A RoofCeilingSet object for this ConstructionSet. | [optional] 
**ApertureSet** | [**ApertureSetAbridged**](ApertureSetAbridged.md) | A ApertureSet object for this ConstructionSet. | [optional] 
**DoorSet** | [**DoorSetAbridged**](DoorSetAbridged.md) | A DoorSet object for this ConstructionSet. | [optional] 
**ShadeConstruction** | **string** | A ShadeConstruction to set the reflectance properties of all outdoor shades to which this ConstructionSet is assigned. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

