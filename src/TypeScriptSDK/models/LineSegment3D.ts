import { IsArray, IsNumber, IsDefined, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';

/** A single line segment face in 3D space. */
export class LineSegment3D {
    @IsArray()
    @IsNumber({},{ each: true })
    @IsDefined()
    /** Line segment base point as 3 (x, y, z) values. */
    p!: number [];
	
    @IsArray()
    @IsNumber({},{ each: true })
    @IsDefined()
    /** Line segment direction vector as 3 (x, y, z) values. */
    v!: number [];
	
    @IsString()
    @IsOptional()
    @Matches(/^LineSegment3D$/)
    type?: string;
	

    constructor() {
        this.type = "LineSegment3D";
    }


    init(_data?: any) {
        if (_data) {
            const obj = plainToClass(LineSegment3D, _data);
            this.p = obj.p;
            this.v = obj.v;
            this.type = obj.type;
        }
    }


    static fromJS(data: any): LineSegment3D {
        data = typeof data === 'object' ? data : {};

        let result = new LineSegment3D();
        result.init(data);
        return result;
    }

	toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["p"] = this.p;
        data["v"] = this.v;
        data["type"] = this.type;
        return Object.fromEntries(
            Object.entries(data).filter(([_, v]) => v !== undefined));
    }

}
