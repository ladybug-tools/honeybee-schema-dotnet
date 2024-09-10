import { IsArray, IsString, IsDefined, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Construction for opaque objects (Face, Shade, Door). */
export class OpaqueConstructionAbridged extends IDdEnergyBaseModel {
    @IsArray()
    @IsString({ each: true })
    @IsDefined()
    /** List of strings for opaque material identifiers. The order of the materials is from exterior to interior. */
    materials!: string [];
	
    @IsString()
    @IsOptional()
    @Matches(/^OpaqueConstructionAbridged$/)
    type?: string;
	

    constructor() {
        super();
        this.type = "OpaqueConstructionAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(OpaqueConstructionAbridged, _data);
            this.materials = obj.materials;
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): OpaqueConstructionAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new OpaqueConstructionAbridged();
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
        super.toJSON(data);
        return data;
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
