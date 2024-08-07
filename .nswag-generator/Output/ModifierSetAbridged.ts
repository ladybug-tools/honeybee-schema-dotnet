import { IsString, IsOptional, IsInstance, ValidateNested, validate, ValidationError } from 'class-validator';
import { WallModifierSetAbridged } from "./WallModifierSetAbridged";
import { FloorModifierSetAbridged } from "./FloorModifierSetAbridged";
import { RoofCeilingModifierSetAbridged } from "./RoofCeilingModifierSetAbridged";
import { ApertureModifierSetAbridged } from "./ApertureModifierSetAbridged";
import { DoorModifierSetAbridged } from "./DoorModifierSetAbridged";
import { ShadeModifierSetAbridged } from "./ShadeModifierSetAbridged";
import { IDdRadianceBaseModel } from "./IDdRadianceBaseModel";

/** Abridged set containing all modifiers needed to create a radiance model. */
export class ModifierSetAbridged extends IDdRadianceBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsInstance(WallModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Optional WallModifierSet object for this ModifierSet (default: None). */
    wall_set?: WallModifierSetAbridged;
	
    @IsInstance(FloorModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Optional FloorModifierSet object for this ModifierSet (default: None). */
    floor_set?: FloorModifierSetAbridged;
	
    @IsInstance(RoofCeilingModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Optional RoofCeilingModifierSet object for this ModifierSet (default: None). */
    roof_ceiling_set?: RoofCeilingModifierSetAbridged;
	
    @IsInstance(ApertureModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Optional ApertureModifierSet object for this ModifierSet (default: None). */
    aperture_set?: ApertureModifierSetAbridged;
	
    @IsInstance(DoorModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Optional DoorModifierSet object for this ModifierSet (default: None). */
    door_set?: DoorModifierSetAbridged;
	
    @IsInstance(ShadeModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Optional ShadeModifierSet object for this ModifierSet (default: None). */
    shade_set?: ShadeModifierSetAbridged;
	
    @IsString()
    @IsOptional()
    /** Optional Modifier to be used for all Faces with an AirBoundary face type. If None, it will be the honeybee generic air wall modifier. */
    air_boundary_modifier?: string;
	

    constructor() {
        super();
        this.type = "ModifierSetAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "ModifierSetAbridged";
            this.wall_set = _data["wall_set"];
            this.floor_set = _data["floor_set"];
            this.roof_ceiling_set = _data["roof_ceiling_set"];
            this.aperture_set = _data["aperture_set"];
            this.door_set = _data["door_set"];
            this.shade_set = _data["shade_set"];
            this.air_boundary_modifier = _data["air_boundary_modifier"];
        }
    }


    static override fromJS(data: any): ModifierSetAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new ModifierSetAbridged();
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
        data["wall_set"] = this.wall_set;
        data["floor_set"] = this.floor_set;
        data["roof_ceiling_set"] = this.roof_ceiling_set;
        data["aperture_set"] = this.aperture_set;
        data["door_set"] = this.door_set;
        data["shade_set"] = this.shade_set;
        data["air_boundary_modifier"] = this.air_boundary_modifier;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: ValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
