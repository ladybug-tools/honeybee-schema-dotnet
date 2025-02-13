import { IsArray, IsString, IsDefined, IsOptional, Matches, MinLength, MaxLength, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Construction for window objects (Aperture, Door). */
export class WindowConstructionAbridged extends IDdEnergyBaseModel {
    @IsArray()
    @IsString({ each: true })
    @IsDefined()
    /** List of strings for glazing or gas material identifiers. The order of the materials is from exterior to interior. If a SimpleGlazSys material is used, it must be the only material in the construction. For multi-layered constructions, adjacent glass layers must be separated by one and only one gas layer. */
    materials!: string [];
	
    @IsString()
    @IsOptional()
    @Matches(/^WindowConstructionAbridged$/)
    /** Type */
    type?: string;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    /** An optional identifier for a frame material that surrounds the window construction. */
    frame?: string;
	

    constructor() {
        super();
        this.type = "WindowConstructionAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(WindowConstructionAbridged, _data, { enableImplicitConversion: true });
            this.materials = obj.materials;
            this.type = obj.type;
            this.frame = obj.frame;
        }
    }


    static override fromJS(data: any): WindowConstructionAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new WindowConstructionAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["materials"] = this.materials;
        data["type"] = this.type;
        data["frame"] = this.frame;
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

