import { IsString, IsOptional, Matches, IsArray, IsInt, IsEnum, IsInstance, ValidateNested, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { IsNestedIntegerArray } from "./../helpers/class-validator";
import { DatedBaseModel } from "./DatedBaseModel";
import { DaylightSavingTime } from "./DaylightSavingTime";
import { DaysOfWeek } from "./DaysOfWeek";

/** Used to describe the time period over which to run the simulation. */
export class RunPeriod extends DatedBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^RunPeriod$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "RunPeriod";
	
    @IsArray()
    @IsInt({ each: true })
    @IsOptional()
    @Expose({ name: "start_date" })
    /** A list of two integers for [month, day], representing the date for the start of the run period. Must be before the end date. */
    startDate: number[] = [1, 1];
	
    @IsArray()
    @IsInt({ each: true })
    @IsOptional()
    @Expose({ name: "end_date" })
    /** A list of two integers for [month, day], representing the date for the end of the run period. Must be after the start date. */
    endDate: number[] = [12, 31];
	
    @IsEnum(DaysOfWeek)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "start_day_of_week" })
    /** Text for the day of the week on which the simulation starts. */
    startDayOfWeek: DaysOfWeek = DaysOfWeek.Sunday;
	
    @IsArray()
    @IsNestedIntegerArray()
    @IsOptional()
    @Expose({ name: "holidays" })
    /** A list of lists where each sub-list consists of two integers for [month, day], representing a date which is a holiday within the simulation. If None, no holidays are applied. */
    holidays?: number[][];
	
    @IsInstance(DaylightSavingTime)
    @Type(() => DaylightSavingTime)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "daylight_saving_time" })
    /** A DaylightSavingTime to dictate the start and end dates of daylight saving time. If None, no daylight saving time is applied to the simulation. */
    daylightSavingTime?: DaylightSavingTime;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "leap_year" })
    /** Boolean noting whether the simulation will be run for a leap year. */
    leapYear: boolean = false;
	

    constructor() {
        super();
        this.type = "RunPeriod";
        this.startDate = [1, 1];
        this.endDate = [12, 31];
        this.startDayOfWeek = DaysOfWeek.Sunday;
        this.leapYear = false;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(RunPeriod, _data);
            this.type = obj.type ?? "RunPeriod";
            this.startDate = obj.startDate ?? [1, 1];
            this.endDate = obj.endDate ?? [12, 31];
            this.startDayOfWeek = obj.startDayOfWeek ?? DaysOfWeek.Sunday;
            this.holidays = obj.holidays;
            this.daylightSavingTime = obj.daylightSavingTime;
            this.leapYear = obj.leapYear ?? false;
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
        data["type"] = this.type ?? "RunPeriod";
        data["start_date"] = this.startDate ?? [1, 1];
        data["end_date"] = this.endDate ?? [12, 31];
        data["start_day_of_week"] = this.startDayOfWeek ?? DaysOfWeek.Sunday;
        data["holidays"] = this.holidays;
        data["daylight_saving_time"] = this.daylightSavingTime;
        data["leap_year"] = this.leapYear ?? false;
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
