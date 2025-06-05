import { IsString, IsOptional, Matches, MinLength, MaxLength, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** A set of constructions for door assemblies. */
export class DoorConstructionSetAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^DoorConstructionSetAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "DoorConstructionSetAbridged";
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "interior_construction" })
    /** Identifier for an OpaqueConstruction for all opaque doors with a Surface boundary condition. */
    interiorConstruction?: string;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "exterior_construction" })
    /** Identifier for an OpaqueConstruction for opaque doors with an Outdoors boundary condition and a Wall face type for their parent face. */
    exteriorConstruction?: string;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "overhead_construction" })
    /** Identifier for an OpaqueConstruction for opaque doors with an Outdoors boundary condition and a RoofCeiling or Floor type for their parent face. */
    overheadConstruction?: string;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "exterior_glass_construction" })
    /** Identifier for a WindowConstruction for all glass doors with an Outdoors boundary condition. */
    exteriorGlassConstruction?: string;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "interior_glass_construction" })
    /** Identifier for a WindowConstruction for all glass doors with a Surface boundary condition. */
    interiorGlassConstruction?: string;
	

    constructor() {
        super();
        this.type = "DoorConstructionSetAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(DoorConstructionSetAbridged, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.type = obj.type ?? "DoorConstructionSetAbridged";
            this.interiorConstruction = obj.interiorConstruction;
            this.exteriorConstruction = obj.exteriorConstruction;
            this.overheadConstruction = obj.overheadConstruction;
            this.exteriorGlassConstruction = obj.exteriorGlassConstruction;
            this.interiorGlassConstruction = obj.interiorGlassConstruction;
        }
    }


    static override fromJS(data: any): DoorConstructionSetAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new DoorConstructionSetAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "DoorConstructionSetAbridged";
        data["interior_construction"] = this.interiorConstruction;
        data["exterior_construction"] = this.exteriorConstruction;
        data["overhead_construction"] = this.overheadConstruction;
        data["exterior_glass_construction"] = this.exteriorGlassConstruction;
        data["interior_glass_construction"] = this.interiorGlassConstruction;
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
