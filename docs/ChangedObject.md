
# HoneybeeSchema.Model.ChangedObject

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ElementType** | **GeometryObjectTypes** | Text for the type of object that has been changed. | 
**ElementId** | **string** | Text string for the unique object ID that has changed. | 
**GeometryChanged** | **bool** | A boolean to note whether the geometry of the object has changed (True) or not (False). For the case of a Room, any change in the geometry of child Faces, Apertures or Doors will cause this property to be True. Note that this property is only True if the change in geometry produces a visible change greater than the base model tolerance. So converting the model between different unit systems, removing colinear vertices, or doing other transformations that are common for export to simulation engines will not trigger this property to become True. | 
**Geometry** | **List&lt;Object&gt;** | A list of DisplayFace3D dictionaries for the new, changed geometry. The schema of DisplayFace3D can be found in the ladybug-display-schema documentation (https://www.ladybug.tools/ladybug-display-schema) and these objects can be used to generate visualizations of individual objects that have been changed. Note that this attribute is always included in the ChangedObject, even when geometry_changed is False. | 
**ElementName** | **string** | Text string for the display name of the object that has changed. | [optional] 
**EnergyChanged** | **bool** | A boolean to note whether the energy properties of the object have changed (True) or not (False) such that it is possible for the properties of the changed object to be applied to the base model. For Rooms, this property will only be true if the energy property assigned to the Room has changed and will not be true if a property assigned to an individual child Face or Aperture has changed. | [optional] [default to false]
**RadianceChanged** | **bool** | A boolean to note whether the radiance properties of the object have changed (True) or not (False) such that it is possible for the properties of the changed object to be applied to the base model. For Rooms, this property will only be true if the radiance property assigned to the Room has changed and will not be true if a property assigned to an individual child Face or Aperture has changed. | [optional] [default to false]
**ExistingGeometry** | **List&lt;Object&gt;** | A list of DisplayFace3D dictionaries for the existing (base) geometry. The schema of DisplayFace3D can be found in the ladybug-display-schema documentation (https://www.ladybug.tools/ladybug-display-schema) and these objects can be used to generate visualizations of individual objects that have been changed. This attribute is optional and will NOT be output if geometry_changed is False. | [optional] 
**Type** | **string** |  | [optional] [readonly] [default to "ChangedObject"]

[[Back to Model list]](../README.md#documentation-for-models)
[[Back to API list]](../README.md#documentation-for-api-endpoints)
[[Back to README]](../README.md)

