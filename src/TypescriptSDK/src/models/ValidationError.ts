import { IsString, IsDefined, Matches, MinLength, MaxLength, IsEnum, IsArray, IsOptional, ValidateNested, IsInstance, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
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
    /** Text with 6 digits for the error code. The first two digits indicate whether the error is a core honeybee error (00) vs. an extension error (any non-zero number). The second two digits indicate the nature of the error (00 is an identifier error, 01 is a geometry error, 02 is an adjacency error). The third two digits are used to give a unique ID to each condition moving upwards from more specific/detailed objects/errors to coarser/more abstract objects/errors. A full list of error codes can be found here: https://docs.pollination.solutions/user-manual/rhino-plugin/troubleshooting/help-with-modeling-error-codes */
    code!: string;
	
    @IsString()
    @IsDefined()
    /** A human-readable version of the error code, typically not more than five words long. */
    error_type!: string;
	
    @IsEnum(ExtensionTypes)
    @Type(() => String)
    @IsDefined()
    /** Text for the Honeybee extension from which the error originated (from the ExtensionTypes enumeration). */
    extension_type!: ExtensionTypes;
	
    @IsEnum(ObjectTypes)
    @Type(() => String)
    @IsDefined()
    /** Text for the type of object that caused the error. */
    element_type!: ObjectTypes;
	
    @IsArray()
    @IsString({ each: true })
    @IsDefined()
    /** A list of text strings for the unique object IDs that caused the error. The list typically contains a single item but there are some types errors that stem from multiple objects like mis-matched area adjacencies or overlapping Room geometries. Note that the IDs in this list can be the identifier of a core object like a Room or a Face or it can be for an extension object like a SensorGrid or a Construction. */
    element_id!: string[];
	
    @IsString()
    @IsDefined()
    /** Text for the error message with a detailed description of what exactly is invalid about the element. */
    message!: string;
	
    @IsString()
    @IsOptional()
    @Matches(/^ValidationError$/)
    /** Type */
    type?: string;
	
    @IsArray()
    @IsString({ each: true })
    @IsOptional()
    /** A list of text strings for the display names of the objects that caused the error. */
    element_name?: string[];
	
    @IsArray()
    @IsArray({ each: true })
    @ValidateNested({each: true })
    @Type(() => Array)
    @IsInstance(ValidationParent, { each: true })
    @Type(() => ValidationParent)
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list lists where each sub-list corresponds to one of the objects in the element_id property. Each sub-list contains information for the parent objects of the object that caused the error. This can be useful for locating the problematic object in the model. This will contain 1 item for a Face with a parent Room. It will contain 2 for an Aperture that has a parent Face with a parent Room. */
    parents?: ValidationParent[][];
	
    @IsArray()
    @IsInstance(ValidationParent, { each: true })
    @Type(() => ValidationParent)
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of top-level parent objects for the specific case of duplicate child-object identifiers, where several top-level parents are involved. */
    top_parents?: ValidationParent[];
	
    @IsArray()
    @IsOptional()
    @Transform(({ value }) => value.map((item: any) => {
      if (item?.type === 'Point3D') return Point3D.fromJS(item);
      else if (item?.type === 'LineSegment3D') return LineSegment3D.fromJS(item);
      else return item;
    }))
    /** An optional list of geometry objects that helps illustrate where exactly issues with invalid geometry exist within the Honeybee object. Examples include the naked and non-manifold line segments for non-solid Room geometries, the points of self-intersection for cases of self-intersecting geometry and out-of-plane vertices for non-planar objects. Oftentimes, zooming directly to these helper geometries will help end users understand invalid situations in their model faster than simple zooming to the invalid Honeybee object in its totality. */
    helper_geometry?: (Point3D | LineSegment3D)[];
	

    constructor() {
        this.type = "ValidationError";
    }


    init(_data?: any) {
        if (_data) {
            const obj = plainToClass(ValidationError, _data, { enableImplicitConversion: true });
            this.code = obj.code;
            this.error_type = obj.error_type;
            this.extension_type = obj.extension_type;
            this.element_type = obj.element_type;
            this.element_id = obj.element_id;
            this.message = obj.message;
            this.type = obj.type;
            this.element_name = obj.element_name;
            this.parents = obj.parents;
            this.top_parents = obj.top_parents;
            this.helper_geometry = obj.helper_geometry;
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
        data["error_type"] = this.error_type;
        data["extension_type"] = this.extension_type;
        data["element_type"] = this.element_type;
        data["element_id"] = this.element_id;
        data["message"] = this.message;
        data["type"] = this.type;
        data["element_name"] = this.element_name;
        data["parents"] = this.parents;
        data["top_parents"] = this.top_parents;
        data["helper_geometry"] = this.helper_geometry;
        return removeUndefinedProperties(data);
    }

}

function removeUndefinedProperties(obj: any): any {
    if (Array.isArray(obj)) {
        return obj.map(removeUndefinedProperties);
    } else if (obj !== null && typeof obj === 'object') {
        return Object.entries(obj)
        .filter(([_, value]) => value !== undefined)
        .reduce((acc, [key, value]) => {
            acc[key] = removeUndefinedProperties(value);
            return acc;
        }, {} as any);
    }
    return obj;
}
