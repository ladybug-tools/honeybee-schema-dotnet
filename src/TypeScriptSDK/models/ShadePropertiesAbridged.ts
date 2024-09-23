import { IsString, IsOptional, Matches, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { ShadeEnergyPropertiesAbridged } from "./ShadeEnergyPropertiesAbridged";
import { ShadeRadiancePropertiesAbridged } from "./ShadeRadiancePropertiesAbridged";

export class ShadePropertiesAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^ShadePropertiesAbridged$/)
    type?: string;
	
    @IsInstance(ShadeEnergyPropertiesAbridged)
    @Type(() => ShadeEnergyPropertiesAbridged)
    @ValidateNested()
    @IsOptional()
    energy?: ShadeEnergyPropertiesAbridged;
	
    @IsInstance(ShadeRadiancePropertiesAbridged)
    @Type(() => ShadeRadiancePropertiesAbridged)
    @ValidateNested()
    @IsOptional()
    radiance?: ShadeRadiancePropertiesAbridged;
	

    constructor() {
        super();
        this.type = "ShadePropertiesAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ShadePropertiesAbridged, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.energy = obj.energy;
            this.radiance = obj.radiance;
        }
    }


    static override fromJS(data: any): ShadePropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new ShadePropertiesAbridged();
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

