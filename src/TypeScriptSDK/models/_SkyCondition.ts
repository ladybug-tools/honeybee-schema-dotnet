import { IsArray, ValidateNested, IsDefined, IsOptional, IsString, validate, ValidationError } from 'class-validator';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { ASHRAEClearSky } from "./ASHRAEClearSky";
import { ASHRAETau } from "./ASHRAETau";

/** Used to specify sky conditions on a design day. */
export class _SkyCondition extends _OpenAPIGenBaseModel {
    @IsArray()
    @ValidateNested({ each: true })
    @IsDefined()
    /** A list of two integers for [month, day], representing the date for the day of the year on which the design day occurs. A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case). */
    date!: number [];
	
    @IsOptional()
    /** Boolean to indicate whether daylight savings time is active on the design day. */
    daylight_savings?: boolean;
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.daylight_savings = False;
        this.type = "_SkyCondition";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.date = _data["date"];
            this.daylight_savings = _data["daylight_savings"] !== undefined ? _data["daylight_savings"] : False;
            this.type = _data["type"] !== undefined ? _data["type"] : "_SkyCondition";
        }
    }


    static override fromJS(data: any): _SkyCondition {
        data = typeof data === 'object' ? data : {};

        if (data["type"] === "ASHRAEClearSky") {
            let result = new ASHRAEClearSky();
            result.init(data);
            return result;
        }
        if (data["type"] === "ASHRAETau") {
            let result = new ASHRAETau();
            result.init(data);
            return result;
        }
        let result = new _SkyCondition();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["date"] = this.date;
        data["daylight_savings"] = this.daylight_savings;
        data["type"] = this.type;
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
