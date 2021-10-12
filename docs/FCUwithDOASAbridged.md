
# HoneybeeSchema.Model.FCUwithDOASAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**UserData** | **Object** | Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). | [optional] 
**Vintage** | **Vintages** | Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards | [optional] 
**SensibleHeatRecovery** | **double** | A number between 0 and 1 for the effectiveness of sensible heat recovery within the system. | [optional] [default to 0D]
**LatentHeatRecovery** | **double** | A number between 0 and 1 for the effectiveness of latent heat recovery within the system. | [optional] [default to 0D]
**DemandControlledVentilation** | **bool** | Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the Rooms. | [optional] [default to false]
**DoasAvailabilitySchedule** | **string** | An optional On/Off discrete schedule to set when the dedicated outdoor air system (DOAS) shuts off. This will not only prevent any outdoor air from flowing thorough the system but will also shut off the fans, which can result in more energy savings when spaces served by the DOAS are completely unoccupied. If None, the DOAS will be always on. | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "FCUwithDOASAbridged"]
**EquipmentType** | **FCUwithDOASEquipmentType** | Text for the specific type of system equipment from the FCUwithDOASEquipmentType enumeration. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

