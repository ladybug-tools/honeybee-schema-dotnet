import { IsString, IsOptional, Equals, IsNumber, Min, IsInt, Max, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { ScheduleFixedInterval } from "./ScheduleFixedInterval";
import { ScheduleRuleset } from "./ScheduleRuleset";

export class ExhaustAir extends IDdEnergyBaseModel {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("ExhaustAir")
    @Expose({ name: "type" })
    /** type */
    type: string = "ExhaustAir";
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "flow_per_area" })
    /** Intensity of exhaust air in [m3/s per m2 of floor area]. */
    flowPerArea: number = 0;
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Expose({ name: "flow_per_fixture" })
    /** The level of exhaust air ventilation in m3/s for each fixture in the room. The term ""fixture"" is used broadly as a way to reference a wide variety of contaminant sources such as toilets/urinals, shower heads, kitchen hoods, fume hoods, etc. */
    flowPerFixture: number = 0;
	
    @Type(() => Number)
    @IsInt()
    @IsOptional()
    @Min(0)
    @Expose({ name: "fixture_count" })
    /** An integer for the number of fixtures in the room. This is multiplied by the flow_per_fixture, which is then added to the flow_per_area to yield the final exhaust air flow rate. */
    fixtureCount: number = 1;
	
    @IsOptional()
    @Expose({ name: "schedule" })
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'ScheduleRuleset') return ScheduleRuleset.fromJS(item);
      else if (item?.type === 'ScheduleFixedInterval') return ScheduleFixedInterval.fromJS(item);
      else return item;
    })
    /** Schedule for the exhaust air ventilation over the course of the year. The type of this schedule should be Fractional and the fractional values get multiplied by the total design flow rate to yield a complete exhaust air profile. Values of 0 in the schedule will shut the exhaust fan off completely. If None, the design level of exhaust air will be used throughout all timesteps of the simulation, meaning that this schedule is Always On. */
    schedule?: (ScheduleRuleset | ScheduleFixedInterval);
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Expose({ name: "pressure_rise" })
    /** A positive number for the the pressure rise across the fan in Pascals (N/m2). This is often a function of the fan speed and the conditions in which the fan is operating. It plays an important role in determining the amount of energy consumed by the fan. Typical kitchen and bathroom exhaust fans have pressure rises around 125 Pa but, in healthcare settings where filters create more resistance, higher pressures around 250 Pa are more common. */
    pressureRise: number = 125;
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Max(1)
    @Expose({ name: "efficiency" })
    /** A number between 0 and 1 for the overall efficiency of the fan. Specifically, this is the ratio of the power delivered to the fluid to the electrical input power. It is the product of the fan motor efficiency and the fan impeller efficiency. Fans that have a higher blade diameter, no obstructions or filters, and operate at lower speeds with smaller pressure rises for their size tend to have higher efficiencies. Because motor efficiencies are typically between 0.8 and 0.9, the best overall fan efficiencies tend to be around 0.7 with most typical fan efficiencies between 0.5 and 0.7. When filters are added, which is common for most exhaust fans, the total efficiency typically ends up between 0.3 and 0.4. */
    efficiency: number = 0.35;
	
    @IsOptional()
    @Expose({ name: "balancing_schedule" })
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'ScheduleRuleset') return ScheduleRuleset.fromJS(item);
      else if (item?.type === 'ScheduleFixedInterval') return ScheduleFixedInterval.fromJS(item);
      else return item;
    })
    /** Schedule for the fraction of exhaust air that is unbalanced by simple airflows, such as infiltration, natural ventilation, or zone mixing. Unbalanced exhaust is modeled as being provided by the outdoor air system in the central air system such that values of 1 in this schedule indicate all exhaust air balancing done by the mechanical system and values of 0 indicate all air balanced by simple air flows. If None, then all the exhaust air flow is assumed to be unbalanced by simple airflows. The the flow rates at the zone return air node are reduced by the flow rate that is being exhausted and the zone outdoor air controller will ensure that the outdoor air flow rate is sufficient to serve the exhaust. */
    balancingSchedule?: (ScheduleRuleset | ScheduleFixedInterval);
	

    constructor() {
        super();
        this.type = "ExhaustAir";
        this.flowPerArea = 0;
        this.flowPerFixture = 0;
        this.fixtureCount = 1;
        this.pressureRise = 125;
        this.efficiency = 0.35;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(ExhaustAir, _data);
            this.type = obj.type ?? "ExhaustAir";
            this.flowPerArea = obj.flowPerArea ?? 0;
            this.flowPerFixture = obj.flowPerFixture ?? 0;
            this.fixtureCount = obj.fixtureCount ?? 1;
            this.schedule = obj.schedule;
            this.pressureRise = obj.pressureRise ?? 125;
            this.efficiency = obj.efficiency ?? 0.35;
            this.balancingSchedule = obj.balancingSchedule;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static override fromJS(data: any): ExhaustAir {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ExhaustAir();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "ExhaustAir";
        data["flow_per_area"] = this.flowPerArea ?? 0;
        data["flow_per_fixture"] = this.flowPerFixture ?? 0;
        data["fixture_count"] = this.fixtureCount ?? 1;
        data["schedule"] = this.schedule;
        data["pressure_rise"] = this.pressureRise ?? 125;
        data["efficiency"] = this.efficiency ?? 0.35;
        data["balancing_schedule"] = this.balancingSchedule;
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
