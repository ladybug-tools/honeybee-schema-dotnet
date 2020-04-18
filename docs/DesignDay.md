
# HoneybeeSchema.Model.DesignDay

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "DesignDay"]
**Name** | **string** | Text string for a unique design day name. This name remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). It is also used to reference the object within SimulationParameters. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**DayType** | **string** |  | 
**DryBulbCondition** | [**DryBulbCondition**](DryBulbCondition.md) | A DryBulbCondition describing temperature conditions on the design day. | 
**HumidityCondition** | [**HumidityCondition**](HumidityCondition.md) | A HumidityCondition describing humidity and precipitation conditions on the design day. | 
**WindCondition** | [**WindCondition**](WindCondition.md) | A WindCondition describing wind conditions on the design day. | 
**SkyCondition** | [**AnyOfASHRAEClearSkyASHRAETau**](AnyOfASHRAEClearSkyASHRAETau.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

