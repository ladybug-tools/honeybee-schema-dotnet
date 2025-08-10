import { IsString, IsOptional, Matches, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { RoomDoe2Properties } from "./RoomDoe2Properties";
import { RoomEnergyPropertiesAbridged } from "./RoomEnergyPropertiesAbridged";
import { RoomRadiancePropertiesAbridged } from "./RoomRadiancePropertiesAbridged";

export class RoomPropertiesAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^RoomPropertiesAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "RoomPropertiesAbridged";
	
    @IsInstance(RoomEnergyPropertiesAbridged)
    @Type(() => RoomEnergyPropertiesAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "energy" })
    /** energy */
    energy?: RoomEnergyPropertiesAbridged;
	
    @IsInstance(RoomRadiancePropertiesAbridged)
    @Type(() => RoomRadiancePropertiesAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "radiance" })
    /** radiance */
    radiance?: RoomRadiancePropertiesAbridged;
	
    @IsInstance(RoomDoe2Properties)
    @Type(() => RoomDoe2Properties)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "doe2" })
    /** doe2 */
    doe2?: RoomDoe2Properties;
	

    constructor() {
        super();
        this.type = "RoomPropertiesAbridged";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(RoomPropertiesAbridged, _data);
            this.type = obj.type ?? "RoomPropertiesAbridged";
            this.energy = obj.energy;
            this.radiance = obj.radiance;
            this.doe2 = obj.doe2;
        }
    }


    static override fromJS(data: any): RoomPropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new RoomPropertiesAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "RoomPropertiesAbridged";
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
