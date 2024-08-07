import { IsString, IsOptional, IsArray, ValidateNested, IsInstance, validate, ValidationError } from 'class-validator';
import { WallModifierSetAbridged } from "./WallModifierSetAbridged";
import { FloorModifierSetAbridged } from "./FloorModifierSetAbridged";
import { RoofCeilingModifierSetAbridged } from "./RoofCeilingModifierSetAbridged";
import { ApertureModifierSetAbridged } from "./ApertureModifierSetAbridged";
import { DoorModifierSetAbridged } from "./DoorModifierSetAbridged";
import { ShadeModifierSetAbridged } from "./ShadeModifierSetAbridged";
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for all objects that are not extensible with additional keys.

This effectively includes all objects except for the Properties classes
that are assigned to geometry objects. */
export class GlobalModifierSet extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** Global Honeybee Radiance modifiers. */
    modifiers?: None [];
	
    @IsInstance(WallModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Global Honeybee WallModifierSet. */
    wall_set?: WallModifierSetAbridged;
	
    @IsInstance(FloorModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Global Honeybee FloorModifierSet. */
    floor_set?: FloorModifierSetAbridged;
	
    @IsInstance(RoofCeilingModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Global Honeybee RoofCeilingModifierSet. */
    roof_ceiling_set?: RoofCeilingModifierSetAbridged;
	
    @IsInstance(ApertureModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Global Honeybee ApertureModifierSet. */
    aperture_set?: ApertureModifierSetAbridged;
	
    @IsInstance(DoorModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Global Honeybee DoorModifierSet. */
    door_set?: DoorModifierSetAbridged;
	
    @IsInstance(ShadeModifierSetAbridged)
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
        this.modifiers = [
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
];
        this.wall_set = new WallModifierSetAbridged();
        this.floor_set = new FloorModifierSetAbridged();
        this.roof_ceiling_set = new RoofCeilingModifierSetAbridged();
        this.aperture_set = new ApertureModifierSetAbridged();
        this.door_set = new DoorModifierSetAbridged();
        this.shade_set = new ShadeModifierSetAbridged();
        this.air_boundary_modifier = "air_boundary";
        this.context_modifier = "generic_context_0.20";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "GlobalModifierSet";
            this.modifiers = _data["modifiers"] !== undefined ? _data["modifiers"] : [
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
];
            this.wall_set = _data["wall_set"] !== undefined ? _data["wall_set"] : new WallModifierSetAbridged();
            this.floor_set = _data["floor_set"] !== undefined ? _data["floor_set"] : new FloorModifierSetAbridged();
            this.roof_ceiling_set = _data["roof_ceiling_set"] !== undefined ? _data["roof_ceiling_set"] : new RoofCeilingModifierSetAbridged();
            this.aperture_set = _data["aperture_set"] !== undefined ? _data["aperture_set"] : new ApertureModifierSetAbridged();
            this.door_set = _data["door_set"] !== undefined ? _data["door_set"] : new DoorModifierSetAbridged();
            this.shade_set = _data["shade_set"] !== undefined ? _data["shade_set"] : new ShadeModifierSetAbridged();
            this.air_boundary_modifier = _data["air_boundary_modifier"] !== undefined ? _data["air_boundary_modifier"] : "air_boundary";
            this.context_modifier = _data["context_modifier"] !== undefined ? _data["context_modifier"] : "generic_context_0.20";
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
			const errorMessages = errors.map((error: ValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
