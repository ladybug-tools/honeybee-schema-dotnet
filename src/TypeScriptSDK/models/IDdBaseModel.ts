import { IsString, IsDefined, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { Aperture } from "./Aperture";
import { Door } from "./Door";
import { Face } from "./Face";
import { Model } from "./Model";
import { Room } from "./Room";
import { Shade } from "./Shade";
import { ShadeMesh } from "./ShadeMesh";

/** Base class for all objects requiring a identifiers acceptable for all engines. */
export class IDdBaseModel extends _OpenAPIGenBaseModel {
    @IsString()
    @IsDefined()
    /** Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, rad). This identifier is also used to reference the object across a Model. It must be < 100 characters and not contain any spaces or special characters. */
    identifier!: string;
	
    @IsString()
    @IsOptional()
    /** Display name of the object with no character restrictions. */
    display_name?: string;
	
    @IsOptional()
    /** Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). */
    user_data?: Object;
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.type = "IDdBaseModel";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.identifier = _data["identifier"];
            this.display_name = _data["display_name"];
            this.user_data = _data["user_data"];
            this.type = _data["type"] !== undefined ? _data["type"] : "IDdBaseModel";
        }
    }


    static override fromJS(data: any): IDdBaseModel {
        data = typeof data === 'object' ? data : {};

        if (data["type"] === "Shade") {
            let result = new Shade();
            result.init(data);
            return result;
        }
        if (data["type"] === "Aperture") {
            let result = new Aperture();
            result.init(data);
            return result;
        }
        if (data["type"] === "Door") {
            let result = new Door();
            result.init(data);
            return result;
        }
        if (data["type"] === "Face") {
            let result = new Face();
            result.init(data);
            return result;
        }
        if (data["type"] === "Room") {
            let result = new Room();
            result.init(data);
            return result;
        }
        if (data["type"] === "ShadeMesh") {
            let result = new ShadeMesh();
            result.init(data);
            return result;
        }
        if (data["type"] === "Model") {
            let result = new Model();
            result.init(data);
            return result;
        }
        let result = new IDdBaseModel();
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
        data["user_data"] = this.user_data;
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
