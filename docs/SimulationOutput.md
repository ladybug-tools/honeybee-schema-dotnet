
# HoneybeeSchema.Model.SimulationOutput

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "SimulationOutput"]
**ReportingFrequency** | **ReportingFrequency** |  | [optional] 
**Outputs** | **List&lt;string&gt;** | A list of EnergyPlus output names as strings, which are requested from the simulation. | [optional] 
**SummaryReports** | **List&lt;string&gt;** | A list of EnergyPlus summary report names as strings. | [optional] 
**UnmetSetpointTolerance** | **double** | A number in degrees Celsius for the difference that the zone conditions must be from the thermostat setpoint in order for the setpoint to be considered unmet. This will affect how unmet hours are reported in the output. ASHRAE 90.1 uses a tolerance of 1.11C, which is equivalent to 1.8F. | [optional] [default to 1.11D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

