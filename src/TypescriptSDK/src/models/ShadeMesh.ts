import { IsInstance, ValidateNested, IsDefined, IsString, IsOptional, Matches, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { IDdBaseModel } from "./IDdBaseModel";
import { Mesh3D } from "./Mesh3D";
import { ShadeMeshPropertiesAbridged } from "./ShadeMeshPropertiesAbridged";

/** Base class for all objects requiring a identifiers acceptable for all engines. */
export class ShadeMesh extends IDdBaseModel {
    @IsInstance(Mesh3D)
    @Type(() => Mesh3D)
    @ValidateNested()
    @IsDefined()
    @Expose({ name: "geometry" })
    /** A Mesh3D for the geometry. */
    geometry!: Mesh3D;
	
    @IsInstance(ShadeMeshPropertiesAbridged)
    @Type(() => ShadeMeshPropertiesAbridged)
    @ValidateNested()
    @IsDefined()
    @Expose({ name: "properties" })
    /** Extension properties for particular simulation engines (Radiance, EnergyPlus). */
    properties!: ShadeMeshPropertiesAbridged;
	
    @IsString()
    @IsOptional()
    @Matches(/^ShadeMesh$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ShadeMesh";
	
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "is_detached" })
    /** Boolean to note whether this shade is detached from any of the other geometry in the model. Cases where this should be True include shade representing surrounding buildings or context. */
    isDetached: boolean = true;
	

    constructor() {
        super();
        this.type = "ShadeMesh";
        this.isDetached = true;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(ShadeMesh, _data);
            this.geometry = obj.geometry;
            this.properties = obj.properties;
            this.type = obj.type ?? "ShadeMesh";
            this.isDetached = obj.isDetached ?? true;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
            this.userData = obj.userData;
        }
    }


    static override fromJS(data: any): ShadeMesh {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ShadeMesh();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["geometry"] = this.geometry;
        data["properties"] = this.properties;
        data["type"] = this.type ?? "ShadeMesh";
        data["is_detached"] = this.isDetached ?? true;
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
