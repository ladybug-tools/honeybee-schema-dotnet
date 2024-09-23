import { IsInstance, ValidateNested, IsOptional, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { OpaqueConstruction } from "./OpaqueConstruction";

/** A set of constructions for wall, floor, or roof assemblies. */
export class _FaceSubSet extends _OpenAPIGenBaseModel {
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
    @Matches(/^_FaceSubSet$/)
    type?: string;
	

    constructor() {
        super();
        this.type = "_FaceSubSet";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(_FaceSubSet, _data);
            this.interior_construction = obj.interior_construction;
            this.exterior_construction = obj.exterior_construction;
            this.ground_construction = obj.ground_construction;
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): _FaceSubSet {
        data = typeof data === 'object' ? data : {};

        let result = new _FaceSubSet();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["interior_construction"] = this.interior_construction;
        data["exterior_construction"] = this.exterior_construction;
        data["ground_construction"] = this.ground_construction;
        data["type"] = this.type;
        data = super.toJSON(data);
        return instanceToPlain(data);
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

