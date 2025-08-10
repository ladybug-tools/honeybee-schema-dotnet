import { IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _PropertiesBaseAbridged } from "./_PropertiesBaseAbridged";

/** Radiance Properties for Honeybee ShadeMesh Abridged. */
export class ShadeMeshRadiancePropertiesAbridged extends _PropertiesBaseAbridged {
    @IsString()
    @IsOptional()
    @Matches(/^ShadeMeshRadiancePropertiesAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ShadeMeshRadiancePropertiesAbridged";
	

    constructor() {
        super();
        this.type = "ShadeMeshRadiancePropertiesAbridged";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(ShadeMeshRadiancePropertiesAbridged, _data);
            this.type = obj.type ?? "ShadeMeshRadiancePropertiesAbridged";
            this.modifier = obj.modifier;
            this.modifierBlk = obj.modifierBlk;
        }
    }


    static override fromJS(data: any): ShadeMeshRadiancePropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ShadeMeshRadiancePropertiesAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "ShadeMeshRadiancePropertiesAbridged";
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
