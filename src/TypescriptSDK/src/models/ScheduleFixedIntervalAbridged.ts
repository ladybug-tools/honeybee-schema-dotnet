import { IsArray, IsNumber, IsDefined, IsString, IsOptional, Matches, MinLength, MaxLength, IsInt, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Used to specify a start date and a list of values for a period of analysis. */
export class ScheduleFixedIntervalAbridged extends IDdEnergyBaseModel {
    @IsArray()
    @IsNumber({},{ each: true })
    @IsDefined()
    @Expose({ name: "values" })
    /** A list of timeseries values occurring at each timestep over the course of the simulation. */
    values!: number[];
	
    @IsString()
    @IsOptional()
    @Matches(/^ScheduleFixedIntervalAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ScheduleFixedIntervalAbridged";
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "schedule_type_limit" })
    /** Identifier of a ScheduleTypeLimit that will be used to validate schedule values against upper/lower limits and assign units to the schedule values. If None, no validation will occur. */
    scheduleTypeLimit?: string;
	
    @IsInt()
    @IsOptional()
    @Expose({ name: "timestep" })
    /** An integer for the number of steps per hour that the input values correspond to.  For example, if each value represents 30 minutes, the timestep is 2. For 15 minutes, it is 4. */
    timestep: number = 1;
	
    @IsArray()
    @IsInt({ each: true })
    @IsOptional()
    @Expose({ name: "start_date" })
    /** A list of two integers for [month, day], representing the start date when the schedule values begin to take effect.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case). */
    startDate: number[] = [1, 1];
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "placeholder_value" })
    /**  A value that will be used for all times not covered by the input values. Typically, your simulation should not need to use this value if the input values completely cover the simulation period. */
    placeholderValue: number = 0;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "interpolate" })
    /** Boolean to note whether values in between intervals should be linearly interpolated or whether successive values should take effect immediately upon the beginning time corresponding to them. */
    interpolate: boolean = false;
	

    constructor() {
        super();
        this.type = "ScheduleFixedIntervalAbridged";
        this.timestep = 1;
        this.startDate = [1, 1];
        this.placeholderValue = 0;
        this.interpolate = false;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ScheduleFixedIntervalAbridged, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.values = obj.values;
            this.type = obj.type ?? "ScheduleFixedIntervalAbridged";
            this.scheduleTypeLimit = obj.scheduleTypeLimit;
            this.timestep = obj.timestep ?? 1;
            this.startDate = obj.startDate ?? [1, 1];
            this.placeholderValue = obj.placeholderValue ?? 0;
            this.interpolate = obj.interpolate ?? false;
        }
    }


    static override fromJS(data: any): ScheduleFixedIntervalAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ScheduleFixedIntervalAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["values"] = this.values;
        data["type"] = this.type ?? "ScheduleFixedIntervalAbridged";
        data["schedule_type_limit"] = this.scheduleTypeLimit;
        data["timestep"] = this.timestep ?? 1;
        data["start_date"] = this.startDate ?? [1, 1];
        data["placeholder_value"] = this.placeholderValue ?? 0;
        data["interpolate"] = this.interpolate ?? false;
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
