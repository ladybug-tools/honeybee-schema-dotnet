import { IsArray, IsString, IsDefined, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects. */
export class Surface extends _OpenAPIGenBaseModel {
    @IsArray()
    @IsString({ each: true })
    @IsDefined()
    @Expose({ name: "boundary_condition_objects" })
    /** A list of up to 3 object identifiers that are adjacent to this one. The first object is always the one that is immediately adjacent and is of the same object type (Face, Aperture, Door). When this boundary condition is applied to a Face, the second object in the tuple will be the parent Room of the adjacent object. When the boundary condition is applied to a sub-face (Door or Aperture), the second object will be the parent Face of the adjacent sub-face and the third object will be the parent Room of the adjacent sub-face. */
    boundaryConditionObjects!: string[];
	
    @IsString()
    @IsOptional()
    @Matches(/^Surface$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "Surface";
	

    constructor() {
        super();
        this.type = "Surface";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(Surface, _data);
            this.boundaryConditionObjects = obj.boundaryConditionObjects;
            this.type = obj.type ?? "Surface";
        }
    }


    static override fromJS(data: any): Surface {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new Surface();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["boundary_condition_objects"] = this.boundaryConditionObjects;
        data["type"] = this.type ?? "Surface";
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
