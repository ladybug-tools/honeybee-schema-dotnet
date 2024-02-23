
# HoneybeeSchema.Model.ModelEnergyProperties

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "ModelEnergyProperties"]
**GlobalConstructionSet** | [**GlobalConstructionSet**](GlobalConstructionSet.md) | Global Energy construction set. | [optional] [readonly] 
**ConstructionSets** | [**List&lt;AnyOfConstructionSetAbridgedConstructionSet&gt;**](AnyOfConstructionSetAbridgedConstructionSet.md) | List of all unique ConstructionSets in the Model. | [optional] 
**Constructions** | [**List&lt;AnyOfOpaqueConstructionAbridgedWindowConstructionAbridgedWindowConstructionShadeAbridgedAirBoundaryConstructionAbridgedOpaqueConstructionWindowConstructionWindowConstructionShadeWindowConstructionDynamicAbridgedWindowConstructionDynamicAirBoundaryConstructionShadeConstruction&gt;**](AnyOfOpaqueConstructionAbridgedWindowConstructionAbridgedWindowConstructionShadeAbridgedAirBoundaryConstructionAbridgedOpaqueConstructionWindowConstructionWindowConstructionShadeWindowConstructionDynamicAbridgedWindowConstructionDynamicAirBoundaryConstructionShadeConstruction.md) | A list of all unique constructions in the model. This includes constructions across all Faces, Apertures, Doors, Shades, Room ConstructionSets, and the global_construction_set. | [optional] 
**Materials** | [**List&lt;AnyOfEnergyMaterialEnergyMaterialNoMassEnergyMaterialVegetationEnergyWindowMaterialGlazingEnergyWindowMaterialSimpleGlazSysEnergyWindowMaterialGasEnergyWindowMaterialGasMixtureEnergyWindowMaterialGasCustomEnergyWindowFrameEnergyWindowMaterialBlindEnergyWindowMaterialShade&gt;**](AnyOfEnergyMaterialEnergyMaterialNoMassEnergyMaterialVegetationEnergyWindowMaterialGlazingEnergyWindowMaterialSimpleGlazSysEnergyWindowMaterialGasEnergyWindowMaterialGasMixtureEnergyWindowMaterialGasCustomEnergyWindowFrameEnergyWindowMaterialBlindEnergyWindowMaterialShade.md) | A list of all unique materials in the model. This includes materials needed to make the Model constructions. | [optional] 
**Hvacs** | [**List&lt;AnyOfIdealAirSystemAbridgedVAVPVAVPSZPTACForcedAirFurnaceFCUwithDOASAbridgedWSHPwithDOASAbridgedVRFwithDOASAbridgedRadiantwithDOASAbridgedFCUWSHPVRFBaseboardEvaporativeCoolerResidentialWindowACGasUnitHeaterRadiantDetailedHVAC&gt;**](AnyOfIdealAirSystemAbridgedVAVPVAVPSZPTACForcedAirFurnaceFCUwithDOASAbridgedWSHPwithDOASAbridgedVRFwithDOASAbridgedRadiantwithDOASAbridgedFCUWSHPVRFBaseboardEvaporativeCoolerResidentialWindowACGasUnitHeaterRadiantDetailedHVAC.md) | List of all unique HVAC systems in the Model. | [optional] 
**Shws** | [**List&lt;SHWSystem&gt;**](SHWSystem.md) | List of all unique Service Hot Water (SHW) systems in the Model. | [optional] 
**ProgramTypes** | [**List&lt;AnyOfProgramTypeAbridgedProgramType&gt;**](AnyOfProgramTypeAbridgedProgramType.md) | List of all unique ProgramTypes in the Model. | [optional] 
**Schedules** | [**List&lt;AnyOfScheduleRulesetAbridgedScheduleFixedIntervalAbridgedScheduleRulesetScheduleFixedInterval&gt;**](AnyOfScheduleRulesetAbridgedScheduleFixedIntervalAbridgedScheduleRulesetScheduleFixedInterval.md) | A list of all unique schedules in the model. This includes schedules across all HVAC systems, ProgramTypes, Rooms, and Shades. | [optional] 
**ScheduleTypeLimits** | [**List&lt;ScheduleTypeLimit&gt;**](ScheduleTypeLimit.md) | A list of all unique ScheduleTypeLimits in the model. This all ScheduleTypeLimits needed to make the Model schedules. | [optional] 
**VentilationSimulationControl** | [**VentilationSimulationControl**](VentilationSimulationControl.md) | An optional parameter to define the global parameters for a ventilation cooling. | [optional] 
**ElectricLoadCenter** | [**ElectricLoadCenter**](ElectricLoadCenter.md) | An optional parameter object that defines the properties of the model electric loads center that manages on site electricity generation and conversion. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

