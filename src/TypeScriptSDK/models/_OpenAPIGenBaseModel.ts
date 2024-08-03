import { IsString, IsOptional, validate, ValidationError } from 'class-validator';
import { Autocalculate } from "./Autocalculate";
import { Location } from "./Location";
import { ProjectInfo } from "./ProjectInfo";

export abstract class _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    /** A base class to use when there is no baseclass available to fall on. */
    type?: string;
	

    constructor() {
        this.type = "InvalidType";
    }


    init(_data?: any) {
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "InvalidType";
        }
    }


    static fromJS(data: any): _OpenAPIGenBaseModel {
        data = typeof data === 'object' ? data : {};

        if (data["type"] === "Autocalculate") {
            let result = new Autocalculate();
            result.init(data);
            return result;
        }
        if (data["type"] === "Location") {
            let result = new Location();
            result.init(data);
            return result;
        }
        if (data["type"] === "ProjectInfo") {
            let result = new ProjectInfo();
            result.init(data);
            return result;
        }
        throw new Error("The abstract class '_OpenAPIGenBaseModel' cannot be instantiated.");
    }

	toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["type"] = this.type;
        return data;
    }

}
