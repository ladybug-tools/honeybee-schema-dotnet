import { IsString, IsOptional, Matches, IsArray, IsInt, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { DatedBaseModel } from "./DatedBaseModel";

/** Used to describe the daylight savings time for the simulation. */
export class DaylightSavingTime extends DatedBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^DaylightSavingTime$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "DaylightSavingTime";
	
    @IsArray()
    @IsInt({ each: true })
    @IsOptional()
    @Expose({ name: "start_date" })
    /** A list of two integers for [month, day], representing the date for the start of daylight savings time. Default: 12 Mar (daylight savings in the US in 2017). */
    startDate: number[] = [3, 12];
	
    @IsArray()
    @IsInt({ each: true })
    @IsOptional()
    @Expose({ name: "end_date" })
    /** A list of two integers for [month, day], representing the date for the end of daylight savings time. Default: 5 Nov (daylight savings in the US in 2017). */
    endDate: number[] = [11, 5];
	

    constructor() {
        super();
        this.type = "DaylightSavingTime";
        this.startDate = [3, 12];
        this.endDate = [11, 5];
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(DaylightSavingTime, _data);
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
        data["type"] = this.type ?? "DaylightSavingTime";
        data["start_date"] = this.startDate ?? [3, 12];
        data["end_date"] = this.endDate ?? [11, 5];
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
