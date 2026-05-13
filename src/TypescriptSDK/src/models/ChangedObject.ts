import { IsBoolean, IsDefined, IsArray, IsString, IsOptional, Equals, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _DiffObjectBase } from "./_DiffObjectBase";

export class ChangedObject extends _DiffObjectBase {
    @Type(() => Boolean)
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
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("ChangedObject")
    @Expose({ name: "type" })
    /** type */
    type: string = "ChangedObject";
	
    @Type(() => Boolean)
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "energy_changed" })
    /** A boolean to note whether the energy properties of the object have changed (True) or not (False) such that it is possible for the properties of the changed object to be applied to the base model. For Rooms, this property will only be true if the energy property assigned to the Room has changed and will not be true if a property assigned to an individual child Face or Aperture has changed. */
    energyChanged: boolean = false;
	
    @Type(() => Boolean)
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
	

    constructor() {
        super();
        this.type = "ChangedObject";
        this.energyChanged = false;
        this.radianceChanged = false;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(ChangedObject, _data);
            this.geometryChanged = obj.geometryChanged;
            this.geometry = obj.geometry;
            this.type = obj.type ?? "ChangedObject";
            this.energyChanged = obj.energyChanged ?? false;
            this.radianceChanged = obj.radianceChanged ?? false;
            this.existingGeometry = obj.existingGeometry;
            this.elementType = obj.elementType;
            this.elementId = obj.elementId;
            this.elementName = obj.elementName;
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
        data["geometry_changed"] = this.geometryChanged;
        data["geometry"] = this.geometry;
        data["type"] = this.type ?? "ChangedObject";
        data["energy_changed"] = this.energyChanged ?? false;
        data["radiance_changed"] = this.radianceChanged ?? false;
        data["existing_geometry"] = this.existingGeometry;
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
