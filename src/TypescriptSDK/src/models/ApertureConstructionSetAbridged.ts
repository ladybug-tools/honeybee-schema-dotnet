import { IsString, IsOptional, Matches, MinLength, MaxLength, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** A set of constructions for aperture assemblies. */
export class ApertureConstructionSetAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^ApertureConstructionSetAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ApertureConstructionSetAbridged";
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "interior_construction" })
    /** Identifier for a WindowConstruction for all apertures with a Surface boundary condition. */
    interiorConstruction?: string;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "window_construction" })
    /** Identifier for a WindowConstruction for apertures with an Outdoors boundary condition, False is_operable property, and a Wall face type for their parent face. */
    windowConstruction?: string;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "skylight_construction" })
    /** Identifier for a WindowConstruction for apertures with a Outdoors boundary condition, False is_operable property, and a RoofCeiling or Floor face type for their parent face. */
    skylightConstruction?: string;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "operable_construction" })
    /** Identifier for a WindowConstruction for all apertures with an Outdoors boundary condition and True is_operable property. */
    operableConstruction?: string;
	

    constructor() {
        super();
        this.type = "ApertureConstructionSetAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ApertureConstructionSetAbridged, _data, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
            this.type = obj.type ?? "ApertureConstructionSetAbridged";
            this.interiorConstruction = obj.interiorConstruction;
            this.windowConstruction = obj.windowConstruction;
            this.skylightConstruction = obj.skylightConstruction;
            this.operableConstruction = obj.operableConstruction;
        }
    }


    static override fromJS(data: any): ApertureConstructionSetAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ApertureConstructionSetAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "ApertureConstructionSetAbridged";
        data["interior_construction"] = this.interiorConstruction;
        data["window_construction"] = this.windowConstruction;
        data["skylight_construction"] = this.skylightConstruction;
        data["operable_construction"] = this.operableConstruction;
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
