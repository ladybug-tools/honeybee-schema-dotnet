import { IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _FaceSubSetAbridged } from "./_FaceSubSetAbridged";

/** A set of constructions for wall assemblies. */
export class WallConstructionSetAbridged extends _FaceSubSetAbridged {
    @IsString()
    @IsOptional()
    @Matches(/^WallConstructionSetAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "WallConstructionSetAbridged";
	

    constructor() {
        super();
        this.type = "WallConstructionSetAbridged";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(WallConstructionSetAbridged, _data);
        }
    }


    static override fromJS(data: any): WallConstructionSetAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new WallConstructionSetAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "WallConstructionSetAbridged";
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
