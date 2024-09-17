import { IsArray, IsString, IsDefined, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects. */
export class Surface extends _OpenAPIGenBaseModel {
    @IsArray()
    @IsString({ each: true })
    @IsDefined()
    /** A list of up to 3 object identifiers that are adjacent to this one. The first object is always the one that is immediately adjacent and is of the same object type (Face, Aperture, Door). When this boundary condition is applied to a Face, the second object in the tuple will be the parent Room of the adjacent object. When the boundary condition is applied to a sub-face (Door or Aperture), the second object will be the parent Face of the adjacent sub-face and the third object will be the parent Room of the adjacent sub-face. */
    boundary_condition_objects!: string [];
	
    @IsString()
    @IsOptional()
    @Matches(/^Surface$/)
    type?: string;
	

    constructor() {
        super();
        this.type = "Surface";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(Surface, _data);
            this.boundary_condition_objects = obj.boundary_condition_objects;
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): Surface {
        data = typeof data === 'object' ? data : {};

        let result = new Surface();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["boundary_condition_objects"] = this.boundary_condition_objects;
        data["type"] = this.type;
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
