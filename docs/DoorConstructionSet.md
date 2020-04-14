
# HoneybeeSchema.Model.DoorConstructionSet

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [default to "DoorConstructionSet"]
**InteriorConstruction** | [**OpaqueConstruction**](OpaqueConstruction.md) | An OpaqueConstruction for all opaque doors with a Surface boundary condition. | [optional] 
**ExteriorConstruction** | [**OpaqueConstruction**](OpaqueConstruction.md) | An OpaqueConstruction for opaque doors with an Outdoors boundary condition and a Wall face type for their parent face. | [optional] 
**OverheadConstruction** | [**OpaqueConstruction**](OpaqueConstruction.md) | An OpaqueConstruction for opaque doors with an Outdoors boundary condition and a RoofCeiling or Floor type for their parent face. | [optional] 
**ExteriorGlassConstruction** | [**WindowConstruction**](WindowConstruction.md) | A WindowConstruction for all glass doors with an Outdoors boundary condition. | [optional] 
**InteriorGlassConstruction** | [**WindowConstruction**](WindowConstruction.md) | A WindowConstruction for all glass doors with a Surface boundary condition. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

