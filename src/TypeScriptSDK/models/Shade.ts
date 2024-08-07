import { IsInstance, ValidateNested, IsDefined, IsString, IsOptional, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Face3D } from "./Face3D";
import { ShadePropertiesAbridged } from "./ShadePropertiesAbridged";
import { IDdBaseModel } from "./IDdBaseModel";

/** Base class for all objects requiring a identifiers acceptable for all engines. */
export class Shade extends IDdBaseModel {
    @IsInstance(Face3D)
    @ValidateNested()
    @IsDefined()
    /** Planar Face3D for the geometry. */
    geometry!: Face3D;
	
    @IsInstance(ShadePropertiesAbridged)
    @ValidateNested()
    @IsDefined()
    /** Extension properties for particular simulation engines (Radiance, EnergyPlus). */
    properties!: ShadePropertiesAbridged;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean to note whether this shade is detached from any of the other geometry in the model. Cases where this should be True include shade representing surrounding buildings or context. Note that this should always be False for shades assigned to parent objects. */
    is_detached?: boolean;
	

    constructor() {
        super();
        this.type = "Shade";
        this.is_detached = false;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.geometry = _data["geometry"];
            this.properties = _data["properties"];
            this.type = _data["type"] !== undefined ? _data["type"] : "Shade";
            this.is_detached = _data["is_detached"] !== undefined ? _data["is_detached"] : false;
        }
    }


    static override fromJS(data: any): Shade {
        data = typeof data === 'object' ? data : {};

        let result = new Shade();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["geometry"] = this.geometry;
        data["properties"] = this.properties;
        data["type"] = this.type;
        data["is_detached"] = this.is_detached;
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
