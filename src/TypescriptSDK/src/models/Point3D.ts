import { IsNumber, IsDefined, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';

/** A point object in 3D space. */
export class Point3D {
    @IsNumber()
    @IsDefined()
    @Expose({ name: "x" })
    /** Number for X coordinate. */
    x!: number;
	
    @IsNumber()
    @IsDefined()
    @Expose({ name: "y" })
    /** Number for Y coordinate. */
    y!: number;
	
    @IsNumber()
    @IsDefined()
    @Expose({ name: "z" })
    /** Number for Z coordinate. */
    z!: number;
	
    @IsString()
    @IsOptional()
    @Matches(/^Point3D$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "Point3D";
	

    constructor() {
        this.type = "Point3D";
    }


    init(_data?: any) {
        if (_data) {
            const obj = plainToClass(Point3D, _data, { enableImplicitConversion: true });
            this.x = obj.x;
            this.y = obj.y;
            this.z = obj.z;
            this.type = obj.type;
        }
    }


    static fromJS(data: any): Point3D {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new Point3D();
        result.init(data);
        return result;
    }

	toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["x"] = this.x;
        data["y"] = this.y;
        data["z"] = this.z;
        data["type"] = this.type;
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
