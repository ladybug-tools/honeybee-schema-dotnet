
# HoneybeeSchema.Model.People

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**PeoplePerArea** | **double** | People per floor area expressed as [people/m2] | 
**OccupancySchedule** | [**AnyOfScheduleRulesetScheduleFixedInterval**](AnyOfScheduleRulesetScheduleFixedInterval.md) | A schedule for the occupancy over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the people_per_area to yield a complete occupancy profile. | 
**ActivitySchedule** | [**AnyOfScheduleRulesetScheduleFixedInterval**](AnyOfScheduleRulesetScheduleFixedInterval.md) | A schedule for the activity of the occupants over the course of the year. The type of this schedule should be Power and the values of the schedule equal to the number of Watts given off by an individual person in the room. | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**Type** | **string** |  | [optional] [default to "People"]
**RadiantFraction** | **double** | The radiant fraction of sensible heat released by people. The defaultvalue is 0.30. | [optional] [default to 0.3M]
**LatentFraction** | [**AnyOfAutocalculatenumber**](AnyOfAutocalculatenumber.md) | Number for the latent fraction of heat gain due to people or an Autocalculate object. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

