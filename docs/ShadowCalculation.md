
# HoneybeeSchema.Model.ShadowCalculation

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "ShadowCalculation"]
**SolarDistribution** | **SolarDistribution** |  | [optional] [default to "FullExteriorWithReflections"]
**CalculationMethod** | **CalculationMethod** | Text noting whether CPU-based polygon clipping method orGPU-based pixel counting method should be used. For low numbers of shadingsurfaces (less than ~200), PolygonClipping requires less runtime thanPixelCounting. However, PixelCounting runtime scales significantlybetter at higher numbers of shading surfaces. PixelCounting also hasno limitations related to zone concavity when used with any“FullInterior” solar distribution options. | [optional] [default to "PolygonClipping"]
**CalculationUpdateMethod** | **CalculationUpdateMethod** | Text describing how often the solar and shading calculations are updated with respect to the flow of time in the simulation. | [optional] [default to "Periodic"]
**CalculationFrequency** | **int** | Integer for the number of days in each period for which a unique shadow calculation will be performed. This field is only used if the Periodic calculation_method is used. | [optional] [default to 30]
**MaximumFigures** | **int** | Number of allowable figures in shadow overlap calculations. | [optional] [default to 15000]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

