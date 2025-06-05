import { IsString, IsOptional, Matches, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { ApertureModifierSetAbridged } from "./ApertureModifierSetAbridged";
import { DoorModifierSetAbridged } from "./DoorModifierSetAbridged";
import { FloorModifierSetAbridged } from "./FloorModifierSetAbridged";
import { IDdRadianceBaseModel } from "./IDdRadianceBaseModel";
import { RoofCeilingModifierSetAbridged } from "./RoofCeilingModifierSetAbridged";
import { ShadeModifierSetAbridged } from "./ShadeModifierSetAbridged";
import { WallModifierSetAbridged } from "./WallModifierSetAbridged";

/** Abridged set containing all modifiers needed to create a radiance model. */
export class ModifierSetAbridged extends IDdRadianceBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^ModifierSetAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ModifierSetAbridged";
	
    @IsInstance(WallModifierSetAbridged)
    @Type(() => WallModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "wall_set" })
    /** Optional WallModifierSet object for this ModifierSet (default: None). */
    wallSet?: WallModifierSetAbridged;
	
    @IsInstance(FloorModifierSetAbridged)
    @Type(() => FloorModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "floor_set" })
    /** Optional FloorModifierSet object for this ModifierSet (default: None). */
    floorSet?: FloorModifierSetAbridged;
	
    @IsInstance(RoofCeilingModifierSetAbridged)
    @Type(() => RoofCeilingModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "roof_ceiling_set" })
    /** Optional RoofCeilingModifierSet object for this ModifierSet (default: None). */
    roofCeilingSet?: RoofCeilingModifierSetAbridged;
	
    @IsInstance(ApertureModifierSetAbridged)
    @Type(() => ApertureModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "aperture_set" })
    /** Optional ApertureModifierSet object for this ModifierSet (default: None). */
    apertureSet?: ApertureModifierSetAbridged;
	
    @IsInstance(DoorModifierSetAbridged)
    @Type(() => DoorModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "door_set" })
    /** Optional DoorModifierSet object for this ModifierSet (default: None). */
    doorSet?: DoorModifierSetAbridged;
	
    @IsInstance(ShadeModifierSetAbridged)
    @Type(() => ShadeModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "shade_set" })
    /** Optional ShadeModifierSet object for this ModifierSet (default: None). */
    shadeSet?: ShadeModifierSetAbridged;
	
    @IsString()
    @IsOptional()
    @Expose({ name: "air_boundary_modifier" })
    /** Optional Modifier to be used for all Faces with an AirBoundary face type. If None, it will be the honeybee generic air wall modifier. */
    airBoundaryModifier?: string;
	

    constructor() {
        super();
        this.type = "ModifierSetAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ModifierSetAbridged, _data, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
            this.type = obj.type ?? "ModifierSetAbridged";
            this.wallSet = obj.wallSet;
            this.floorSet = obj.floorSet;
            this.roofCeilingSet = obj.roofCeilingSet;
            this.apertureSet = obj.apertureSet;
            this.doorSet = obj.doorSet;
            this.shadeSet = obj.shadeSet;
            this.airBoundaryModifier = obj.airBoundaryModifier;
        }
    }


    static override fromJS(data: any): ModifierSetAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ModifierSetAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "ModifierSetAbridged";
        data["wall_set"] = this.wallSet;
        data["floor_set"] = this.floorSet;
        data["roof_ceiling_set"] = this.roofCeilingSet;
        data["aperture_set"] = this.apertureSet;
        data["door_set"] = this.doorSet;
        data["shade_set"] = this.shadeSet;
        data["air_boundary_modifier"] = this.airBoundaryModifier;
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
