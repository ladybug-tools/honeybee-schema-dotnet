
# HoneybeeSchema.Model.Radiant

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Vintage** | **Vintages** | Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "Radiant"]
**EquipmentType** | **RadiantEquipmentType** | Text for the specific type of system equipment from the RadiantEquipmentType enumeration. | [optional] 
**RadiantFaceType** | **RadiantFaceTypes** | Text to indicate which faces are thermally active by default. Note that this property has no effect when the rooms to which the HVAC system is assigned have constructions with internal source materials. In this case, those constructions will dictate the thermally active surfaces. | [optional] 
**MinimumOperationTime** | **double** | A number for the minimum number of hours of operation for the radiant system before it shuts off. | [optional] [default to 1.0D]
**SwitchOverTime** | **double** | A number for the minimum number of hours for when the system can switch between heating and cooling. | [optional] [default to 24.0D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

