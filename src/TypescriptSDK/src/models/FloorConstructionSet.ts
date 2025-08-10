import { IsInstance, ValidateNested, IsOptional, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { OpaqueConstruction } from "./OpaqueConstruction";

/** A set of constructions for floor assemblies. */
export class FloorConstructionSet extends _OpenAPIGenBaseModel {
    @IsInstance(OpaqueConstruction)
    @Type(() => OpaqueConstruction)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "interior_construction" })
    /** An OpaqueConstruction for walls with a Surface or Adiabatic boundary condition. */
    interiorConstruction?: OpaqueConstruction;
	
    @IsInstance(OpaqueConstruction)
    @Type(() => OpaqueConstruction)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "exterior_construction" })
    /** An OpaqueConstruction for walls with an Outdoors boundary condition. */
    exteriorConstruction?: OpaqueConstruction;
	
    @IsInstance(OpaqueConstruction)
    @Type(() => OpaqueConstruction)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "ground_construction" })
    /** An OpaqueConstruction for walls with a Ground boundary condition. */
    groundConstruction?: OpaqueConstruction;
	
    @IsString()
    @IsOptional()
    @Matches(/^FloorConstructionSet$/)
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
            this.interiorConstruction = obj.interiorConstruction;
            this.exteriorConstruction = obj.exteriorConstruction;
            this.groundConstruction = obj.groundConstruction;
            this.type = obj.type ?? "FloorConstructionSet";
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
        data["interior_construction"] = this.interiorConstruction;
        data["exterior_construction"] = this.exteriorConstruction;
        data["ground_construction"] = this.groundConstruction;
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
