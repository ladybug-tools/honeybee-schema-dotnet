
# HoneybeeSchema.Model.Location

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "Location"]
**City** | **string** | Name of the city as a string. | [optional] [default to "-"]
**Latitude** | **double** | Location latitude between -90 and 90 (Default: 0). | [optional] [default to 0D]
**Longitude** | **double** | Location longitude between -180 (west) and 180 (east) (Default: 0). | [optional] [default to 0D]
**TimeZone** | **double** | Time zone between -12 hours (west) and +14 hours (east). If None, the time zone will be an estimated integer value derived from the longitude in accordance with solar time. | [optional] 
**Elevation** | **double** | A number for elevation of the location in meters. (Default: 0). | [optional] [default to 0D]
**StationId** | **string** | ID of the location if the location is representing a weather station. | [optional] 
**Source** | **string** | Source of data (e.g. TMY, TMY3). | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

