
# HoneybeeSchema.Model.EnergyWindowMaterialGasCustom

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**ConductivityCoeffA** | **double** | The A coefficient for gas conductivity in W/(m-K). | 
**ViscosityCoeffA** | **double** | The A coefficient for gas viscosity in kg/(m-s). | 
**SpecificHeatCoeffA** | **double** | The A coefficient for gas specific heat in J/(kg-K). | 
**SpecificHeatRatio** | **double** | The specific heat ratio for gas. | 
**MolecularWeight** | **double** | The molecular weight for gas in g/mol. | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "EnergyWindowMaterialGasCustom"]
**Thickness** | **double** | Thickness of the gas layer in meters. Default value is 0.0125. | [optional] [default to 0.0125D]
**ConductivityCoeffB** | **double** | The B coefficient for gas conductivity in W/(m-K2). | [optional] [default to 0D]
**ConductivityCoeffC** | **double** | The C coefficient for gas conductivity in W/(m-K3). | [optional] [default to 0D]
**ViscosityCoeffB** | **double** | The B coefficient for gas viscosity in kg/(m-s-K). | [optional] [default to 0D]
**ViscosityCoeffC** | **double** | The C coefficient for gas viscosity in kg/(m-s-K2). | [optional] [default to 0D]
**SpecificHeatCoeffB** | **double** | The B coefficient for gas specific heat in J/(kg-K2). | [optional] [default to 0D]
**SpecificHeatCoeffC** | **double** | The C coefficient for gas specific heat in J/(kg-K3). | [optional] [default to 0D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

