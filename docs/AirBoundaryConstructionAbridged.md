
# HoneybeeSchema.Model.AirBoundaryConstructionAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Name of the object. Must use only ASCII characters and exclude (, ; ! \\n \\t). It cannot be longer than 100 characters. | 
**AirMixingSchedule** | **string** | Name of A fractional schedule for the air mixing schedule across the construction. | 
**Type** | **string** |  | [optional] [default to "AirBoundaryConstructionAbridged"]
**AirMixingPerArea** | **double** | A positive number for the amount of air mixing between Rooms across the air boundary surface [m3/s-m2]. Default: 0.1 corresponds to average indoor air speeds of 0.1 m/s (roughly 20 fpm), which is typical of what would be induced by a HVAC system. | [optional] [default to 0.1M]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

