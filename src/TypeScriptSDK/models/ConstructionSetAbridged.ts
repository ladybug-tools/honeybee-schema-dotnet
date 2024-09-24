import { IsString, IsOptional, Matches, IsInstance, ValidateNested, MinLength, MaxLength, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { ApertureConstructionSetAbridged } from "./ApertureConstructionSetAbridged";
import { DoorConstructionSetAbridged } from "./DoorConstructionSetAbridged";
import { FloorConstructionSetAbridged } from "./FloorConstructionSetAbridged";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { RoofCeilingConstructionSetAbridged } from "./RoofCeilingConstructionSetAbridged";
import { WallConstructionSetAbridged } from "./WallConstructionSetAbridged";

/** A set of constructions for different surface types and boundary conditions. */
export class ConstructionSetAbridged extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^ConstructionSetAbridged$/)
    type?: string;
	
    @IsInstance(WallConstructionSetAbridged)
    @Type(() => WallConstructionSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** A WallConstructionSetAbridged object for this ConstructionSet. */
    wall_set?: WallConstructionSetAbridged;
	
    @IsInstance(FloorConstructionSetAbridged)
    @Type(() => FloorConstructionSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** A FloorConstructionSetAbridged object for this ConstructionSet. */
    floor_set?: FloorConstructionSetAbridged;
	
    @IsInstance(RoofCeilingConstructionSetAbridged)
    @Type(() => RoofCeilingConstructionSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** A RoofCeilingConstructionSetAbridged object for this ConstructionSet. */
    roof_ceiling_set?: RoofCeilingConstructionSetAbridged;
	
    @IsInstance(ApertureConstructionSetAbridged)
    @Type(() => ApertureConstructionSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** A ApertureConstructionSetAbridged object for this ConstructionSet. */
    aperture_set?: ApertureConstructionSetAbridged;
	
    @IsInstance(DoorConstructionSetAbridged)
    @Type(() => DoorConstructionSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** A DoorConstructionSetAbridged object for this ConstructionSet. */
    door_set?: DoorConstructionSetAbridged;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    /** The identifier of a ShadeConstruction to set the reflectance properties of all outdoor shades of all objects to which this ConstructionSet is assigned. */
    shade_construction?: string;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    /** The identifier of an AirBoundaryConstruction or OpaqueConstruction to set the properties of Faces with an AirBoundary type. */
    air_boundary_construction?: string;
	

    constructor() {
        super();
        this.type = "ConstructionSetAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ConstructionSetAbridged, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.wall_set = obj.wall_set;
            this.floor_set = obj.floor_set;
            this.roof_ceiling_set = obj.roof_ceiling_set;
            this.aperture_set = obj.aperture_set;
            this.door_set = obj.door_set;
            this.shade_construction = obj.shade_construction;
            this.air_boundary_construction = obj.air_boundary_construction;
        }
    }


    static override fromJS(data: any): ConstructionSetAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ConstructionSetAbridged();
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
        data["shade_construction"] = this.shade_construction;
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

