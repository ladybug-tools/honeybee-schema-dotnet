import { IsInt, IsDefined, IsString, IsOptional, validate, ValidationError } from 'class-validator';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** A RGB color. */
export class Color extends _OpenAPIGenBaseModel {
    @IsInt()
    @IsDefined()
    /** Value for red channel. */
    r!: number;
	
    @IsInt()
    @IsDefined()
    /** Value for green channel. */
    g!: number;
	
    @IsInt()
    @IsDefined()
    /** Value for blue channel. */
    b!: number;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsInt()
    @IsOptional()
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
            this.r = _data["r"];
            this.g = _data["g"];
            this.b = _data["b"];
            this.type = _data["type"] !== undefined ? _data["type"] : "Color";
            this.a = _data["a"] !== undefined ? _data["a"] : 255;
        }
    }


    static override fromJS(data: any): Color {
        data = typeof data === 'object' ? data : {};

        let result = new Color();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["r"] = this.r;
        data["g"] = this.g;
        data["b"] = this.b;
        data["type"] = this.type;
        data["a"] = this.a;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: ValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
