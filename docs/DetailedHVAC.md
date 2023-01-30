
# HoneybeeSchema.Model.DetailedHVAC

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Specification** | **Object** | A JSON-serializable dictionary representing the full specification of the detailed system. This can be obtained by calling the ToJson() method on any IronBug HVAC system and then serializing the resulting JSON string into a Python dictionary using the native Python json package. Note that the Rooms that the HVAC is assigned to must be specified as ThermalZones under this specification in order for the resulting Model this HVAC is a part of to be valid. | 
**Type** | **string** |  | [optional] [readonly] [default to "DetailedHVAC"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

