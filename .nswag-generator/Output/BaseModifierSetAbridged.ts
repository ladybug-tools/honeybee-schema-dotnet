import { IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { WallModifierSetAbridged } from "./WallModifierSetAbridged";
import { FloorModifierSetAbridged } from "./FloorModifierSetAbridged";
import { RoofCeilingModifierSetAbridged } from "./RoofCeilingModifierSetAbridged";
import { DoorModifierSetAbridged } from "./DoorModifierSetAbridged";
import { ShadeModifierSetAbridged } from "./ShadeModifierSetAbridged";

/** Base class for the abridged modifier sets assigned to Faces. */
export class BaseModifierSetAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    /** Identifier for a radiance modifier object for faces with an  Outdoors boundary condition. */
    exterior_modifier?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier for a radiance modifier object for faces with a boundary condition other than Outdoors. */
    interior_modifier?: string;
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.type = "BaseModifierSetAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.exterior_modifier = _data["exterior_modifier"];
            this.interior_modifier = _data["interior_modifier"];
            this.type = _data["type"] !== undefined ? _data["type"] : "BaseModifierSetAbridged";
        }
    }


    static override fromJS(data: any): BaseModifierSetAbridged {
        data = typeof data === 'object' ? data : {};

        if (data["type"] === "WallModifierSetAbridged") {
            let result = new WallModifierSetAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "FloorModifierSetAbridged") {
            let result = new FloorModifierSetAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "RoofCeilingModifierSetAbridged") {
            let result = new RoofCeilingModifierSetAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "DoorModifierSetAbridged") {
            let result = new DoorModifierSetAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "ShadeModifierSetAbridged") {
            let result = new ShadeModifierSetAbridged();
            result.init(data);
            return result;
        }
        let result = new BaseModifierSetAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["exterior_modifier"] = this.exterior_modifier;
        data["interior_modifier"] = this.interior_modifier;
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
