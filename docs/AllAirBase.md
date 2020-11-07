
# HoneybeeSchema.Model.AllAirBase

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**Vintage** | **Vintages** | Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards | [optional] 
**EconomizerType** | **AllAirEconomizerType** | Text to indicate the type of air-side economizer used on the system (from the AllAirEconomizerType enumeration). If Inferred, the economizer will be set to whatever is recommended for the given vintage. | [optional] 
**SensibleHeatRecovery** | [**AnyOfAutosizedouble**](AnyOfAutosizedouble.md) | A number between 0 and 1 for the effectiveness of sensible heat recovery within the system. If None or Autosize, it will be whatever is recommended for the given vintage. | [optional] 
**LatentHeatRecovery** | [**AnyOfAutosizedouble**](AnyOfAutosizedouble.md) | A number between 0 and 1 for the effectiveness of latent heat recovery within the system. If None or Autosize, it will be whatever is recommended for the given vintage. | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "_AllAirBase"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

