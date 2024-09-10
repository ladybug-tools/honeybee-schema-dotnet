import { IsInstance, ValidateNested, IsDefined, IsString, IsOptional, Matches, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { IDdBaseModel } from "./IDdBaseModel";
import { Mesh3D } from "./Mesh3D";
import { ShadeMeshPropertiesAbridged } from "./ShadeMeshPropertiesAbridged";

/** Base class for all objects requiring a identifiers acceptable for all engines. */
export class ShadeMesh extends IDdBaseModel {
    @IsInstance(Mesh3D)
    @Type(() => Mesh3D)
    @ValidateNested()
    @IsDefined()
    /** A Mesh3D for the geometry. */
    geometry!: Mesh3D;
	
    @IsInstance(ShadeMeshPropertiesAbridged)
    @Type(() => ShadeMeshPropertiesAbridged)
    @ValidateNested()
    @IsDefined()
    /** Extension properties for particular simulation engines (Radiance, EnergyPlus). */
    properties!: ShadeMeshPropertiesAbridged;
	
    @IsString()
    @IsOptional()
    @Matches(/^ShadeMesh$/)
    type?: string;
	
    @IsBoolean()
    @IsOptional()
    /** Boolean to note whether this shade is detached from any of the other geometry in the model. Cases where this should be True include shade representing surrounding buildings or context. */
    is_detached?: boolean;
	

    constructor() {
        super();
        this.type = "ShadeMesh";
        this.is_detached = true;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ShadeMesh, _data);
            this.geometry = obj.geometry;
            this.properties = obj.properties;
            this.type = obj.type;
            this.is_detached = obj.is_detached;
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
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || [error]).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
