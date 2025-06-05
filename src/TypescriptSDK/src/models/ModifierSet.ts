import { IsString, IsOptional, Matches, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
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
    @Expose({ name: "type" })
    /** type */
    type: string = "ModifierSet";
	
    @IsInstance(WallModifierSet)
    @Type(() => WallModifierSet)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "wall_set" })
    /** An optional WallModifierSet object for this ModifierSet. (default: None). */
    wallSet?: WallModifierSet;
	
    @IsInstance(FloorModifierSet)
    @Type(() => FloorModifierSet)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "floor_set" })
    /** An optional FloorModifierSet object for this ModifierSet. (default: None). */
    floorSet?: FloorModifierSet;
	
    @IsInstance(RoofCeilingModifierSet)
    @Type(() => RoofCeilingModifierSet)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "roof_ceiling_set" })
    /** An optional RoofCeilingModifierSet object for this ModifierSet. (default: None). */
    roofCeilingSet?: RoofCeilingModifierSet;
	
    @IsInstance(ApertureModifierSet)
    @Type(() => ApertureModifierSet)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "aperture_set" })
    /** An optional ApertureModifierSet object for this ModifierSet. (default: None). */
    apertureSet?: ApertureModifierSet;
	
    @IsInstance(DoorModifierSet)
    @Type(() => DoorModifierSet)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "door_set" })
    /** An optional DoorModifierSet object for this ModifierSet. (default: None). */
    doorSet?: DoorModifierSet;
	
    @IsInstance(ShadeModifierSet)
    @Type(() => ShadeModifierSet)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "shade_set" })
    /** An optional ShadeModifierSet object for this ModifierSet. (default: None). */
    shadeSet?: ShadeModifierSet;
	
    @IsOptional()
    @Expose({ name: "air_boundary_modifier" })
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'Plastic') return Plastic.fromJS(item);
      else if (item?.type === 'Glass') return Glass.fromJS(item);
      else if (item?.type === 'BSDF') return BSDF.fromJS(item);
      else if (item?.type === 'Glow') return Glow.fromJS(item);
      else if (item?.type === 'Light') return Light.fromJS(item);
      else if (item?.type === 'Trans') return Trans.fromJS(item);
      else if (item?.type === 'Metal') return Metal.fromJS(item);
      else if (item?.type === 'Void') return Void.fromJS(item);
      else if (item?.type === 'Mirror') return Mirror.fromJS(item);
      else return item;
    })
    /** An optional Modifier to be used for all Faces with an AirBoundary face type. If None, it will be the honeybee generic air wall modifier. */
    airBoundaryModifier?: (Plastic | Glass | BSDF | Glow | Light | Trans | Metal | Void | Mirror);
	

    constructor() {
        super();
        this.type = "ModifierSet";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ModifierSet, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.wallSet = obj.wallSet;
            this.floorSet = obj.floorSet;
            this.roofCeilingSet = obj.roofCeilingSet;
            this.apertureSet = obj.apertureSet;
            this.doorSet = obj.doorSet;
            this.shadeSet = obj.shadeSet;
            this.airBoundaryModifier = obj.airBoundaryModifier;
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
        data["wall_set"] = this.wallSet;
        data["floor_set"] = this.floorSet;
        data["roof_ceiling_set"] = this.roofCeilingSet;
        data["aperture_set"] = this.apertureSet;
        data["door_set"] = this.doorSet;
        data["shade_set"] = this.shadeSet;
        data["air_boundary_modifier"] = this.airBoundaryModifier;
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
