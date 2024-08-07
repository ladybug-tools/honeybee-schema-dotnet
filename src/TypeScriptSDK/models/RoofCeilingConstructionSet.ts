import { IsInstance, ValidateNested, IsOptional, IsString, validate, ValidationError as TsValidationError } from 'class-validator';
import { OpaqueConstruction } from "./OpaqueConstruction";
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** A set of constructions for roof and ceiling assemblies. */
export class RoofCeilingConstructionSet extends _OpenAPIGenBaseModel {
    @IsInstance(OpaqueConstruction)
    @ValidateNested()
    @IsOptional()
    /** An OpaqueConstruction for walls with a Surface or Adiabatic boundary condition. */
    interior_construction?: OpaqueConstruction;
	
    @IsInstance(OpaqueConstruction)
    @ValidateNested()
    @IsOptional()
    /** An OpaqueConstruction for walls with an Outdoors boundary condition. */
    exterior_construction?: OpaqueConstruction;
	
    @IsInstance(OpaqueConstruction)
    @ValidateNested()
    @IsOptional()
    /** An OpaqueConstruction for walls with a Ground boundary condition. */
    ground_construction?: OpaqueConstruction;
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.type = "RoofCeilingConstructionSet";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.interior_construction = _data["interior_construction"];
            this.exterior_construction = _data["exterior_construction"];
            this.ground_construction = _data["ground_construction"];
            this.type = _data["type"] !== undefined ? _data["type"] : "RoofCeilingConstructionSet";
        }
    }


    static override fromJS(data: any): RoofCeilingConstructionSet {
        data = typeof data === 'object' ? data : {};

        let result = new RoofCeilingConstructionSet();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["interior_construction"] = this.interior_construction;
        data["exterior_construction"] = this.exterior_construction;
        data["ground_construction"] = this.ground_construction;
        data["type"] = this.type;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
