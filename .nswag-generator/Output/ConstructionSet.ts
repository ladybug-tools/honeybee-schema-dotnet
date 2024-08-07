import { IsString, IsOptional, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { WallConstructionSet } from "./WallConstructionSet";
import { FloorConstructionSet } from "./FloorConstructionSet";
import { RoofCeilingConstructionSet } from "./RoofCeilingConstructionSet";
import { ApertureConstructionSet } from "./ApertureConstructionSet";
import { DoorConstructionSet } from "./DoorConstructionSet";
import { ShadeConstruction } from "./ShadeConstruction";
import { AirBoundaryConstruction } from "./AirBoundaryConstruction";
import { OpaqueConstruction } from "./OpaqueConstruction";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** A set of constructions for different surface types and boundary conditions. */
export class ConstructionSet extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsInstance(WallConstructionSet)
    @ValidateNested()
    @IsOptional()
    /** A WallConstructionSet object for this ConstructionSet. */
    wall_set?: WallConstructionSet;
	
    @IsInstance(FloorConstructionSet)
    @ValidateNested()
    @IsOptional()
    /** A FloorConstructionSet object for this ConstructionSet. */
    floor_set?: FloorConstructionSet;
	
    @IsInstance(RoofCeilingConstructionSet)
    @ValidateNested()
    @IsOptional()
    /** A RoofCeilingConstructionSet object for this ConstructionSet. */
    roof_ceiling_set?: RoofCeilingConstructionSet;
	
    @IsInstance(ApertureConstructionSet)
    @ValidateNested()
    @IsOptional()
    /** A ApertureConstructionSet object for this ConstructionSet. */
    aperture_set?: ApertureConstructionSet;
	
    @IsInstance(DoorConstructionSet)
    @ValidateNested()
    @IsOptional()
    /** A DoorConstructionSet object for this ConstructionSet. */
    door_set?: DoorConstructionSet;
	
    @IsInstance(ShadeConstruction)
    @ValidateNested()
    @IsOptional()
    /** A ShadeConstruction to set the reflectance properties of all outdoor shades of all objects to which this ConstructionSet is assigned. */
    shade_construction?: ShadeConstruction;
	
    @IsOptional()
    /** An AirBoundaryConstruction or OpaqueConstruction to set the properties of Faces with an AirBoundary type. */
    air_boundary_construction?: (AirBoundaryConstruction | OpaqueConstruction);
	

    constructor() {
        super();
        this.type = "ConstructionSet";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "ConstructionSet";
            this.wall_set = _data["wall_set"];
            this.floor_set = _data["floor_set"];
            this.roof_ceiling_set = _data["roof_ceiling_set"];
            this.aperture_set = _data["aperture_set"];
            this.door_set = _data["door_set"];
            this.shade_construction = _data["shade_construction"];
            this.air_boundary_construction = _data["air_boundary_construction"];
        }
    }


    static override fromJS(data: any): ConstructionSet {
        data = typeof data === 'object' ? data : {};

        let result = new ConstructionSet();
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
        data["wall_set"] = this.wall_set;
        data["floor_set"] = this.floor_set;
        data["roof_ceiling_set"] = this.roof_ceiling_set;
        data["aperture_set"] = this.aperture_set;
        data["door_set"] = this.door_set;
        data["shade_construction"] = this.shade_construction;
        data["air_boundary_construction"] = this.air_boundary_construction;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
