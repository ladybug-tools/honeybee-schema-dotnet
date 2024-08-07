import { IsArray, ValidateNested, IsDefined, IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Construction for window objects (Aperture, Door). */
export class WindowConstructionAbridged extends IDdEnergyBaseModel {
    @IsArray()
    @ValidateNested({ each: true })
    @IsDefined()
    /** List of strings for glazing or gas material identifiers. The order of the materials is from exterior to interior. If a SimpleGlazSys material is used, it must be the only material in the construction. For multi-layered constructions, adjacent glass layers must be separated by one and only one gas layer. */
    materials!: string [];
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsString()
    @IsOptional()
    /** An optional identifier for a frame material that surrounds the window construction. */
    frame?: string;
	

    constructor() {
        super();
        this.type = "WindowConstructionAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.materials = _data["materials"];
            this.type = _data["type"] !== undefined ? _data["type"] : "WindowConstructionAbridged";
            this.frame = _data["frame"];
        }
    }


    static override fromJS(data: any): WindowConstructionAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new WindowConstructionAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["materials"] = this.materials;
        data["type"] = this.type;
        data["frame"] = this.frame;
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
