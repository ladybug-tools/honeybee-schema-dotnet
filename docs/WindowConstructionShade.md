
# HoneybeeSchema.Model.WindowConstructionShade

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**WindowConstruction** | [**WindowConstruction**](WindowConstruction.md) | A WindowConstruction object that serves as the \&quot;switched off\&quot; version of the construction (aka. the \&quot;bare construction\&quot;). The shade_material and shade_location will be used to modify this starting construction. | 
**ShadeMaterial** | [**AnyOfEnergyWindowMaterialShadeEnergyWindowMaterialBlindEnergyWindowMaterialGlazing**](AnyOfEnergyWindowMaterialShadeEnergyWindowMaterialBlindEnergyWindowMaterialGlazing.md) | Identifier of a An EnergyWindowMaterialShade or an EnergyWindowMaterialBlind that serves as the shading layer for this construction. This can also be an EnergyWindowMaterialGlazing, which will indicate that the WindowConstruction has a dynamically-controlled glass pane like an electrochromic window assembly. | 
**Type** | **string** |  | [optional] [readonly] [default to "WindowConstructionShade"]
**ShadeLocation** | **ShadeLocation** |  | [optional] 
**ControlType** | **ControlType** |  | [optional] 
**Setpoint** | **double** | A number that corresponds to the specified control_type. This can be a value in (W/m2), (C) or (W) depending upon the control type.Note that this value cannot be None for any control type except \&quot;AlwaysOn.\&quot; | [optional] 
**Schedule** | [**AnyOfScheduleRulesetScheduleFixedInterval**](AnyOfScheduleRulesetScheduleFixedInterval.md) | An optional ScheduleRuleset or ScheduleFixedInterval to be applied on top of the control_type. If None, the control_type will govern all behavior of the construction. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

