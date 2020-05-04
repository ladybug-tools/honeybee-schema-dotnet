
# HoneybeeSchema.Model.ApertureModifierSet

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "ApertureModifierSet"]
**WindowModifier** | [**AnyOfPlasticGlassBSDFGlowLightTransVoidMirror**](AnyOfPlasticGlassBSDFGlowLightTransVoidMirror.md) | A modifier object for apertures with an Outdoors boundary condition, False is_operable property, and Wall parent Face. | [optional] 
**InteriorModifier** | [**AnyOfPlasticGlassBSDFGlowLightTransVoidMirror**](AnyOfPlasticGlassBSDFGlowLightTransVoidMirror.md) | A modifier object for apertures with a Surface boundary condition. | [optional] 
**SkylightModifier** | [**AnyOfPlasticGlassBSDFGlowLightTransVoidMirror**](AnyOfPlasticGlassBSDFGlowLightTransVoidMirror.md) | A modifier object for apertures with an Outdoors boundary condition, False is_operable property, and a RoofCeiling or Floor face type for their parent face. | [optional] 
**OperableModifier** | [**AnyOfPlasticGlassBSDFGlowLightTransVoidMirror**](AnyOfPlasticGlassBSDFGlowLightTransVoidMirror.md) | A modifier object for apertures with an Outdoors boundary condition and a True is_operable property. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

