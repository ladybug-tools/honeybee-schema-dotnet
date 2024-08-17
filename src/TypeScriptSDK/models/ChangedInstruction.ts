import { IsEnum, ValidateNested, IsDefined, IsString, IsOptional, IsBoolean, validate, ValidationError as TsValidationError } from 'class-validator';
import { GeometryObjectTypes } from "./GeometryObjectTypes";
import { OpenAPIGenBaseModel } from "./OpenAPIGenBaseModel";

export class ChangedInstruction extends OpenAPIGenBaseModel {
    @IsEnum(GeometryObjectTypes)
    @ValidateNested()
    @IsDefined()
    /** Text for the type of object that has been changed. */
    element_type!: GeometryObjectTypes;
	
    @IsString()
    @IsDefined()
    /** Text string for the unique object ID that has changed. */
    element_id!: string;
	
    @IsString()
    @IsOptional()
    /** Text string for the display name of the object that has changed. */
    element_name?: string;
	
    @IsBoolean()
    @IsOptional()
    /** A boolean to note whether the geometry of the object in the new/updated model should replace the base/existing geometry (True) or the existing geometry should be kept (False). */
    update_geometry?: boolean;
	
    @IsBoolean()
    @IsOptional()
    /** A boolean to note whether the energy properties of the object in the new/updated model should replace the base/existing energy properties (True) or the base/existing energy properties should be kept (False). */
    update_energy?: boolean;
	
    @IsBoolean()
    @IsOptional()
    /** A boolean to note whether the radiance properties of the object in the new/updated model should replace the base/existing radiance properties (True) or the base/existing radiance properties should be kept (False). */
    update_radiance?: boolean;
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.update_geometry = true;
        this.update_energy = true;
        this.update_radiance = true;
        this.type = "ChangedInstruction";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.element_type = _data["element_type"];
            this.element_id = _data["element_id"];
            this.element_name = _data["element_name"];
            this.update_geometry = _data["update_geometry"] !== undefined ? _data["update_geometry"] : true;
            this.update_energy = _data["update_energy"] !== undefined ? _data["update_energy"] : true;
            this.update_radiance = _data["update_radiance"] !== undefined ? _data["update_radiance"] : true;
            this.type = _data["type"] !== undefined ? _data["type"] : "ChangedInstruction";
        }
    }


    static override fromJS(data: any): ChangedInstruction {
        data = typeof data === 'object' ? data : {};

        let result = new ChangedInstruction();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["element_type"] = this.element_type;
        data["element_id"] = this.element_id;
        data["element_name"] = this.element_name;
        data["update_geometry"] = this.update_geometry;
        data["update_energy"] = this.update_energy;
        data["update_radiance"] = this.update_radiance;
        data["type"] = this.type;
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
