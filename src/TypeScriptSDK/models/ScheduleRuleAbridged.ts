import { IsString, IsDefined, IsOptional, IsBoolean, IsArray, IsInt, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { DatedBaseModel } from "./DatedBaseModel";

/** Schedule rule including a ScheduleDay and when it should be applied.. */
export class ScheduleRuleAbridged extends DatedBaseModel {
    @IsString()
    @IsDefined()
    /** The identifier of a ScheduleDay object associated with this rule. */
    schedule_day!: string;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean noting whether to apply schedule_day on Sundays. */
    apply_sunday?: boolean;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean noting whether to apply schedule_day on Mondays. */
    apply_monday?: boolean;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean noting whether to apply schedule_day on Tuesdays. */
    apply_tuesday?: boolean;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean noting whether to apply schedule_day on Wednesdays. */
    apply_wednesday?: boolean;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean noting whether to apply schedule_day on Thursdays. */
    apply_thursday?: boolean;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean noting whether to apply schedule_day on Fridays. */
    apply_friday?: boolean;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean noting whether to apply schedule_day on Saturdays. */
    apply_saturday?: boolean;
	
    @IsArray()
    @IsInt({ each: true })
    @IsOptional()
    /** A list of two integers for [month, day], representing the start date of the period over which the schedule_day will be applied.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case). */
    start_date?: number [];
	
    @IsArray()
    @IsInt({ each: true })
    @IsOptional()
    /** A list of two integers for [month, day], representing the end date of the period over which the schedule_day will be applied.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case). */
    end_date?: number [];
	

    constructor() {
        super();
        this.type = "ScheduleRuleAbridged";
        this.apply_sunday = false;
        this.apply_monday = false;
        this.apply_tuesday = false;
        this.apply_wednesday = false;
        this.apply_thursday = false;
        this.apply_friday = false;
        this.apply_saturday = false;
        this.start_date = [1, 1];
        this.end_date = [12, 31];
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ScheduleRuleAbridged, _data);
            this.schedule_day = obj.schedule_day;
            this.type = obj.type;
            this.apply_sunday = obj.apply_sunday;
            this.apply_monday = obj.apply_monday;
            this.apply_tuesday = obj.apply_tuesday;
            this.apply_wednesday = obj.apply_wednesday;
            this.apply_thursday = obj.apply_thursday;
            this.apply_friday = obj.apply_friday;
            this.apply_saturday = obj.apply_saturday;
            this.start_date = obj.start_date;
            this.end_date = obj.end_date;
        }
    }


    static override fromJS(data: any): ScheduleRuleAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new ScheduleRuleAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["schedule_day"] = this.schedule_day;
        data["type"] = this.type;
        data["apply_sunday"] = this.apply_sunday;
        data["apply_monday"] = this.apply_monday;
        data["apply_tuesday"] = this.apply_tuesday;
        data["apply_wednesday"] = this.apply_wednesday;
        data["apply_thursday"] = this.apply_thursday;
        data["apply_friday"] = this.apply_friday;
        data["apply_saturday"] = this.apply_saturday;
        data["start_date"] = this.start_date;
        data["end_date"] = this.end_date;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || [error.property]).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
