
# HoneybeeSchema.Model.ApertureConstructionSetAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "ApertureConstructionSetAbridged"]
**InteriorConstruction** | **string** | Identifier for a WindowConstruction for apertures with an Outdoors boundary condition, False is_operable property, and a Wall face type for their parent face. | [optional] 
**WindowConstruction** | **string** | Identifier for a WindowConstruction for all apertures with a Surface boundary condition. | [optional] 
**SkylightConstruction** | **string** | Identifier for a WindowConstruction for apertures with a Outdoors boundary condition, False is_operable property, and a RoofCeiling or Floor face type for their parent face. | [optional] 
**OperableConstruction** | **string** | Identifier for a WindowConstruction for all apertures with an Outdoors boundary condition and True is_operable property.. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

