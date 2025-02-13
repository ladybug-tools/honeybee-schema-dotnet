import { IsString, IsOptional, Matches, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { ShadeMeshEnergyPropertiesAbridged } from "./ShadeMeshEnergyPropertiesAbridged";
import { ShadeMeshRadiancePropertiesAbridged } from "./ShadeMeshRadiancePropertiesAbridged";

export class ShadeMeshPropertiesAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^ShadeMeshPropertiesAbridged$/)
    /** Type */
    type?: string;
	
    @IsInstance(ShadeMeshEnergyPropertiesAbridged)
    @Type(() => ShadeMeshEnergyPropertiesAbridged)
    @ValidateNested()
    @IsOptional()
    /** Energy */
    energy?: ShadeMeshEnergyPropertiesAbridged;
	
    @IsInstance(ShadeMeshRadiancePropertiesAbridged)
    @Type(() => ShadeMeshRadiancePropertiesAbridged)
    @ValidateNested()
    @IsOptional()
    /** Radiance */
    radiance?: ShadeMeshRadiancePropertiesAbridged;
	

    constructor() {
        super();
        this.type = "ShadeMeshPropertiesAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ShadeMeshPropertiesAbridged, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.energy = obj.energy;
            this.radiance = obj.radiance;
        }
    }


    static override fromJS(data: any): ShadeMeshPropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ShadeMeshPropertiesAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["energy"] = this.energy;
        data["radiance"] = this.radiance;
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

