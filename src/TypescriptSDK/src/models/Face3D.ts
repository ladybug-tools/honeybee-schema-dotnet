import { IsArray, IsDefined, IsString, IsOptional, Matches, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { IsNestedNumberArray } from "./../helpers/class-validator";
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { Plane } from "./Plane";

/** A single planar face in 3D space. */
export class Face3D extends _OpenAPIGenBaseModel {
    @IsArray()
    @IsNestedNumberArray()
    @IsDefined()
    @Expose({ name: "boundary" })
    /** A list of points representing the outer boundary vertices of the face. The list should include at least 3 points and each point should be a list of 3 (x, y, z) values. */
    boundary!: number[][];
	
    @IsString()
    @IsOptional()
    @Matches(/^Face3D$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "Face3D";
	
    @IsArray()
    @IsNestedNumberArray()
    @IsOptional()
    @Expose({ name: "holes" })
    /** Optional list of lists with one list for each hole in the face.Each hole should be a list of at least 3 points and each point a list of 3 (x, y, z) values. If None, it will be assumed that there are no holes in the face. */
    holes?: number[][][];
	
    @IsInstance(Plane)
    @Type(() => Plane)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "plane" })
    /** Optional Plane indicating the plane in which the face exists.If None, the plane will usually be derived from the boundary points. */
    plane?: Plane;
	

    constructor() {
        super();
        this.type = "Face3D";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(Face3D, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.boundary = obj.boundary;
            this.type = obj.type ?? "Face3D";
            this.holes = obj.holes;
            this.plane = obj.plane;
        }
    }


    static override fromJS(data: any): Face3D {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new Face3D();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["boundary"] = this.boundary;
        data["type"] = this.type ?? "Face3D";
        data["holes"] = this.holes;
        data["plane"] = this.plane;
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
