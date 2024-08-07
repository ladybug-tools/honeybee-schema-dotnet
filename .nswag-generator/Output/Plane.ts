import { IsArray, ValidateNested, IsDefined, IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for all objects that are not extensible with additional keys.

This effectively includes all objects except for the Properties classes
that are assigned to geometry objects. */
export class Plane extends _OpenAPIGenBaseModel {
    @IsArray()
    @ValidateNested({ each: true })
    @IsDefined()
    /** Plane normal as 3 (x, y, z) values. */
    n!: number [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsDefined()
    /** Plane origin as 3 (x, y, z) values */
    o!: number [];
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** Plane x-axis as 3 (x, y, z) values. If None, it is autocalculated. */
    x?: number [];
	

    constructor() {
        super();
        this.type = "Plane";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.n = _data["n"];
            this.o = _data["o"];
            this.type = _data["type"] !== undefined ? _data["type"] : "Plane";
            this.x = _data["x"];
        }
    }


    static override fromJS(data: any): Plane {
        data = typeof data === 'object' ? data : {};

        let result = new Plane();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["n"] = this.n;
        data["o"] = this.o;
        data["type"] = this.type;
        data["x"] = this.x;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
