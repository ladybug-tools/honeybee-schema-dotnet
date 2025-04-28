import { IsString, IsOptional, Matches, IsArray, IsInt, IsEnum, IsInstance, ValidateNested, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { IsNestedIntegerArray } from "./../helpers/class-validator";
import { DatedBaseModel } from "./DatedBaseModel";
import { DaylightSavingTime } from "./DaylightSavingTime";
import { DaysOfWeek } from "./DaysOfWeek";

/** Used to describe the time period over which to run the simulation. */
export class RunPeriod extends DatedBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^RunPeriod$/)
    /** Type */
    type?: string;
	
    @IsArray()
    @IsInt({ each: true })
    @IsOptional()
    /** A list of two integers for [month, day], representing the date for the start of the run period. Must be before the end date. */
    start_date?: number[];
	
    @IsArray()
    @IsInt({ each: true })
    @IsOptional()
    /** A list of two integers for [month, day], representing the date for the end of the run period. Must be after the start date. */
    end_date?: number[];
	
    @IsEnum(DaysOfWeek)
    @Type(() => String)
    @IsOptional()
    /** Text for the day of the week on which the simulation starts. */
    start_day_of_week?: DaysOfWeek;
	
    @IsArray()
    @IsNestedIntegerArray()
    @IsOptional()
    /** A list of lists where each sub-list consists of two integers for [month, day], representing a date which is a holiday within the simulation. If None, no holidays are applied. */
    holidays?: number[][];
	
    @IsInstance(DaylightSavingTime)
    @Type(() => DaylightSavingTime)
    @ValidateNested()
    @IsOptional()
    /** A DaylightSavingTime to dictate the start and end dates of daylight saving time. If None, no daylight saving time is applied to the simulation. */
    daylight_saving_time?: DaylightSavingTime;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean noting whether the simulation will be run for a leap year. */
    leap_year?: boolean;
	

    constructor() {
        super();
        this.type = "RunPeriod";
        this.start_date = [1, 1];
        this.end_date = [12, 31];
        this.start_day_of_week = DaysOfWeek.Sunday;
        this.leap_year = false;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(RunPeriod, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.start_date = obj.start_date;
            this.end_date = obj.end_date;
            this.start_day_of_week = obj.start_day_of_week;
            this.holidays = obj.holidays;
            this.daylight_saving_time = obj.daylight_saving_time;
            this.leap_year = obj.leap_year;
        }
    }


    static override fromJS(data: any): RunPeriod {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new RunPeriod();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["start_date"] = this.start_date;
        data["end_date"] = this.end_date;
        data["start_day_of_week"] = this.start_day_of_week;
        data["holidays"] = this.holidays;
        data["daylight_saving_time"] = this.daylight_saving_time;
        data["leap_year"] = this.leap_year;
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

