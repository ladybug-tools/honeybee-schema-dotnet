import { IsArray, ValidateNested, IsDefined, IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** A single Radiance of sensors. */
export class Sensor extends _OpenAPIGenBaseModel {
    @IsArray()
    @ValidateNested({ each: true })
    @IsDefined()
    /** Position of sensor in space as an array of (x, y, z) values. */
    pos!: number [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsDefined()
    /** Direction of sensor as an array of (x, y, z) values. */
    dir!: number [];
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.type = "Sensor";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.pos = _data["pos"];
            this.dir = _data["dir"];
            this.type = _data["type"] !== undefined ? _data["type"] : "Sensor";
        }
    }


    static override fromJS(data: any): Sensor {
        data = typeof data === 'object' ? data : {};

        let result = new Sensor();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["pos"] = this.pos;
        data["dir"] = this.dir;
        data["type"] = this.type;
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
