
# HoneybeeSchema.Model.SimulationParameter

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "SimulationParameter"]
**Output** | [**SimulationOutput**](SimulationOutput.md) | A SimulationOutput that lists the desired outputs from the simulation and the format in which to report them. | [optional] 
**RunPeriod** | [**RunPeriod**](RunPeriod.md) | A RunPeriod to describe the time period over which to run the simulation. | [optional] 
**Timestep** | **int** | An integer for the number of timesteps per hour at which the energy calculation will be run. | [optional] [default to 6]
**SimulationControl** | [**SimulationControl**](SimulationControl.md) | A SimulationControl object that describes which types of calculations to run. | [optional] 
**ShadowCalculation** | [**ShadowCalculation**](ShadowCalculation.md) | A ShadowCalculation object describing settings for the EnergyPlus Shadow Calculation. | [optional] 
**SizingParameter** | [**SizingParameter**](SizingParameter.md) | A SizingParameter object with criteria for sizing the heating and cooling system. | [optional] 
**NorthAngle** | **double** | A number between -360 and 360 for the north direction in degrees.This is the counterclockwise difference between the North and the positive Y-axis. 90 is West and 270 is East. Note that this is different than the convention used in EnergyPlus, which uses clockwise difference instead of counterclockwise difference. | [optional] [default to 0D]
**TerrainType** | **string** | Text for the terrain in which the model sits. This is used to determine the wind profile over the height of the rooms. | [optional] [default to TerrainTypeEnum.City]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

