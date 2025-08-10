import { IsString, IsOptional, Matches, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
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
    @Expose({ name: "type" })
    /** type */
    type: string = "ConstructionSet";
	
    @IsInstance(WallConstructionSet)
    @Type(() => WallConstructionSet)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "wall_set" })
    /** A WallConstructionSet object for this ConstructionSet. */
    wallSet?: WallConstructionSet;
	
    @IsInstance(FloorConstructionSet)
    @Type(() => FloorConstructionSet)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "floor_set" })
    /** A FloorConstructionSet object for this ConstructionSet. */
    floorSet?: FloorConstructionSet;
	
    @IsInstance(RoofCeilingConstructionSet)
    @Type(() => RoofCeilingConstructionSet)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "roof_ceiling_set" })
    /** A RoofCeilingConstructionSet object for this ConstructionSet. */
    roofCeilingSet?: RoofCeilingConstructionSet;
	
    @IsInstance(ApertureConstructionSet)
    @Type(() => ApertureConstructionSet)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "aperture_set" })
    /** A ApertureConstructionSet object for this ConstructionSet. */
    apertureSet?: ApertureConstructionSet;
	
    @IsInstance(DoorConstructionSet)
    @Type(() => DoorConstructionSet)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "door_set" })
    /** A DoorConstructionSet object for this ConstructionSet. */
    doorSet?: DoorConstructionSet;
	
    @IsInstance(ShadeConstruction)
    @Type(() => ShadeConstruction)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "shade_construction" })
    /** A ShadeConstruction to set the reflectance properties of all outdoor shades of all objects to which this ConstructionSet is assigned. */
    shadeConstruction?: ShadeConstruction;
	
    @IsOptional()
    @Expose({ name: "air_boundary_construction" })
    @Transform(({ value }) => {
      const item = value;
      if (item?.type === 'AirBoundaryConstruction') return AirBoundaryConstruction.fromJS(item);
      else if (item?.type === 'OpaqueConstruction') return OpaqueConstruction.fromJS(item);
      else return item;
    })
    /** An AirBoundaryConstruction or OpaqueConstruction to set the properties of Faces with an AirBoundary type. */
    airBoundaryConstruction?: (AirBoundaryConstruction | OpaqueConstruction);
	

    constructor() {
        super();
        this.type = "ConstructionSet";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(ConstructionSet, _data);
            this.type = obj.type ?? "ConstructionSet";
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
        data["type"] = this.type ?? "ConstructionSet";
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
