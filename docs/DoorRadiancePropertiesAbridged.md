
# HoneybeeSchema.Model.DoorRadiancePropertiesAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "DoorRadiancePropertiesAbridged"]
**Modifier** | **string** | A string for a Honeybee Radiance Modifier (default: None). | [optional] 
**ModifierBlk** | **string** | A string for a Honeybee Radiance Modifier to be used in direct solar simulations and in isolation studies (assessingthe contribution of individual objects) (default: None). | [optional] 
**DynamicGroupIdentifier** | **string** | An optional string to note the dynamic group &#39;             &#39;to which the Door is a part of. Doors sharing the same &#39;             &#39;dynamic_group_identifier will have their states change in unison. &#39;             &#39;If None, the Door is assumed to be static. (default: None). | [optional] 
**States** | [**List&lt;RadianceSubFaceStateAbridged&gt;**](RadianceSubFaceStateAbridged.md) | An optional list of abridged states (default: None). | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

