
# HoneybeeSchema.Model.ScheduleTypeLimit

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Name** | **string** | Name of the object. Must use only ASCII characters and exclude (, ; ! \\n \\t). It cannot be longer than 100 characters. | 
**Type** | **string** |  | [optional] [default to "ScheduleTypeLimit"]
**LowerLimit** | [**AnyOfNoLimitnumber**](AnyOfNoLimitnumber.md) | Lower limit for the schedule type or NoLimit. | [optional] 
**UpperLimit** | [**AnyOfNoLimitnumber**](AnyOfNoLimitnumber.md) | Upper limit for the schedule type or NoLimit. | [optional] 
**NumericType** | **string** |  | [optional] [default to NumericTypeEnum.Continuous]
**UnitType** | **string** |  | [optional] [default to UnitTypeEnum.Dimensionless]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

