import { IsString, IsOptional, Matches, IsInstance, ValidateNested, MinLength, MaxLength, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
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
    @Expose({ name: "type" })
    /** type */
    type: string = "ConstructionSetAbridged";
	
    @IsInstance(WallConstructionSetAbridged)
    @Type(() => WallConstructionSetAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "wall_set" })
    /** A WallConstructionSetAbridged object for this ConstructionSet. */
    wallSet?: WallConstructionSetAbridged;
	
    @IsInstance(FloorConstructionSetAbridged)
    @Type(() => FloorConstructionSetAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "floor_set" })
    /** A FloorConstructionSetAbridged object for this ConstructionSet. */
    floorSet?: FloorConstructionSetAbridged;
	
    @IsInstance(RoofCeilingConstructionSetAbridged)
    @Type(() => RoofCeilingConstructionSetAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "roof_ceiling_set" })
    /** A RoofCeilingConstructionSetAbridged object for this ConstructionSet. */
    roofCeilingSet?: RoofCeilingConstructionSetAbridged;
	
    @IsInstance(ApertureConstructionSetAbridged)
    @Type(() => ApertureConstructionSetAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "aperture_set" })
    /** A ApertureConstructionSetAbridged object for this ConstructionSet. */
    apertureSet?: ApertureConstructionSetAbridged;
	
    @IsInstance(DoorConstructionSetAbridged)
    @Type(() => DoorConstructionSetAbridged)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "door_set" })
    /** A DoorConstructionSetAbridged object for this ConstructionSet. */
    doorSet?: DoorConstructionSetAbridged;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "shade_construction" })
    /** The identifier of a ShadeConstruction to set the reflectance properties of all outdoor shades of all objects to which this ConstructionSet is assigned. */
    shadeConstruction?: string;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "air_boundary_construction" })
    /** The identifier of an AirBoundaryConstruction or OpaqueConstruction to set the properties of Faces with an AirBoundary type. */
    airBoundaryConstruction?: string;
	

    constructor() {
        super();
        this.type = "ConstructionSetAbridged";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(ConstructionSetAbridged, _data);
            this.type = obj.type ?? "ConstructionSetAbridged";
            this.wallSet = obj.wallSet;
            this.floorSet = obj.floorSet;
            this.roofCeilingSet = obj.roofCeilingSet;
            this.apertureSet = obj.apertureSet;
            this.doorSet = obj.doorSet;
            this.shadeConstruction = obj.shadeConstruction;
            this.airBoundaryConstruction = obj.airBoundaryConstruction;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
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
        data["type"] = this.type ?? "ConstructionSetAbridged";
        data["wall_set"] = this.wallSet;
        data["floor_set"] = this.floorSet;
        data["roof_ceiling_set"] = this.roofCeilingSet;
        data["aperture_set"] = this.apertureSet;
        data["door_set"] = this.doorSet;
        data["shade_construction"] = this.shadeConstruction;
        data["air_boundary_construction"] = this.airBoundaryConstruction;
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
