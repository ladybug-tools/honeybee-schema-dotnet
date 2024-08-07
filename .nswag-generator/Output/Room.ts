import { IsArray, ValidateNested, IsDefined, IsInstance, IsString, IsOptional, IsInt, validate, ValidationError } from 'class-validator';
import { Face } from "./Face";
import { RoomPropertiesAbridged } from "./RoomPropertiesAbridged";
import { Shade } from "./Shade";
import { IDdBaseModel } from "./IDdBaseModel";

/** Base class for all objects requiring a identifiers acceptable for all engines. */
export class Room extends IDdBaseModel {
    @IsArray()
    @ValidateNested({ each: true })
    @IsDefined()
    /** Faces that together form the closed volume of a room. */
    faces!: Face [];
	
    @IsInstance(RoomPropertiesAbridged)
    @ValidateNested()
    @IsDefined()
    /** Extension properties for particular simulation engines (Radiance, EnergyPlus). */
    properties!: RoomPropertiesAbridged;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** Shades assigned to the interior side of this object (eg. partitions, tables). */
    indoor_shades?: Shade [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** Shades assigned to the exterior side of this object (eg. trees, landscaping). */
    outdoor_shades?: Shade [];
	
    @IsInt()
    @IsOptional()
    /** An integer noting how many times this Room is repeated. Multipliers are used to speed up the calculation when similar Rooms are repeated more than once. Essentially, a given simulation with the Room is run once and then the result is multiplied by the multiplier. */
    multiplier?: number;
	
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
        this.exclude_floor_area = False;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.faces = _data["faces"];
            this.properties = _data["properties"];
            this.type = _data["type"] !== undefined ? _data["type"] : "Room";
            this.indoor_shades = _data["indoor_shades"];
            this.outdoor_shades = _data["outdoor_shades"];
            this.multiplier = _data["multiplier"] !== undefined ? _data["multiplier"] : 1;
            this.exclude_floor_area = _data["exclude_floor_area"] !== undefined ? _data["exclude_floor_area"] : False;
            this.story = _data["story"];
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
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["faces"] = this.faces;
        data["properties"] = this.properties;
        data["type"] = this.type;
        data["indoor_shades"] = this.indoor_shades;
        data["outdoor_shades"] = this.outdoor_shades;
        data["multiplier"] = this.multiplier;
        data["exclude_floor_area"] = this.exclude_floor_area;
        data["story"] = this.story;
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
