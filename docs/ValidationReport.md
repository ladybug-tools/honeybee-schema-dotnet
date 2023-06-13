
# HoneybeeSchema.Model.ValidationReport

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AppVersion** | **string** | Text string for the version of honeybee-core or dragonfly-core that performed the validation. | 
**SchemaVersion** | **string** | Text string for the version of honeybee-schema or dragonfly-schema that performed the validation. | 
**Valid** | **bool** | Boolean to note whether the Model is valid or not. | 
**Type** | **string** |  | [optional] [readonly] [default to "ValidationReport"]
**AppName** | **string** | Text string for the name of the application that performed the validation. This is typically either Honeybee or Dragonfly. | [optional] [default to "Honeybee"]
**FatalError** | **string** | A text string containing an exception if the Model failed to serialize. It will be an empty string if serialization was successful. | [optional] [default to ""]
**Errors** | [**List&lt;ValidationError&gt;**](ValidationError.md) | A list of objects for each error that was discovered in the model. This will be an empty list or None if no errors were found. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

