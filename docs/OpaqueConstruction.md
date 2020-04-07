
# HoneybeeSchema.Model.OpaqueConstruction

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**Layers** | **List&lt;string&gt;** | List of strings for material identifiers. The order of the materials is from exterior to interior. | 
**Materials** | [**List&lt;AnyOfEnergyMaterialEnergyMaterialNoMass&gt;**](AnyOfEnergyMaterialEnergyMaterialNoMass.md) | List of materials. The order of the materials is from outside to inside. | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**Type** | **string** |  | [optional] [default to "OpaqueConstruction"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

