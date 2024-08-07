import { IsString, IsOptional, validate, ValidationError } from 'class-validator';
import { WindowConstruction } from "./WindowConstruction";
import { WindowConstructionShade } from "./WindowConstructionShade";
import { WindowConstructionDynamic } from "./WindowConstructionDynamic";
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** A set of constructions for aperture assemblies. */
export class ApertureConstructionSet extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsOptional()
    /** A WindowConstruction for all apertures with a Surface boundary condition. */
    interior_construction?: (WindowConstruction | WindowConstructionShade | WindowConstructionDynamic);
	
    @IsOptional()
    /** A WindowConstruction for apertures with an Outdoors boundary condition, False is_operable property, and a Wall face type for their parent face. */
    window_construction?: (WindowConstruction | WindowConstructionShade | WindowConstructionDynamic);
	
    @IsOptional()
    /** A WindowConstruction for apertures with a Outdoors boundary condition, False is_operable property, and a RoofCeiling or Floor face type for their parent face. */
    skylight_construction?: (WindowConstruction | WindowConstructionShade | WindowConstructionDynamic);
	
    @IsOptional()
    /** A WindowConstruction for all apertures with an Outdoors boundary condition and True is_operable property. */
    operable_construction?: (WindowConstruction | WindowConstructionShade | WindowConstructionDynamic);
	

    constructor() {
        super();
        this.type = "ApertureConstructionSet";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.type = _data["type"] !== undefined ? _data["type"] : "ApertureConstructionSet";
            this.interior_construction = _data["interior_construction"];
            this.window_construction = _data["window_construction"];
            this.skylight_construction = _data["skylight_construction"];
            this.operable_construction = _data["operable_construction"];
        }
    }


    static override fromJS(data: any): ApertureConstructionSet {
        data = typeof data === 'object' ? data : {};

        let result = new ApertureConstructionSet();
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
        data["interior_construction"] = this.interior_construction;
        data["window_construction"] = this.window_construction;
        data["skylight_construction"] = this.skylight_construction;
        data["operable_construction"] = this.operable_construction;
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
