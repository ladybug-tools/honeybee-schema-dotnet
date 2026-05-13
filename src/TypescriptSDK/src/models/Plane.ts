import { IsArray, IsNumber, IsDefined, IsString, IsOptional, Equals, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

export class Plane extends _OpenAPIGenBaseModel {
    @IsArray()
    @Type(() => Number)
    @IsNumber({},{ each: true })
    @IsDefined()
    @Expose({ name: "n" })
    /** Plane normal as 3 (x, y, z) values. */
    n!: number[];
	
    @IsArray()
    @Type(() => Number)
    @IsNumber({},{ each: true })
    @IsDefined()
    @Expose({ name: "o" })
    /** Plane origin as 3 (x, y, z) values */
    o!: number[];
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("Plane")
    @Expose({ name: "type" })
    /** type */
    type: string = "Plane";
	
    @IsArray()
    @Type(() => Number)
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
            this.n = obj.n;
            this.o = obj.o;
            this.type = obj.type ?? "Plane";
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
