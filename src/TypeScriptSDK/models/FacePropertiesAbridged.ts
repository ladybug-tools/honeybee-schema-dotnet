import { IsString, IsOptional, Matches, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { FaceEnergyPropertiesAbridged } from "./FaceEnergyPropertiesAbridged";
import { FaceRadiancePropertiesAbridged } from "./FaceRadiancePropertiesAbridged";

export class FacePropertiesAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^FacePropertiesAbridged$/)
    type?: string;
	
    @IsInstance(FaceEnergyPropertiesAbridged)
    @Type(() => FaceEnergyPropertiesAbridged)
    @ValidateNested()
    @IsOptional()
    energy?: FaceEnergyPropertiesAbridged;
	
    @IsInstance(FaceRadiancePropertiesAbridged)
    @Type(() => FaceRadiancePropertiesAbridged)
    @ValidateNested()
    @IsOptional()
    radiance?: FaceRadiancePropertiesAbridged;
	

    constructor() {
        super();
        this.type = "FacePropertiesAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(FacePropertiesAbridged, _data);
            this.type = obj.type;
            this.energy = obj.energy;
            this.radiance = obj.radiance;
        }
    }


    static override fromJS(data: any): FacePropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new FacePropertiesAbridged();
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
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || [error]).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
