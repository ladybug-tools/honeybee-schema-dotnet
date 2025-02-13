import { IsArray, IsDefined, IsString, IsOptional, Matches, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { IsNestedNumberArray, IsNestedIntegerArray } from "./../helpers/class-validator";
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { Color } from "./Color";

/** A mesh in 3D space. */
export class Mesh3D extends _OpenAPIGenBaseModel {
    @IsArray()
    @IsNestedNumberArray()
    @IsDefined()
    /** A list of points representing the vertices of the mesh. The list should include at least 3 points and each point should be a list of 3 (x, y, z) values. */
    vertices!: number [] [];
	
    @IsArray()
    @IsNestedIntegerArray()
    @IsDefined()
    /** A list of lists with each sub-list having either 3 or 4 integers. These integers correspond to indices within the list of vertices. */
    faces!: number [] [];
	
    @IsString()
    @IsOptional()
    @Matches(/^Mesh3D$/)
    /** Type */
    type?: string;
	
    @IsArray()
    @IsInstance(Color, { each: true })
    @Type(() => Color)
    @ValidateNested({ each: true })
    @IsOptional()
    /** An optional list of colors that correspond to either the faces of the mesh or the vertices of the mesh. */
    colors?: Color [];
	

    constructor() {
        super();
        this.type = "Mesh3D";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(Mesh3D, _data, { enableImplicitConversion: true });
            this.vertices = obj.vertices;
            this.faces = obj.faces;
            this.type = obj.type;
            this.colors = obj.colors;
        }
    }


    static override fromJS(data: any): Mesh3D {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new Mesh3D();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["vertices"] = this.vertices;
        data["faces"] = this.faces;
        data["type"] = this.type;
        data["colors"] = this.colors;
        data = super.toJSON(data);
        return instanceToPlain(data);
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

