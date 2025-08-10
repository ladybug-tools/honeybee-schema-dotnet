import { IsString, IsOptional, Matches, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { ModelDoe2Properties } from "./ModelDoe2Properties";
import { ModelEnergyProperties } from "./ModelEnergyProperties";
import { ModelRadianceProperties } from "./ModelRadianceProperties";

export class ModelProperties extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^ModelProperties$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ModelProperties";
	
    @IsInstance(ModelEnergyProperties)
    @Type(() => ModelEnergyProperties)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "energy" })
    /** energy */
    energy?: ModelEnergyProperties;
	
    @IsInstance(ModelRadianceProperties)
    @Type(() => ModelRadianceProperties)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "radiance" })
    /** radiance */
    radiance?: ModelRadianceProperties;
	
    @IsInstance(ModelDoe2Properties)
    @Type(() => ModelDoe2Properties)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "doe2" })
    /** doe2 */
    doe2?: ModelDoe2Properties;
	

    constructor() {
        super();
        this.type = "ModelProperties";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(ModelProperties, _data);
            this.type = obj.type ?? "ModelProperties";
            this.energy = obj.energy;
            this.radiance = obj.radiance;
            this.doe2 = obj.doe2;
        }
    }


    static override fromJS(data: any): ModelProperties {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ModelProperties();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "ModelProperties";
        data["energy"] = this.energy;
        data["radiance"] = this.radiance;
        data["doe2"] = this.doe2;
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
