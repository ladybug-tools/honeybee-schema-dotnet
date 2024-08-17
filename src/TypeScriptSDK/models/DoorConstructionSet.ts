import { IsString, IsOptional, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { OpaqueConstruction } from "./OpaqueConstruction";
import { OpenAPIGenBaseModel } from "./OpenAPIGenBaseModel";
import { WindowConstruction } from "./WindowConstruction";
import { WindowConstructionDynamic } from "./WindowConstructionDynamic";
import { WindowConstructionShade } from "./WindowConstructionShade";

/** A set of constructions for door assemblies. */
export class DoorConstructionSet extends OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsInstance(OpaqueConstruction)
    @ValidateNested()
    @IsOptional()
    /** An OpaqueConstruction for all opaque doors with a Surface boundary condition. */
    interior_construction?: OpaqueConstruction;
	
    @IsInstance(OpaqueConstruction)
    @ValidateNested()
    @IsOptional()
    /** An OpaqueConstruction for opaque doors with an Outdoors boundary condition and a Wall face type for their parent face. */
    exterior_construction?: OpaqueConstruction;
	
    @IsInstance(OpaqueConstruction)
    @ValidateNested()
    @IsOptional()
    /** An OpaqueConstruction for opaque doors with an Outdoors boundary condition and a RoofCeiling or Floor type for their parent face. */
    overhead_construction?: OpaqueConstruction;
	
    @IsOptional()
    /** A WindowConstruction for all glass doors with an Outdoors boundary condition. */
    exterior_glass_construction?: (WindowConstruction | WindowConstructionShade | WindowConstructionDynamic);
	
    @IsOptional()
    /** A WindowConstruction for all glass doors with a Surface boundary condition. */
    interior_glass_construction?: (WindowConstruction | WindowConstructionShade | WindowConstructionDynamic);
	

    constructor() {
        super();
        this.type = "DoorConstructionSet";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "DoorConstructionSet";
            this.interior_construction = _data["interior_construction"];
            this.exterior_construction = _data["exterior_construction"];
            this.overhead_construction = _data["overhead_construction"];
            this.exterior_glass_construction = _data["exterior_glass_construction"];
            this.interior_glass_construction = _data["interior_glass_construction"];
        }
    }


    static override fromJS(data: any): DoorConstructionSet {
        data = typeof data === 'object' ? data : {};

        let result = new DoorConstructionSet();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["type"] = this.type;
        data["interior_construction"] = this.interior_construction;
        data["exterior_construction"] = this.exterior_construction;
        data["overhead_construction"] = this.overhead_construction;
        data["exterior_glass_construction"] = this.exterior_glass_construction;
        data["interior_glass_construction"] = this.interior_glass_construction;
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
