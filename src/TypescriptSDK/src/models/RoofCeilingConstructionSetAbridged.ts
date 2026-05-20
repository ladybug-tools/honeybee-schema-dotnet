import { IsString, IsOptional, Equals, MinLength, MaxLength, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';

/** A set of constructions for roof and ceiling assemblies. */
export class RoofCeilingConstructionSetAbridged {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("RoofCeilingConstructionSetAbridged")
    @Expose({ name: "type" })
    /** type */
    type: string = "RoofCeilingConstructionSetAbridged";
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "interior_construction" })
    /** Identifier for an OpaqueConstruction for faces with a Surface or Adiabatic boundary condition. */
    interiorConstruction?: string;
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "exterior_construction" })
    /** Identifier for an OpaqueConstruction for faces with an Outdoors boundary condition. */
    exteriorConstruction?: string;
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "ground_construction" })
    /** Identifier for an OpaqueConstruction for faces with a Ground boundary condition. */
    groundConstruction?: string;
	

    constructor() {
        this.type = "RoofCeilingConstructionSetAbridged";
    }


    init(_data?: any) {

        if (_data) {
            const obj = deepTransform(RoofCeilingConstructionSetAbridged, _data);
            this.type = obj.type ?? "RoofCeilingConstructionSetAbridged";
            this.interiorConstruction = obj.interiorConstruction;
            this.exteriorConstruction = obj.exteriorConstruction;
            this.groundConstruction = obj.groundConstruction;
        }
    }


    static fromJS(data: any): RoofCeilingConstructionSetAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new RoofCeilingConstructionSetAbridged();
        result.init(data);
        return result;
    }

	toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "RoofCeilingConstructionSetAbridged";
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
