
# HoneybeeSchema.Model.PeopleAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**PeoplePerArea** | **double** | People per floor area expressed as [people/m2] | 
**OccupancySchedule** | **string** | Identifier of a schedule for the occupancy over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the people_per_area to yield a complete occupancy profile. | 
**Type** | **string** |  | [optional] [readonly] [default to "PeopleAbridged"]
**ActivitySchedule** | **string** | Identifier of a schedule for the activity of the occupants over the course of the year. The type of this schedule should be ActivityLevel and the values of the schedule equal to the number of Watts given off by an individual person in the room. If None, a default constant schedule with 120 Watts per person will be used, which is typical of awake, adult humans who are seated. | [optional] 
**RadiantFraction** | **double** | The radiant fraction of sensible heat released by people. (Default: 0.3). | [optional] [default to 0.3D]
**LatentFraction** | [**AnyOfAutocalculatedouble**](AnyOfAutocalculatedouble.md) | Number for the latent fraction of heat gain due to people or an Autocalculate object. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

