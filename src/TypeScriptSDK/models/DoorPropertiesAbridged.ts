import { IsString, IsOptional, IsInstance, ValidateNested, validate, ValidationError } from 'class-validator';
import { DoorEnergyPropertiesAbridged } from "./DoorEnergyPropertiesAbridged";
import { DoorRadiancePropertiesAbridged } from "./DoorRadiancePropertiesAbridged";
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

export class DoorPropertiesAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsInstance(DoorEnergyPropertiesAbridged)
    @ValidateNested()
    @IsOptional()
    energy?: DoorEnergyPropertiesAbridged;
	
    @IsInstance(DoorRadiancePropertiesAbridged)
    @ValidateNested()
    @IsOptional()
    radiance?: DoorRadiancePropertiesAbridged;
	

    constructor() {
        super();
        this.type = "DoorPropertiesAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "DoorPropertiesAbridged";
            this.energy = _data["energy"];
            this.radiance = _data["radiance"];
        }
    }


    static override fromJS(data: any): DoorPropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new DoorPropertiesAbridged();
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
        data["energy"] = this.energy;
        data["radiance"] = this.radiance;
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
