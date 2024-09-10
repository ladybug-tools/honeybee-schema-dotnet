import { IsString, IsOptional, Matches, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { RoomDoe2Properties } from "./RoomDoe2Properties";
import { RoomEnergyPropertiesAbridged } from "./RoomEnergyPropertiesAbridged";
import { RoomRadiancePropertiesAbridged } from "./RoomRadiancePropertiesAbridged";

export class RoomPropertiesAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^RoomPropertiesAbridged$/)
    type?: string;
	
    @IsInstance(RoomEnergyPropertiesAbridged)
    @Type(() => RoomEnergyPropertiesAbridged)
    @ValidateNested()
    @IsOptional()
    energy?: RoomEnergyPropertiesAbridged;
	
    @IsInstance(RoomRadiancePropertiesAbridged)
    @Type(() => RoomRadiancePropertiesAbridged)
    @ValidateNested()
    @IsOptional()
    radiance?: RoomRadiancePropertiesAbridged;
	
    @IsInstance(RoomDoe2Properties)
    @Type(() => RoomDoe2Properties)
    @ValidateNested()
    @IsOptional()
    doe2?: RoomDoe2Properties;
	

    constructor() {
        super();
        this.type = "RoomPropertiesAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(RoomPropertiesAbridged, _data);
            this.type = obj.type;
            this.energy = obj.energy;
            this.radiance = obj.radiance;
            this.doe2 = obj.doe2;
        }
    }


    static override fromJS(data: any): RoomPropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new RoomPropertiesAbridged();
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
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || [error]).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
