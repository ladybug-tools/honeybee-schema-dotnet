import { IsArray, IsNumber, IsDefined, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';

/** A single line segment face in 3D space. */
export class LineSegment3D {
    @IsArray()
    @IsNumber({},{ each: true })
    @IsDefined()
    @Expose({ name: "p" })
    /** Line segment base point as 3 (x, y, z) values. */
    p!: number[];
	
    @IsArray()
    @IsNumber({},{ each: true })
    @IsDefined()
    @Expose({ name: "v" })
    /** Line segment direction vector as 3 (x, y, z) values. */
    v!: number[];
	
    @IsString()
    @IsOptional()
    @Matches(/^LineSegment3D$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "LineSegment3D";
	

    constructor() {
        this.type = "LineSegment3D";
    }


    init(_data?: any) {
        if (_data) {
            const obj = plainToClass(LineSegment3D, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.p = obj.p;
            this.v = obj.v;
            this.type = obj.type ?? "LineSegment3D";
        }
    }


    static fromJS(data: any): LineSegment3D {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new LineSegment3D();
        result.init(data);
        return result;
    }

	toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["p"] = this.p;
        data["v"] = this.v;
        data["type"] = this.type ?? "LineSegment3D";
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
