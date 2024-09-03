import { IsString, IsOptional, Matches, IsArray, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { ApertureModifierSetAbridged } from "./ApertureModifierSetAbridged";
import { DoorModifierSetAbridged } from "./DoorModifierSetAbridged";
import { FloorModifierSetAbridged } from "./FloorModifierSetAbridged";
import { Glass } from "./Glass";
import { Plastic } from "./Plastic";
import { RoofCeilingModifierSetAbridged } from "./RoofCeilingModifierSetAbridged";
import { ShadeModifierSetAbridged } from "./ShadeModifierSetAbridged";
import { Trans } from "./Trans";
import { WallModifierSetAbridged } from "./WallModifierSetAbridged";

/** Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects. */
export class GlobalModifierSet extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^GlobalModifierSet$/)
    type?: string;
	
    @IsArray()
    @IsOptional()
    /** Global Honeybee Radiance modifiers. */
    modifiers?: (Plastic | Glass | Trans) [];
	
    @IsInstance(WallModifierSetAbridged)
    @Type(() => WallModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Global Honeybee WallModifierSet. */
    wall_set?: WallModifierSetAbridged;
	
    @IsInstance(FloorModifierSetAbridged)
    @Type(() => FloorModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Global Honeybee FloorModifierSet. */
    floor_set?: FloorModifierSetAbridged;
	
    @IsInstance(RoofCeilingModifierSetAbridged)
    @Type(() => RoofCeilingModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Global Honeybee RoofCeilingModifierSet. */
    roof_ceiling_set?: RoofCeilingModifierSetAbridged;
	
    @IsInstance(ApertureModifierSetAbridged)
    @Type(() => ApertureModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Global Honeybee ApertureModifierSet. */
    aperture_set?: ApertureModifierSetAbridged;
	
    @IsInstance(DoorModifierSetAbridged)
    @Type(() => DoorModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Global Honeybee DoorModifierSet. */
    door_set?: DoorModifierSetAbridged;
	
    @IsInstance(ShadeModifierSetAbridged)
    @Type(() => ShadeModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Global Honeybee ShadeModifierSet. */
    shade_set?: ShadeModifierSetAbridged;
	
    @IsString()
    @IsOptional()
    /** Global Honeybee Modifier for AirBoundary Faces. */
    air_boundary_modifier?: string;
	
    @IsString()
    @IsOptional()
    /** Global Honeybee Modifier for context Shades. */
    context_modifier?: string;
	

    constructor() {
        super();
        this.type = "GlobalModifierSet";
        this.modifiers = [Plastic.fromJS({
  "identifier": "generic_floor_0.20",
  "display_name": null,
  "type": "Plastic",
  "modifier": null,
  "dependencies": [],
  "r_reflectance": 0.2,
  "g_reflectance": 0.2,
  "b_reflectance": 0.2,
  "specularity": 0.0,
  "roughness": 0.0
}), Plastic.fromJS({
  "identifier": "generic_wall_0.50",
  "display_name": null,
  "type": "Plastic",
  "modifier": null,
  "dependencies": [],
  "r_reflectance": 0.5,
  "g_reflectance": 0.5,
  "b_reflectance": 0.5,
  "specularity": 0.0,
  "roughness": 0.0
}), Plastic.fromJS({
  "identifier": "generic_ceiling_0.80",
  "display_name": null,
  "type": "Plastic",
  "modifier": null,
  "dependencies": [],
  "r_reflectance": 0.8,
  "g_reflectance": 0.8,
  "b_reflectance": 0.8,
  "specularity": 0.0,
  "roughness": 0.0
}), Plastic.fromJS({
  "identifier": "generic_opaque_door_0.50",
  "display_name": null,
  "type": "Plastic",
  "modifier": null,
  "dependencies": [],
  "r_reflectance": 0.5,
  "g_reflectance": 0.5,
  "b_reflectance": 0.5,
  "specularity": 0.0,
  "roughness": 0.0
}), Plastic.fromJS({
  "identifier": "generic_interior_shade_0.50",
  "display_name": null,
  "type": "Plastic",
  "modifier": null,
  "dependencies": [],
  "r_reflectance": 0.5,
  "g_reflectance": 0.5,
  "b_reflectance": 0.5,
  "specularity": 0.0,
  "roughness": 0.0
}), Plastic.fromJS({
  "identifier": "generic_exterior_shade_0.35",
  "display_name": null,
  "type": "Plastic",
  "modifier": null,
  "dependencies": [],
  "r_reflectance": 0.35,
  "g_reflectance": 0.35,
  "b_reflectance": 0.35,
  "specularity": 0.0,
  "roughness": 0.0
}), Plastic.fromJS({
  "identifier": "generic_context_0.20",
  "display_name": null,
  "type": "Plastic",
  "modifier": null,
  "dependencies": [],
  "r_reflectance": 0.2,
  "g_reflectance": 0.2,
  "b_reflectance": 0.2,
  "specularity": 0.0,
  "roughness": 0.0
}), Glass.fromJS({
  "identifier": "generic_interior_window_vis_0.88",
  "display_name": null,
  "type": "Glass",
  "modifier": null,
  "dependencies": [],
  "r_transmissivity": 0.9584154328610596,
  "g_transmissivity": 0.9584154328610596,
  "b_transmissivity": 0.9584154328610596,
  "refraction_index": null
}), Glass.fromJS({
  "identifier": "generic_exterior_window_vis_0.64",
  "display_name": null,
  "type": "Glass",
  "modifier": null,
  "dependencies": [],
  "r_transmissivity": 0.6975761815384331,
  "g_transmissivity": 0.6975761815384331,
  "b_transmissivity": 0.6975761815384331,
  "refraction_index": null
}), Trans.fromJS({
  "identifier": "air_boundary",
  "display_name": null,
  "type": "Trans",
  "modifier": null,
  "dependencies": [],
  "r_reflectance": 1.0,
  "g_reflectance": 1.0,
  "b_reflectance": 1.0,
  "specularity": 0.0,
  "roughness": 0.0,
  "transmitted_diff": 1.0,
  "transmitted_spec": 1.0
})];
        this.wall_set = WallModifierSetAbridged.fromJS({
  "exterior_modifier": "generic_wall_0.50",
  "interior_modifier": "generic_wall_0.50",
  "type": "WallModifierSetAbridged"
});
        this.floor_set = FloorModifierSetAbridged.fromJS({
  "exterior_modifier": "generic_floor_0.20",
  "interior_modifier": "generic_floor_0.20",
  "type": "FloorModifierSetAbridged"
});
        this.roof_ceiling_set = RoofCeilingModifierSetAbridged.fromJS({
  "exterior_modifier": "generic_ceiling_0.80",
  "interior_modifier": "generic_ceiling_0.80",
  "type": "RoofCeilingModifierSetAbridged"
});
        this.aperture_set = ApertureModifierSetAbridged.fromJS({
  "type": "ApertureModifierSetAbridged",
  "window_modifier": "generic_exterior_window_vis_0.64",
  "interior_modifier": "generic_interior_window_vis_0.88",
  "skylight_modifier": "generic_exterior_window_vis_0.64",
  "operable_modifier": "generic_exterior_window_vis_0.64"
});
        this.door_set = DoorModifierSetAbridged.fromJS({
  "exterior_modifier": "generic_opaque_door_0.50",
  "interior_modifier": "generic_opaque_door_0.50",
  "type": "DoorModifierSetAbridged",
  "interior_glass_modifier": "generic_interior_window_vis_0.88",
  "exterior_glass_modifier": "generic_exterior_window_vis_0.64",
  "overhead_modifier": "generic_opaque_door_0.50"
});
        this.shade_set = ShadeModifierSetAbridged.fromJS({
  "exterior_modifier": "generic_exterior_shade_0.35",
  "interior_modifier": "generic_interior_shade_0.50",
  "type": "ShadeModifierSetAbridged"
});
        this.air_boundary_modifier = "air_boundary";
        this.context_modifier = "generic_context_0.20";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(GlobalModifierSet, _data);
            this.type = obj.type;
            this.modifiers = obj.modifiers;
            this.wall_set = obj.wall_set;
            this.floor_set = obj.floor_set;
            this.roof_ceiling_set = obj.roof_ceiling_set;
            this.aperture_set = obj.aperture_set;
            this.door_set = obj.door_set;
            this.shade_set = obj.shade_set;
            this.air_boundary_modifier = obj.air_boundary_modifier;
            this.context_modifier = obj.context_modifier;
        }
    }


    static override fromJS(data: any): GlobalModifierSet {
        data = typeof data === 'object' ? data : {};

        let result = new GlobalModifierSet();
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
        data["modifiers"] = this.modifiers;
        data["wall_set"] = this.wall_set;
        data["floor_set"] = this.floor_set;
        data["roof_ceiling_set"] = this.roof_ceiling_set;
        data["aperture_set"] = this.aperture_set;
        data["door_set"] = this.door_set;
        data["shade_set"] = this.shade_set;
        data["air_boundary_modifier"] = this.air_boundary_modifier;
        data["context_modifier"] = this.context_modifier;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || [error.property]).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
