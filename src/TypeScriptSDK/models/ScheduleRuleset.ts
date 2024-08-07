import { IsArray, ValidateNested, IsDefined, IsString, IsOptional, IsInstance, validate, ValidationError } from 'class-validator';
import { ScheduleDay } from "./ScheduleDay";
import { ScheduleRuleAbridged } from "./ScheduleRuleAbridged";
import { ScheduleTypeLimit } from "./ScheduleTypeLimit";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Used to define a schedule for a default day, further described by ScheduleRule. */
export class ScheduleRuleset extends IDdEnergyBaseModel {
    @IsArray()
    @ValidateNested({ each: true })
    @IsDefined()
    /** A list of ScheduleDays that are referenced in the other keys of this ScheduleRulesetAbridged. */
    day_schedules!: ScheduleDay [];
	
    @IsString()
    @IsDefined()
    /** An identifier for the ScheduleDay that will be used for all days when no ScheduleRule is applied. This ScheduleDay must be in the day_schedules. */
    default_day_schedule!: string;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of ScheduleRuleAbridged that note exceptions to the default_day_schedule. These rules should be ordered from highest to lowest priority. */
    schedule_rules?: ScheduleRuleAbridged [];
	
    @IsString()
    @IsOptional()
    /** An identifier for the ScheduleDay that will be used for holidays. This ScheduleDay must be in the day_schedules. */
    holiday_schedule?: string;
	
    @IsString()
    @IsOptional()
    /** An identifier for the ScheduleDay that will be used for the summer design day. This ScheduleDay must be in the day_schedules. */
    summer_designday_schedule?: string;
	
    @IsString()
    @IsOptional()
    /** An identifier for the ScheduleDay that will be used for the winter design day. This ScheduleDay must be in the day_schedules. */
    winter_designday_schedule?: string;
	
    @IsInstance(ScheduleTypeLimit)
    @ValidateNested()
    @IsOptional()
    /** ScheduleTypeLimit object that will be used to validate schedule values against upper/lower limits and assign units to the schedule values. If None, no validation will occur. */
    schedule_type_limit?: ScheduleTypeLimit;
	

    constructor() {
        super();
        this.type = "ScheduleRuleset";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.day_schedules = _data["day_schedules"];
            this.default_day_schedule = _data["default_day_schedule"];
            this.type = _data["type"] !== undefined ? _data["type"] : "ScheduleRuleset";
            this.schedule_rules = _data["schedule_rules"];
            this.holiday_schedule = _data["holiday_schedule"];
            this.summer_designday_schedule = _data["summer_designday_schedule"];
            this.winter_designday_schedule = _data["winter_designday_schedule"];
            this.schedule_type_limit = _data["schedule_type_limit"];
        }
    }


    static override fromJS(data: any): ScheduleRuleset {
        data = typeof data === 'object' ? data : {};

        let result = new ScheduleRuleset();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["day_schedules"] = this.day_schedules;
        data["default_day_schedule"] = this.default_day_schedule;
        data["type"] = this.type;
        data["schedule_rules"] = this.schedule_rules;
        data["holiday_schedule"] = this.holiday_schedule;
        data["summer_designday_schedule"] = this.summer_designday_schedule;
        data["winter_designday_schedule"] = this.winter_designday_schedule;
        data["schedule_type_limit"] = this.schedule_type_limit;
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
