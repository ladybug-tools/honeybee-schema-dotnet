
# HoneybeeSchema.Model.VentilationOpening

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "VentilationOpening"]
**FractionAreaOperable** | **double** | A number for the fraction of the window area that is operable. | [optional] [default to 0.5D]
**FractionHeightOperable** | **double** | A number for the fraction of the distance from the bottom of the window to the top that is operable | [optional] [default to 1.0D]
**DischargeCoefficient** | **double** | A number that will be multipled by the area of the window in the stack (buoyancy-driven) part of the equation to account for additional friction from window geometry, insect screens, etc. Typical values include 0.45, for unobstructed windows WITH insect screens and 0.65 for unobstructed windows WITHOUT insect screens. This value should be lowered if windows are of an awning or casement type and are not allowed to fully open. | [optional] [default to 0.45D]
**WindCrossVent** | **bool** | Boolean to indicate if there is an opening of roughly equal area on the opposite side of the Room such that wind-driven cross ventilation will be induced. If False, the assumption is that the operable area is primarily on one side of the Room and there is no wind-driven ventilation. | [optional] [default to false]
**FlowCoefficientClosed** | **double** | An optional number in kg/s-m, at 1 Pa per meter of crack length, used to calculate the mass flow rate when the opening is closed; required to run an AirflowNetwork simulation. The DesignBuilder Cracks template defines the flow coefficient for a tight, low-leakage closed external window to be 0.00001, and the flow coefficient for a very poor, high-leakage closed external window to be 0.003. | [optional] 
**FlowExponentClosed** | **double** | An optional dimensionless number between 0.5 and 1 used to calculate the mass flow rate when the opening is closed; required to run an AirflowNetwork simulation. This value represents the leak geometry impact on airflow, with 0.5 generally corresponding to turbulent orifice flow and 1 generally corresponding to laminar flow. The default of 0.65 is representative of many cases of wall and window leakage, used when the exponent cannot be measured. | [optional] [default to 0.65D]
**TwoWayThreshold** | **double** | A number in kg/m3 indicating the minimum density difference above which two-way flow may occur due to stack effect, required to run an AirflowNetwork simulation. This value is required because the air density difference between two zones (which drives two-way air flow) will tend towards division by zero errors as the air density difference approaches zero. The default of 0.0001 is a typical default value used for AirflowNetwork openings. | [optional] [default to 0.00010D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

