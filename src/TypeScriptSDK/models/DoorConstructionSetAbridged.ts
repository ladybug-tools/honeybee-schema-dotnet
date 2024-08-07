import { IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** A set of constructions for door assemblies. */
export class DoorConstructionSetAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier for an OpaqueConstruction for all opaque doors with a Surface boundary condition. */
    interior_construction?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier for an OpaqueConstruction for opaque doors with an Outdoors boundary condition and a Wall face type for their parent face. */
    exterior_construction?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier for an OpaqueConstruction for opaque doors with an Outdoors boundary condition and a RoofCeiling or Floor type for their parent face. */
    overhead_construction?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier for a WindowConstruction for all glass doors with an Outdoors boundary condition. */
    exterior_glass_construction?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier for a WindowConstruction for all glass doors with a Surface boundary condition. */
    interior_glass_construction?: string;
	

    constructor() {
        super();
        this.type = "DoorConstructionSetAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "DoorConstructionSetAbridged";
            this.interior_construction = _data["interior_construction"];
            this.exterior_construction = _data["exterior_construction"];
            this.overhead_construction = _data["overhead_construction"];
            this.exterior_glass_construction = _data["exterior_glass_construction"];
            this.interior_glass_construction = _data["interior_glass_construction"];
        }
    }


    static override fromJS(data: any): DoorConstructionSetAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new DoorConstructionSetAbridged();
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
