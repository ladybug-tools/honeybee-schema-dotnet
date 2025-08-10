import { IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { BaseModifierSetAbridged } from "./BaseModifierSetAbridged";

/** Abridged set containing radiance modifiers needed for a model's Roofs. */
export class RoofCeilingModifierSetAbridged extends BaseModifierSetAbridged {
    @IsString()
    @IsOptional()
    @Matches(/^RoofCeilingModifierSetAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "RoofCeilingModifierSetAbridged";
	

    constructor() {
        super();
        this.type = "RoofCeilingModifierSetAbridged";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(RoofCeilingModifierSetAbridged, _data);
            this.type = obj.type ?? "RoofCeilingModifierSetAbridged";
            this.exteriorModifier = obj.exteriorModifier;
            this.interiorModifier = obj.interiorModifier;
        }
    }


    static override fromJS(data: any): RoofCeilingModifierSetAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new RoofCeilingModifierSetAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "RoofCeilingModifierSetAbridged";
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
