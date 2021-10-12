
# HoneybeeSchema.Model.WindowConstructionDynamic

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Constructions** | [**List&lt;WindowConstruction&gt;**](WindowConstruction.md) | A list of WindowConstruction objects that define the various states that the dynamic window can assume. | 
**Schedule** | [**AnyOfScheduleRulesetScheduleFixedInterval**](AnyOfScheduleRulesetScheduleFixedInterval.md) | A control schedule that dictates which constructions are active at given times throughout the simulation. The values of the schedule should be intergers and range from 0 to one less then the number of constructions. Zero indicates that the first construction is active, one indicates that the second on is active, etc. The schedule type limits of this schedule should be \&quot;Control Level.\&quot; If building custom schedule type limits that describe a particular range of states, the type limits should be \&quot;Discrete\&quot; and the unit type should be \&quot;Mode,\&quot; \&quot;Control,\&quot; or some other fractional unit. | 
**Type** | **string** |  | [optional] [readonly] [default to "WindowConstructionDynamic"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

