import { IsString, IsOptional, Equals, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { BaseModifierSet } from "./BaseModifierSet";

/** Set containing radiance modifiers needed for a model's Floors. */
export class FloorModifierSet extends BaseModifierSet {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("FloorModifierSet")
    @Expose({ name: "type" })
    /** type */
    type: string = "FloorModifierSet";
	

    constructor() {
        super();
        this.type = "FloorModifierSet";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(FloorModifierSet, _data);
            this.type = obj.type ?? "FloorModifierSet";
            this.exteriorModifier = obj.exteriorModifier;
            this.interiorModifier = obj.interiorModifier;
        }
    }


    static override fromJS(data: any): FloorModifierSet {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new FloorModifierSet();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "FloorModifierSet";
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
