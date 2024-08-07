import { IsDefined, IsString, IsOptional, validate, ValidationError } from 'class-validator';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Detailed HVAC system object defined using IronBug or OpenStudio .NET bindings. */
export class DetailedHVAC extends IDdEnergyBaseModel {
    @IsDefined()
    /** A JSON-serializable dictionary representing the full specification of the detailed system. This can be obtained by calling the ToJson() method on any IronBug HVAC system and then serializing the resulting JSON string into a Python dictionary using the native Python json package. Note that the Rooms that the HVAC is assigned to must be specified as ThermalZones under this specification in order for the resulting Model this HVAC is a part of to be valid. */
    specification!: Object;
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.type = "DetailedHVAC";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.specification = _data["specification"];
            this.type = _data["type"] !== undefined ? _data["type"] : "DetailedHVAC";
        }
    }


    static override fromJS(data: any): DetailedHVAC {
        data = typeof data === 'object' ? data : {};

        let result = new DetailedHVAC();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["specification"] = this.specification;
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
