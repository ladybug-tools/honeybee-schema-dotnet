import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for all objects that are not extensible with additional keys.

This effectively includes all objects except for the Properties classes
that are assigned to geometry objects. */
export class Autocalculate extends _OpenAPIGenBaseModel {
    type?: string;

    constructor() {
        super();
        this.type = "Autocalculate";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "Autocalculate";
        }
    }


    static override fromJS(data: any): Autocalculate {
        data = typeof data === 'object' ? data : {};


        let result = new Autocalculate();
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
        super.toJSON(data);
        return data;
    }
}
