
# HoneybeeSchema.Model.Room

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, rad). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters and not contain any spaces or special characters. | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**UserData** | [**Object**](.md) | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Faces** | [**List&lt;Face&gt;**](Face.md) | Faces that together form the closed volume of a room. | 
**Properties** | [**RoomPropertiesAbridged**](RoomPropertiesAbridged.md) | Extension properties for particular simulation engines (Radiance, EnergyPlus). | 
**Type** | **string** |  | [optional] [readonly] [default to "Room"]
**IndoorShades** | [**List&lt;Shade&gt;**](Shade.md) | Shades assigned to the interior side of this object (eg. partitions, tables). | [optional] 
**OutdoorShades** | [**List&lt;Shade&gt;**](Shade.md) | Shades assigned to the exterior side of this object (eg. trees, landscaping). | [optional] 
**Multiplier** | **int** | An integer noting how many times this Room is repeated. Multipliers are used to speed up the calculation when similar Rooms are repeated more than once. Essentially, a given simulation with the Room is run once and then the result is mutliplied by the multiplier. | [optional] [default to 1]
**Story** | **string** | Text string for the story identifier to which this Room belongs. Rooms sharing the same story identifier are considered part of the same story in a Model. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

