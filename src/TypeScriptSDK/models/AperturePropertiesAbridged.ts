import { IsString, IsOptional, Matches, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { ApertureEnergyPropertiesAbridged } from "./ApertureEnergyPropertiesAbridged";
import { ApertureRadiancePropertiesAbridged } from "./ApertureRadiancePropertiesAbridged";

export class AperturePropertiesAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^AperturePropertiesAbridged$/)
    type?: string;
	
    @IsInstance(ApertureEnergyPropertiesAbridged)
    @Type(() => ApertureEnergyPropertiesAbridged)
    @ValidateNested()
    @IsOptional()
    energy?: ApertureEnergyPropertiesAbridged;
	
    @IsInstance(ApertureRadiancePropertiesAbridged)
    @Type(() => ApertureRadiancePropertiesAbridged)
    @ValidateNested()
    @IsOptional()
    radiance?: ApertureRadiancePropertiesAbridged;
	

    constructor() {
        super();
        this.type = "AperturePropertiesAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(AperturePropertiesAbridged, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.energy = obj.energy;
            this.radiance = obj.radiance;
        }
    }


    static override fromJS(data: any): AperturePropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new AperturePropertiesAbridged();
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

