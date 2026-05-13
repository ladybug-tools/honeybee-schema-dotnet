import { IsString, IsOptional, Equals, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _FaceSubSet } from "./_FaceSubSet";

/** A set of constructions for floor assemblies. */
export class FloorConstructionSet extends _FaceSubSet {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("FloorConstructionSet")
    @Expose({ name: "type" })
    /** type */
    type: string = "FloorConstructionSet";
	

    constructor() {
        super();
        this.type = "FloorConstructionSet";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(FloorConstructionSet, _data);
            this.type = obj.type ?? "FloorConstructionSet";
            this.interiorConstruction = obj.interiorConstruction;
            this.exteriorConstruction = obj.exteriorConstruction;
            this.groundConstruction = obj.groundConstruction;
        }
    }


    static override fromJS(data: any): FloorConstructionSet {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new FloorConstructionSet();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "FloorConstructionSet";
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
