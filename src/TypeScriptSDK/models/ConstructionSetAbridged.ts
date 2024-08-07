import { IsString, IsOptional, IsInstance, ValidateNested, validate, ValidationError } from 'class-validator';
import { WallConstructionSetAbridged } from "./WallConstructionSetAbridged";
import { FloorConstructionSetAbridged } from "./FloorConstructionSetAbridged";
import { RoofCeilingConstructionSetAbridged } from "./RoofCeilingConstructionSetAbridged";
import { ApertureConstructionSetAbridged } from "./ApertureConstructionSetAbridged";
import { DoorConstructionSetAbridged } from "./DoorConstructionSetAbridged";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** A set of constructions for different surface types and boundary conditions. */
export class ConstructionSetAbridged extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsInstance(WallConstructionSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** A WallConstructionSetAbridged object for this ConstructionSet. */
    wall_set?: WallConstructionSetAbridged;
	
    @IsInstance(FloorConstructionSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** A FloorConstructionSetAbridged object for this ConstructionSet. */
    floor_set?: FloorConstructionSetAbridged;
	
    @IsInstance(RoofCeilingConstructionSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** A RoofCeilingConstructionSetAbridged object for this ConstructionSet. */
    roof_ceiling_set?: RoofCeilingConstructionSetAbridged;
	
    @IsInstance(ApertureConstructionSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** A ApertureConstructionSetAbridged object for this ConstructionSet. */
    aperture_set?: ApertureConstructionSetAbridged;
	
    @IsInstance(DoorConstructionSetAbridged)
    @ValidateNested()
    @IsOptional()
    /** A DoorConstructionSetAbridged object for this ConstructionSet. */
    door_set?: DoorConstructionSetAbridged;
	
    @IsString()
    @IsOptional()
    /** The identifier of a ShadeConstruction to set the reflectance properties of all outdoor shades of all objects to which this ConstructionSet is assigned. */
    shade_construction?: string;
	
    @IsString()
    @IsOptional()
    /** The identifier of an AirBoundaryConstruction or OpaqueConstruction to set the properties of Faces with an AirBoundary type. */
    air_boundary_construction?: string;
	

    constructor() {
        super();
        this.type = "ConstructionSetAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "ConstructionSetAbridged";
            this.wall_set = _data["wall_set"];
            this.floor_set = _data["floor_set"];
            this.roof_ceiling_set = _data["roof_ceiling_set"];
            this.aperture_set = _data["aperture_set"];
            this.door_set = _data["door_set"];
            this.shade_construction = _data["shade_construction"];
            this.air_boundary_construction = _data["air_boundary_construction"];
        }
    }


    static override fromJS(data: any): ConstructionSetAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new ConstructionSetAbridged();
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
			const errorMessages = errors.map((error: ValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
