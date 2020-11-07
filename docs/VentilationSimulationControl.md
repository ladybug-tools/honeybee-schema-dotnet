
# HoneybeeSchema.Model.VentilationSimulationControl

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "VentilationSimulationControl"]
**VentControlType** | **VentilationControlType** | Text indicating type of ventilation control. Choices are: SingleZone, MultiZoneWithDistribution, MultiZoneWithoutDistribution. The MultiZone options will model air flow with the AirflowNetwork model, which is generally more accurate then the SingleZone option, but will take considerably longer to simulate, and requires defining more ventilation parameters to explicitly account for weather and building-induced pressure differences, and the leakage geometry corresponding to specific windows, doors, and surface cracks. | [optional] 
**ReferenceTemperature** | **double** | Reference temperature measurement in Celsius under which the surface crack data were obtained. | [optional] [default to 20D]
**ReferencePressure** | **double** | Reference barometric pressure measurement in Pascals under which the surface crack data were obtained. | [optional] [default to 101325D]
**ReferenceHumidityRatio** | **double** | Reference humidity ratio measurement in kgWater/kgDryAir under which the surface crack data were obtained. | [optional] [default to 0D]
**BuildingType** | **BuildingType** | Text indicating relationship between building footprint and height used to calculate the wind pressure coefficients for exterior surfaces.Choices are: LowRise and HighRise. LowRise corresponds to rectangular building whose height is less then three times the width and length of the footprint. HighRise corresponds to a rectangular building whose height is more than three times the width and length of the footprint. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate. | [optional] 
**LongAxisAngle** | **double** | The clockwise rotation in degrees from true North of the long axis of the building. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate. | [optional] [default to 0D]
**AspectRatio** | **double** | Aspect ratio of a rectangular footprint, defined as the ratio of length of the short axis divided by the length of the long axis. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate. | [optional] [default to 1D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

