import { IsString, IsDefined, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { Mirror } from "./Mirror";
import { ModifierBase } from "./ModifierBase";
import { Plastic } from "./Plastic";
import { Glass } from "./Glass";
import { BSDF } from "./BSDF";
import { Glow } from "./Glow";
import { Light } from "./Light";
import { Trans } from "./Trans";
import { Metal } from "./Metal";
import { StateGeometryAbridged } from "./StateGeometryAbridged";
import { ModifierSetAbridged } from "./ModifierSetAbridged";
import { ModifierSet } from "./ModifierSet";
import { SensorGrid } from "./SensorGrid";
import { _RadianceAsset } from "./_RadianceAsset";
import { View } from "./View";

/** Base class for all objects requiring a valid Radiance identifier. */
export class IDdRadianceBaseModel extends _OpenAPIGenBaseModel {
    @IsString()
    @IsDefined()
    /** Text string for a unique Radiance object. Must not contain spaces or special characters. This will be used to identify the object across a model and in the exported Radiance files. */
    identifier!: string;
	
    @IsString()
    @IsOptional()
    /** Display name of the object with no character restrictions. */
    display_name?: string;
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.type = "IDdRadianceBaseModel";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.identifier = _data["identifier"];
            this.display_name = _data["display_name"];
            this.type = _data["type"] !== undefined ? _data["type"] : "IDdRadianceBaseModel";
        }
    }


    static override fromJS(data: any): IDdRadianceBaseModel {
        data = typeof data === 'object' ? data : {};

        if (data["type"] === "Mirror") {
            let result = new Mirror();
            result.init(data);
            return result;
        }
        if (data["type"] === "ModifierBase") {
            let result = new ModifierBase();
            result.init(data);
            return result;
        }
        if (data["type"] === "Plastic") {
            let result = new Plastic();
            result.init(data);
            return result;
        }
        if (data["type"] === "Glass") {
            let result = new Glass();
            result.init(data);
            return result;
        }
        if (data["type"] === "BSDF") {
            let result = new BSDF();
            result.init(data);
            return result;
        }
        if (data["type"] === "Glow") {
            let result = new Glow();
            result.init(data);
            return result;
        }
        if (data["type"] === "Light") {
            let result = new Light();
            result.init(data);
            return result;
        }
        if (data["type"] === "Trans") {
            let result = new Trans();
            result.init(data);
            return result;
        }
        if (data["type"] === "Metal") {
            let result = new Metal();
            result.init(data);
            return result;
        }
        if (data["type"] === "StateGeometryAbridged") {
            let result = new StateGeometryAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "ModifierSetAbridged") {
            let result = new ModifierSetAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "ModifierSet") {
            let result = new ModifierSet();
            result.init(data);
            return result;
        }
        if (data["type"] === "SensorGrid") {
            let result = new SensorGrid();
            result.init(data);
            return result;
        }
        if (data["type"] === "_RadianceAsset") {
            let result = new _RadianceAsset();
            result.init(data);
            return result;
        }
        if (data["type"] === "View") {
            let result = new View();
            result.init(data);
            return result;
        }
        let result = new IDdRadianceBaseModel();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["identifier"] = this.identifier;
        data["display_name"] = this.display_name;
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
