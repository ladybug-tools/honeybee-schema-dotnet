
# HoneybeeSchema.Model.VentilationOpening

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "VentilationOpening"]
**FractionAreaOperable** | **double** | A number for the fraction of the window area that is operable. | [optional] [default to 0.5D]
**FractionHeightOperable** | **double** | A number for the fraction of the distance from the bottom of the window to the top that is operable. | [optional] [default to 1.0D]
**DischargeCoefficient** | **double** | A number that will be multipled by the area of the window in the stack (buoyancy-driven) part of the equation to account for additional friction from window geometry, insect screens, etc. Typical values include 0.17, for unobstructed windows with insect screens and 0.25 for unobstructed windows without insect screens. This value should be lowered if windows are of an awning or casement type and not allowed to fully open. | [optional] [default to 0.17D]
**WindCrossVent** | **bool** | Boolean to indicate if there is an opening of roughly equal area on the opposite side of the Room such that wind-driven cross ventilation will be induced. If False, the assumption is that the operable area is primarily on one side of the Room and there is no wind-driven ventilation. | [optional] [default to false]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

