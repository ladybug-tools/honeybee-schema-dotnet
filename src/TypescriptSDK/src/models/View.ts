import { IsArray, IsNumber, IsDefined, IsString, IsOptional, Matches, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _RadianceAsset } from "./_RadianceAsset";
import { ViewType } from "./ViewType";

/** A single Radiance of sensors. */
export class View extends _RadianceAsset {
    @IsArray()
    @IsNumber({},{ each: true })
    @IsDefined()
    @Expose({ name: "position" })
    /** The view position (-vp) as an array of (x, y, z) values.This is the focal point of a perspective view or the center of a parallel projection. */
    position!: number[];
	
    @IsArray()
    @IsNumber({},{ each: true })
    @IsDefined()
    @Expose({ name: "direction" })
    /** The view direction (-vd) as an array of (x, y, z) values.The length of this vector indicates the focal distance as needed by the pixel depth of field (-pd) in rpict. */
    direction!: number[];
	
    @IsArray()
    @IsNumber({},{ each: true })
    @IsDefined()
    @Expose({ name: "up_vector" })
    /** The view up (-vu) vector as an array of (x, y, z) values. */
    upVector!: number[];
	
    @IsString()
    @IsOptional()
    @Matches(/^View$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "View";
	
    @IsEnum(ViewType)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "view_type" })
    /** viewType */
    viewType: ViewType = ViewType.V;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "h_size" })
    /** A number for the horizontal field of view in degrees (for all perspective projections including fisheye). For a parallel projection, this is the view width in world coordinates. */
    hSize: number = 60;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "v_size" })
    /** A number for the vertical field of view in degrees (for all perspective projections including fisheye). For a parallel projection, this is the view width in world coordinates. */
    vSize: number = 60;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "shift" })
    /** The view shift (-vs). This is the amount the actual image will be shifted to the right of the specified view. This option is useful for generating skewed perspectives or rendering an image a piece at a time. A value of 1 means that the rendered image starts just to the right of the normal view. A value of -1 would be to the left. Larger or fractional values are permitted as well. */
    shift?: number;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "lift" })
    /** The view lift (-vl). This is the amount the actual image will be lifted up from the specified view. This option is useful for generating skewed perspectives or rendering an image a piece at a time. A value of 1 means that the rendered image starts just to the right of the normal view. A value of -1 would be to the left. Larger or fractional values are permitted as well. */
    lift?: number;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "fore_clip" })
    /** View fore clip (-vo) at a distance from the view point.The plane will be perpendicular to the view direction for perspective and parallel view types. For fisheye view types, the clipping plane is actually a clipping sphere, centered on the view point with fore_clip radius. Objects in front of this imaginary surface will not be visible. */
    foreClip?: number;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "aft_clip" })
    /** View aft clip (-va) at a distance from the view point.Like the view fore plane, it will be perpendicular to the view direction for perspective and parallel view types. For fisheye view types, the clipping plane is actually a clipping sphere, centered on the view point with radius val. */
    aftClip?: number;
	
    @IsString()
    @IsOptional()
    @Expose({ name: "group_identifier" })
    /** An optional string to note the view group '             'to which the sensor is a part of. Views sharing the same '             'group_identifier will be written to the same subfolder in Radiance '             'folder (default: None). */
    groupIdentifier?: string;
	

    constructor() {
        super();
        this.type = "View";
        this.viewType = ViewType.V;
        this.hSize = 60;
        this.vSize = 60;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(View, _data);
        }
    }


    static override fromJS(data: any): View {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new View();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["position"] = this.position;
        data["direction"] = this.direction;
        data["up_vector"] = this.upVector;
        data["type"] = this.type ?? "View";
        data["view_type"] = this.viewType ?? ViewType.V;
        data["h_size"] = this.hSize ?? 60;
        data["v_size"] = this.vSize ?? 60;
        data["shift"] = this.shift;
        data["lift"] = this.lift;
        data["fore_clip"] = this.foreClip;
        data["aft_clip"] = this.aftClip;
        data["group_identifier"] = this.groupIdentifier;
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
