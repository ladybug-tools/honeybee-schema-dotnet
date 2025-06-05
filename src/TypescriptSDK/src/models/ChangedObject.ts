import { IsEnum, IsDefined, IsString, Matches, MinLength, MaxLength, IsBoolean, IsArray, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { GeometryObjectTypes } from "./GeometryObjectTypes";

export class ChangedObject extends _OpenAPIGenBaseModel {
    @IsEnum(GeometryObjectTypes)
    @Type(() => String)
    @IsDefined()
    @Expose({ name: "element_type" })
    /** Text for the type of object that has been changed. */
    elementType!: GeometryObjectTypes;
	
    @IsString()
    @IsDefined()
    @Matches(/^[^,;!\n\t]+$/)
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "element_id" })
    /** Text string for the unique object ID that has changed. */
    elementId!: string;
	
    @IsBoolean()
    @IsDefined()
    @Expose({ name: "geometry_changed" })
    /** A boolean to note whether the geometry of the object has changed (True) or not (False). For the case of a Room, any change in the geometry of child Faces, Apertures or Doors will cause this property to be True. Note that this property is only True if the change in geometry produces a visible change greater than the base model tolerance. So converting the model between different unit systems, removing colinear vertices, or doing other transformations that are common for export to simulation engines will not trigger this property to become True. */
    geometryChanged!: boolean;
	
    @IsArray()
    @IsDefined()
    @Expose({ name: "geometry" })
    /** A list of DisplayFace3D dictionaries for the new, changed geometry. The schema of DisplayFace3D can be found in the ladybug-display-schema documentation (https://www.ladybug.tools/ladybug-display-schema) and these objects can be used to generate visualizations of individual objects that have been changed. Note that this attribute is always included in the ChangedObject, even when geometry_changed is False. */
    geometry!: Object[];
	
    @IsString()
    @IsOptional()
    @Expose({ name: "element_name" })
    /** Text string for the display name of the object that has changed. */
    elementName?: string;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "energy_changed" })
    /** A boolean to note whether the energy properties of the object have changed (True) or not (False) such that it is possible for the properties of the changed object to be applied to the base model. For Rooms, this property will only be true if the energy property assigned to the Room has changed and will not be true if a property assigned to an individual child Face or Aperture has changed. */
    energyChanged: boolean = false;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "radiance_changed" })
    /** A boolean to note whether the radiance properties of the object have changed (True) or not (False) such that it is possible for the properties of the changed object to be applied to the base model. For Rooms, this property will only be true if the radiance property assigned to the Room has changed and will not be true if a property assigned to an individual child Face or Aperture has changed. */
    radianceChanged: boolean = false;
	
    @IsArray()
    @IsOptional()
    @Expose({ name: "existing_geometry" })
    /** A list of DisplayFace3D dictionaries for the existing (base) geometry. The schema of DisplayFace3D can be found in the ladybug-display-schema documentation (https://www.ladybug.tools/ladybug-display-schema) and these objects can be used to generate visualizations of individual objects that have been changed. This attribute is optional and will NOT be output if geometry_changed is False. */
    existingGeometry?: Object[];
	
    @IsString()
    @IsOptional()
    @Matches(/^ChangedObject$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ChangedObject";
	

    constructor() {
        super();
        this.energyChanged = false;
        this.radianceChanged = false;
        this.type = "ChangedObject";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ChangedObject, _data, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
            this.elementType = obj.elementType;
            this.elementId = obj.elementId;
            this.geometryChanged = obj.geometryChanged;
            this.geometry = obj.geometry;
            this.elementName = obj.elementName;
            this.energyChanged = obj.energyChanged ?? false;
            this.radianceChanged = obj.radianceChanged ?? false;
            this.existingGeometry = obj.existingGeometry;
            this.type = obj.type ?? "ChangedObject";
        }
    }


    static override fromJS(data: any): ChangedObject {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ChangedObject();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["element_type"] = this.elementType;
        data["element_id"] = this.elementId;
        data["geometry_changed"] = this.geometryChanged;
        data["geometry"] = this.geometry;
        data["element_name"] = this.elementName;
        data["energy_changed"] = this.energyChanged ?? false;
        data["radiance_changed"] = this.radianceChanged ?? false;
        data["existing_geometry"] = this.existingGeometry;
        data["type"] = this.type ?? "ChangedObject";
        data = super.toJSON(data);
        return instanceToPlain(data, { exposeUnsetFields: false });
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || [error]).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
