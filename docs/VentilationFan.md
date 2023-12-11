
# HoneybeeSchema.Model.VentilationFan

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Identifier** | **string** | Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be &lt; 100 characters, use only ASCII characters and exclude (, ; ! \\n \\t). | 
**DisplayName** | **string** | Display name of the object with no character restrictions. | [optional] 
**FlowRate** | **double** | A number for the flow rate of the fan in m3/s. | 
**PressureRise** | **double** | A number for the the pressure rise across the fan in Pascals (N/m2). This is often a function of the fan speed and the conditions in which the fan is operating since having the fan blow air through filters or narrow ducts will increase the pressure rise that is needed to deliver the input flow rate. The pressure rise plays an important role in determining the amount of energy consumed by the fan. Smaller fans like a 0.05 m3/s desk fan tend to have lower pressure rises around 60 Pa. Larger fans, such as a 6 m3/s fan used for ventilating a large room tend to have higher pressure rises around 400 Pa. The highest pressure rises are typically for large fans blowing air through ducts and filters, which can have pressure rises as high as 1000 Pa. | 
**Efficiency** | **double** | A number between 0 and 1 for the overall efficiency of the fan. Specifically, this is the ratio of the power delivered to the fluid to the electrical input power. It is the product of the fan motor efficiency and the fan impeller efficiency. Fans that have a higher blade diameter and operate at lower speeds with smaller pressure rises for their size tend to have higher efficiencies. Because motor efficiencies are typically between 0.8 and 0.9, the best overall fan efficiencies tend to be around 0.7 with most typical fan efficiencies between 0.5 and 0.7. The lowest efficiencies often happen for small fans in situations with high pressure rises for their size, which can result in efficiencies as low as 0.15. | 
**Type** | **string** |  | [optional] [readonly] [default to "VentilationFan"]
**VentilationType** | **VentilationType** | Text to indicate the type of type of ventilation. Choose from the options below. For either Exhaust or Intake, values for fan pressure and efficiency define the fan electric consumption. For Exhaust ventilation, the conditions of the air entering the space are assumed to be equivalent to outside air conditions. For Intake and Balanced ventilation, an appropriate amount of fan heat is added to the entering air stream. For Balanced ventilation, both an intake fan and an exhaust fan are assumed to co-exist, both having the same flow rate and power consumption (using the entered values for fan pressure rise and fan total efficiency). Thus, the fan electric consumption for Balanced ventilation is twice that for the Exhaust or Intake ventilation types which employ only a single fan. | [optional] 
**Control** | [**VentilationControlAbridged**](VentilationControlAbridged.md) | A VentilationControl object that dictates the conditions under which the fan is turned on. If None, a default VentilationControl will be generated, which will keep the fan on all of the time. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

