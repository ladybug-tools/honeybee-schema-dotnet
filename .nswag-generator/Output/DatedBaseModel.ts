import { IsString, IsOptional, validate, ValidationError } from 'class-validator';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { ScheduleRuleAbridged } from "./ScheduleRuleAbridged";
import { DaylightSavingTime } from "./DaylightSavingTime";
import { RunPeriod } from "./RunPeriod";

/** Base class for all objects needing to check for a valid Date. */
export class DatedBaseModel extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.type = "DatedBaseModel";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "DatedBaseModel";
        }
    }


    static override fromJS(data: any): DatedBaseModel {
        data = typeof data === 'object' ? data : {};

        if (data["type"] === "ScheduleRuleAbridged") {
            let result = new ScheduleRuleAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "DaylightSavingTime") {
            let result = new DaylightSavingTime();
            result.init(data);
            return result;
        }
        if (data["type"] === "RunPeriod") {
            let result = new RunPeriod();
            result.init(data);
            return result;
        }
        let result = new DatedBaseModel();
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
