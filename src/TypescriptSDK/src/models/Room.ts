import { IsArray, IsInstance, ValidateNested, IsDefined, IsString, IsOptional, Matches, IsInt, Min, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { Face } from "./Face";
import { IDdBaseModel } from "./IDdBaseModel";
import { RoomPropertiesAbridged } from "./RoomPropertiesAbridged";
import { Shade } from "./Shade";

/** Base class for all objects requiring a identifiers acceptable for all engines. */
export class Room extends IDdBaseModel {
    @IsArray()
    @IsInstance(Face, { each: true })
    @Type(() => Face)
    @ValidateNested({ each: true })
    @IsDefined()
    @Expose({ name: "faces" })
    /** Faces that together form the closed volume of a room. */
    faces!: Face[];
	
    @IsInstance(RoomPropertiesAbridged)
    @Type(() => RoomPropertiesAbridged)
    @ValidateNested()
    @IsDefined()
    @Expose({ name: "properties" })
    /** Extension properties for particular simulation engines (Radiance, EnergyPlus). */
    properties!: RoomPropertiesAbridged;
	
    @IsString()
    @IsOptional()
    @Matches(/^Room$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "Room";
	
    @IsArray()
    @IsInstance(Shade, { each: true })
    @Type(() => Shade)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "indoor_shades" })
    /** Shades assigned to the interior side of this object (eg. partitions, tables). */
    indoorShades?: Shade[];
	
    @IsArray()
    @IsInstance(Shade, { each: true })
    @Type(() => Shade)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "outdoor_shades" })
    /** Shades assigned to the exterior side of this object (eg. trees, landscaping). */
    outdoorShades?: Shade[];
	
    @IsInt()
    @IsOptional()
    @Min(1)
    @Expose({ name: "multiplier" })
    /** An integer noting how many times this Room is repeated. Multipliers are used to speed up the calculation when similar Rooms are repeated more than once. Essentially, a given simulation with the Room is run once and then the result is multiplied by the multiplier. */
    multiplier: number = 1;
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "exclude_floor_area" })
    /** A boolean for whether the Room floor area contributes to Models it is a part of. Note that this will not affect the floor_area property of this Room itself but it will ensure the Room floor area is excluded from any calculations when the Room is part of a Model, including EUI calculations. */
    excludeFloorArea: boolean = false;
	
    @IsString()
    @IsOptional()
    @Expose({ name: "zone" })
    /** Text string for for the zone identifier to which this Room belongs. Rooms sharing the same zone identifier are considered part of the same zone in a Model. If the zone identifier has not been specified, it will be the same as the Room identifier in the destination engine. Note that this property has no character restrictions. */
    zone?: string;
	
    @IsString()
    @IsOptional()
    @Expose({ name: "story" })
    /** Text string for the story identifier to which this Room belongs. Rooms sharing the same story identifier are considered part of the same story in a Model. Note that this property has no character restrictions. */
    story?: string;
	

    constructor() {
        super();
        this.type = "Room";
        this.multiplier = 1;
        this.excludeFloorArea = false;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(Room, _data);
            this.faces = obj.faces;
            this.properties = obj.properties;
            this.type = obj.type ?? "Room";
            this.indoorShades = obj.indoorShades;
            this.outdoorShades = obj.outdoorShades;
            this.multiplier = obj.multiplier ?? 1;
            this.excludeFloorArea = obj.excludeFloorArea ?? false;
            this.zone = obj.zone;
            this.story = obj.story;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
            this.userData = obj.userData;
        }
    }


    static override fromJS(data: any): Room {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new Room();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["faces"] = this.faces;
        data["properties"] = this.properties;
        data["type"] = this.type ?? "Room";
        data["indoor_shades"] = this.indoorShades;
        data["outdoor_shades"] = this.outdoorShades;
        data["multiplier"] = this.multiplier ?? 1;
        data["exclude_floor_area"] = this.excludeFloorArea ?? false;
        data["zone"] = this.zone;
        data["story"] = this.story;
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
