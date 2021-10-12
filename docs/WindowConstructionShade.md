
# HoneybeeSchema.Model.WindowConstructionShade

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**WindowConstruction** | [**WindowConstruction**](WindowConstruction.md) | A WindowConstruction object that serves as the \&quot;switched off\&quot; version of the construction (aka. the \&quot;bare construction\&quot;). The shade_material and shade_location will be used to modify this starting construction. | 
**ShadeMaterial** | [**AnyOfEnergyWindowMaterialShadeEnergyWindowMaterialBlindEnergyWindowMaterialGlazing**](AnyOfEnergyWindowMaterialShadeEnergyWindowMaterialBlindEnergyWindowMaterialGlazing.md) | Identifier of a An EnergyWindowMaterialShade or an EnergyWindowMaterialBlind that serves as the shading layer for this construction. This can also be an EnergyWindowMaterialGlazing, which will indicate that the WindowConstruction has a dynamically-controlled glass pane like an electrochromic window assembly. | 
**Type** | **string** |  | [optional] [readonly] [default to "WindowConstructionShade"]
**ShadeLocation** | **ShadeLocation** | Text to indicate where in the window assembly the shade_material is located.  Note that the WindowConstruction must have at least one gas gap to use the \&quot;Between\&quot; option. Also note that, for a WindowConstruction with more than one gas gap, the \&quot;Between\&quot; option defalts to using the inner gap as this is the only option that EnergyPlus supports. | [optional] 
**ControlType** | **ControlType** | Text to indicate how the shading device is controlled, which determines when the shading is “on” or “off.” | [optional] 
**Setpoint** | **double** | A number that corresponds to the specified control_type. This can be a value in (W/m2), (C) or (W) depending upon the control type.Note that this value cannot be None for any control type except \&quot;AlwaysOn.\&quot; | [optional] 
**Schedule** | [**AnyOfScheduleRulesetScheduleFixedInterval**](AnyOfScheduleRulesetScheduleFixedInterval.md) | An optional ScheduleRuleset or ScheduleFixedInterval to be applied on top of the control_type. If None, the control_type will govern all behavior of the construction. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

