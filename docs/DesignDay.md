
# HoneybeeDotNet.Model.DesignDay

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Name of the object. Must use only ASCII characters and exclude (, ; ! \\n \\t). It cannot be longer than 100 characters. | 
**DayType** | **string** |  | 
**DryBulbCondition** | [**DryBulbCondition**](DryBulbCondition.md) | A DryBulbCondition describing temperature conditions on the design day. | 
**HumidityCondition** | [**HumidityCondition**](HumidityCondition.md) | A HumidityCondition describing humidity and precipitation conditions on the design day. | 
**WindCondition** | [**WindCondition**](WindCondition.md) | A WindCondition describing wind conditions on the design day. | 
**SkyCondition** | [**AnyOfobjectobject**](AnyOfobjectobject.md) | A SkyCondition (either ASHRAEClearSky or ASHRAETau) describing solar irradiance conditions on the design day. | 
**Type** | **string** |  | [optional] [default to "DesignDay"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

