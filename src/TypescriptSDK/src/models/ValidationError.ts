import { IsString, IsDefined, Matches, MinLength, MaxLength, IsEnum, IsArray, IsOptional, ValidateNested, IsInstance, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { ExtensionTypes } from "./ExtensionTypes";
import { LineSegment3D } from "./LineSegment3D";
import { ObjectTypes } from "./ObjectTypes";
import { Point3D } from "./Point3D";
import { ValidationParent } from "./ValidationParent";

export class ValidationError {
    @IsString()
    @IsDefined()
    @Matches(/([0-9]+)/)
    @MinLength(6)
    @MaxLength(6)
    @Expose({ name: "code" })
    /** Text with 6 digits for the error code. The first two digits indicate whether the error is a core honeybee error (00) vs. an extension error (any non-zero number). The second two digits indicate the nature of the error (00 is an identifier error, 01 is a geometry error, 02 is an adjacency error). The third two digits are used to give a unique ID to each condition moving upwards from more specific/detailed objects/errors to coarser/more abstract objects/errors. A full list of error codes can be found here: https://docs.pollination.solutions/user-manual/rhino-plugin/troubleshooting/help-with-modeling-error-codes */
    code!: string;
	
    @IsString()
    @IsDefined()
    @Expose({ name: "error_type" })
    /** A human-readable version of the error code, typically not more than five words long. */
    errorType!: string;
	
    @IsEnum(ExtensionTypes)
    @Type(() => String)
    @IsDefined()
    @Expose({ name: "extension_type" })
    /** Text for the Honeybee extension from which the error originated (from the ExtensionTypes enumeration). */
    extensionType!: ExtensionTypes;
	
    @IsEnum(ObjectTypes)
    @Type(() => String)
    @IsDefined()
    @Expose({ name: "element_type" })
    /** Text for the type of object that caused the error. */
    elementType!: ObjectTypes;
	
    @IsArray()
    @IsString({ each: true })
    @IsDefined()
    @Expose({ name: "element_id" })
    /** A list of text strings for the unique object IDs that caused the error. The list typically contains a single item but there are some types errors that stem from multiple objects like mis-matched area adjacencies or overlapping Room geometries. Note that the IDs in this list can be the identifier of a core object like a Room or a Face or it can be for an extension object like a SensorGrid or a Construction. */
    elementId!: string[];
	
    @IsString()
    @IsDefined()
    @Expose({ name: "message" })
    /** Text for the error message with a detailed description of what exactly is invalid about the element. */
    message!: string;
	
    @IsString()
    @IsOptional()
    @Matches(/^ValidationError$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ValidationError";
	
    @IsArray()
    @IsString({ each: true })
    @IsOptional()
    @Expose({ name: "element_name" })
    /** A list of text strings for the display names of the objects that caused the error. */
    elementName?: string[];
	
    @IsArray()
    @IsArray({ each: true })
    @ValidateNested({each: true })
    @Type(() => Array)
    @IsInstance(ValidationParent, { each: true })
    @Type(() => ValidationParent)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "parents" })
    /** A list lists where each sub-list corresponds to one of the objects in the element_id property. Each sub-list contains information for the parent objects of the object that caused the error. This can be useful for locating the problematic object in the model. This will contain 1 item for a Face with a parent Room. It will contain 2 for an Aperture that has a parent Face with a parent Room. */
    parents?: ValidationParent[][];
	
    @IsArray()
    @IsInstance(ValidationParent, { each: true })
    @Type(() => ValidationParent)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "top_parents" })
    /** A list of top-level parent objects for the specific case of duplicate child-object identifiers, where several top-level parents are involved. */
    topParents?: ValidationParent[];
	
    @IsArray()
    @IsOptional()
    @Expose({ name: "helper_geometry" })
    @Transform(({ value }) => value.map((item: any) => {
      if (item?.type === 'Point3D') return Point3D.fromJS(item);
      else if (item?.type === 'LineSegment3D') return LineSegment3D.fromJS(item);
      else return item;
    }))
    /** An optional list of geometry objects that helps illustrate where exactly issues with invalid geometry exist within the Honeybee object. Examples include the naked and non-manifold line segments for non-solid Room geometries, the points of self-intersection for cases of self-intersecting geometry and out-of-plane vertices for non-planar objects. Oftentimes, zooming directly to these helper geometries will help end users understand invalid situations in their model faster than simple zooming to the invalid Honeybee object in its totality. */
    helperGeometry?: (Point3D | LineSegment3D)[];
	

    constructor() {
        this.type = "ValidationError";
    }


    init(_data?: any) {
        if (_data) {
            const obj = plainToClass(ValidationError, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.code = obj.code;
            this.errorType = obj.errorType;
            this.extensionType = obj.extensionType;
            this.elementType = obj.elementType;
            this.elementId = obj.elementId;
            this.message = obj.message;
            this.type = obj.type ?? "ValidationError";
            this.elementName = obj.elementName;
            this.parents = obj.parents;
            this.topParents = obj.topParents;
            this.helperGeometry = obj.helperGeometry;
        }
    }


    static fromJS(data: any): ValidationError {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ValidationError();
        result.init(data);
        return result;
    }

	toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["code"] = this.code;
        data["error_type"] = this.errorType;
        data["extension_type"] = this.extensionType;
        data["element_type"] = this.elementType;
        data["element_id"] = this.elementId;
        data["message"] = this.message;
        data["type"] = this.type ?? "ValidationError";
        data["element_name"] = this.elementName;
        data["parents"] = this.parents;
        data["top_parents"] = this.topParents;
        data["helper_geometry"] = this.helperGeometry;
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
