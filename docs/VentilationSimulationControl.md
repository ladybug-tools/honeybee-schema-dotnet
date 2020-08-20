
# HoneybeeSchema.Model.VentilationSimulationControl

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "VentilationSimulationControl"]
**VentControlType** | **VentilationControlType** |  | [optional] 
**ReferenceTemperature** | **double** | Reference temperature measurement in Celsius under which the surface crack data were obtained. | [optional] [default to 20D]
**ReferencePressure** | **double** | Reference barometric pressure measurement in Pascals under which the surface crack data were obtained. | [optional] [default to 101325D]
**ReferenceHumidityRatio** | **double** | Reference humidity ratio measurement in kgWater/kgDryAir under which the surface crack data were obtained. | [optional] [default to 0D]
**BuildingType** | **BuildingType** |  | [optional] 
**LongAxisAngle** | **double** | The clockwise rotation in degrees from true North of the long axis of the building. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate. | [optional] [default to 0D]
**AspectRatio** | **double** | Aspect ratio of a rectangular footprint, defined as the ratio of length of the short axis divided by the length of the long axis. This parameter is required to automatically calculate wind pressure coefficients for the AirflowNetwork simulation. If used for complex building geometries that cannot be described as a highrise or lowrise rectangular mass, the resulting air flow and pressure simulated on the building surfaces may be inaccurate. | [optional] [default to 1D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

