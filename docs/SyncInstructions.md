
# HoneybeeSchema.Model.SyncInstructions

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "SyncInstructions"]
**ChangedObjects** | [**List&lt;ChangedInstruction&gt;**](ChangedInstruction.md) | A list of ChangedInstruction definitions for each top-level object with properties to transfer from the new/updated model to the base/existing model. | [optional] 
**DeletedObjects** | [**List&lt;DeletedInstruction&gt;**](DeletedInstruction.md) | A list of DeletedInstruction definitions for each top-level object to be deleted from the base/existing model. | [optional] 
**AddedObjects** | [**List&lt;AddedInstruction&gt;**](AddedInstruction.md) | A list of AddedInstruction definitions for each top-level object to be added to the base/existing model from the new/updated model. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

