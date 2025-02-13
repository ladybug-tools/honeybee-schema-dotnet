import { IsInt, IsDefined, Min, Max, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** A RGB color. */
export class Color extends _OpenAPIGenBaseModel {
    @IsInt()
    @IsDefined()
    @Min(0)
    @Max(255)
    /** Value for red channel. */
    r!: number;
	
    @IsInt()
    @IsDefined()
    @Min(0)
    @Max(255)
    /** Value for green channel. */
    g!: number;
	
    @IsInt()
    @IsDefined()
    @Min(0)
    @Max(255)
    /** Value for blue channel. */
    b!: number;
	
    @IsString()
    @IsOptional()
    @Matches(/^Color$/)
    /** Type */
    type?: string;
	
    @IsInt()
    @IsOptional()
    @Min(0)
    @Max(255)
    /** Value for the alpha channel, which defines the opacity as a number between 0 (fully transparent) and 255 (fully opaque). */
    a?: number;
	

    constructor() {
        super();
        this.type = "Color";
        this.a = 255;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(Color, _data, { enableImplicitConversion: true });
            this.r = obj.r;
            this.g = obj.g;
            this.b = obj.b;
            this.type = obj.type;
            this.a = obj.a;
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
        data["type"] = this.type;
        data["a"] = this.a;
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

