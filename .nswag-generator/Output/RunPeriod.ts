import { IsString, IsOptional, IsArray, ValidateNested, IsEnum, IsInstance, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { DatedBaseModel } from "./DatedBaseModel";
import { DaylightSavingTime } from "./DaylightSavingTime";
import { DaysOfWeek } from "./DaysOfWeek";

/** Used to describe the time period over which to run the simulation. */
export class RunPeriod extends DatedBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of two integers for [month, day], representing the date for the start of the run period. Must be before the end date. */
    start_date?: number [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of two integers for [month, day], representing the date for the end of the run period. Must be after the start date. */
    end_date?: number [];
	
    @IsEnum(DaysOfWeek)
    @ValidateNested()
    @IsOptional()
    /** Text for the day of the week on which the simulation starts. */
    start_day_of_week?: DaysOfWeek;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of lists where each sub-list consists of two integers for [month, day], representing a date which is a holiday within the simulation. If None, no holidays are applied. */
    holidays?: number [] [];
	
    @IsInstance(DaylightSavingTime)
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
            this.type = _data["type"] !== undefined ? _data["type"] : "RunPeriod";
            this.start_date = _data["start_date"] !== undefined ? _data["start_date"] : [1, 1];
            this.end_date = _data["end_date"] !== undefined ? _data["end_date"] : [12, 31];
            this.start_day_of_week = _data["start_day_of_week"] !== undefined ? _data["start_day_of_week"] : DaysOfWeek.Sunday;
            this.holidays = _data["holidays"];
            this.daylight_saving_time = _data["daylight_saving_time"];
            this.leap_year = _data["leap_year"] !== undefined ? _data["leap_year"] : false;
        }
    }


    static override fromJS(data: any): RunPeriod {
        data = typeof data === 'object' ? data : {};

        let result = new RunPeriod();
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
        data["start_day_of_week"] = this.start_day_of_week;
        data["holidays"] = this.holidays;
        data["daylight_saving_time"] = this.daylight_saving_time;
        data["leap_year"] = this.leap_year;
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
