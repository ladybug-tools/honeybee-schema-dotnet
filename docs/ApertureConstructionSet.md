
# HoneybeeSchema.Model.ApertureConstructionSet

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [default to "ApertureConstructionSet"]
**InteriorConstruction** | [**WindowConstruction**](WindowConstruction.md) | A WindowConstruction for apertures with an Outdoors boundary condition, False is_operable property, and a Wall face type for their parent face. | [optional] 
**WindowConstruction** | [**WindowConstruction**](WindowConstruction.md) | A WindowConstruction for all apertures with a Surface boundary condition. | [optional] 
**SkylightConstruction** | [**WindowConstruction**](WindowConstruction.md) | A WindowConstruction for apertures with a Outdoors boundary condition, False is_operable property, and a RoofCeiling or Floor face type for their parent face. | [optional] 
**OperableConstruction** | [**WindowConstruction**](WindowConstruction.md) | A WindowConstruction for all apertures with an Outdoors boundary condition and True is_operable property.. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

