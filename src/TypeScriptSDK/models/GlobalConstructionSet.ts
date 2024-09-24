import { IsString, IsOptional, Matches, IsArray, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { AirBoundaryConstructionAbridged } from "./AirBoundaryConstructionAbridged";
import { ApertureConstructionSetAbridged } from "./ApertureConstructionSetAbridged";
import { DoorConstructionSetAbridged } from "./DoorConstructionSetAbridged";
import { EnergyMaterial } from "./EnergyMaterial";
import { EnergyMaterialNoMass } from "./EnergyMaterialNoMass";
import { EnergyWindowMaterialGas } from "./EnergyWindowMaterialGas";
import { EnergyWindowMaterialGlazing } from "./EnergyWindowMaterialGlazing";
import { FloorConstructionSetAbridged } from "./FloorConstructionSetAbridged";
import { OpaqueConstructionAbridged } from "./OpaqueConstructionAbridged";
import { RoofCeilingConstructionSetAbridged } from "./RoofCeilingConstructionSetAbridged";
import { ShadeConstruction } from "./ShadeConstruction";
import { WallConstructionSetAbridged } from "./WallConstructionSetAbridged";
import { WindowConstructionAbridged } from "./WindowConstructionAbridged";

/** Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects. */
export class GlobalConstructionSet extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^GlobalConstructionSet$/)
    type?: string;
	
    @IsArray()
    @IsOptional()
    @Transform(({ value }) => value.map((item: any) => {
      if (item.type === 'EnergyMaterial') return EnergyMaterial.fromJS(item);
      else if (item.type === 'EnergyMaterialNoMass') return EnergyMaterialNoMass.fromJS(item);
      else if (item.type === 'EnergyWindowMaterialGlazing') return EnergyWindowMaterialGlazing.fromJS(item);
      else if (item.type === 'EnergyWindowMaterialGas') return EnergyWindowMaterialGas.fromJS(item);
      else return item;
    }))
    /** Global Honeybee Energy materials. */
    materials?: (EnergyMaterial | EnergyMaterialNoMass | EnergyWindowMaterialGlazing | EnergyWindowMaterialGas) [];
	
    @IsArray()
    @IsOptional()
    @Transform(({ value }) => value.map((item: any) => {
      if (item.type === 'OpaqueConstructionAbridged') return OpaqueConstructionAbridged.fromJS(item);
      else if (item.type === 'WindowConstructionAbridged') return WindowConstructionAbridged.fromJS(item);
      else if (item.type === 'ShadeConstruction') return ShadeConstruction.fromJS(item);
      else if (item.type === 'AirBoundaryConstructionAbridged') return AirBoundaryConstructionAbridged.fromJS(item);
      else return item;
    }))
    /** Global Honeybee Energy constructions. */
    constructions?: (OpaqueConstructionAbridged | WindowConstructionAbridged | ShadeConstruction | AirBoundaryConstructionAbridged) [];
	
    @IsInstance(WallConstructionSetAbridged)
    @Type(() => WallConstructionSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Global Honeybee WallConstructionSet. */
    wall_set?: WallConstructionSetAbridged;
	
    @IsInstance(FloorConstructionSetAbridged)
    @Type(() => FloorConstructionSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Global Honeybee FloorConstructionSet. */
    floor_set?: FloorConstructionSetAbridged;
	
    @IsInstance(RoofCeilingConstructionSetAbridged)
    @Type(() => RoofCeilingConstructionSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Global Honeybee RoofCeilingConstructionSet. */
    roof_ceiling_set?: RoofCeilingConstructionSetAbridged;
	
    @IsInstance(ApertureConstructionSetAbridged)
    @Type(() => ApertureConstructionSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Global Honeybee ApertureConstructionSet. */
    aperture_set?: ApertureConstructionSetAbridged;
	
    @IsInstance(DoorConstructionSetAbridged)
    @Type(() => DoorConstructionSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Global Honeybee DoorConstructionSet. */
    door_set?: DoorConstructionSetAbridged;
	
    @IsString()
    @IsOptional()
    /** Global Honeybee Construction for building-attached Shades. */
    shade_construction?: string;
	
    @IsString()
    @IsOptional()
    /** Global Honeybee Construction for context Shades. */
    context_construction?: string;
	
    @IsString()
    @IsOptional()
    /** Global Honeybee Construction for AirBoundary Faces. */
    air_boundary_construction?: string;
	

    constructor() {
        super();
        this.type = "GlobalConstructionSet";
        this.materials = [EnergyMaterial.fromJS({
  "identifier": "Generic Roof Membrane",
  "display_name": null,
  "user_data": null,
  "type": "EnergyMaterial",
  "roughness": "MediumRough",
  "thickness": 0.01,
  "conductivity": 0.16,
  "density": 1120.0,
  "specific_heat": 1460.0,
  "thermal_absorptance": 0.9,
  "solar_absorptance": 0.65,
  "visible_absorptance": 0.65
}), EnergyMaterial.fromJS({
  "identifier": "Generic Acoustic Tile",
  "display_name": null,
  "user_data": null,
  "type": "EnergyMaterial",
  "roughness": "MediumSmooth",
  "thickness": 0.02,
  "conductivity": 0.06,
  "density": 368.0,
  "specific_heat": 590.0,
  "thermal_absorptance": 0.9,
  "solar_absorptance": 0.2,
  "visible_absorptance": 0.2
}), EnergyMaterial.fromJS({
  "identifier": "Generic 25mm Wood",
  "display_name": null,
  "user_data": null,
  "type": "EnergyMaterial",
  "roughness": "MediumSmooth",
  "thickness": 0.0254,
  "conductivity": 0.15,
  "density": 608.0,
  "specific_heat": 1630.0,
  "thermal_absorptance": 0.9,
  "solar_absorptance": 0.5,
  "visible_absorptance": 0.5
}), EnergyMaterial.fromJS({
  "identifier": "Generic HW Concrete",
  "display_name": null,
  "user_data": null,
  "type": "EnergyMaterial",
  "roughness": "MediumRough",
  "thickness": 0.2,
  "conductivity": 1.95,
  "density": 2240.0,
  "specific_heat": 900.0,
  "thermal_absorptance": 0.9,
  "solar_absorptance": 0.8,
  "visible_absorptance": 0.8
}), EnergyWindowMaterialGas.fromJS({
  "identifier": "Generic Window Air Gap",
  "display_name": null,
  "user_data": null,
  "type": "EnergyWindowMaterialGas",
  "thickness": 0.0127,
  "gas_type": "Air"
}), EnergyMaterial.fromJS({
  "identifier": "Generic Gypsum Board",
  "display_name": null,
  "user_data": null,
  "type": "EnergyMaterial",
  "roughness": "MediumSmooth",
  "thickness": 0.0127,
  "conductivity": 0.16,
  "density": 800.0,
  "specific_heat": 1090.0,
  "thermal_absorptance": 0.9,
  "solar_absorptance": 0.5,
  "visible_absorptance": 0.5
}), EnergyMaterial.fromJS({
  "identifier": "Generic Wall Air Gap",
  "display_name": null,
  "user_data": null,
  "type": "EnergyMaterial",
  "roughness": "Smooth",
  "thickness": 0.1,
  "conductivity": 0.667,
  "density": 1.28,
  "specific_heat": 1000.0,
  "thermal_absorptance": 0.9,
  "solar_absorptance": 0.7,
  "visible_absorptance": 0.7
}), EnergyMaterial.fromJS({
  "identifier": "Generic Ceiling Air Gap",
  "display_name": null,
  "user_data": null,
  "type": "EnergyMaterial",
  "roughness": "Smooth",
  "thickness": 0.1,
  "conductivity": 0.556,
  "density": 1.28,
  "specific_heat": 1000.0,
  "thermal_absorptance": 0.9,
  "solar_absorptance": 0.7,
  "visible_absorptance": 0.7
}), EnergyMaterial.fromJS({
  "identifier": "Generic Brick",
  "display_name": null,
  "user_data": null,
  "type": "EnergyMaterial",
  "roughness": "MediumRough",
  "thickness": 0.1,
  "conductivity": 0.9,
  "density": 1920.0,
  "specific_heat": 790.0,
  "thermal_absorptance": 0.9,
  "solar_absorptance": 0.65,
  "visible_absorptance": 0.65
}), EnergyMaterial.fromJS({
  "identifier": "Generic 50mm Insulation",
  "display_name": null,
  "user_data": null,
  "type": "EnergyMaterial",
  "roughness": "MediumRough",
  "thickness": 0.05,
  "conductivity": 0.03,
  "density": 43.0,
  "specific_heat": 1210.0,
  "thermal_absorptance": 0.9,
  "solar_absorptance": 0.7,
  "visible_absorptance": 0.7
}), EnergyWindowMaterialGlazing.fromJS({
  "identifier": "Generic Low-e Glass",
  "display_name": null,
  "user_data": null,
  "type": "EnergyWindowMaterialGlazing",
  "thickness": 0.006,
  "solar_transmittance": 0.45,
  "solar_reflectance": 0.36,
  "solar_reflectance_back": 0.36,
  "visible_transmittance": 0.71,
  "visible_reflectance": 0.21,
  "visible_reflectance_back": 0.21,
  "infrared_transmittance": 0.0,
  "emissivity": 0.84,
  "emissivity_back": 0.047,
  "conductivity": 1.0,
  "dirt_correction": 1.0,
  "solar_diffusing": false
}), EnergyMaterial.fromJS({
  "identifier": "Generic Painted Metal",
  "display_name": null,
  "user_data": null,
  "type": "EnergyMaterial",
  "roughness": "Smooth",
  "thickness": 0.0015,
  "conductivity": 45.0,
  "density": 7690.0,
  "specific_heat": 410.0,
  "thermal_absorptance": 0.9,
  "solar_absorptance": 0.5,
  "visible_absorptance": 0.5
}), EnergyMaterial.fromJS({
  "identifier": "Generic LW Concrete",
  "display_name": null,
  "user_data": null,
  "type": "EnergyMaterial",
  "roughness": "MediumRough",
  "thickness": 0.1,
  "conductivity": 0.53,
  "density": 1280.0,
  "specific_heat": 840.0,
  "thermal_absorptance": 0.9,
  "solar_absorptance": 0.8,
  "visible_absorptance": 0.8
}), EnergyMaterial.fromJS({
  "identifier": "Generic 25mm Insulation",
  "display_name": null,
  "user_data": null,
  "type": "EnergyMaterial",
  "roughness": "MediumRough",
  "thickness": 0.025,
  "conductivity": 0.03,
  "density": 43.0,
  "specific_heat": 1210.0,
  "thermal_absorptance": 0.9,
  "solar_absorptance": 0.7,
  "visible_absorptance": 0.7
}), EnergyWindowMaterialGlazing.fromJS({
  "identifier": "Generic Clear Glass",
  "display_name": null,
  "user_data": null,
  "type": "EnergyWindowMaterialGlazing",
  "thickness": 0.006,
  "solar_transmittance": 0.77,
  "solar_reflectance": 0.07,
  "solar_reflectance_back": 0.07,
  "visible_transmittance": 0.88,
  "visible_reflectance": 0.08,
  "visible_reflectance_back": 0.08,
  "infrared_transmittance": 0.0,
  "emissivity": 0.84,
  "emissivity_back": 0.84,
  "conductivity": 1.0,
  "dirt_correction": 1.0,
  "solar_diffusing": false
})];
        this.constructions = [OpaqueConstructionAbridged.fromJS({
  "identifier": "Generic Interior Door",
  "display_name": null,
  "user_data": null,
  "type": "OpaqueConstructionAbridged",
  "materials": [
    "Generic 25mm Wood"
  ]
}), WindowConstructionAbridged.fromJS({
  "identifier": "Generic Single Pane",
  "display_name": null,
  "user_data": null,
  "type": "WindowConstructionAbridged",
  "materials": [
    "Generic Clear Glass"
  ],
  "frame": null
}), ShadeConstruction.fromJS({
  "identifier": "Generic Shade",
  "display_name": null,
  "user_data": null,
  "type": "ShadeConstruction",
  "solar_reflectance": 0.35,
  "visible_reflectance": 0.35,
  "is_specular": false
}), ShadeConstruction.fromJS({
  "identifier": "Generic Context",
  "display_name": null,
  "user_data": null,
  "type": "ShadeConstruction",
  "solar_reflectance": 0.2,
  "visible_reflectance": 0.2,
  "is_specular": false
}), OpaqueConstructionAbridged.fromJS({
  "identifier": "Generic Interior Ceiling",
  "display_name": null,
  "user_data": null,
  "type": "OpaqueConstructionAbridged",
  "materials": [
    "Generic LW Concrete",
    "Generic Ceiling Air Gap",
    "Generic Acoustic Tile"
  ]
}), OpaqueConstructionAbridged.fromJS({
  "identifier": "Generic Interior Wall",
  "display_name": null,
  "user_data": null,
  "type": "OpaqueConstructionAbridged",
  "materials": [
    "Generic Gypsum Board",
    "Generic Wall Air Gap",
    "Generic Gypsum Board"
  ]
}), OpaqueConstructionAbridged.fromJS({
  "identifier": "Generic Exposed Floor",
  "display_name": null,
  "user_data": null,
  "type": "OpaqueConstructionAbridged",
  "materials": [
    "Generic Painted Metal",
    "Generic Ceiling Air Gap",
    "Generic 50mm Insulation",
    "Generic LW Concrete"
  ]
}), OpaqueConstructionAbridged.fromJS({
  "identifier": "Generic Interior Floor",
  "display_name": null,
  "user_data": null,
  "type": "OpaqueConstructionAbridged",
  "materials": [
    "Generic Acoustic Tile",
    "Generic Ceiling Air Gap",
    "Generic LW Concrete"
  ]
}), OpaqueConstructionAbridged.fromJS({
  "identifier": "Generic Ground Slab",
  "display_name": null,
  "user_data": null,
  "type": "OpaqueConstructionAbridged",
  "materials": [
    "Generic 50mm Insulation",
    "Generic HW Concrete"
  ]
}), OpaqueConstructionAbridged.fromJS({
  "identifier": "Generic Roof",
  "display_name": null,
  "user_data": null,
  "type": "OpaqueConstructionAbridged",
  "materials": [
    "Generic Roof Membrane",
    "Generic 50mm Insulation",
    "Generic LW Concrete",
    "Generic Ceiling Air Gap",
    "Generic Acoustic Tile"
  ]
}), OpaqueConstructionAbridged.fromJS({
  "identifier": "Generic Exterior Wall",
  "display_name": null,
  "user_data": null,
  "type": "OpaqueConstructionAbridged",
  "materials": [
    "Generic Brick",
    "Generic LW Concrete",
    "Generic 50mm Insulation",
    "Generic Wall Air Gap",
    "Generic Gypsum Board"
  ]
}), OpaqueConstructionAbridged.fromJS({
  "identifier": "Generic Underground Wall",
  "display_name": null,
  "user_data": null,
  "type": "OpaqueConstructionAbridged",
  "materials": [
    "Generic 50mm Insulation",
    "Generic HW Concrete",
    "Generic Wall Air Gap",
    "Generic Gypsum Board"
  ]
}), AirBoundaryConstructionAbridged.fromJS({
  "identifier": "Generic Air Boundary",
  "display_name": null,
  "user_data": null,
  "type": "AirBoundaryConstructionAbridged",
  "air_mixing_per_area": 0.1,
  "air_mixing_schedule": "Always On"
}), OpaqueConstructionAbridged.fromJS({
  "identifier": "Generic Underground Roof",
  "display_name": null,
  "user_data": null,
  "type": "OpaqueConstructionAbridged",
  "materials": [
    "Generic 50mm Insulation",
    "Generic HW Concrete",
    "Generic Ceiling Air Gap",
    "Generic Acoustic Tile"
  ]
}), WindowConstructionAbridged.fromJS({
  "identifier": "Generic Double Pane",
  "display_name": null,
  "user_data": null,
  "type": "WindowConstructionAbridged",
  "materials": [
    "Generic Low-e Glass",
    "Generic Window Air Gap",
    "Generic Clear Glass"
  ],
  "frame": null
}), OpaqueConstructionAbridged.fromJS({
  "identifier": "Generic Exterior Door",
  "display_name": null,
  "user_data": null,
  "type": "OpaqueConstructionAbridged",
  "materials": [
    "Generic Painted Metal",
    "Generic 25mm Insulation",
    "Generic Painted Metal"
  ]
})];
        this.wall_set = WallConstructionSetAbridged.fromJS({
  "interior_construction": "Generic Interior Wall",
  "exterior_construction": "Generic Exterior Wall",
  "ground_construction": "Generic Underground Wall",
  "type": "WallConstructionSetAbridged"
});
        this.floor_set = FloorConstructionSetAbridged.fromJS({
  "interior_construction": "Generic Interior Floor",
  "exterior_construction": "Generic Exposed Floor",
  "ground_construction": "Generic Ground Slab",
  "type": "FloorConstructionSetAbridged"
});
        this.roof_ceiling_set = RoofCeilingConstructionSetAbridged.fromJS({
  "interior_construction": "Generic Interior Ceiling",
  "exterior_construction": "Generic Roof",
  "ground_construction": "Generic Underground Roof",
  "type": "RoofCeilingConstructionSetAbridged"
});
        this.aperture_set = ApertureConstructionSetAbridged.fromJS({
  "type": "ApertureConstructionSetAbridged",
  "interior_construction": "Generic Single Pane",
  "window_construction": "Generic Double Pane",
  "skylight_construction": "Generic Double Pane",
  "operable_construction": "Generic Double Pane"
});
        this.door_set = DoorConstructionSetAbridged.fromJS({
  "type": "DoorConstructionSetAbridged",
  "interior_construction": "Generic Interior Door",
  "exterior_construction": "Generic Exterior Door",
  "overhead_construction": "Generic Exterior Door",
  "exterior_glass_construction": "Generic Double Pane",
  "interior_glass_construction": "Generic Single Pane"
});
        this.shade_construction = "Generic Shade";
        this.context_construction = "Generic Context";
        this.air_boundary_construction = "Generic Air Boundary";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(GlobalConstructionSet, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.materials = obj.materials;
            this.constructions = obj.constructions;
            this.wall_set = obj.wall_set;
            this.floor_set = obj.floor_set;
            this.roof_ceiling_set = obj.roof_ceiling_set;
            this.aperture_set = obj.aperture_set;
            this.door_set = obj.door_set;
            this.shade_construction = obj.shade_construction;
            this.context_construction = obj.context_construction;
            this.air_boundary_construction = obj.air_boundary_construction;
        }
    }


    static override fromJS(data: any): GlobalConstructionSet {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new GlobalConstructionSet();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["materials"] = this.materials;
        data["constructions"] = this.constructions;
        data["wall_set"] = this.wall_set;
        data["floor_set"] = this.floor_set;
        data["roof_ceiling_set"] = this.roof_ceiling_set;
        data["aperture_set"] = this.aperture_set;
        data["door_set"] = this.door_set;
        data["shade_construction"] = this.shade_construction;
        data["context_construction"] = this.context_construction;
        data["air_boundary_construction"] = this.air_boundary_construction;
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

