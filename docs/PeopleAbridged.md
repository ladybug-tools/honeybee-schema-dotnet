
# HoneybeeDotNet.Model.PeopleAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Name of the object. Must use only ASCII characters and exclude (, ; ! \\n \\t). It cannot be longer than 100 characters. | 
**PeoplePerArea** | **double** | People per floor area expressed as [people/m2] | 
**OccupancySchedule** | **string** | Name of a schedule for the occupancy over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the people_per_area to yield a complete occupancy profile. | 
**ActivitySchedule** | **string** | Name of a schedule for the activity of the occupants over the course of the year. The type of this schedule should be Power and the values of the schedule equal to the number of Watts given off by an individual person in the room. | 
**Type** | **string** |  | [optional] [default to "PeopleAbridged"]
**RadiantFraction** | **double** | The radiant fraction of sensible heat released by people. The defaultvalue is 0.30. | [optional] [default to 0.3M]
**LatentFraction** | [**AnyOfnumberstring**](AnyOfnumberstring.md) | Number for the latent fraction of heat gain due to people or simply the word \&quot;autocalculate\&quot;. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

