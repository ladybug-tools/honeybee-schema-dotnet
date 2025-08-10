import { IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { BaseModifierSetAbridged } from "./BaseModifierSetAbridged";

/** Abridged set containing radiance modifiers needed for a model's Walls. */
export class WallModifierSetAbridged extends BaseModifierSetAbridged {
    @IsString()
    @IsOptional()
    @Matches(/^WallModifierSetAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "WallModifierSetAbridged";
	

    constructor() {
        super();
        this.type = "WallModifierSetAbridged";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(WallModifierSetAbridged, _data);
            this.type = obj.type ?? "WallModifierSetAbridged";
            this.exteriorModifier = obj.exteriorModifier;
            this.interiorModifier = obj.interiorModifier;
        }
    }


    static override fromJS(data: any): WallModifierSetAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new WallModifierSetAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "WallModifierSetAbridged";
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
