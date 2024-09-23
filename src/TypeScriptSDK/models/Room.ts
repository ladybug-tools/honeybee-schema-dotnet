import { IsArray, IsInstance, ValidateNested, IsDefined, IsString, IsOptional, Matches, IsInt, Min, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
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
    /** Faces that together form the closed volume of a room. */
    faces!: Face [];
	
    @IsInstance(RoomPropertiesAbridged)
    @Type(() => RoomPropertiesAbridged)
    @ValidateNested()
    @IsDefined()
    /** Extension properties for particular simulation engines (Radiance, EnergyPlus). */
    properties!: RoomPropertiesAbridged;
	
    @IsString()
    @IsOptional()
    @Matches(/^Room$/)
    type?: string;
	
    @IsArray()
    @IsInstance(Shade, { each: true })
    @Type(() => Shade)
    @ValidateNested({ each: true })
    @IsOptional()
    /** Shades assigned to the interior side of this object (eg. partitions, tables). */
    indoor_shades?: Shade [];
	
    @IsArray()
    @IsInstance(Shade, { each: true })
    @Type(() => Shade)
    @ValidateNested({ each: true })
    @IsOptional()
    /** Shades assigned to the exterior side of this object (eg. trees, landscaping). */
    outdoor_shades?: Shade [];
	
    @IsInt()
    @IsOptional()
    @Min(1)
    /** An integer noting how many times this Room is repeated. Multipliers are used to speed up the calculation when similar Rooms are repeated more than once. Essentially, a given simulation with the Room is run once and then the result is multiplied by the multiplier. */
    multiplier?: number;
	
    @IsBoolean()
    @IsOptional()
    /** A boolean for whether the Room floor area contributes to Models it is a part of. Note that this will not affect the floor_area property of this Room itself but it will ensure the Room floor area is excluded from any calculations when the Room is part of a Model, including EUI calculations. */
    exclude_floor_area?: boolean;
	
    @IsString()
    @IsOptional()
    /** Text string for the story identifier to which this Room belongs. Rooms sharing the same story identifier are considered part of the same story in a Model. Note that this property has no character restrictions. */
    story?: string;
	

    constructor() {
        super();
        this.type = "Room";
        this.multiplier = 1;
        this.exclude_floor_area = false;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(Room, _data);
            this.faces = obj.faces;
            this.properties = obj.properties;
            this.type = obj.type;
            this.indoor_shades = obj.indoor_shades;
            this.outdoor_shades = obj.outdoor_shades;
            this.multiplier = obj.multiplier;
            this.exclude_floor_area = obj.exclude_floor_area;
            this.story = obj.story;
        }
    }


    static override fromJS(data: any): Room {
        data = typeof data === 'object' ? data : {};

        let result = new Room();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["faces"] = this.faces;
        data["properties"] = this.properties;
        data["type"] = this.type;
        data["indoor_shades"] = this.indoor_shades;
        data["outdoor_shades"] = this.outdoor_shades;
        data["multiplier"] = this.multiplier;
        data["exclude_floor_area"] = this.exclude_floor_area;
        data["story"] = this.story;
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

