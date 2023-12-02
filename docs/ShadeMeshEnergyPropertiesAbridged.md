
# HoneybeeSchema.Model.ShadeMeshEnergyPropertiesAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "ShadeMeshEnergyPropertiesAbridged"]
**Construction** | **string** | Identifier of a ShadeConstruction to set the reflectance and specularity of the Shade. If None, it will be a generic context construction that is completely diffuse with 0.2 visible and solar reflectance. Unless it is building attached, in which case it will be set by the default generic ConstructionSet. | [optional] 
**TransmittanceSchedule** | **string** | Identifier of a schedule to set the transmittance of the shade, which can vary throughout the simulation. If None, the shade will be completely opaque. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

