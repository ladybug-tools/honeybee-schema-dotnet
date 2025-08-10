import { IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _FaceSubSetAbridged } from "./_FaceSubSetAbridged";

/** A set of constructions for floor assemblies. */
export class FloorConstructionSetAbridged extends _FaceSubSetAbridged {
    @IsString()
    @IsOptional()
    @Matches(/^FloorConstructionSetAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "FloorConstructionSetAbridged";
	

    constructor() {
        super();
        this.type = "FloorConstructionSetAbridged";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(FloorConstructionSetAbridged, _data);
            this.type = obj.type ?? "FloorConstructionSetAbridged";
            this.interiorConstruction = obj.interiorConstruction;
            this.exteriorConstruction = obj.exteriorConstruction;
            this.groundConstruction = obj.groundConstruction;
        }
    }


    static override fromJS(data: any): FloorConstructionSetAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new FloorConstructionSetAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "FloorConstructionSetAbridged";
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
