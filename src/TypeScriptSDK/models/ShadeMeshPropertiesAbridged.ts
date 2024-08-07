import { IsString, IsOptional, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { ShadeMeshEnergyPropertiesAbridged } from "./ShadeMeshEnergyPropertiesAbridged";
import { ShadeMeshRadiancePropertiesAbridged } from "./ShadeMeshRadiancePropertiesAbridged";

export class ShadeMeshPropertiesAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsInstance(ShadeMeshEnergyPropertiesAbridged)
    @ValidateNested()
    @IsOptional()
    energy?: ShadeMeshEnergyPropertiesAbridged;
	
    @IsInstance(ShadeMeshRadiancePropertiesAbridged)
    @ValidateNested()
    @IsOptional()
    radiance?: ShadeMeshRadiancePropertiesAbridged;
	

    constructor() {
        super();
        this.type = "ShadeMeshPropertiesAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "ShadeMeshPropertiesAbridged";
            this.energy = _data["energy"];
            this.radiance = _data["radiance"];
        }
    }


    static override fromJS(data: any): ShadeMeshPropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new ShadeMeshPropertiesAbridged();
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
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
