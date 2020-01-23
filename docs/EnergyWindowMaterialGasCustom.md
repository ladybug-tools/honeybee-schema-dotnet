
# HoneybeeDotNet.Model.EnergyWindowMaterialGasCustom

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Name of the object. Must use only ASCII characters and exclude (, ; ! \\n \\t). It cannot be longer than 100 characters. | 
**ConductivityCoeffA** | **decimal** | The A coefficient for gas conductivity in W/(m-K). | 
**ViscosityCoeffA** | **decimal** | The A coefficient for gas viscosity in kg/(m-s). | 
**SpecificHeatCoeffA** | **decimal** | The A coefficient for gas specific heat in J/(kg-K). | 
**SpecificHeatRatio** | **decimal** | The specific heat ratio for gas. | 
**MolecularWeight** | **decimal** | The molecular weight for gas in g/mol. | 
**Type** | **string** |  | [optional] [default to "EnergyWindowMaterialGasCustom"]
**Thickness** | **decimal** | Thickness of the gas layer in meters. Default value is 0.0125. | [optional] [default to 0.0125M]
**ConductivityCoeffB** | **decimal** | The B coefficient for gas conductivity in W/(m-K2). | [optional] [default to 0M]
**ConductivityCoeffC** | **decimal** | The C coefficient for gas conductivity in W/(m-K3). | [optional] [default to 0M]
**ViscosityCoeffB** | **decimal** | The B coefficient for gas viscosity in kg/(m-s-K). | [optional] [default to 0M]
**ViscosityCoeffC** | **decimal** | The C coefficient for gas viscosity in kg/(m-s-K2). | [optional] [default to 0M]
**SpecificHeatCoeffB** | **decimal** | The B coefficient for gas specific heat in J/(kg-K2). | [optional] [default to 0M]
**SpecificHeatCoeffC** | **decimal** | The C coefficient for gas specific heat in J/(kg-K3). | [optional] [default to 0M]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

