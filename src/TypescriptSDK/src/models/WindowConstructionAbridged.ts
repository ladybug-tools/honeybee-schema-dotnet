import { IsArray, IsString, IsDefined, IsOptional, Matches, MinLength, MaxLength, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Construction for window objects (Aperture, Door). */
export class WindowConstructionAbridged extends IDdEnergyBaseModel {
    @IsArray()
    @IsString({ each: true })
    @IsDefined()
    @Expose({ name: "materials" })
    /** List of strings for glazing or gas material identifiers. The order of the materials is from exterior to interior. If a SimpleGlazSys material is used, it must be the only material in the construction. For multi-layered constructions, adjacent glass layers must be separated by one and only one gas layer. */
    materials!: string[];
	
    @IsString()
    @IsOptional()
    @Matches(/^WindowConstructionAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "WindowConstructionAbridged";
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "frame" })
    /** An optional identifier for a frame material that surrounds the window construction. */
    frame?: string;
	

    constructor() {
        super();
        this.type = "WindowConstructionAbridged";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(WindowConstructionAbridged, _data);
            this.materials = obj.materials;
            this.type = obj.type ?? "WindowConstructionAbridged";
            this.frame = obj.frame;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
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
        data["type"] = this.type ?? "WindowConstructionAbridged";
        data["frame"] = this.frame;
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
