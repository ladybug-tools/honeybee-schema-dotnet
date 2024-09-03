import { IsArray, ValidateNested, IsNumber, IsDefined, IsString, IsOptional, Matches, IsInstance, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { Plane } from "./Plane";

/** A single planar face in 3D space. */
export class Face3D extends _OpenAPIGenBaseModel {
    @IsArray()
    @IsArray({ each: true })
    @ValidateNested({each: true })
    @Type(() => Array)
    @IsNumber({},{ each: true })
    @IsDefined()
    /** A list of points representing the outer boundary vertices of the face. The list should include at least 3 points and each point should be a list of 3 (x, y, z) values. */
    boundary!: number [] [];
	
    @IsString()
    @IsOptional()
    @Matches(/^Face3D$/)
    type?: string;
	
    @IsArray()
    @IsArray({ each: true })
    @ValidateNested({each: true })
    @Type(() => Array)
    @IsArray({ each: true })
    @ValidateNested({each: true })
    @Type(() => Array)
    @IsNumber({},{ each: true })
    @IsOptional()
    /** Optional list of lists with one list for each hole in the face.Each hole should be a list of at least 3 points and each point a list of 3 (x, y, z) values. If None, it will be assumed that there are no holes in the face. */
    holes?: number [] [] [];
	
    @IsInstance(Plane)
    @Type(() => Plane)
    @ValidateNested()
    @IsOptional()
    /** Optional Plane indicating the plane in which the face exists.If None, the plane will usually be derived from the boundary points. */
    plane?: Plane;
	

    constructor() {
        super();
        this.type = "Face3D";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(Face3D, _data);
            this.boundary = obj.boundary;
            this.type = obj.type;
            this.holes = obj.holes;
            this.plane = obj.plane;
        }
    }


    static override fromJS(data: any): Face3D {
        data = typeof data === 'object' ? data : {};

        let result = new Face3D();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["boundary"] = this.boundary;
        data["type"] = this.type;
        data["holes"] = this.holes;
        data["plane"] = this.plane;
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
