
# HoneybeeSchema.Model.WindowConstruction

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Layers** | **List&lt;string&gt;** | List of strings for glazing or gas material identifiers. The order of the materials is from exterior to interior. If a SimpleGlazSys material is used, it must be the only material in the construction. For multi-layered constructions, adjacent glass layers must be separated by one and only one gas layer. | 
**Materials** | [**List&lt;AnyOfEnergyWindowMaterialSimpleGlazSysEnergyWindowMaterialGlazingEnergyWindowMaterialGasEnergyWindowMaterialGasCustomEnergyWindowMaterialGasMixture&gt;**](AnyOfEnergyWindowMaterialSimpleGlazSysEnergyWindowMaterialGlazingEnergyWindowMaterialGasEnergyWindowMaterialGasCustomEnergyWindowMaterialGasMixture.md) | List of glazing and gas material definitions that are referenced in the layers. Note that the order of materials does not matter and there is no need to specify duplicated materials in this list. | 
**Type** | **string** |  | [optional] [readonly] [default to "WindowConstruction"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

