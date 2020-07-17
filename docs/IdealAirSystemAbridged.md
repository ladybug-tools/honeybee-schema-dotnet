
# HoneybeeSchema.Model.IdealAirSystemAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "IdealAirSystemAbridged"]
**EconomizerType** | **EconomizerType** |  | [optional] 
**DemandControlledVentilation** | **bool** | Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the zone. | [optional] [default to false]
**SensibleHeatRecovery** | **double** | A number between 0 and 1 for the effectiveness of sensible heat recovery within the system. | [optional] [default to 0D]
**LatentHeatRecovery** | **double** | A number between 0 and 1 for the effectiveness of latent heat recovery within the system. | [optional] [default to 0D]
**HeatingAirTemperature** | **double** | A number for the maximum heating supply air temperature [C]. | [optional] [default to 50D]
**CoolingAirTemperature** | **double** | A number for the minimum cooling supply air temperature [C]. | [optional] [default to 13D]
**HeatingLimit** | [**AnyOfAutosizeNoLimitdouble**](AnyOfAutosizeNoLimitdouble.md) | A number for the maximum heating capacity in Watts. This can also be an Autosize object to indicate that the capacity should be determined during the EnergyPlus sizing calculation. This can also be a NoLimit object to indicate no upper limit to the heating capacity. | [optional] 
**CoolingLimit** | [**AnyOfAutosizeNoLimitdouble**](AnyOfAutosizeNoLimitdouble.md) | A number for the maximum cooling capacity in Watts. This can also be an Autosize object to indicate that the capacity should be determined during the EnergyPlus sizing calculation. This can also be a NoLimit object to indicate no upper limit to the cooling capacity. | [optional] 
**HeatingAvailability** | **string** | An optional identifier of a schedule to set the availability of heating over the course of the simulation. | [optional] 
**CoolingAvailability** | **string** | An optional identifier of a schedule to set the availability of cooling over the course of the simulation. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

