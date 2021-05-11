
# HoneybeeSchema.Model.WindowConstruction

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**Materials** | [**List&lt;AnyOfEnergyWindowMaterialSimpleGlazSysEnergyWindowMaterialGlazingEnergyWindowMaterialGasEnergyWindowMaterialGasCustomEnergyWindowMaterialGasMixture&gt;**](AnyOfEnergyWindowMaterialSimpleGlazSysEnergyWindowMaterialGlazingEnergyWindowMaterialGasEnergyWindowMaterialGasCustomEnergyWindowMaterialGasMixture.md) | List of glazing and gas material definitions. The order of the materials is from exterior to interior. If a SimpleGlazSys material is used, it must be the only material in the construction. For multi-layered constructions, adjacent glass layers must be separated by one and only one gas layer. | 
**Type** | **string** |  | [optional] [readonly] [default to "WindowConstruction"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

