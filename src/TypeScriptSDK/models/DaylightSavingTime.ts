import { IsString, IsOptional, IsArray, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { DatedBaseModel } from "./DatedBaseModel";

/** Used to describe the daylight savings time for the simulation. */
export class DaylightSavingTime extends DatedBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of two integers for [month, day], representing the date for the start of daylight savings time. Default: 12 Mar (daylight savings in the US in 2017). */
    start_date?: number [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of two integers for [month, day], representing the date for the end of daylight savings time. Default: 5 Nov (daylight savings in the US in 2017). */
    end_date?: number [];
	

    constructor() {
        super();
        this.type = "DaylightSavingTime";
        this.start_date = [3, 12];
        this.end_date = [11, 5];
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "DaylightSavingTime";
            this.start_date = _data["start_date"] !== undefined ? _data["start_date"] : [3, 12];
            this.end_date = _data["end_date"] !== undefined ? _data["end_date"] : [11, 5];
        }
    }


    static override fromJS(data: any): DaylightSavingTime {
        data = typeof data === 'object' ? data : {};

        let result = new DaylightSavingTime();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["type"] = this.type;
        data["start_date"] = this.start_date;
        data["end_date"] = this.end_date;
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
