import { IsString, IsOptional, Matches, IsNumber, Min, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { ScheduleFixedInterval } from "./ScheduleFixedInterval";
import { ScheduleRuleset } from "./ScheduleRuleset";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class Ventilation extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^Ventilation$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "Ventilation";
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "flow_per_person" })
    /** Intensity of ventilation in[] m3/s per person]. Note that setting this value does not mean that ventilation is varied based on real-time occupancy but rather that the design level of ventilation is determined using this value and the People object of the Room. */
    flowPerPerson: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "flow_per_area" })
    /** Intensity of ventilation in [m3/s per m2 of floor area]. */
    flowPerArea: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "air_changes_per_hour" })
    /** Intensity of ventilation in air changes per hour (ACH) for the entire Room. */
    airChangesPerHour: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "flow_per_zone" })
    /** Intensity of ventilation in m3/s for the entire Room. */
    flowPerZone: number = 0;
	
    @IsOptional()
    @Expose({ name: "schedule" })
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'ScheduleRuleset') return ScheduleRuleset.fromJS(item);
      else if (item?.type === 'ScheduleFixedInterval') return ScheduleFixedInterval.fromJS(item);
      else return item;
    })
    /** Schedule for the ventilation over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the total design flow rate (determined from the sum of the other 4 fields) to yield a complete ventilation profile. */
    schedule?: (ScheduleRuleset | ScheduleFixedInterval);
	

    constructor() {
        super();
        this.type = "Ventilation";
        this.flowPerPerson = 0;
        this.flowPerArea = 0;
        this.airChangesPerHour = 0;
        this.flowPerZone = 0;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(Ventilation, _data);
            this.type = obj.type ?? "Ventilation";
            this.flowPerPerson = obj.flowPerPerson ?? 0;
            this.flowPerArea = obj.flowPerArea ?? 0;
            this.airChangesPerHour = obj.airChangesPerHour ?? 0;
            this.flowPerZone = obj.flowPerZone ?? 0;
            this.schedule = obj.schedule;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static override fromJS(data: any): Ventilation {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new Ventilation();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "Ventilation";
        data["flow_per_person"] = this.flowPerPerson ?? 0;
        data["flow_per_area"] = this.flowPerArea ?? 0;
        data["air_changes_per_hour"] = this.airChangesPerHour ?? 0;
        data["flow_per_zone"] = this.flowPerZone ?? 0;
        data["schedule"] = this.schedule;
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
