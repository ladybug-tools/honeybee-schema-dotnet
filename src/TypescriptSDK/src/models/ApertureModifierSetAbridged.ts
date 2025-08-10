import { IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Abridged set containing radiance modifiers needed for a model's Apertures. */
export class ApertureModifierSetAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^ApertureModifierSetAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ApertureModifierSetAbridged";
	
    @IsString()
    @IsOptional()
    @Expose({ name: "window_modifier" })
    /** Identifier of modifier object for apertures with an Outdoors boundary condition, False is_operable property, and Wall parent Face. */
    windowModifier?: string;
	
    @IsString()
    @IsOptional()
    @Expose({ name: "interior_modifier" })
    /** Identifier of modifier object for apertures with a Surface boundary condition. */
    interiorModifier?: string;
	
    @IsString()
    @IsOptional()
    @Expose({ name: "skylight_modifier" })
    /** Identifier of modifier object for apertures with an Outdoors boundary condition, False is_operable property, and a RoofCeiling or Floor face type for their parent face. */
    skylightModifier?: string;
	
    @IsString()
    @IsOptional()
    @Expose({ name: "operable_modifier" })
    /** Identifier of modifier object for apertures with an Outdoors boundary condition and a True is_operable property. */
    operableModifier?: string;
	

    constructor() {
        super();
        this.type = "ApertureModifierSetAbridged";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(ApertureModifierSetAbridged, _data);
        }
    }


    static override fromJS(data: any): ApertureModifierSetAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ApertureModifierSetAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "ApertureModifierSetAbridged";
        data["window_modifier"] = this.windowModifier;
        data["interior_modifier"] = this.interiorModifier;
        data["skylight_modifier"] = this.skylightModifier;
        data["operable_modifier"] = this.operableModifier;
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
