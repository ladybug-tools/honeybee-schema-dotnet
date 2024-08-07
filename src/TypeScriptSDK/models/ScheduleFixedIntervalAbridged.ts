import { IsArray, ValidateNested, IsDefined, IsString, IsOptional, IsInt, IsNumber, validate, ValidationError } from 'class-validator';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Used to specify a start date and a list of values for a period of analysis. */
export class ScheduleFixedIntervalAbridged extends IDdEnergyBaseModel {
    @IsArray()
    @ValidateNested({ each: true })
    @IsDefined()
    /** A list of timeseries values occuring at each timestep over the course of the simulation. */
    values!: number [];
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier of a ScheduleTypeLimit that will be used to validate schedule values against upper/lower limits and assign units to the schedule values. If None, no validation will occur. */
    schedule_type_limit?: string;
	
    @IsInt()
    @IsOptional()
    /** An integer for the number of steps per hour that the input values correspond to.  For example, if each value represents 30 minutes, the timestep is 2. For 15 minutes, it is 4. */
    timestep?: number;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of two integers for [month, day], representing the start date when the schedule values begin to take effect.A third integer may be added to denote whether the date should be re-serialized for a leap year (it should be a 1 in this case). */
    start_date?: number [];
	
    @IsNumber()
    @IsOptional()
    /**  A value that will be used for all times not covered by the input values. Typically, your simulation should not need to use this value if the input values completely cover the simulation period. */
    placeholder_value?: number;
	
    @IsOptional()
    /** Boolean to note whether values in between intervals should be linearly interpolated or whether successive values should take effect immediately upon the beginning time corresponding to them. */
    interpolate?: boolean;
	

    constructor() {
        super();
        this.type = "ScheduleFixedIntervalAbridged";
        this.timestep = 1;
        this.start_date = [
  1,
  1
];
        this.placeholder_value = 0;
        this.interpolate = False;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.values = _data["values"];
            this.type = _data["type"] !== undefined ? _data["type"] : "ScheduleFixedIntervalAbridged";
            this.schedule_type_limit = _data["schedule_type_limit"];
            this.timestep = _data["timestep"] !== undefined ? _data["timestep"] : 1;
            this.start_date = _data["start_date"] !== undefined ? _data["start_date"] : [
  1,
  1
];
            this.placeholder_value = _data["placeholder_value"] !== undefined ? _data["placeholder_value"] : 0;
            this.interpolate = _data["interpolate"] !== undefined ? _data["interpolate"] : False;
        }
    }


    static override fromJS(data: any): ScheduleFixedIntervalAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new ScheduleFixedIntervalAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["values"] = this.values;
        data["type"] = this.type;
        data["schedule_type_limit"] = this.schedule_type_limit;
        data["timestep"] = this.timestep;
        data["start_date"] = this.start_date;
        data["placeholder_value"] = this.placeholder_value;
        data["interpolate"] = this.interpolate;
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
