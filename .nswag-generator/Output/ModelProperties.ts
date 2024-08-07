import { IsString, IsOptional, IsInstance, ValidateNested, validate, ValidationError } from 'class-validator';
import { ModelEnergyProperties } from "./ModelEnergyProperties";
import { ModelRadianceProperties } from "./ModelRadianceProperties";
import { ModelDoe2Properties } from "./ModelDoe2Properties";
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

export class ModelProperties extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsInstance(ModelEnergyProperties)
    @ValidateNested()
    @IsOptional()
    energy?: ModelEnergyProperties;
	
    @IsInstance(ModelRadianceProperties)
    @ValidateNested()
    @IsOptional()
    radiance?: ModelRadianceProperties;
	
    @IsInstance(ModelDoe2Properties)
    @ValidateNested()
    @IsOptional()
    doe2?: ModelDoe2Properties;
	

    constructor() {
        super();
        this.type = "ModelProperties";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "ModelProperties";
            this.energy = _data["energy"];
            this.radiance = _data["radiance"];
            this.doe2 = _data["doe2"];
        }
    }


    static override fromJS(data: any): ModelProperties {
        data = typeof data === 'object' ? data : {};

        let result = new ModelProperties();
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
        data["doe2"] = this.doe2;
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
