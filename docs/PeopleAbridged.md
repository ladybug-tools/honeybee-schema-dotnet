
# HoneybeeSchema.Model.PeopleAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**PeoplePerArea** | **double** | People per floor area expressed as [people/m2] | 
**OccupancySchedule** | **string** | Identifier of a schedule for the occupancy over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the people_per_area to yield a complete occupancy profile. | 
**Type** | **string** |  | [optional] [readonly] [default to "PeopleAbridged"]
**ActivitySchedule** | **string** | Identifier of a schedule for the activity of the occupants over the course of the year. The type of this schedule should be ActivityLevel and the values of the schedule equal to the number of Watts given off by an individual person in the room. If None, a default constant schedule with 120 Watts per person will be used, which is typical of awake, adult humans who are seated. | [optional] 
**RadiantFraction** | **double** | The radiant fraction of sensible heat released by people. (Default: 0.3). | [optional] [default to 0.3D]
**LatentFraction** | [**AnyOfAutocalculatenumber**](AnyOfAutocalculatenumber.md) | Number for the latent fraction of heat gain due to people or an Autocalculate object. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

