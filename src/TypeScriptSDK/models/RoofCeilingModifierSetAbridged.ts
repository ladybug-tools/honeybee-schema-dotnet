import { IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { BaseModifierSetAbridged } from "./BaseModifierSetAbridged";

/** Abridged set containing radiance modifiers needed for a model's Roofs. */
export class RoofCeilingModifierSetAbridged extends BaseModifierSetAbridged {
    @IsString()
    @IsOptional()
    @Matches(/^RoofCeilingModifierSetAbridged$/)
    type?: string;
	

    constructor() {
        super();
        this.type = "RoofCeilingModifierSetAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(RoofCeilingModifierSetAbridged, _data);
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): RoofCeilingModifierSetAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new RoofCeilingModifierSetAbridged();
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

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || [error.property]).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
