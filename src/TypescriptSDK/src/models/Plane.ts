import { IsArray, IsNumber, IsDefined, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects. */
export class Plane extends _OpenAPIGenBaseModel {
    @IsArray()
    @IsNumber({},{ each: true })
    @IsDefined()
    @Expose({ name: "n" })
    /** Plane normal as 3 (x, y, z) values. */
    n!: number[];
	
    @IsArray()
    @IsNumber({},{ each: true })
    @IsDefined()
    @Expose({ name: "o" })
    /** Plane origin as 3 (x, y, z) values */
    o!: number[];
	
    @IsString()
    @IsOptional()
    @Matches(/^Plane$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "Plane";
	
    @IsArray()
    @IsNumber({},{ each: true })
    @IsOptional()
    @Expose({ name: "x" })
    /** Plane x-axis as 3 (x, y, z) values. If None, it is autocalculated. */
    x?: number[];
	

    constructor() {
        super();
        this.type = "Plane";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(Plane, _data);
        }
    }


    static override fromJS(data: any): Plane {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new Plane();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["n"] = this.n;
        data["o"] = this.o;
        data["type"] = this.type ?? "Plane";
        data["x"] = this.x;
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
