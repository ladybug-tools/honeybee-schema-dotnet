import { IsEnum, ValidateNested, IsDefined, IsString, IsBoolean, IsArray, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { GeometryObjectTypes } from "./GeometryObjectTypes";
import { OpenAPIGenBaseModel } from "./OpenAPIGenBaseModel";

export class ChangedObject extends OpenAPIGenBaseModel {
    @IsEnum(GeometryObjectTypes)
    @ValidateNested()
    @IsDefined()
    /** Text for the type of object that has been changed. */
    element_type!: GeometryObjectTypes;
	
    @IsString()
    @IsDefined()
    /** Text string for the unique object ID that has changed. */
    element_id!: string;
	
    @IsBoolean()
    @IsDefined()
    /** A boolean to note whether the geometry of the object has changed (True) or not (False). For the case of a Room, any change in the geometry of child Faces, Apertures or Doors will cause this property to be True. Note that this property is only True if the change in geometry produces a visible change greater than the base model tolerance. So converting the model between different unit systems, removing colinear vertices, or doing other transformations that are common for export to simulation engines will not trigger this property to become True. */
    geometry_changed!: boolean;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsDefined()
    /** A list of DisplayFace3D dictionaries for the new, changed geometry. The schema of DisplayFace3D can be found in the ladybug-display-schema documentation (https://www.ladybug.tools/ladybug-display-schema) and these objects can be used to generate visualizations of individual objects that have been changed. Note that this attribute is always included in the ChangedObject, even when geometry_changed is False. */
    geometry!: Object [];
	
    @IsString()
    @IsOptional()
    /** Text string for the display name of the object that has changed. */
    element_name?: string;
	
    @IsBoolean()
    @IsOptional()
    /** A boolean to note whether the energy properties of the object have changed (True) or not (False) such that it is possible for the properties of the changed object to be applied to the base model. For Rooms, this property will only be true if the energy property assigned to the Room has changed and will not be true if a property assigned to an individual child Face or Aperture has changed. */
    energy_changed?: boolean;
	
    @IsBoolean()
    @IsOptional()
    /** A boolean to note whether the radiance properties of the object have changed (True) or not (False) such that it is possible for the properties of the changed object to be applied to the base model. For Rooms, this property will only be true if the radiance property assigned to the Room has changed and will not be true if a property assigned to an individual child Face or Aperture has changed. */
    radiance_changed?: boolean;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of DisplayFace3D dictionaries for the existing (base) geometry. The schema of DisplayFace3D can be found in the ladybug-display-schema documentation (https://www.ladybug.tools/ladybug-display-schema) and these objects can be used to generate visualizations of individual objects that have been changed. This attribute is optional and will NOT be output if geometry_changed is False. */
    existing_geometry?: Object [];
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.energy_changed = false;
        this.radiance_changed = false;
        this.type = "ChangedObject";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.element_type = _data["element_type"];
            this.element_id = _data["element_id"];
            this.geometry_changed = _data["geometry_changed"];
            this.geometry = _data["geometry"];
            this.element_name = _data["element_name"];
            this.energy_changed = _data["energy_changed"] !== undefined ? _data["energy_changed"] : false;
            this.radiance_changed = _data["radiance_changed"] !== undefined ? _data["radiance_changed"] : false;
            this.existing_geometry = _data["existing_geometry"];
            this.type = _data["type"] !== undefined ? _data["type"] : "ChangedObject";
        }
    }


    static override fromJS(data: any): ChangedObject {
        data = typeof data === 'object' ? data : {};

        let result = new ChangedObject();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["element_type"] = this.element_type;
        data["element_id"] = this.element_id;
        data["geometry_changed"] = this.geometry_changed;
        data["geometry"] = this.geometry;
        data["element_name"] = this.element_name;
        data["energy_changed"] = this.energy_changed;
        data["radiance_changed"] = this.radiance_changed;
        data["existing_geometry"] = this.existing_geometry;
        data["type"] = this.type;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
