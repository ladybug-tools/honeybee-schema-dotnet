
# HoneybeeSchema.Model.ElectricLoadCenter

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "ElectricLoadCenter"]
**InverterEfficiency** | **double** | A number between 0 and 1 for the load center inverter nominal rated DC-to-AC conversion efficiency. An inverter converts DC power, such as that output by photovoltaic panels, to AC power, such as that distributed by the electrical grid and is available from standard electrical outlets. Inverter efficiency is defined as the inverter rated AC power output divided by its rated DC power output. | [optional] [default to 0.96D]
**InverterDcToAcSizeRatio** | **double** | A positive number (typically greater than 1) for the ratio of the inverter DC rated size to its AC rated size. Typically, inverters are not sized to convert the full DC output under standard test conditions (STC) as such conditions rarely occur in reality and therefore unnecessarily add to the size/cost of the inverter. For a system with a high DC to AC size ratio, during times when the DC power output exceeds the inverter rated DC input size, the inverter limits the power output by increasing the DC operating voltage, which moves the arrays operating point down its current-voltage (I-V) curve. In EnergyPlus, this is accomplished by simply limiting the system output to the AC size as dictated by the ratio. The default value of 1.1 is reasonable for most systems. A typical range is 1.1 to 1.25, although some large-scale systems have ratios of as high as 1.5. The optimal value depends on the system location, array orientation, and module cost. | [optional] [default to 1.1D]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

