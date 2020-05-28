
# HoneybeeSchema.Model.ShadeEnergyPropertiesAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "ShadeEnergyPropertiesAbridged"]
**Construction** | **string** | Identifier of a ShadeConstruction to set the reflectance and specularity of the Shade. If None, the construction is set by theparent Room construction_set, the Model global_construction_set or (in the case fo an orphaned shade) the EnergyPlus default of 0.2 diffuse reflectance. | [optional] 
**TransmittanceSchedule** | **string** | Identifier of a schedule to set the transmittance of the shade, which can vary throughout the simulation. If None, the shade will be completely opaque. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

