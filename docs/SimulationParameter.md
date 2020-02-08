
# HoneybeeSchema.Model.SimulationParameter

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [default to "SimulationParameter"]
**Output** | [**SimulationOutput**](SimulationOutput.md) | A SimulationOutput that lists the desired outputs from the simulation and the format in which to report them. | [optional] 
**RunPeriod** | [**RunPeriod**](RunPeriod.md) | A RunPeriod to describe the time period over which to run the simulation. | [optional] 
**Timestep** | **int** | An integer for the number of timesteps per hour at which the energy calculation will be run. | [optional] [default to 6]
**SimulationControl** | [**SimulationControl**](SimulationControl.md) | A SimulationControl object that describes which types of calculations to run. | [optional] 
**ShadowCalculation** | [**ShadowCalculation**](ShadowCalculation.md) | A ShadowCalculation object describing settings for the EnergyPlus Shadow Calculation. | [optional] 
**SizingParameter** | [**SizingParameter**](SizingParameter.md) | A SizingParameter object with criteria for sizing the heating and cooling system. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

