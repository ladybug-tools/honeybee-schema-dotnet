import { IsString, IsOptional, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { AFNCrack } from "./AFNCrack";
import { OpenAPIGenBaseModel } from "./OpenAPIGenBaseModel";

/** Base class for all objects that are not extensible with additional keys.\n\nThis effectively includes all objects except for the Properties classes\nthat are assigned to geometry objects. */
export class FaceEnergyPropertiesAbridged extends OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier of an OpaqueConstruction for the Face. If None, the construction is set by the parent Room construction_set or the Model global_construction_set. */
    construction?: string;
	
    @IsInstance(AFNCrack)
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
            this.type = _data["type"] !== undefined ? _data["type"] : "FaceEnergyPropertiesAbridged";
            this.construction = _data["construction"];
            this.vent_crack = _data["vent_crack"];
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
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["type"] = this.type;
        data["construction"] = this.construction;
        data["vent_crack"] = this.vent_crack;
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
