import { IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { BaseModifierSetAbridged } from "./BaseModifierSetAbridged";

/** Abridged set containing radiance modifiers needed for a model's Doors. */
export class DoorModifierSetAbridged extends BaseModifierSetAbridged {
    @IsString()
    @IsOptional()
    @Matches(/^DoorModifierSetAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "DoorModifierSetAbridged";
	
    @IsString()
    @IsOptional()
    @Expose({ name: "interior_glass_modifier" })
    /** Identifier of modifier object for glass with a Surface boundary condition. */
    interiorGlassModifier?: string;
	
    @IsString()
    @IsOptional()
    @Expose({ name: "exterior_glass_modifier" })
    /** Identifier of modifier object for glass with an Outdoors boundary condition. */
    exteriorGlassModifier?: string;
	
    @IsString()
    @IsOptional()
    @Expose({ name: "overhead_modifier" })
    /** Identifier of a modifier object for doors with an Outdoors boundary condition and a RoofCeiling or Floor face type for their parent face. */
    overheadModifier?: string;
	

    constructor() {
        super();
        this.type = "DoorModifierSetAbridged";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(DoorModifierSetAbridged, _data);
        }
    }


    static override fromJS(data: any): DoorModifierSetAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new DoorModifierSetAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "DoorModifierSetAbridged";
        data["interior_glass_modifier"] = this.interiorGlassModifier;
        data["exterior_glass_modifier"] = this.exteriorGlassModifier;
        data["overhead_modifier"] = this.overheadModifier;
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
