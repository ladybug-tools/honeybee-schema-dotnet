
# HoneybeeSchema.Model.ComparisonReport

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "ComparisonReport"]
**ChangedObjects** | [**List&lt;ChangedObject&gt;**](ChangedObject.md) | A list of ChangedObject definitions for each top-level object that has changed in the model. To be a changed object, the object identifier must be the same in both models but some other property (either geometry or extension attributes) has experienced a meaningful change. | [optional] 
**DeletedObjects** | [**List&lt;DeletedObject&gt;**](DeletedObject.md) | A list of DeletedObject definitions for each top-level object that has been deleted in the process of going from the base model to the new model. | [optional] 
**AddedObjects** | [**List&lt;AddedObject&gt;**](AddedObject.md) | A list of AddedObject definitions for each top-level object that has been added in the process of going from the base model to the new model. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

