import { IsArray, IsNumber, IsDefined, IsString, IsOptional, Matches, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { _RadianceAsset } from "./_RadianceAsset";
import { ViewType } from "./ViewType";

/** A single Radiance of sensors. */
export class View extends _RadianceAsset {
    @IsArray()
    @IsNumber({},{ each: true })
    @IsDefined()
    /** The view position (-vp) as an array of (x, y, z) values.This is the focal point of a perspective view or the center of a parallel projection. */
    position!: number [];
	
    @IsArray()
    @IsNumber({},{ each: true })
    @IsDefined()
    /** The view direction (-vd) as an array of (x, y, z) values.The length of this vector indicates the focal distance as needed by the pixel depth of field (-pd) in rpict. */
    direction!: number [];
	
    @IsArray()
    @IsNumber({},{ each: true })
    @IsDefined()
    /** The view up (-vu) vector as an array of (x, y, z) values. */
    up_vector!: number [];
	
    @IsString()
    @IsOptional()
    @Matches(/^View$/)
    type?: string;
	
    @IsEnum(ViewType)
    @Type(() => String)
    @IsOptional()
    view_type?: ViewType;
	
    @IsNumber()
    @IsOptional()
    /** A number for the horizontal field of view in degrees (for all perspective projections including fisheye). For a parallel projection, this is the view width in world coordinates. */
    h_size?: number;
	
    @IsNumber()
    @IsOptional()
    /** A number for the vertical field of view in degrees (for all perspective projections including fisheye). For a parallel projection, this is the view width in world coordinates. */
    v_size?: number;
	
    @IsNumber()
    @IsOptional()
    /** The view shift (-vs). This is the amount the actual image will be shifted to the right of the specified view. This option is useful for generating skewed perspectives or rendering an image a piece at a time. A value of 1 means that the rendered image starts just to the right of the normal view. A value of -1 would be to the left. Larger or fractional values are permitted as well. */
    shift?: number;
	
    @IsNumber()
    @IsOptional()
    /** The view lift (-vl). This is the amount the actual image will be lifted up from the specified view. This option is useful for generating skewed perspectives or rendering an image a piece at a time. A value of 1 means that the rendered image starts just to the right of the normal view. A value of -1 would be to the left. Larger or fractional values are permitted as well. */
    lift?: number;
	
    @IsNumber()
    @IsOptional()
    /** View fore clip (-vo) at a distance from the view point.The plane will be perpendicular to the view direction for perspective and parallel view types. For fisheye view types, the clipping plane is actually a clipping sphere, centered on the view point with fore_clip radius. Objects in front of this imaginary surface will not be visible. */
    fore_clip?: number;
	
    @IsNumber()
    @IsOptional()
    /** View aft clip (-va) at a distance from the view point.Like the view fore plane, it will be perpendicular to the view direction for perspective and parallel view types. For fisheye view types, the clipping plane is actually a clipping sphere, centered on the view point with radius val. */
    aft_clip?: number;
	
    @IsString()
    @IsOptional()
    /** An optional string to note the view group '             'to which the sensor is a part of. Views sharing the same '             'group_identifier will be written to the same subfolder in Radiance '             'folder (default: None). */
    group_identifier?: string;
	

    constructor() {
        super();
        this.type = "View";
        this.view_type = ViewType.v;
        this.h_size = 60;
        this.v_size = 60;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(View, _data);
            this.position = obj.position;
            this.direction = obj.direction;
            this.up_vector = obj.up_vector;
            this.type = obj.type;
            this.view_type = obj.view_type;
            this.h_size = obj.h_size;
            this.v_size = obj.v_size;
            this.shift = obj.shift;
            this.lift = obj.lift;
            this.fore_clip = obj.fore_clip;
            this.aft_clip = obj.aft_clip;
            this.group_identifier = obj.group_identifier;
        }
    }


    static override fromJS(data: any): View {
        data = typeof data === 'object' ? data : {};

        let result = new View();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["position"] = this.position;
        data["direction"] = this.direction;
        data["up_vector"] = this.up_vector;
        data["type"] = this.type;
        data["view_type"] = this.view_type;
        data["h_size"] = this.h_size;
        data["v_size"] = this.v_size;
        data["shift"] = this.shift;
        data["lift"] = this.lift;
        data["fore_clip"] = this.fore_clip;
        data["aft_clip"] = this.aft_clip;
        data["group_identifier"] = this.group_identifier;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || [error.property]).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
