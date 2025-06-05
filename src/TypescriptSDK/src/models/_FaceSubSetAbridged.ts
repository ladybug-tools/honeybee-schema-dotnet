import { IsString, IsOptional, MinLength, MaxLength, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** A set of constructions for wall, floor, or roof assemblies. */
export class _FaceSubSetAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "interior_construction" })
    /** Identifier for an OpaqueConstruction for faces with a Surface or Adiabatic boundary condition. */
    interiorConstruction?: string;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "exterior_construction" })
    /** Identifier for an OpaqueConstruction for faces with an Outdoors boundary condition. */
    exteriorConstruction?: string;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "ground_construction" })
    /** Identifier for an OpaqueConstruction for faces with a Ground boundary condition. */
    groundConstruction?: string;
	
    @IsString()
    @IsOptional()
    @Matches(/^_FaceSubSetAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "_FaceSubSetAbridged";
	

    constructor() {
        super();
        this.type = "_FaceSubSetAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(_FaceSubSetAbridged, _data, { enableImplicitConversion: true });
            this.interiorConstruction = obj.interiorConstruction;
            this.exteriorConstruction = obj.exteriorConstruction;
            this.groundConstruction = obj.groundConstruction;
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): _FaceSubSetAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new _FaceSubSetAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["interior_construction"] = this.interiorConstruction;
        data["exterior_construction"] = this.exteriorConstruction;
        data["ground_construction"] = this.groundConstruction;
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
