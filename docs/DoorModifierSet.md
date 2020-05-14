
# HoneybeeSchema.Model.DoorModifierSet

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ExteriorModifier** | [**AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror**](AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror.md) | A radiance modifier object for faces with an Outdoors boundary condition. | [optional] 
**InteriorModifier** | [**AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror**](AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror.md) | A radiance modifier object for faces with a boundary condition other than Outdoors. | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "DoorModifierSet"]
**InteriorGlassModifier** | [**AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror**](AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror.md) | A modifier object for glass with a Surface boundary condition. | [optional] 
**ExteriorGlassModifier** | [**AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror**](AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror.md) | A modifier object for glass with an Outdoors boundary condition. | [optional] 
**OverheadModifier** | [**AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror**](AnyOfPlasticGlassBSDFGlowLightTransMetalVoidMirror.md) | A window modifier object for doors with an Outdoors boundary condition and a RoofCeiling or Floor face type for their parent face. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

