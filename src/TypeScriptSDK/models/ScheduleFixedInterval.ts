import { IsArray, IsNumber, IsDefined, IsString, IsOptional, Matches, IsInstance, ValidateNested, IsInt, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { ScheduleTypeLimit } from "./ScheduleTypeLimit";

/** Used to specify a start date and a list of values for a period of analysis. */
export class ScheduleFixedInterval extends IDdEnergyBaseModel {
    @IsArray()
    @IsNumber({},{ each: true })
    @IsDefined()
    /** A list of timeseries values occurring at each timestep over the course of the simulation. */
    values!: number [];
	
    @IsString()
    @IsOptional()
    @Matches(/^ScheduleFixedInterval$/)
    type?: string;
	
    @IsInstance(ScheduleTypeLimit)
    @Type(() => ScheduleTypeLimit)
    @ValidateNested()
    @IsOptional()
    /** ScheduleTypeLimit object that will be used to validate schedule values against upper/lower limits and assign units to the schedule values. If None, no validation will occur. */
    schedule_type_limit?: ScheduleTypeLimit;
	
    @IsInt()
    @IsOptional()
    /** An integer for the number of steps per hour that the input values correspond to.  For example, if each value represents 30 minutes, the timestep is 2. For 15 minutes, it is 4. */
    timestep?: number;
	
    @IsArray()
    @IsInt({ each: true })
    @IsOptional()
    /** A list of two integers for [month, day], representing the start date when the schedule values begin to take effect.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case). */
    start_date?: number [];
	
    @IsNumber()
    @IsOptional()
    /**  A value that will be used for all times not covered by the input values. Typically, your simulation should not need to use this value if the input values completely cover the simulation period. */
    placeholder_value?: number;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean to note whether values in between intervals should be linearly interpolated or whether successive values should take effect immediately upon the beginning time corresponding to them. */
    interpolate?: boolean;
	

    constructor() {
        super();
        this.type = "ScheduleFixedInterval";
        this.timestep = 1;
        this.start_date = [1, 1];
        this.placeholder_value = 0;
        this.interpolate = false;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ScheduleFixedInterval, _data);
            this.values = obj.values;
            this.type = obj.type;
            this.schedule_type_limit = obj.schedule_type_limit;
            this.timestep = obj.timestep;
            this.start_date = obj.start_date;
            this.placeholder_value = obj.placeholder_value;
            this.interpolate = obj.interpolate;
        }
    }


    static override fromJS(data: any): ScheduleFixedInterval {
        data = typeof data === 'object' ? data : {};

        let result = new ScheduleFixedInterval();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["values"] = this.values;
        data["type"] = this.type;
        data["schedule_type_limit"] = this.schedule_type_limit;
        data["timestep"] = this.timestep;
        data["start_date"] = this.start_date;
        data["placeholder_value"] = this.placeholder_value;
        data["interpolate"] = this.interpolate;
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

