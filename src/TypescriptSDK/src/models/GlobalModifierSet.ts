import { IsString, IsOptional, Matches, IsArray, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
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
    @Expose({ name: "type" })
    /** type */
    type: string = "GlobalModifierSet";
	
    @IsArray()
    @IsOptional()
    @Expose({ name: "modifiers" })
    @Transform(({ value }) => value.map((item: any) => {
      if (item?.type === 'Plastic') return Plastic.fromJS(item);
      else if (item?.type === 'Glass') return Glass.fromJS(item);
      else if (item?.type === 'Trans') return Trans.fromJS(item);
      else return item;
    }))
    /** Global Honeybee Radiance modifiers. */
    modifiers: (Plastic | Glass | Trans)[] = [Plastic.fromJS({
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
	
    @IsInstance(WallModifierSetAbridged)
    @Type(() => WallModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "wall_set" })
    /** Global Honeybee WallModifierSet. */
    wallSet: WallModifierSetAbridged = WallModifierSetAbridged.fromJS({
  "exterior_modifier": "generic_wall_0.50",
  "interior_modifier": "generic_wall_0.50",
  "type": "WallModifierSetAbridged"
});
	
    @IsInstance(FloorModifierSetAbridged)
    @Type(() => FloorModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "floor_set" })
    /** Global Honeybee FloorModifierSet. */
    floorSet: FloorModifierSetAbridged = FloorModifierSetAbridged.fromJS({
  "exterior_modifier": "generic_floor_0.20",
  "interior_modifier": "generic_floor_0.20",
  "type": "FloorModifierSetAbridged"
});
	
    @IsInstance(RoofCeilingModifierSetAbridged)
    @Type(() => RoofCeilingModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "roof_ceiling_set" })
    /** Global Honeybee RoofCeilingModifierSet. */
    roofCeilingSet: RoofCeilingModifierSetAbridged = RoofCeilingModifierSetAbridged.fromJS({
  "exterior_modifier": "generic_ceiling_0.80",
  "interior_modifier": "generic_ceiling_0.80",
  "type": "RoofCeilingModifierSetAbridged"
});
	
    @IsInstance(ApertureModifierSetAbridged)
    @Type(() => ApertureModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "aperture_set" })
    /** Global Honeybee ApertureModifierSet. */
    apertureSet: ApertureModifierSetAbridged = ApertureModifierSetAbridged.fromJS({
  "type": "ApertureModifierSetAbridged",
  "window_modifier": "generic_exterior_window_vis_0.64",
  "interior_modifier": "generic_interior_window_vis_0.88",
  "skylight_modifier": "generic_exterior_window_vis_0.64",
  "operable_modifier": "generic_exterior_window_vis_0.64"
});
	
    @IsInstance(DoorModifierSetAbridged)
    @Type(() => DoorModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "door_set" })
    /** Global Honeybee DoorModifierSet. */
    doorSet: DoorModifierSetAbridged = DoorModifierSetAbridged.fromJS({
  "exterior_modifier": "generic_opaque_door_0.50",
  "interior_modifier": "generic_opaque_door_0.50",
  "type": "DoorModifierSetAbridged",
  "interior_glass_modifier": "generic_interior_window_vis_0.88",
  "exterior_glass_modifier": "generic_exterior_window_vis_0.64",
  "overhead_modifier": "generic_opaque_door_0.50"
});
	
    @IsInstance(ShadeModifierSetAbridged)
    @Type(() => ShadeModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "shade_set" })
    /** Global Honeybee ShadeModifierSet. */
    shadeSet: ShadeModifierSetAbridged = ShadeModifierSetAbridged.fromJS({
  "exterior_modifier": "generic_exterior_shade_0.35",
  "interior_modifier": "generic_interior_shade_0.50",
  "type": "ShadeModifierSetAbridged"
});
	
    @IsString()
    @IsOptional()
    @Expose({ name: "air_boundary_modifier" })
    /** Global Honeybee Modifier for AirBoundary Faces. */
    airBoundaryModifier: string = "air_boundary";
	
    @IsString()
    @IsOptional()
    @Expose({ name: "context_modifier" })
    /** Global Honeybee Modifier for context Shades. */
    contextModifier: string = "generic_context_0.20";
	

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
        this.wallSet = WallModifierSetAbridged.fromJS({
  "exterior_modifier": "generic_wall_0.50",
  "interior_modifier": "generic_wall_0.50",
  "type": "WallModifierSetAbridged"
});
        this.floorSet = FloorModifierSetAbridged.fromJS({
  "exterior_modifier": "generic_floor_0.20",
  "interior_modifier": "generic_floor_0.20",
  "type": "FloorModifierSetAbridged"
});
        this.roofCeilingSet = RoofCeilingModifierSetAbridged.fromJS({
  "exterior_modifier": "generic_ceiling_0.80",
  "interior_modifier": "generic_ceiling_0.80",
  "type": "RoofCeilingModifierSetAbridged"
});
        this.apertureSet = ApertureModifierSetAbridged.fromJS({
  "type": "ApertureModifierSetAbridged",
  "window_modifier": "generic_exterior_window_vis_0.64",
  "interior_modifier": "generic_interior_window_vis_0.88",
  "skylight_modifier": "generic_exterior_window_vis_0.64",
  "operable_modifier": "generic_exterior_window_vis_0.64"
});
        this.doorSet = DoorModifierSetAbridged.fromJS({
  "exterior_modifier": "generic_opaque_door_0.50",
  "interior_modifier": "generic_opaque_door_0.50",
  "type": "DoorModifierSetAbridged",
  "interior_glass_modifier": "generic_interior_window_vis_0.88",
  "exterior_glass_modifier": "generic_exterior_window_vis_0.64",
  "overhead_modifier": "generic_opaque_door_0.50"
});
        this.shadeSet = ShadeModifierSetAbridged.fromJS({
  "exterior_modifier": "generic_exterior_shade_0.35",
  "interior_modifier": "generic_interior_shade_0.50",
  "type": "ShadeModifierSetAbridged"
});
        this.airBoundaryModifier = "air_boundary";
        this.contextModifier = "generic_context_0.20";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(GlobalModifierSet, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.modifiers = obj.modifiers;
            this.wallSet = obj.wallSet;
            this.floorSet = obj.floorSet;
            this.roofCeilingSet = obj.roofCeilingSet;
            this.apertureSet = obj.apertureSet;
            this.doorSet = obj.doorSet;
            this.shadeSet = obj.shadeSet;
            this.airBoundaryModifier = obj.airBoundaryModifier;
            this.contextModifier = obj.contextModifier;
        }
    }


    static override fromJS(data: any): GlobalModifierSet {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new GlobalModifierSet();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["modifiers"] = this.modifiers;
        data["wall_set"] = this.wallSet;
        data["floor_set"] = this.floorSet;
        data["roof_ceiling_set"] = this.roofCeilingSet;
        data["aperture_set"] = this.apertureSet;
        data["door_set"] = this.doorSet;
        data["shade_set"] = this.shadeSet;
        data["air_boundary_modifier"] = this.airBoundaryModifier;
        data["context_modifier"] = this.contextModifier;
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
