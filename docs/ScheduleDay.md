
# HoneybeeSchema.Model.ScheduleDay

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**Values** | **List&lt;double&gt;** | A list of floats or integers for the values of the schedule. The length of this list must match the length of the times list. | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "ScheduleDay"]
**Times** | **List&lt;List&lt;int&gt;&gt;** | A list of lists with each sub-list possesing 2 values for [hour, minute]. The length of the master list must match the length of the values list. Each time in the master list represents the time of day that the corresponding value begins to take effect. For example [(0,0), (9,0), (17,0)] in combination with the values [0, 1, 0] denotes a schedule value of 0 from 0:00 to 9:00, a value of 1 from 9:00 to 17:00 and 0 from 17:00 to the end of the day. Note that this representation of times as the \&quot;time of beginning\&quot; is a different convention than EnergyPlus, which uses \&quot;time until\&quot;. | [optional] 
**Interpolate** | **bool** | Boolean to note whether values in between times should be linearly interpolated or whether successive values should take effect immediately upon the beginning time corrsponding to them. | [optional] [default to false]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

