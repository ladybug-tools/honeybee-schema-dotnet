
# HoneybeeSchema.Model.PeopleAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**PeoplePerArea** | **double** | People per floor area expressed as [people/m2] | 
**OccupancySchedule** | **string** | Identifier of a schedule for the occupancy over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the people_per_area to yield a complete occupancy profile. | 
**ActivitySchedule** | **string** | Identifier of a schedule for the activity of the occupants over the course of the year. The type of this schedule should be Power and the values of the schedule equal to the number of Watts given off by an individual person in the room. | 
**Type** | **string** |  | [optional] [readonly] [default to "PeopleAbridged"]
**RadiantFraction** | **double** | The radiant fraction of sensible heat released by people. The defaultvalue is 0.30. | [optional] [default to 0.3D]
**LatentFraction** | [**AnyOfAutocalculatedouble**](AnyOfAutocalculatedouble.md) | Number for the latent fraction of heat gain due to people or an Autocalculate object. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

