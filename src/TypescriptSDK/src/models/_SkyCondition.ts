import { IsArray, IsInt, IsDefined, IsBoolean, IsOptional, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Used to specify sky conditions on a design day. */
export class _SkyCondition extends _OpenAPIGenBaseModel {
    @IsArray()
    @IsInt({ each: true })
    @IsDefined()
    @Expose({ name: "date" })
    /** A list of two integers for [month, day], representing the date for the day of the year on which the design day occurs. A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case). */
    date!: number[];
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "daylight_savings" })
    /** Boolean to indicate whether daylight savings time is active on the design day. */
    daylightSavings: boolean = false;
	
    @IsString()
    @IsOptional()
    @Matches(/^_SkyCondition$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "_SkyCondition";
	

    constructor() {
        super();
        this.daylightSavings = false;
        this.type = "_SkyCondition";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(_SkyCondition, _data, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
            this.date = obj.date;
            this.daylightSavings = obj.daylightSavings ?? false;
            this.type = obj.type ?? "_SkyCondition";
        }
    }


    static override fromJS(data: any): _SkyCondition {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new _SkyCondition();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["date"] = this.date;
        data["daylight_savings"] = this.daylightSavings ?? false;
        data["type"] = this.type ?? "_SkyCondition";
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
