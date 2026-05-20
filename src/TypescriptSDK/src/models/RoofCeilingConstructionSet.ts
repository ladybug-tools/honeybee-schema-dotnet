import { IsString, IsOptional, Equals, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { OpaqueConstruction } from "./OpaqueConstruction";

/** A set of constructions for roof and ceiling assemblies. */
export class RoofCeilingConstructionSet {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("RoofCeilingConstructionSet")
    @Expose({ name: "type" })
    /** type */
    type: string = "RoofCeilingConstructionSet";
	
    @Type(() => OpaqueConstruction)
    @IsInstance(OpaqueConstruction)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "interior_construction" })
    /** An OpaqueConstruction for walls with a Surface or Adiabatic boundary condition. */
    interiorConstruction?: OpaqueConstruction;
	
    @Type(() => OpaqueConstruction)
    @IsInstance(OpaqueConstruction)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "exterior_construction" })
    /** An OpaqueConstruction for walls with an Outdoors boundary condition. */
    exteriorConstruction?: OpaqueConstruction;
	
    @Type(() => OpaqueConstruction)
    @IsInstance(OpaqueConstruction)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "ground_construction" })
    /** An OpaqueConstruction for walls with a Ground boundary condition. */
    groundConstruction?: OpaqueConstruction;
	

    constructor() {
        this.type = "RoofCeilingConstructionSet";
    }


    init(_data?: any) {

        if (_data) {
            const obj = deepTransform(RoofCeilingConstructionSet, _data);
            this.type = obj.type ?? "RoofCeilingConstructionSet";
            this.interiorConstruction = obj.interiorConstruction;
            this.exteriorConstruction = obj.exteriorConstruction;
            this.groundConstruction = obj.groundConstruction;
        }
    }


    static fromJS(data: any): RoofCeilingConstructionSet {
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

	toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "RoofCeilingConstructionSet";
        data["interior_construction"] = this.interiorConstruction;
        data["exterior_construction"] = this.exteriorConstruction;
        data["ground_construction"] = this.groundConstruction;
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
