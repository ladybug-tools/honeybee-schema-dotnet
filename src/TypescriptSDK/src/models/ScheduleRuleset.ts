import { IsArray, IsInstance, ValidateNested, IsDefined, IsString, MinLength, MaxLength, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { ScheduleDay } from "./ScheduleDay";
import { ScheduleRuleAbridged } from "./ScheduleRuleAbridged";
import { ScheduleTypeLimit } from "./ScheduleTypeLimit";

/** Used to define a schedule for a default day, further described by ScheduleRule. */
export class ScheduleRuleset extends IDdEnergyBaseModel {
    @IsArray()
    @IsInstance(ScheduleDay, { each: true })
    @Type(() => ScheduleDay)
    @ValidateNested({ each: true })
    @IsDefined()
    @Expose({ name: "day_schedules" })
    /** A list of ScheduleDays that are referenced in the other keys of this ScheduleRulesetAbridged. */
    daySchedules!: ScheduleDay[];
	
    @IsString()
    @IsDefined()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "default_day_schedule" })
    /** An identifier for the ScheduleDay that will be used for all days when no ScheduleRule is applied. This ScheduleDay must be in the day_schedules. */
    defaultDaySchedule!: string;
	
    @IsString()
    @IsOptional()
    @Matches(/^ScheduleRuleset$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ScheduleRuleset";
	
    @IsArray()
    @IsInstance(ScheduleRuleAbridged, { each: true })
    @Type(() => ScheduleRuleAbridged)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "schedule_rules" })
    /** A list of ScheduleRuleAbridged that note exceptions to the default_day_schedule. These rules should be ordered from highest to lowest priority. */
    scheduleRules?: ScheduleRuleAbridged[];
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "holiday_schedule" })
    /** An identifier for the ScheduleDay that will be used for holidays. This ScheduleDay must be in the day_schedules. */
    holidaySchedule?: string;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "summer_designday_schedule" })
    /** An identifier for the ScheduleDay that will be used for the summer design day. This ScheduleDay must be in the day_schedules. */
    summerDesigndaySchedule?: string;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "winter_designday_schedule" })
    /** An identifier for the ScheduleDay that will be used for the winter design day. This ScheduleDay must be in the day_schedules. */
    winterDesigndaySchedule?: string;
	
    @IsInstance(ScheduleTypeLimit)
    @Type(() => ScheduleTypeLimit)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "schedule_type_limit" })
    /** ScheduleTypeLimit object that will be used to validate schedule values against upper/lower limits and assign units to the schedule values. If None, no validation will occur. */
    scheduleTypeLimit?: ScheduleTypeLimit;
	

    constructor() {
        super();
        this.type = "ScheduleRuleset";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(ScheduleRuleset, _data);
            this.daySchedules = obj.daySchedules;
            this.defaultDaySchedule = obj.defaultDaySchedule;
            this.type = obj.type ?? "ScheduleRuleset";
            this.scheduleRules = obj.scheduleRules;
            this.holidaySchedule = obj.holidaySchedule;
            this.summerDesigndaySchedule = obj.summerDesigndaySchedule;
            this.winterDesigndaySchedule = obj.winterDesigndaySchedule;
            this.scheduleTypeLimit = obj.scheduleTypeLimit;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static override fromJS(data: any): ScheduleRuleset {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ScheduleRuleset();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["day_schedules"] = this.daySchedules;
        data["default_day_schedule"] = this.defaultDaySchedule;
        data["type"] = this.type ?? "ScheduleRuleset";
        data["schedule_rules"] = this.scheduleRules;
        data["holiday_schedule"] = this.holidaySchedule;
        data["summer_designday_schedule"] = this.summerDesigndaySchedule;
        data["winter_designday_schedule"] = this.winterDesigndaySchedule;
        data["schedule_type_limit"] = this.scheduleTypeLimit;
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
