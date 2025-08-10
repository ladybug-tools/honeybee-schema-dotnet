import { IsDefined, IsString, IsOptional, Matches, IsNumber, Min, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { ScheduleFixedInterval } from "./ScheduleFixedInterval";
import { ScheduleRuleset } from "./ScheduleRuleset";

/** Used to specify information about the setpoint schedule. */
export class Setpoint extends IDdEnergyBaseModel {
    @IsDefined()
    @Expose({ name: "cooling_schedule" })
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'ScheduleRuleset') return ScheduleRuleset.fromJS(item);
      else if (item?.type === 'ScheduleFixedInterval') return ScheduleFixedInterval.fromJS(item);
      else return item;
    })
    /** Schedule for the cooling setpoint. The values in this schedule should be temperature in [C]. */
    coolingSchedule!: (ScheduleRuleset | ScheduleFixedInterval);
	
    @IsDefined()
    @Expose({ name: "heating_schedule" })
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'ScheduleRuleset') return ScheduleRuleset.fromJS(item);
      else if (item?.type === 'ScheduleFixedInterval') return ScheduleFixedInterval.fromJS(item);
      else return item;
    })
    /** Schedule for the heating setpoint. The values in this schedule should be temperature in [C]. */
    heatingSchedule!: (ScheduleRuleset | ScheduleFixedInterval);
	
    @IsString()
    @IsOptional()
    @Matches(/^Setpoint$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "Setpoint";
	
    @IsOptional()
    @Expose({ name: "humidifying_schedule" })
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'ScheduleRuleset') return ScheduleRuleset.fromJS(item);
      else if (item?.type === 'ScheduleFixedInterval') return ScheduleFixedInterval.fromJS(item);
      else return item;
    })
    /** Schedule for the humidification setpoint. The values in this schedule should be in [%]. */
    humidifyingSchedule?: (ScheduleRuleset | ScheduleFixedInterval);
	
    @IsOptional()
    @Expose({ name: "dehumidifying_schedule" })
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'ScheduleRuleset') return ScheduleRuleset.fromJS(item);
      else if (item?.type === 'ScheduleFixedInterval') return ScheduleFixedInterval.fromJS(item);
      else return item;
    })
    /** Schedule for the dehumidification setpoint. The values in this schedule should be in [%]. */
    dehumidifyingSchedule?: (ScheduleRuleset | ScheduleFixedInterval);
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "setpoint_cutout_difference" })
    /** An optional positive number for the temperature difference between the cutout temperature and the setpoint temperature. Specifying a non-zero number here is useful for modeling the throttling range associated with a given setup of setpoint controls and HVAC equipment. Throttling ranges describe the range where a zone is slightly over-cooled or over-heated beyond the thermostat setpoint. They are used to avoid situations where HVAC systems turn on only to turn off a few minutes later, thereby wearing out the parts of mechanical systems faster. They can have a minor impact on energy consumption and can often have significant impacts on occupant thermal comfort, though using the default value of zero will often yield results that are close enough when trying to estimate the annual heating/cooling energy use. Specifying a value of zero effectively assumes that the system will turn on whenever conditions are outside the setpoint range and will cut out as soon as the setpoint is reached. */
    setpointCutoutDifference: number = 0;
	

    constructor() {
        super();
        this.type = "Setpoint";
        this.setpointCutoutDifference = 0;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(Setpoint, _data);
            this.coolingSchedule = obj.coolingSchedule;
            this.heatingSchedule = obj.heatingSchedule;
            this.type = obj.type ?? "Setpoint";
            this.humidifyingSchedule = obj.humidifyingSchedule;
            this.dehumidifyingSchedule = obj.dehumidifyingSchedule;
            this.setpointCutoutDifference = obj.setpointCutoutDifference ?? 0;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static override fromJS(data: any): Setpoint {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new Setpoint();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["cooling_schedule"] = this.coolingSchedule;
        data["heating_schedule"] = this.heatingSchedule;
        data["type"] = this.type ?? "Setpoint";
        data["humidifying_schedule"] = this.humidifyingSchedule;
        data["dehumidifying_schedule"] = this.dehumidifyingSchedule;
        data["setpoint_cutout_difference"] = this.setpointCutoutDifference ?? 0;
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
