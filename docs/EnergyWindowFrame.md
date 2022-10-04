
# HoneybeeSchema.Model.EnergyWindowFrame

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Width** | **double** | Number for the width of frame in plane of window [m]. The frame width is assumed to be the same on all sides of window.. | 
**Conductance** | **double** | Number for the thermal conductance of the frame material measured from inside to outside of the frame surface (no air films) and taking 2D conduction effects into account [W/m2-K]. | 
**Type** | **string** |  | [optional] [readonly] [default to "EnergyWindowFrame"]
**EdgeToCenterRatio** | **double** | Number between 0 and 4 for the ratio of the glass conductance near the frame (excluding air films) divided by the glass conductance at the center of the glazing (excluding air films). This is used only for multi-pane glazing constructions. This ratio should usually be greater than 1.0 since the spacer material that separates the glass panes is usually more conductive than the gap between panes. A value of 1 effectively indicates no spacer. Values should usually be obtained from the LBNL WINDOW program so that the unique characteristics of the window construction can be accounted for. | [optional] [default to 1D]
**OutsideProjection** | **double** | Number for the distance that the frame projects outward from the outside face of the glazing [m]. This is used to calculate shadowing of frame onto glass, solar absorbed by the frame, IR emitted and absorbed by the frame, and convection from frame. | [optional] [default to 0D]
**InsideProjection** | **double** | Number for the distance that the frame projects inward from the inside face of the glazing [m]. This is used to calculate solar absorbed by the frame, IR emitted and absorbed by the frame, and convection from frame. | [optional] [default to 0D]
**ThermalAbsorptance** | **double** | Fraction of incident long wavelength radiation that is absorbed by the frame material. | [optional] [default to 0.9D]
**SolarAbsorptance** | **double** | Fraction of incident solar radiation absorbed by the frame material. | [optional] [default to 0.7D]
**VisibleAbsorptance** | **double** | Fraction of incident visible wavelength radiation absorbed by the frame material. | [optional] [default to 0.7D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

