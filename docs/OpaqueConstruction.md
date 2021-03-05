
# HoneybeeSchema.Model.OpaqueConstruction

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Layers** | **List&lt;string&gt;** | List of strings for opaque material identifiers. The order of the materials is from exterior to interior. | 
**Materials** | [**List&lt;AnyOfEnergyMaterialEnergyMaterialNoMass&gt;**](AnyOfEnergyMaterialEnergyMaterialNoMass.md) | List of opaque material definitions that are referenced in the layers. Note that the order of materials does not matter and there is no need to specify duplicated materials in this list. | 
**Type** | **string** |  | [optional] [readonly] [default to "OpaqueConstruction"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

