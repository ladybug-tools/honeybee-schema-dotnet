
# HoneybeeSchema.Model.IdealAirSystemAbridged

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Name of the object. Must use only ASCII characters and exclude (, ; ! \\n \\t). It cannot be longer than 100 characters. | 
**Type** | **string** |  | [optional] [default to "IdealAirSystemAbridged"]
**EconomizerType** | **string** | Text to indicate the type of air-side economizer used on the ideal air system. Economizers will mix in a greater amount of outdoor air to cool the zone (rather than running the cooling system) when the zone needs cooling and the outdoor air is cooler than the zone. | [optional] [default to EconomizerTypeEnum.DifferentialDryBulb]
**DemandControlVentilation** | **bool** | Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the zone. | [optional] [default to false]
**SensibleHeatRecovery** | **double** | A number between 0 and 1 for the effectiveness of sensible heat recovery within the system. | [optional] [default to 0M]
**LatentHeatRecovery** | **double** | A number between 0 and 1 for the effectiveness of latent heat recovery within the system. | [optional] [default to 0M]
**HeatingAirTemperature** | **double** | A number for the maximum heating supply air temperature [C]. | [optional] [default to 50M]
**CoolingAirTemperature** | **double** | A number for the minimum cooling supply air temperature [C]. | [optional] [default to 13M]
**HeatingLimit** | [**AnyOfNoLimitAutosizenumber**](AnyOfNoLimitAutosizenumber.md) | A number for the maximum heating capacity in Watts. This can also be an Autosize object to indicate that the capacity should be determined during the EnergyPlus sizing calculation. This can also be a NoLimit boject to indicate no upper limit to the heating capacity. | [optional] 
**CoolingLimit** | [**AnyOfNoLimitAutosizenumber**](AnyOfNoLimitAutosizenumber.md) | A number for the maximum cooling capacity in Watts. This can also be an Autosize object to indicate that the capacity should be determined during the EnergyPlus sizing calculation. This can also be a NoLimit boject to indicate no upper limit to the cooling capacity. | [optional] 
**HeatingAvailability** | **string** | An optional name of a schedule to set the availability of heating over the course of the simulation. | [optional] 
**CoolingAvailability** | **string** | An optional name of a schedule to set the availability of cooling over the course of the simulation. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

