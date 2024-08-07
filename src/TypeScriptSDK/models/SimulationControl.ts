import { IsString, IsOptional, validate, ValidationError } from 'class-validator';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Used to specify which types of calculations to run. */
export class SimulationControl extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsOptional()
    /** Boolean for whether the zone sizing calculation should be run. */
    do_zone_sizing?: boolean;
	
    @IsOptional()
    /** Boolean for whether the system sizing calculation should be run. */
    do_system_sizing?: boolean;
	
    @IsOptional()
    /** Boolean for whether the plant sizing calculation should be run. */
    do_plant_sizing?: boolean;
	
    @IsOptional()
    /** Boolean for whether the simulation should be run for the sizing periods. */
    run_for_run_periods?: boolean;
	
    @IsOptional()
    /** Boolean for whether the simulation should be run for the run periods. */
    run_for_sizing_periods?: boolean;
	

    constructor() {
        super();
        this.type = "SimulationControl";
        this.do_zone_sizing = True;
        this.do_system_sizing = True;
        this.do_plant_sizing = True;
        this.run_for_run_periods = True;
        this.run_for_sizing_periods = False;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "SimulationControl";
            this.do_zone_sizing = _data["do_zone_sizing"] !== undefined ? _data["do_zone_sizing"] : True;
            this.do_system_sizing = _data["do_system_sizing"] !== undefined ? _data["do_system_sizing"] : True;
            this.do_plant_sizing = _data["do_plant_sizing"] !== undefined ? _data["do_plant_sizing"] : True;
            this.run_for_run_periods = _data["run_for_run_periods"] !== undefined ? _data["run_for_run_periods"] : True;
            this.run_for_sizing_periods = _data["run_for_sizing_periods"] !== undefined ? _data["run_for_sizing_periods"] : False;
        }
    }


    static override fromJS(data: any): SimulationControl {
        data = typeof data === 'object' ? data : {};

        let result = new SimulationControl();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["type"] = this.type;
        data["do_zone_sizing"] = this.do_zone_sizing;
        data["do_system_sizing"] = this.do_system_sizing;
        data["do_plant_sizing"] = this.do_plant_sizing;
        data["run_for_run_periods"] = this.run_for_run_periods;
        data["run_for_sizing_periods"] = this.run_for_sizing_periods;
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
