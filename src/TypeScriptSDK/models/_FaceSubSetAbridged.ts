import { IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { FloorConstructionSetAbridged } from "./FloorConstructionSetAbridged";
import { RoofCeilingConstructionSetAbridged } from "./RoofCeilingConstructionSetAbridged";
import { WallConstructionSetAbridged } from "./WallConstructionSetAbridged";

/** A set of constructions for wall, floor, or roof assemblies. */
export class _FaceSubSetAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    /** Identifier for an OpaqueConstruction for faces with a Surface or Adiabatic boundary condition. */
    interior_construction?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier for an OpaqueConstruction for faces with an Outdoors boundary condition. */
    exterior_construction?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier for an OpaqueConstruction for faces with a Ground boundary condition. */
    ground_construction?: string;
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.type = "_FaceSubSetAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.interior_construction = _data["interior_construction"];
            this.exterior_construction = _data["exterior_construction"];
            this.ground_construction = _data["ground_construction"];
            this.type = _data["type"] !== undefined ? _data["type"] : "_FaceSubSetAbridged";
        }
    }


    static override fromJS(data: any): _FaceSubSetAbridged {
        data = typeof data === 'object' ? data : {};

        if (data["type"] === "WallConstructionSetAbridged") {
            let result = new WallConstructionSetAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "FloorConstructionSetAbridged") {
            let result = new FloorConstructionSetAbridged();
            result.init(data);
            return result;
        }
        if (data["type"] === "RoofCeilingConstructionSetAbridged") {
            let result = new RoofCeilingConstructionSetAbridged();
            result.init(data);
            return result;
        }
        let result = new _FaceSubSetAbridged();
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
