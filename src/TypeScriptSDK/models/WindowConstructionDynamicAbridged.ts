import { IsArray, ValidateNested, IsDefined, IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { WindowConstructionAbridged } from "./WindowConstructionAbridged";

/** Construction for window objects with an included shade layer. */
export class WindowConstructionDynamicAbridged extends IDdEnergyBaseModel {
    @IsArray()
    @ValidateNested({ each: true })
    @IsDefined()
    /** A list of WindowConstructionAbridged objects that define the various states that the dynamic window can assume. */
    constructions!: WindowConstructionAbridged [];
	
    @IsString()
    @IsDefined()
    /** An identifier for a control schedule that dictates which constructions are active at given times throughout the simulation. The values of the schedule should be integers and range from 0 to one less then the number of constructions. Zero indicates that the first construction is active, one indicates that the second on is active, etc. The schedule type limits of this schedule should be ""Control Level."" If building custom schedule type limits that describe a particular range of states, the type limits should be ""Discrete"" and the unit type should be ""Mode,"" ""Control,"" or some other fractional unit. */
    schedule!: string;
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.type = "WindowConstructionDynamicAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.constructions = _data["constructions"];
            this.schedule = _data["schedule"];
            this.type = _data["type"] !== undefined ? _data["type"] : "WindowConstructionDynamicAbridged";
        }
    }


    static override fromJS(data: any): WindowConstructionDynamicAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new WindowConstructionDynamicAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["constructions"] = this.constructions;
        data["schedule"] = this.schedule;
        data["type"] = this.type;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
