
# HoneybeeSchema.Model.SimulationOutput

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "SimulationOutput"]
**ReportingFrequency** | **ReportingFrequency** |  | [optional] 
**IncludeSqlite** | **bool** | Boolean to note whether a SQLite report should be requested from the simulation. | [optional] [default to true]
**IncludeHtml** | **bool** | Boolean to note whether an HTML report should be requested from the simulation. | [optional] [default to true]
**Outputs** | **List&lt;string&gt;** | A list of EnergyPlus output names as strings, which are requested from the simulation. | [optional] 
**SummaryReports** | **List&lt;string&gt;** | A list of EnergyPlus summary report names as strings. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

