
# HoneybeeSchema.Model.ServiceHotWaterAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**FlowPerArea** | **double** | Number for the total volume flow rate of water per unit area of floor [L/h-m2]. | 
**Schedule** | **string** | Identifier of the schedule for the hot water use over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the flow_per_area to yield a complete water usage profile. | 
**Type** | **string** |  | [optional] [readonly] [default to "ServiceHotWaterAbridged"]
**TargetTemperature** | **double** | Number for the target temperature of water out of the tap (C). This the temperature after hot water has been mixed with cold water from the water mains. The default is 60C, which essentially assumes that the flow_per_area on this object is only for water straight out of the water heater. | [optional] [default to 60D]
**SensibleFraction** | **double** | A number between 0 and 1 for the fraction of the total hot water load given off as sensible heat in the zone. | [optional] [default to 0.2D]
**LatentFraction** | **double** | A number between 0 and 1 for the fraction of the total hot water load that is latent. | [optional] [default to 0.05D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

