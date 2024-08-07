import { IsString, IsDefined, IsOptional, IsArray, ValidateNested, validate, ValidationError } from 'class-validator';
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
	
    @IsOptional()
    /** Boolean noting whether to apply schedule_day on Sundays. */
    apply_sunday?: boolean;
	
    @IsOptional()
    /** Boolean noting whether to apply schedule_day on Mondays. */
    apply_monday?: boolean;
	
    @IsOptional()
    /** Boolean noting whether to apply schedule_day on Tuesdays. */
    apply_tuesday?: boolean;
	
    @IsOptional()
    /** Boolean noting whether to apply schedule_day on Wednesdays. */
    apply_wednesday?: boolean;
	
    @IsOptional()
    /** Boolean noting whether to apply schedule_day on Thursdays. */
    apply_thursday?: boolean;
	
    @IsOptional()
    /** Boolean noting whether to apply schedule_day on Fridays. */
    apply_friday?: boolean;
	
    @IsOptional()
    /** Boolean noting whether to apply schedule_day on Saturdays. */
    apply_saturday?: boolean;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of two integers for [month, day], representing the start date of the period over which the schedule_day will be applied.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case). */
    start_date?: number [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of two integers for [month, day], representing the end date of the period over which the schedule_day will be applied.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case). */
    end_date?: number [];
	

    constructor() {
        super();
        this.type = "ScheduleRuleAbridged";
        this.apply_sunday = False;
        this.apply_monday = False;
        this.apply_tuesday = False;
        this.apply_wednesday = False;
        this.apply_thursday = False;
        this.apply_friday = False;
        this.apply_saturday = False;
        this.start_date = [
  1,
  1
];
        this.end_date = [
  12,
  31
];
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.schedule_day = _data["schedule_day"];
            this.type = _data["type"] !== undefined ? _data["type"] : "ScheduleRuleAbridged";
            this.apply_sunday = _data["apply_sunday"] !== undefined ? _data["apply_sunday"] : False;
            this.apply_monday = _data["apply_monday"] !== undefined ? _data["apply_monday"] : False;
            this.apply_tuesday = _data["apply_tuesday"] !== undefined ? _data["apply_tuesday"] : False;
            this.apply_wednesday = _data["apply_wednesday"] !== undefined ? _data["apply_wednesday"] : False;
            this.apply_thursday = _data["apply_thursday"] !== undefined ? _data["apply_thursday"] : False;
            this.apply_friday = _data["apply_friday"] !== undefined ? _data["apply_friday"] : False;
            this.apply_saturday = _data["apply_saturday"] !== undefined ? _data["apply_saturday"] : False;
            this.start_date = _data["start_date"] !== undefined ? _data["start_date"] : [
  1,
  1
];
            this.end_date = _data["end_date"] !== undefined ? _data["end_date"] : [
  12,
  31
];
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
			const errorMessages = errors.map((error: ValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
