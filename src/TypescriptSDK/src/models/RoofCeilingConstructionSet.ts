import { IsString, IsOptional, Equals, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _FaceSubSet } from "./_FaceSubSet";

/** A set of constructions for roof and ceiling assemblies. */
export class RoofCeilingConstructionSet extends _FaceSubSet {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("RoofCeilingConstructionSet")
    @Expose({ name: "type" })
    /** type */
    type: string = "RoofCeilingConstructionSet";
	

    constructor() {
        super();
        this.type = "RoofCeilingConstructionSet";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(RoofCeilingConstructionSet, _data);
            this.type = obj.type ?? "RoofCeilingConstructionSet";
            this.interiorConstruction = obj.interiorConstruction;
            this.exteriorConstruction = obj.exteriorConstruction;
            this.groundConstruction = obj.groundConstruction;
        }
    }


    static override fromJS(data: any): RoofCeilingConstructionSet {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new RoofCeilingConstructionSet();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "RoofCeilingConstructionSet";
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
