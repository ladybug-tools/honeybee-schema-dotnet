import { IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { IDdRadianceBaseModel } from "./IDdRadianceBaseModel";

/** Base class for Radiance Modifiers */
export class ModifierBase extends IDdRadianceBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^ModifierBase$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ModifierBase";
	

    constructor() {
        super();
        this.type = "ModifierBase";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(ModifierBase, _data);
            this.type = obj.type ?? "ModifierBase";
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static override fromJS(data: any): ModifierBase {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ModifierBase();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "ModifierBase";
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
