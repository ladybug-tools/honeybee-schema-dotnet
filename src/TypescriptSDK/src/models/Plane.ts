import { IsArray, IsNumber, IsDefined, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
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
        super.init(_data);
        if (_data) {
            const obj = plainToClass(Plane, _data, { enableImplicitConversion: true });
            this.n = obj.n;
            this.o = obj.o;
            this.type = obj.type;
            this.x = obj.x;
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
        data["type"] = this.type;
        data["x"] = this.x;
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
