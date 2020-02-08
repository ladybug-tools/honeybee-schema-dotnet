
# HoneybeeSchema.Model.EnergyWindowMaterialGasCustom

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Name of the object. Must use only ASCII characters and exclude (, ; ! \\n \\t). It cannot be longer than 100 characters. | 
**ConductivityCoeffA** | **double** | The A coefficient for gas conductivity in W/(m-K). | 
**ViscosityCoeffA** | **double** | The A coefficient for gas viscosity in kg/(m-s). | 
**SpecificHeatCoeffA** | **double** | The A coefficient for gas specific heat in J/(kg-K). | 
**SpecificHeatRatio** | **double** | The specific heat ratio for gas. | 
**MolecularWeight** | **double** | The molecular weight for gas in g/mol. | 
**Type** | **string** |  | [optional] [default to "EnergyWindowMaterialGasCustom"]
**Thickness** | **double** | Thickness of the gas layer in meters. Default value is 0.0125. | [optional] [default to 0.0125M]
**ConductivityCoeffB** | **double** | The B coefficient for gas conductivity in W/(m-K2). | [optional] [default to 0M]
**ConductivityCoeffC** | **double** | The C coefficient for gas conductivity in W/(m-K3). | [optional] [default to 0M]
**ViscosityCoeffB** | **double** | The B coefficient for gas viscosity in kg/(m-s-K). | [optional] [default to 0M]
**ViscosityCoeffC** | **double** | The C coefficient for gas viscosity in kg/(m-s-K2). | [optional] [default to 0M]
**SpecificHeatCoeffB** | **double** | The B coefficient for gas specific heat in J/(kg-K2). | [optional] [default to 0M]
**SpecificHeatCoeffC** | **double** | The C coefficient for gas specific heat in J/(kg-K3). | [optional] [default to 0M]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

