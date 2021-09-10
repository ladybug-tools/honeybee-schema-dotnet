
# HoneybeeSchema.Model.WindowConstructionDynamicAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**Constructions** | [**List&lt;WindowConstructionAbridged&gt;**](WindowConstructionAbridged.md) | A list of WindowConstructionAbridged objects that define the various states that the dynamic window can assume. | 
**Schedule** | **string** | An identifier for a control schedule that dictates which constructions are active at given times throughout the simulation. The values of the schedule should be intergers and range from 0 to one less then the number of constructions. Zero indicates that the first construction is active, one indicates that the second on is active, etc. The schedule type limits of this schedule should be \&quot;Control Level.\&quot; If building custom schedule type limits that describe a particular range of states, the type limits should be \&quot;Discrete\&quot; and the unit type should be \&quot;Mode,\&quot; \&quot;Control,\&quot; or some other fractional unit. | 
**Type** | **string** |  | [optional] [readonly] [default to "WindowConstructionDynamicAbridged"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

