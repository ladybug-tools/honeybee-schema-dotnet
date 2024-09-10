import { IsArray, ValidateNested, IsNumber, IsDefined, IsInt, IsString, IsOptional, Matches, IsInstance, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { Color } from "./Color";

/** A mesh in 3D space. */
export class Mesh3D extends _OpenAPIGenBaseModel {
    @IsArray()
    @IsArray({ each: true })
    @ValidateNested({each: true })
    @Type(() => Array)
    @IsNumber({},{ each: true })
    @IsDefined()
    /** A list of points representing the vertices of the mesh. The list should include at least 3 points and each point should be a list of 3 (x, y, z) values. */
    vertices!: number [] [];
	
    @IsArray()
    @IsArray({ each: true })
    @ValidateNested({each: true })
    @Type(() => Array)
    @IsInt({ each: true })
    @IsDefined()
    /** A list of lists with each sub-list having either 3 or 4 integers. These integers correspond to indices within the list of vertices. */
    faces!: number [] [];
	
    @IsString()
    @IsOptional()
    @Matches(/^Mesh3D$/)
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
            const obj = plainToClass(Mesh3D, _data);
            this.vertices = obj.vertices;
            this.faces = obj.faces;
            this.type = obj.type;
            this.colors = obj.colors;
        }
    }


    static override fromJS(data: any): Mesh3D {
        data = typeof data === 'object' ? data : {};

        let result = new Mesh3D();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["vertices"] = this.vertices;
        data["faces"] = this.faces;
        data["type"] = this.type;
        data["colors"] = this.colors;
        super.toJSON(data);
        return data;
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
