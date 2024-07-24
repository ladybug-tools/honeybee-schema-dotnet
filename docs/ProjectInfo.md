
# HoneybeeSchema.Model.ProjectInfo

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "ProjectInfo"]
**North** | **double** | A number between -360 to 360 where positive values rotate the compass counterclockwise (towards the West) and negative values rotate the compass clockwise (towards the East). | [optional] [default to 0D]
**WeatherUrls** | **List&lt;string&gt;** | A list of URLs to zip files that includes EPW, DDY and STAT files. You can find these URLs from the EPWMAP. The first URL will be used as the primary weather file. | [optional] 
**Location** | [**Location**](Location.md) | Project location. This value is usually generated from the information in the weather files. | [optional] 
**AshraeClimateZone** | **ClimateZones** | Project location climate zone. | [optional] 
**BuildingType** | [**List&lt;BuildingTypes&gt;**](BuildingTypes.md) | A list of building types for the project. The first building type is considered the primary type for the project. | [optional] 
**Vintage** | [**List&lt;EfficiencyStandards&gt;**](EfficiencyStandards.md) | A list of building vintages (e.g. ASHRAE_2019, ASHRAE_2016). | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

