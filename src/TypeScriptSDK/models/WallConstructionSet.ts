import { IsInstance, ValidateNested, IsOptional, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { OpaqueConstruction } from "./OpaqueConstruction";

/** A set of constructions for wall assemblies. */
export class WallConstructionSet extends _OpenAPIGenBaseModel {
    @IsInstance(OpaqueConstruction)
    @Type(() => OpaqueConstruction)
    @ValidateNested()
    @IsOptional()
    /** An OpaqueConstruction for walls with a Surface or Adiabatic boundary condition. */
    interior_construction?: OpaqueConstruction;
	
    @IsInstance(OpaqueConstruction)
    @Type(() => OpaqueConstruction)
    @ValidateNested()
    @IsOptional()
    /** An OpaqueConstruction for walls with an Outdoors boundary condition. */
    exterior_construction?: OpaqueConstruction;
	
    @IsInstance(OpaqueConstruction)
    @Type(() => OpaqueConstruction)
    @ValidateNested()
    @IsOptional()
    /** An OpaqueConstruction for walls with a Ground boundary condition. */
    ground_construction?: OpaqueConstruction;
	
    @IsString()
    @IsOptional()
    @Matches(/^WallConstructionSet$/)
    type?: string;
	

    constructor() {
        super();
        this.type = "WallConstructionSet";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(WallConstructionSet, _data);
            this.interior_construction = obj.interior_construction;
            this.exterior_construction = obj.exterior_construction;
            this.ground_construction = obj.ground_construction;
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): WallConstructionSet {
        data = typeof data === 'object' ? data : {};

        let result = new WallConstructionSet();
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
        data = super.toJSON(data);
        return data;
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
