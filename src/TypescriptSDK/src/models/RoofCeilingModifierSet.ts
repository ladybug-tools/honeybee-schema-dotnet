import { IsString, IsOptional, Equals, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { BaseModifierSet } from "./BaseModifierSet";

/** Set containing radiance modifiers needed for a model's roofs. */
export class RoofCeilingModifierSet extends BaseModifierSet {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("RoofCeilingModifierSet")
    @Expose({ name: "type" })
    /** type */
    type: string = "RoofCeilingModifierSet";
	

    constructor() {
        super();
        this.type = "RoofCeilingModifierSet";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(RoofCeilingModifierSet, _data);
            this.type = obj.type ?? "RoofCeilingModifierSet";
            this.exteriorModifier = obj.exteriorModifier;
            this.interiorModifier = obj.interiorModifier;
        }
    }


    static override fromJS(data: any): RoofCeilingModifierSet {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new RoofCeilingModifierSet();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "RoofCeilingModifierSet";
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
