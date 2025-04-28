import { IsString, IsOptional, Matches, IsArray, IsInt, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { DatedBaseModel } from "./DatedBaseModel";

/** Used to describe the daylight savings time for the simulation. */
export class DaylightSavingTime extends DatedBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^DaylightSavingTime$/)
    /** Type */
    type?: string;
	
    @IsArray()
    @IsInt({ each: true })
    @IsOptional()
    /** A list of two integers for [month, day], representing the date for the start of daylight savings time. Default: 12 Mar (daylight savings in the US in 2017). */
    start_date?: number[];
	
    @IsArray()
    @IsInt({ each: true })
    @IsOptional()
    /** A list of two integers for [month, day], representing the date for the end of daylight savings time. Default: 5 Nov (daylight savings in the US in 2017). */
    end_date?: number[];
	

    constructor() {
        super();
        this.type = "DaylightSavingTime";
        this.start_date = [3, 12];
        this.end_date = [11, 5];
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(DaylightSavingTime, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.start_date = obj.start_date;
            this.end_date = obj.end_date;
        }
    }


    static override fromJS(data: any): DaylightSavingTime {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new DaylightSavingTime();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["start_date"] = this.start_date;
        data["end_date"] = this.end_date;
        data = super.toJSON(data);
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

