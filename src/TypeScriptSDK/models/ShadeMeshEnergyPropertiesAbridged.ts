import { IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { OpenAPIGenBaseModel } from "./OpenAPIGenBaseModel";

/** Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects. */
export class ShadeMeshEnergyPropertiesAbridged extends OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier of a ShadeConstruction to set the reflectance and specularity of the Shade. If None, it will be a generic context construction that is completely diffuse with 0.2 visible and solar reflectance. Unless it is building attached, in which case it will be set by the default generic ConstructionSet. */
    construction?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier of a schedule to set the transmittance of the shade, which can vary throughout the simulation. If None, the shade will be completely opaque. */
    transmittance_schedule?: string;
	

    constructor() {
        super();
        this.type = "ShadeMeshEnergyPropertiesAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "ShadeMeshEnergyPropertiesAbridged";
            this.construction = _data["construction"];
            this.transmittance_schedule = _data["transmittance_schedule"];
        }
    }


    static override fromJS(data: any): ShadeMeshEnergyPropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new ShadeMeshEnergyPropertiesAbridged();
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
        data["construction"] = this.construction;
        data["transmittance_schedule"] = this.transmittance_schedule;
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
