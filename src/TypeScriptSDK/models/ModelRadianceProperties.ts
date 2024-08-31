import { IsString, IsOptional, IsInstance, ValidateNested, IsArray, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { BSDF } from "./BSDF";
import { Glass } from "./Glass";
import { GlobalModifierSet } from "./GlobalModifierSet";
import { Glow } from "./Glow";
import { Light } from "./Light";
import { Metal } from "./Metal";
import { Mirror } from "./Mirror";
import { ModifierSet } from "./ModifierSet";
import { ModifierSetAbridged } from "./ModifierSetAbridged";
import { Plastic } from "./Plastic";
import { SensorGrid } from "./SensorGrid";
import { Trans } from "./Trans";
import { View } from "./View";
import { Void } from "./Void";

/** Radiance Properties for Honeybee Model. */
export class ModelRadianceProperties extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsInstance(GlobalModifierSet)
    @Type(() => GlobalModifierSet)
    @ValidateNested()
    @IsOptional()
    /** Global Radiance modifier set. */
    global_modifier_set?: GlobalModifierSet;
	
    @IsArray()
    @IsOptional()
    /** A list of all unique modifiers in the model. This includes modifiers across all Faces, Apertures, Doors, Shades, Room ModifierSets, and the global_modifier_set. */
    modifiers?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror) [];
	
    @IsArray()
    @IsOptional()
    /** A list of all unique Room-Assigned ModifierSets in the Model. */
    modifier_sets?: (ModifierSet | ModifierSetAbridged) [];
	
    @IsArray()
    @IsInstance(SensorGrid, { each: true })
    @Type(() => SensorGrid)
    @ValidateNested({ each: true })
    @IsOptional()
    /** An array of SensorGrids that are associated with the model. */
    sensor_grids?: SensorGrid [];
	
    @IsArray()
    @IsInstance(View, { each: true })
    @Type(() => View)
    @ValidateNested({ each: true })
    @IsOptional()
    /** An array of Views that are associated with the model. */
    views?: View [];
	

    constructor() {
        super();
        this.type = "ModelRadianceProperties";
        this.global_modifier_set = GlobalModifierSet.fromJS({
  "type": "GlobalModifierSet",
  "modifiers": [
    {
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
    },
    {
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
    },
    {
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
    },
    {
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
    },
    {
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
    },
    {
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
    },
    {
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
    },
    {
      "identifier": "generic_interior_window_vis_0.88",
      "display_name": null,
      "type": "Glass",
      "modifier": null,
      "dependencies": [],
      "r_transmissivity": 0.9584154328610596,
      "g_transmissivity": 0.9584154328610596,
      "b_transmissivity": 0.9584154328610596,
      "refraction_index": null
    },
    {
      "identifier": "generic_exterior_window_vis_0.64",
      "display_name": null,
      "type": "Glass",
      "modifier": null,
      "dependencies": [],
      "r_transmissivity": 0.6975761815384331,
      "g_transmissivity": 0.6975761815384331,
      "b_transmissivity": 0.6975761815384331,
      "refraction_index": null
    },
    {
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
    }
  ],
  "wall_set": {
    "exterior_modifier": "generic_wall_0.50",
    "interior_modifier": "generic_wall_0.50",
    "type": "WallModifierSetAbridged"
  },
  "floor_set": {
    "exterior_modifier": "generic_floor_0.20",
    "interior_modifier": "generic_floor_0.20",
    "type": "FloorModifierSetAbridged"
  },
  "roof_ceiling_set": {
    "exterior_modifier": "generic_ceiling_0.80",
    "interior_modifier": "generic_ceiling_0.80",
    "type": "RoofCeilingModifierSetAbridged"
  },
  "aperture_set": {
    "type": "ApertureModifierSetAbridged",
    "window_modifier": "generic_exterior_window_vis_0.64",
    "interior_modifier": "generic_interior_window_vis_0.88",
    "skylight_modifier": "generic_exterior_window_vis_0.64",
    "operable_modifier": "generic_exterior_window_vis_0.64"
  },
  "door_set": {
    "exterior_modifier": "generic_opaque_door_0.50",
    "interior_modifier": "generic_opaque_door_0.50",
    "type": "DoorModifierSetAbridged",
    "interior_glass_modifier": "generic_interior_window_vis_0.88",
    "exterior_glass_modifier": "generic_exterior_window_vis_0.64",
    "overhead_modifier": "generic_opaque_door_0.50"
  },
  "shade_set": {
    "exterior_modifier": "generic_exterior_shade_0.35",
    "interior_modifier": "generic_interior_shade_0.50",
    "type": "ShadeModifierSetAbridged"
  },
  "air_boundary_modifier": "air_boundary",
  "context_modifier": "generic_context_0.20"
});
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ModelRadianceProperties, _data);
            this.type = obj.type;
            this.global_modifier_set = obj.global_modifier_set;
            this.modifiers = obj.modifiers;
            this.modifier_sets = obj.modifier_sets;
            this.sensor_grids = obj.sensor_grids;
            this.views = obj.views;
        }
    }


    static override fromJS(data: any): ModelRadianceProperties {
        data = typeof data === 'object' ? data : {};

        let result = new ModelRadianceProperties();
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
        data["global_modifier_set"] = this.global_modifier_set;
        data["modifiers"] = this.modifiers;
        data["modifier_sets"] = this.modifier_sets;
        data["sensor_grids"] = this.sensor_grids;
        data["views"] = this.views;
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
