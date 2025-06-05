import { IsString, IsOptional, Matches, MinLength, MaxLength, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { AFNCrack } from "./AFNCrack";

/** Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects. */
export class FaceEnergyPropertiesAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^FaceEnergyPropertiesAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "FaceEnergyPropertiesAbridged";
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "construction" })
    /** Identifier of an OpaqueConstruction for the Face. If None, the construction is set by the parent Room construction_set or the Model global_construction_set. */
    construction?: string;
	
    @IsInstance(AFNCrack)
    @Type(() => AFNCrack)
    @ValidateNested()
    @IsOptional()
    @Expose({ name: "vent_crack" })
    /** An optional AFNCrack to specify airflow through a surface crack used by the AirflowNetwork. */
    ventCrack?: AFNCrack;
	

    constructor() {
        super();
        this.type = "FaceEnergyPropertiesAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(FaceEnergyPropertiesAbridged, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.type = obj.type ?? "FaceEnergyPropertiesAbridged";
            this.construction = obj.construction;
            this.ventCrack = obj.ventCrack;
        }
    }


    static override fromJS(data: any): FaceEnergyPropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new FaceEnergyPropertiesAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "FaceEnergyPropertiesAbridged";
        data["construction"] = this.construction;
        data["vent_crack"] = this.ventCrack;
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
