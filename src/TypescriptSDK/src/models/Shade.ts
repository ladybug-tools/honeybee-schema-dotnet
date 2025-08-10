import { IsInstance, ValidateNested, IsDefined, IsString, IsOptional, Matches, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { Face3D } from "./Face3D";
import { IDdBaseModel } from "./IDdBaseModel";
import { ShadePropertiesAbridged } from "./ShadePropertiesAbridged";

/** Base class for all objects requiring a identifiers acceptable for all engines. */
export class Shade extends IDdBaseModel {
    @IsInstance(Face3D)
    @Type(() => Face3D)
    @ValidateNested()
    @IsDefined()
    @Expose({ name: "geometry" })
    /** Planar Face3D for the geometry. */
    geometry!: Face3D;
	
    @IsInstance(ShadePropertiesAbridged)
    @Type(() => ShadePropertiesAbridged)
    @ValidateNested()
    @IsDefined()
    @Expose({ name: "properties" })
    /** Extension properties for particular simulation engines (Radiance, EnergyPlus). */
    properties!: ShadePropertiesAbridged;
	
    @IsString()
    @IsOptional()
    @Matches(/^Shade$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "Shade";
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "is_detached" })
    /** Boolean to note whether this shade is detached from any of the other geometry in the model. Cases where this should be True include shade representing surrounding buildings or context. Note that this should always be False for shades assigned to parent objects. */
    isDetached: boolean = false;
	

    constructor() {
        super();
        this.type = "Shade";
        this.isDetached = false;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(Shade, _data);
        }
    }


    static override fromJS(data: any): Shade {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new Shade();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["geometry"] = this.geometry;
        data["properties"] = this.properties;
        data["type"] = this.type ?? "Shade";
        data["is_detached"] = this.isDetached ?? false;
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
