import { IsString, IsDefined, MinLength, MaxLength, IsOptional, Matches, IsBoolean, IsArray, IsInt, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { DatedBaseModel } from "./DatedBaseModel";

/** Schedule rule including a ScheduleDay and when it should be applied.. */
export class ScheduleRuleAbridged extends DatedBaseModel {
    @IsString()
    @IsDefined()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "schedule_day" })
    /** The identifier of a ScheduleDay object associated with this rule. */
    scheduleDay!: string;
	
    @IsString()
    @IsOptional()
    @Matches(/^ScheduleRuleAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ScheduleRuleAbridged";
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "apply_sunday" })
    /** Boolean noting whether to apply schedule_day on Sundays. */
    applySunday: boolean = false;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "apply_monday" })
    /** Boolean noting whether to apply schedule_day on Mondays. */
    applyMonday: boolean = false;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "apply_tuesday" })
    /** Boolean noting whether to apply schedule_day on Tuesdays. */
    applyTuesday: boolean = false;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "apply_wednesday" })
    /** Boolean noting whether to apply schedule_day on Wednesdays. */
    applyWednesday: boolean = false;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "apply_thursday" })
    /** Boolean noting whether to apply schedule_day on Thursdays. */
    applyThursday: boolean = false;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "apply_friday" })
    /** Boolean noting whether to apply schedule_day on Fridays. */
    applyFriday: boolean = false;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "apply_saturday" })
    /** Boolean noting whether to apply schedule_day on Saturdays. */
    applySaturday: boolean = false;
	
    @IsArray()
    @IsInt({ each: true })
    @IsOptional()
    @Expose({ name: "start_date" })
    /** A list of two integers for [month, day], representing the start date of the period over which the schedule_day will be applied.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case). */
    startDate: number[] = [1, 1];
	
    @IsArray()
    @IsInt({ each: true })
    @IsOptional()
    @Expose({ name: "end_date" })
    /** A list of two integers for [month, day], representing the end date of the period over which the schedule_day will be applied.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case). */
    endDate: number[] = [12, 31];
	

    constructor() {
        super();
        this.type = "ScheduleRuleAbridged";
        this.applySunday = false;
        this.applyMonday = false;
        this.applyTuesday = false;
        this.applyWednesday = false;
        this.applyThursday = false;
        this.applyFriday = false;
        this.applySaturday = false;
        this.startDate = [1, 1];
        this.endDate = [12, 31];
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ScheduleRuleAbridged, _data, { enableImplicitConversion: true });
            this.scheduleDay = obj.scheduleDay;
            this.type = obj.type;
            this.applySunday = obj.applySunday;
            this.applyMonday = obj.applyMonday;
            this.applyTuesday = obj.applyTuesday;
            this.applyWednesday = obj.applyWednesday;
            this.applyThursday = obj.applyThursday;
            this.applyFriday = obj.applyFriday;
            this.applySaturday = obj.applySaturday;
            this.startDate = obj.startDate;
            this.endDate = obj.endDate;
        }
    }


    static override fromJS(data: any): ScheduleRuleAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ScheduleRuleAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["schedule_day"] = this.scheduleDay;
        data["type"] = this.type;
        data["apply_sunday"] = this.applySunday;
        data["apply_monday"] = this.applyMonday;
        data["apply_tuesday"] = this.applyTuesday;
        data["apply_wednesday"] = this.applyWednesday;
        data["apply_thursday"] = this.applyThursday;
        data["apply_friday"] = this.applyFriday;
        data["apply_saturday"] = this.applySaturday;
        data["start_date"] = this.startDate;
        data["end_date"] = this.endDate;
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
