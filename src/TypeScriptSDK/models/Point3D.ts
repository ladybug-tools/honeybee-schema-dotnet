import { IsNumber, IsDefined, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';

/** A point object in 3D space. */
export class Point3D {
    @IsNumber()
    @IsDefined()
    /** Number for X coordinate. */
    x!: number;
	
    @IsNumber()
    @IsDefined()
    /** Number for Y coordinate. */
    y!: number;
	
    @IsNumber()
    @IsDefined()
    /** Number for Z coordinate. */
    z!: number;
	
    @IsString()
    @IsOptional()
    @Matches(/^Point3D$/)
    type?: string;
	

    constructor() {
        this.type = "Point3D";
    }


    init(_data?: any) {
        if (_data) {
            const obj = plainToClass(Point3D, _data);
            this.x = obj.x;
            this.y = obj.y;
            this.z = obj.z;
            this.type = obj.type;
        }
    }


    static fromJS(data: any): Point3D {
        data = typeof data === 'object' ? data : {};

        let result = new Point3D();
        result.init(data);
        return result;
    }

	toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["x"] = this.x;
        data["y"] = this.y;
        data["z"] = this.z;
        data["type"] = this.type;
        return data;
    }

}
