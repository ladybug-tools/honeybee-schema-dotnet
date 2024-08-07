import { IsInstance, ValidateNested, IsDefined, IsString, IsOptional, validate, ValidationError } from 'class-validator';
import { Mesh3D } from "./Mesh3D";
import { ShadeMeshPropertiesAbridged } from "./ShadeMeshPropertiesAbridged";
import { IDdBaseModel } from "./IDdBaseModel";

/** Base class for all objects requiring a identifiers acceptable for all engines. */
export class ShadeMesh extends IDdBaseModel {
    @IsInstance(Mesh3D)
    @ValidateNested()
    @IsDefined()
    /** A Mesh3D for the geometry. */
    geometry!: Mesh3D;
	
    @IsInstance(ShadeMeshPropertiesAbridged)
    @ValidateNested()
    @IsDefined()
    /** Extension properties for particular simulation engines (Radiance, EnergyPlus). */
    properties!: ShadeMeshPropertiesAbridged;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsOptional()
    /** Boolean to note whether this shade is detached from any of the other geometry in the model. Cases where this should be True include shade representing surrounding buildings or context. */
    is_detached?: boolean;
	

    constructor() {
        super();
        this.type = "ShadeMesh";
        this.is_detached = True;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.geometry = _data["geometry"];
            this.properties = _data["properties"];
            this.type = _data["type"] !== undefined ? _data["type"] : "ShadeMesh";
            this.is_detached = _data["is_detached"] !== undefined ? _data["is_detached"] : True;
        }
    }


    static override fromJS(data: any): ShadeMesh {
        data = typeof data === 'object' ? data : {};

        let result = new ShadeMesh();
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
			const errorMessages = errors.map((error: ValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
