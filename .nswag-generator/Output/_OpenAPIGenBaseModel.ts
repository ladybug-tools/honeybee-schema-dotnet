
export abstract class _OpenAPIGenBaseModel {
    /** A base class to use when there is no baseclass available to fall on. */
    type!: string;

    static fromJS(data: any): _OpenAPIGenBaseModel {
        data = typeof data === 'object' ? data : {};

        if (data[""] === "type") {

            let result = new Autocalculate();
            result.init(data);
            return result;
        }
        if (data[""] === "type") {

            let result = new Location();
            result.init(data);
            return result;
        }
        if (data[""] === "type") {

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
