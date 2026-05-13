import { IsNumber, IsDefined, Min, IsString, IsOptional, Equals, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { ScheduleFixedInterval } from "./ScheduleFixedInterval";
import { ScheduleRuleset } from "./ScheduleRuleset";

export class Infiltration extends IDdEnergyBaseModel {
    @Type(() => Number)
    @IsNumber()
    @IsDefined()
    @Min(0)
    @Expose({ name: "flow_per_exterior_area" })
    /** Number for the infiltration per exterior surface area in m3/s-m2. */
    flowPerExteriorArea!: number;
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("Infiltration")
    @Expose({ name: "type" })
    /** type */
    type: string = "Infiltration";
	
    @IsOptional()
    @Expose({ name: "schedule" })
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'ScheduleRuleset') return ScheduleRuleset.fromJS(item);
      else if (item?.type === 'ScheduleFixedInterval') return ScheduleFixedInterval.fromJS(item);
      else return item;
    })
    /** The schedule for the infiltration over the course of the year. The type of this schedule should be Fractional and the fractional values will get multiplied by the flow_per_exterior_area to yield a complete infiltration profile. If None, an Always On schedule will be used. */
    schedule?: (ScheduleRuleset | ScheduleFixedInterval);
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "constant_coefficient" })
    /** constantCoefficient */
    constantCoefficient: number = 1;
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "temperature_coefficient" })
    /** temperatureCoefficient */
    temperatureCoefficient: number = 0;
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "velocity_coefficient" })
    /** velocityCoefficient */
    velocityCoefficient: number = 0;
	

    constructor() {
        super();
        this.type = "Infiltration";
        this.constantCoefficient = 1;
        this.temperatureCoefficient = 0;
        this.velocityCoefficient = 0;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(Infiltration, _data);
            this.flowPerExteriorArea = obj.flowPerExteriorArea;
            this.type = obj.type ?? "Infiltration";
            this.schedule = obj.schedule;
            this.constantCoefficient = obj.constantCoefficient ?? 1;
            this.temperatureCoefficient = obj.temperatureCoefficient ?? 0;
            this.velocityCoefficient = obj.velocityCoefficient ?? 0;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static override fromJS(data: any): Infiltration {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new Infiltration();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["flow_per_exterior_area"] = this.flowPerExteriorArea;
        data["type"] = this.type ?? "Infiltration";
        data["schedule"] = this.schedule;
        data["constant_coefficient"] = this.constantCoefficient ?? 1;
        data["temperature_coefficient"] = this.temperatureCoefficient ?? 0;
        data["velocity_coefficient"] = this.velocityCoefficient ?? 0;
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
