import { IsString, IsOptional, Matches, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { ModelDoe2Properties } from "./ModelDoe2Properties";
import { ModelEnergyProperties } from "./ModelEnergyProperties";
import { ModelRadianceProperties } from "./ModelRadianceProperties";

export class ModelProperties extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^ModelProperties$/)
    type?: string;
	
    @IsInstance(ModelEnergyProperties)
    @Type(() => ModelEnergyProperties)
    @ValidateNested()
    @IsOptional()
    energy?: ModelEnergyProperties;
	
    @IsInstance(ModelRadianceProperties)
    @Type(() => ModelRadianceProperties)
    @ValidateNested()
    @IsOptional()
    radiance?: ModelRadianceProperties;
	
    @IsInstance(ModelDoe2Properties)
    @Type(() => ModelDoe2Properties)
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
            const obj = plainToClass(ModelProperties, _data);
            this.type = obj.type;
            this.energy = obj.energy;
            this.radiance = obj.radiance;
            this.doe2 = obj.doe2;
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
        data["type"] = this.type;
        data["energy"] = this.energy;
        data["radiance"] = this.radiance;
        data["doe2"] = this.doe2;
        data = super.toJSON(data);
        return instanceToPlain(data);
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

