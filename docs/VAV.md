
# HoneybeeSchema.Model.VAV

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**EconomizerType** | **AllAirEconomizerType** |  | [optional] 
**SensibleHeatRecovery** | [**AnyOfAutosizedouble**](AnyOfAutosizedouble.md) | A number between 0 and 1 for the effectiveness of sensible heat recovery within the system. If None or Autosize, it will be whatever is recommended for the given vintage. | [optional] 
**LatentHeatRecovery** | [**AnyOfAutosizedouble**](AnyOfAutosizedouble.md) | A number between 0 and 1 for the effectiveness of latent heat recovery within the system. If None or Autosize, it will be whatever is recommended for the given vintage. | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "VAV"]
**EquipmentType** | **VAVEquipmentType** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

