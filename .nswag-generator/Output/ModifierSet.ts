import { IsString, IsOptional, IsInstance, ValidateNested, validate, ValidationError } from 'class-validator';
import { WallModifierSet } from "./WallModifierSet";
import { FloorModifierSet } from "./FloorModifierSet";
import { RoofCeilingModifierSet } from "./RoofCeilingModifierSet";
import { ApertureModifierSet } from "./ApertureModifierSet";
import { DoorModifierSet } from "./DoorModifierSet";
import { ShadeModifierSet } from "./ShadeModifierSet";
import { Plastic } from "./Plastic";
import { Glass } from "./Glass";
import { BSDF } from "./BSDF";
import { Glow } from "./Glow";
import { Light } from "./Light";
import { Trans } from "./Trans";
import { Metal } from "./Metal";
import { Void } from "./Void";
import { Mirror } from "./Mirror";
import { IDdRadianceBaseModel } from "./IDdRadianceBaseModel";

/** Set containing all radiance modifiers needed to create a radiance model. */
export class ModifierSet extends IDdRadianceBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsInstance(WallModifierSet)
    @ValidateNested()
    @IsOptional()
    /** An optional WallModifierSet object for this ModifierSet. (default: None). */
    wall_set?: WallModifierSet;
	
    @IsInstance(FloorModifierSet)
    @ValidateNested()
    @IsOptional()
    /** An optional FloorModifierSet object for this ModifierSet. (default: None). */
    floor_set?: FloorModifierSet;
	
    @IsInstance(RoofCeilingModifierSet)
    @ValidateNested()
    @IsOptional()
    /** An optional RoofCeilingModifierSet object for this ModifierSet. (default: None). */
    roof_ceiling_set?: RoofCeilingModifierSet;
	
    @IsInstance(ApertureModifierSet)
    @ValidateNested()
    @IsOptional()
    /** An optional ApertureModifierSet object for this ModifierSet. (default: None). */
    aperture_set?: ApertureModifierSet;
	
    @IsInstance(DoorModifierSet)
    @ValidateNested()
    @IsOptional()
    /** An optional DoorModifierSet object for this ModifierSet. (default: None). */
    door_set?: DoorModifierSet;
	
    @IsInstance(ShadeModifierSet)
    @ValidateNested()
    @IsOptional()
    /** An optional ShadeModifierSet object for this ModifierSet. (default: None). */
    shade_set?: ShadeModifierSet;
	
    @IsOptional()
    /** An optional Modifier to be used for all Faces with an AirBoundary face type. If None, it will be the honeybee generic air wall modifier. */
    air_boundary_modifier?: Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror;
	

    constructor() {
        super();
        this.type = "ModifierSet";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "ModifierSet";
            this.wall_set = _data["wall_set"];
            this.floor_set = _data["floor_set"];
            this.roof_ceiling_set = _data["roof_ceiling_set"];
            this.aperture_set = _data["aperture_set"];
            this.door_set = _data["door_set"];
            this.shade_set = _data["shade_set"];
            this.air_boundary_modifier = _data["air_boundary_modifier"];
        }
    }


    static override fromJS(data: any): ModifierSet {
        data = typeof data === 'object' ? data : {};

        let result = new ModifierSet();
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
