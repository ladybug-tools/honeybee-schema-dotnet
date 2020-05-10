
# HoneybeeSchema.Model.ModelEnergyProperties

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "ModelEnergyProperties"]
**GlobalConstructionSet** | **string** | Identifier for the ConstructionSet to be used for all objects lacking their own construction or a parent Room construction_set. This ConstructionSet must appear under the Model construction_sets. | [optional] 
**ConstructionSets** | [**List&lt;AnyOfConstructionSetAbridgedConstructionSet&gt;**](AnyOfConstructionSetAbridgedConstructionSet.md) | List of all unique ConstructionSets in the Model. | [optional] 
**Constructions** | [**List&lt;AnyOfOpaqueConstructionAbridgedWindowConstructionAbridgedShadeConstructionAirBoundaryConstructionAbridgedOpaqueConstructionWindowConstructionAirBoundaryConstruction&gt;**](AnyOfOpaqueConstructionAbridgedWindowConstructionAbridgedShadeConstructionAirBoundaryConstructionAbridgedOpaqueConstructionWindowConstructionAirBoundaryConstruction.md) | A list of all unique constructions in the model. This includes constructions across all Faces, Apertures, Doors, Shades, Room ConstructionSets, and the global_construction_set. | [optional] 
**Materials** | [**List&lt;AnyOfEnergyMaterialEnergyMaterialNoMassEnergyWindowMaterialGasEnergyWindowMaterialGasCustomEnergyWindowMaterialGasMixtureEnergyWindowMaterialSimpleGlazSysEnergyWindowMaterialBlindEnergyWindowMaterialGlazingEnergyWindowMaterialShade&gt;**](AnyOfEnergyMaterialEnergyMaterialNoMassEnergyWindowMaterialGasEnergyWindowMaterialGasCustomEnergyWindowMaterialGasMixtureEnergyWindowMaterialSimpleGlazSysEnergyWindowMaterialBlindEnergyWindowMaterialGlazingEnergyWindowMaterialShade.md) | A list of all unique materials in the model. This includes materials needed to make the Model constructions. | [optional] 
**Hvacs** | [**List&lt;IdealAirSystemAbridged&gt;**](IdealAirSystemAbridged.md) | List of all unique HVAC systems in the Model. | [optional] 
**ProgramTypes** | [**List&lt;AnyOfProgramTypeAbridgedProgramType&gt;**](AnyOfProgramTypeAbridgedProgramType.md) | List of all unique ProgramTypes in the Model. | [optional] 
**Schedules** | [**List&lt;AnyOfScheduleRulesetAbridgedScheduleFixedIntervalAbridgedScheduleRulesetScheduleFixedInterval&gt;**](AnyOfScheduleRulesetAbridgedScheduleFixedIntervalAbridgedScheduleRulesetScheduleFixedInterval.md) | A list of all unique schedules in the model. This includes schedules across all HVAC systems, ProgramTypes, Rooms, and Shades. | [optional] 
**ScheduleTypeLimits** | [**List&lt;ScheduleTypeLimit&gt;**](ScheduleTypeLimit.md) | A list of all unique ScheduleTypeLimits in the model. This all ScheduleTypeLimits needed to make the Model schedules. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

