import { IsArray, ValidateNested, IsDefined, IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';

/** A single line segment face in 3D space. */
export abstract class LineSegment3D {
    @IsArray()
    @ValidateNested({ each: true })
    @IsDefined()
    /** Line segment base point as 3 (x, y, z) values. */
    p!: number [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsDefined()
    /** Line segment direction vector as 3 (x, y, z) values. */
    v!: number [];
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        this.type = "LineSegment3D";
    }


    init(_data?: any) {
        if (_data) {
            this.p = _data["p"];
            this.v = _data["v"];
            this.type = _data["type"] !== undefined ? _data["type"] : "LineSegment3D";
        }
    }


    static fromJS(data: any): LineSegment3D {
        data = typeof data === 'object' ? data : {};

        throw new Error("The abstract class 'LineSegment3D' cannot be instantiated.");
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
        return data;
    }

}
