import { IsString, IsOptional, Equals, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { BaseModifierSet } from "./BaseModifierSet";

/** Set containing radiance modifiers needed for a model's Shade. */
export class ShadeModifierSet extends BaseModifierSet {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("ShadeModifierSet")
    @Expose({ name: "type" })
    /** type */
    type: string = "ShadeModifierSet";
	

    constructor() {
        super();
        this.type = "ShadeModifierSet";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(ShadeModifierSet, _data);
            this.type = obj.type ?? "ShadeModifierSet";
            this.exteriorModifier = obj.exteriorModifier;
            this.interiorModifier = obj.interiorModifier;
        }
    }


    static override fromJS(data: any): ShadeModifierSet {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ShadeModifierSet();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "ShadeModifierSet";
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
