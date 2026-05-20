import { IsNumber, IsDefined, Min, Max, IsString, IsOptional, Equals, IsArray, IsInt, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';

/** Used to specify sky conditions on a design day. */
export class ASHRAEClearSky {
    @Type(() => Number)
    @IsNumber()
    @IsDefined()
    @Min(0)
    @Max(1.2)
    @Expose({ name: "clearness" })
    /** Value between 0 and 1.2 that will get multiplied by the irradiance to correct for factors like elevation above sea level. */
    clearness!: number;
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("ASHRAEClearSky")
    @Expose({ name: "type" })
    /** type */
    type: string = "ASHRAEClearSky";
	
    @IsArray()
    @Type(() => Number)
    @IsInt({ each: true })
    @IsDefined()
    @Expose({ name: "date" })
    /** A list of two integers for [month, day], representing the date for the day of the year on which the design day occurs. A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case). */
    date!: number[];
	
    @Type(() => Boolean)
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "daylight_savings" })
    /** Boolean to indicate whether daylight savings time is active on the design day. */
    daylightSavings: boolean = false;
	

    constructor() {
        this.type = "ASHRAEClearSky";
        this.daylightSavings = false;
    }


    init(_data?: any) {

        if (_data) {
            const obj = deepTransform(ASHRAEClearSky, _data);
            this.clearness = obj.clearness;
            this.type = obj.type ?? "ASHRAEClearSky";
            this.date = obj.date;
            this.daylightSavings = obj.daylightSavings ?? false;
        }
    }


    static fromJS(data: any): ASHRAEClearSky {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ASHRAEClearSky();
        result.init(data);
        return result;
    }

	toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["clearness"] = this.clearness;
        data["type"] = this.type ?? "ASHRAEClearSky";
        data["date"] = this.date;
        data["daylight_savings"] = this.daylightSavings ?? false;
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
