import { IsString, IsOptional, Matches, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { ApertureModifierSet } from "./ApertureModifierSet";
import { BSDF } from "./BSDF";
import { DoorModifierSet } from "./DoorModifierSet";
import { FloorModifierSet } from "./FloorModifierSet";
import { Glass } from "./Glass";
import { Glow } from "./Glow";
import { IDdRadianceBaseModel } from "./IDdRadianceBaseModel";
import { Light } from "./Light";
import { Metal } from "./Metal";
import { Mirror } from "./Mirror";
import { Plastic } from "./Plastic";
import { RoofCeilingModifierSet } from "./RoofCeilingModifierSet";
import { ShadeModifierSet } from "./ShadeModifierSet";
import { Trans } from "./Trans";
import { Void } from "./Void";
import { WallModifierSet } from "./WallModifierSet";

/** Set containing all radiance modifiers needed to create a radiance model. */
export class ModifierSet extends IDdRadianceBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^ModifierSet$/)
    type?: string;
	
    @IsInstance(WallModifierSet)
    @Type(() => WallModifierSet)
    @ValidateNested()
    @IsOptional()
    /** An optional WallModifierSet object for this ModifierSet. (default: None). */
    wall_set?: WallModifierSet;
	
    @IsInstance(FloorModifierSet)
    @Type(() => FloorModifierSet)
    @ValidateNested()
    @IsOptional()
    /** An optional FloorModifierSet object for this ModifierSet. (default: None). */
    floor_set?: FloorModifierSet;
	
    @IsInstance(RoofCeilingModifierSet)
    @Type(() => RoofCeilingModifierSet)
    @ValidateNested()
    @IsOptional()
    /** An optional RoofCeilingModifierSet object for this ModifierSet. (default: None). */
    roof_ceiling_set?: RoofCeilingModifierSet;
	
    @IsInstance(ApertureModifierSet)
    @Type(() => ApertureModifierSet)
    @ValidateNested()
    @IsOptional()
    /** An optional ApertureModifierSet object for this ModifierSet. (default: None). */
    aperture_set?: ApertureModifierSet;
	
    @IsInstance(DoorModifierSet)
    @Type(() => DoorModifierSet)
    @ValidateNested()
    @IsOptional()
    /** An optional DoorModifierSet object for this ModifierSet. (default: None). */
    door_set?: DoorModifierSet;
	
    @IsInstance(ShadeModifierSet)
    @Type(() => ShadeModifierSet)
    @ValidateNested()
    @IsOptional()
    /** An optional ShadeModifierSet object for this ModifierSet. (default: None). */
    shade_set?: ShadeModifierSet;
	
    @IsOptional()
    @Transform(({ value }) => {
      const item = value;
      if (item.type === 'Plastic') return Plastic.fromJS(item);
      else if (item.type === 'Glass') return Glass.fromJS(item);
      else if (item.type === 'BSDF') return BSDF.fromJS(item);
      else if (item.type === 'Glow') return Glow.fromJS(item);
      else if (item.type === 'Light') return Light.fromJS(item);
      else if (item.type === 'Trans') return Trans.fromJS(item);
      else if (item.type === 'Metal') return Metal.fromJS(item);
      else if (item.type === 'Void') return Void.fromJS(item);
      else if (item.type === 'Mirror') return Mirror.fromJS(item);
      else return item;
    })
    /** An optional Modifier to be used for all Faces with an AirBoundary face type. If None, it will be the honeybee generic air wall modifier. */
    air_boundary_modifier?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror);
	

    constructor() {
        super();
        this.type = "ModifierSet";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ModifierSet, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.wall_set = obj.wall_set;
            this.floor_set = obj.floor_set;
            this.roof_ceiling_set = obj.roof_ceiling_set;
            this.aperture_set = obj.aperture_set;
            this.door_set = obj.door_set;
            this.shade_set = obj.shade_set;
            this.air_boundary_modifier = obj.air_boundary_modifier;
        }
    }


    static override fromJS(data: any): ModifierSet {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ModifierSet();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["wall_set"] = this.wall_set;
        data["floor_set"] = this.floor_set;
        data["roof_ceiling_set"] = this.roof_ceiling_set;
        data["aperture_set"] = this.aperture_set;
        data["door_set"] = this.door_set;
        data["shade_set"] = this.shade_set;
        data["air_boundary_modifier"] = this.air_boundary_modifier;
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

