import { IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Abridged set containing radiance modifiers needed for a model's Apertures. */
export class ApertureModifierSetAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier of modifier object for apertures with an Outdoors boundary condition, False is_operable property, and Wall parent Face. */
    window_modifier?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier of modifier object for apertures with a Surface boundary condition. */
    interior_modifier?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier of modifier object for apertures with an Outdoors boundary condition, False is_operable property, and a RoofCeiling or Floor face type for their parent face. */
    skylight_modifier?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier of modifier object for apertures with an Outdoors boundary condition and a True is_operable property. */
    operable_modifier?: string;
	

    constructor() {
        super();
        this.type = "ApertureModifierSetAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "ApertureModifierSetAbridged";
            this.window_modifier = _data["window_modifier"];
            this.interior_modifier = _data["interior_modifier"];
            this.skylight_modifier = _data["skylight_modifier"];
            this.operable_modifier = _data["operable_modifier"];
        }
    }


    static override fromJS(data: any): ApertureModifierSetAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new ApertureModifierSetAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["type"] = this.type;
        data["window_modifier"] = this.window_modifier;
        data["interior_modifier"] = this.interior_modifier;
        data["skylight_modifier"] = this.skylight_modifier;
        data["operable_modifier"] = this.operable_modifier;
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
