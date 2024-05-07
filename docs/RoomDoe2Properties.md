
# HoneybeeSchema.Model.RoomDoe2Properties

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | **string** |  | [optional] [readonly] [default to "RoomDoe2Properties"]
**AssignedFlow** | [**AnyOfAutocalculatenumber**](AnyOfAutocalculatenumber.md) | A number for the design supply air flow rate for the zone the Room is assigned to (cfm). This establishes the minimum allowed design air flow. Note that the actual design flow may be larger. If Autocalculate, this parameter will not be written into the INP. | [optional] 
**FlowPerArea** | [**AnyOfAutocalculatenumber**](AnyOfAutocalculatenumber.md) | A number for the design supply air flow rate to the zone per unit floor area (cfm/ft2). If Autocalculate, this parameter will not be written into the INP. | [optional] 
**MinFlowRatio** | [**AnyOfAutocalculatenumber**](AnyOfAutocalculatenumber.md) | A number between 0 and 1 for the minimum allowable zone air supply flow rate, expressed as a fraction of design flow rate. Applicable to variable-volume type systems only. If Autocalculate, this parameter will not be written into the INP. | [optional] 
**MinFlowPerArea** | [**AnyOfAutocalculatenumber**](AnyOfAutocalculatenumber.md) | A number for the minimum air flow per square foot of floor area (cfm/ft2). This is an alternative way of specifying the min_flow_ratio. If Autocalculate, this parameter will not be written into the INP. | [optional] 
**HmaxFlowRatio** | [**AnyOfAutocalculatenumber**](AnyOfAutocalculatenumber.md) | A number between 0 and 1 for the ratio of the maximum (or fixed) heating airflow to the cooling airflow. The specific meaning varies according to the type of zone terminal. If Autocalculate, this parameter will not be written into the INP. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

