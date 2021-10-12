
# HoneybeeSchema.Model.ScheduleFixedInterval

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Values** | **List&lt;double&gt;** | A list of timeseries values occuring at each timestep over the course of the simulation. | 
**Type** | **string** |  | [optional] [readonly] [default to "ScheduleFixedInterval"]
**ScheduleTypeLimit** | [**ScheduleTypeLimit**](ScheduleTypeLimit.md) | ScheduleTypeLimit object that will be used to validate schedule values against upper/lower limits and assign units to the schedule values. If None, no validation will occur. | [optional] 
**Timestep** | **int** | An integer for the number of steps per hour that the input values correspond to.  For example, if each value represents 30 minutes, the timestep is 2. For 15 minutes, it is 4. | [optional] [default to 1]
**StartDate** | **List&lt;int&gt;** | A list of two integers for [month, day], representing the start date when the schedule values begin to take effect.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case). | [optional] 
**PlaceholderValue** | **double** |  A value that will be used for all times not covered by the input values. Typically, your simulation should not need to use this value if the input values completely cover the simulation period. | [optional] [default to 0D]
**Interpolate** | **bool** | Boolean to note whether values in between intervals should be linearly interpolated or whether successive values should take effect immediately upon the beginning time corresponding to them. | [optional] [default to false]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

