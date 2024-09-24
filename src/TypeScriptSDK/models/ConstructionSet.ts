import { IsString, IsOptional, Matches, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { AirBoundaryConstruction } from "./AirBoundaryConstruction";
import { ApertureConstructionSet } from "./ApertureConstructionSet";
import { DoorConstructionSet } from "./DoorConstructionSet";
import { FloorConstructionSet } from "./FloorConstructionSet";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { OpaqueConstruction } from "./OpaqueConstruction";
import { RoofCeilingConstructionSet } from "./RoofCeilingConstructionSet";
import { ShadeConstruction } from "./ShadeConstruction";
import { WallConstructionSet } from "./WallConstructionSet";

/** A set of constructions for different surface types and boundary conditions. */
export class ConstructionSet extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^ConstructionSet$/)
    type?: string;
	
    @IsInstance(WallConstructionSet)
    @Type(() => WallConstructionSet)
    @ValidateNested()
    @IsOptional()
    /** A WallConstructionSet object for this ConstructionSet. */
    wall_set?: WallConstructionSet;
	
    @IsInstance(FloorConstructionSet)
    @Type(() => FloorConstructionSet)
    @ValidateNested()
    @IsOptional()
    /** A FloorConstructionSet object for this ConstructionSet. */
    floor_set?: FloorConstructionSet;
	
    @IsInstance(RoofCeilingConstructionSet)
    @Type(() => RoofCeilingConstructionSet)
    @ValidateNested()
    @IsOptional()
    /** A RoofCeilingConstructionSet object for this ConstructionSet. */
    roof_ceiling_set?: RoofCeilingConstructionSet;
	
    @IsInstance(ApertureConstructionSet)
    @Type(() => ApertureConstructionSet)
    @ValidateNested()
    @IsOptional()
    /** A ApertureConstructionSet object for this ConstructionSet. */
    aperture_set?: ApertureConstructionSet;
	
    @IsInstance(DoorConstructionSet)
    @Type(() => DoorConstructionSet)
    @ValidateNested()
    @IsOptional()
    /** A DoorConstructionSet object for this ConstructionSet. */
    door_set?: DoorConstructionSet;
	
    @IsInstance(ShadeConstruction)
    @Type(() => ShadeConstruction)
    @ValidateNested()
    @IsOptional()
    /** A ShadeConstruction to set the reflectance properties of all outdoor shades of all objects to which this ConstructionSet is assigned. */
    shade_construction?: ShadeConstruction;
	
    @IsOptional()
    @Transform(({ value }) => {
      const item = value;
      if (item.type === 'AirBoundaryConstruction') return AirBoundaryConstruction.fromJS(item);
      else if (item.type === 'OpaqueConstruction') return OpaqueConstruction.fromJS(item);
      else return item;
    })
    /** An AirBoundaryConstruction or OpaqueConstruction to set the properties of Faces with an AirBoundary type. */
    air_boundary_construction?: (AirBoundaryConstruction | OpaqueConstruction);
	

    constructor() {
        super();
        this.type = "ConstructionSet";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ConstructionSet, _data, { enableImplicitConversion: true });
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


    static override fromJS(data: any): ConstructionSet {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ConstructionSet();
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

