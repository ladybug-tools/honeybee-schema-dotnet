import { IsString, IsOptional, Matches, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
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
    /** Type */
    type?: string;
	
    @IsInstance(WallModifierSetAbridged)
    @Type(() => WallModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Optional WallModifierSet object for this ModifierSet (default: None). */
    wall_set?: WallModifierSetAbridged;
	
    @IsInstance(FloorModifierSetAbridged)
    @Type(() => FloorModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Optional FloorModifierSet object for this ModifierSet (default: None). */
    floor_set?: FloorModifierSetAbridged;
	
    @IsInstance(RoofCeilingModifierSetAbridged)
    @Type(() => RoofCeilingModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Optional RoofCeilingModifierSet object for this ModifierSet (default: None). */
    roof_ceiling_set?: RoofCeilingModifierSetAbridged;
	
    @IsInstance(ApertureModifierSetAbridged)
    @Type(() => ApertureModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Optional ApertureModifierSet object for this ModifierSet (default: None). */
    aperture_set?: ApertureModifierSetAbridged;
	
    @IsInstance(DoorModifierSetAbridged)
    @Type(() => DoorModifierSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** Optional DoorModifierSet object for this ModifierSet (default: None). */
    door_set?: DoorModifierSetAbridged;
	
    @IsInstance(ShadeModifierSetAbridged)
    @Type(() => ShadeModifierSetAbridged)
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
            const obj = plainToClass(ModifierSetAbridged, _data, { enableImplicitConversion: true });
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

