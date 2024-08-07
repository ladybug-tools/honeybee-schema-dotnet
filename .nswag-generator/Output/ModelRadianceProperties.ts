import { IsString, IsOptional, IsInstance, ValidateNested, IsArray, validate, ValidationError } from 'class-validator';
import { GlobalModifierSet } from "./GlobalModifierSet";
import { SensorGrid } from "./SensorGrid";
import { View } from "./View";
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Radiance Properties for Honeybee Model. */
export class ModelRadianceProperties extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsInstance(GlobalModifierSet)
    @ValidateNested()
    @IsOptional()
    /** Global Radiance modifier set. */
    global_modifier_set?: GlobalModifierSet;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of all unique modifiers in the model. This includes modifiers across all Faces, Apertures, Doors, Shades, Room ModifierSets, and the global_modifier_set. */
    modifiers?: None [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of all unique Room-Assigned ModifierSets in the Model. */
    modifier_sets?: None [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** An array of SensorGrids that are associated with the model. */
    sensor_grids?: SensorGrid [];
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** An array of Views that are associated with the model. */
    views?: View [];
	

    constructor() {
        super();
        this.type = "ModelRadianceProperties";
        this.global_modifier_set = new GlobalModifierSet();
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "ModelRadianceProperties";
            this.global_modifier_set = _data["global_modifier_set"] !== undefined ? _data["global_modifier_set"] : new GlobalModifierSet();
            this.modifiers = _data["modifiers"];
            this.modifier_sets = _data["modifier_sets"];
            this.sensor_grids = _data["sensor_grids"];
            this.views = _data["views"];
        }
    }


    static override fromJS(data: any): ModelRadianceProperties {
        data = typeof data === 'object' ? data : {};

        let result = new ModelRadianceProperties();
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
        data["global_modifier_set"] = this.global_modifier_set;
        data["modifiers"] = this.modifiers;
        data["modifier_sets"] = this.modifier_sets;
        data["sensor_grids"] = this.sensor_grids;
        data["views"] = this.views;
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
