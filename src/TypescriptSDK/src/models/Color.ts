import { IsInt, IsDefined, Min, Max, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** A RGB color. */
export class Color extends _OpenAPIGenBaseModel {
    @IsInt()
    @IsDefined()
    @Min(0)
    @Max(255)
    @Expose({ name: "r" })
    /** Value for red channel. */
    r!: number;
	
    @IsInt()
    @IsDefined()
    @Min(0)
    @Max(255)
    @Expose({ name: "g" })
    /** Value for green channel. */
    g!: number;
	
    @IsInt()
    @IsDefined()
    @Min(0)
    @Max(255)
    @Expose({ name: "b" })
    /** Value for blue channel. */
    b!: number;
	
    @IsString()
    @IsOptional()
    @Matches(/^Color$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "Color";
	
    @IsInt()
    @IsOptional()
    @Min(0)
    @Max(255)
    @Expose({ name: "a" })
    /** Value for the alpha channel, which defines the opacity as a number between 0 (fully transparent) and 255 (fully opaque). */
    a: number = 255;
	

    constructor() {
        super();
        this.type = "Color";
        this.a = 255;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(Color, _data);
            this.r = obj.r;
            this.g = obj.g;
            this.b = obj.b;
            this.type = obj.type ?? "Color";
            this.a = obj.a ?? 255;
        }
    }


    static override fromJS(data: any): Color {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new Color();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["r"] = this.r;
        data["g"] = this.g;
        data["b"] = this.b;
        data["type"] = this.type ?? "Color";
        data["a"] = this.a ?? 255;
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
