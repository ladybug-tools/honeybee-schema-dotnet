import { IsString, IsOptional, Matches, MinLength, MaxLength, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { AFNCrack } from "./AFNCrack";

/** Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects. */
export class FaceEnergyPropertiesAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^FaceEnergyPropertiesAbridged$/)
    type?: string;
	
    @IsString()
    @IsOptional()
    @MinLength(1)
    @MaxLength(100)
    /** Identifier of an OpaqueConstruction for the Face. If None, the construction is set by the parent Room construction_set or the Model global_construction_set. */
    construction?: string;
	
    @IsInstance(AFNCrack)
    @Type(() => AFNCrack)
    @ValidateNested()
    @IsOptional()
    /** An optional AFNCrack to specify airflow through a surface crack used by the AirflowNetwork. */
    vent_crack?: AFNCrack;
	

    constructor() {
        super();
        this.type = "FaceEnergyPropertiesAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(FaceEnergyPropertiesAbridged, _data);
            this.type = obj.type;
            this.construction = obj.construction;
            this.vent_crack = obj.vent_crack;
        }
    }


    static override fromJS(data: any): FaceEnergyPropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new FaceEnergyPropertiesAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["construction"] = this.construction;
        data["vent_crack"] = this.vent_crack;
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

