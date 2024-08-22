import { IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { ApertureRadiancePropertiesAbridged } from "./ApertureRadiancePropertiesAbridged";
import { DoorRadiancePropertiesAbridged } from "./DoorRadiancePropertiesAbridged";
import { FaceRadiancePropertiesAbridged } from "./FaceRadiancePropertiesAbridged";
import { ShadeMeshRadiancePropertiesAbridged } from "./ShadeMeshRadiancePropertiesAbridged";
import { ShadeRadiancePropertiesAbridged } from "./ShadeRadiancePropertiesAbridged";

/** Base class of Abridged Radiance Properties. */
export class _PropertiesBaseAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    /** A string for a Honeybee Radiance Modifier (default: None). */
    modifier?: string;
	
    @IsString()
    @IsOptional()
    /** A string for a Honeybee Radiance Modifier to be used in direct solar simulations and in isolation studies (assessingthe contribution of individual objects) (default: None). */
    modifier_blk?: string;
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.type = "_PropertiesBaseAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.modifier = _data["modifier"];
            this.modifier_blk = _data["modifier_blk"];
            this.type = _data["type"] !== undefined ? _data["type"] : "_PropertiesBaseAbridged";
        }
    }


    static override fromJS(data: any): _PropertiesBaseAbridged {
        data = typeof data === 'object' ? data : {};

        if (data["type"] === "ShadeMeshRadiancePropertiesAbridged") {
            let result = new ShadeMeshRadiancePropertiesAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "ApertureRadiancePropertiesAbridged") {
            let result = new ApertureRadiancePropertiesAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "DoorRadiancePropertiesAbridged") {
            let result = new DoorRadiancePropertiesAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "ShadeRadiancePropertiesAbridged") {
            let result = new ShadeRadiancePropertiesAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "FaceRadiancePropertiesAbridged") {
            let result = new FaceRadiancePropertiesAbridged();
            result.init(data);
            return result;
        }
        let result = new _PropertiesBaseAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["modifier"] = this.modifier;
        data["modifier_blk"] = this.modifier_blk;
        data["type"] = this.type;
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
