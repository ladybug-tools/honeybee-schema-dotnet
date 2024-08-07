import { IsString, IsDefined, IsBoolean, IsOptional, IsArray, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { ValidationError } from "./ValidationError";

export class ValidationReport {
    @IsString()
    @IsDefined()
    /** Text string for the version of honeybee-core or dragonfly-core that performed the validation. */
    app_version!: string;
	
    @IsString()
    @IsDefined()
    /** Text string for the version of honeybee-schema or dragonfly-schema that performed the validation. */
    schema_version!: string;
	
    @IsBoolean()
    @IsDefined()
    /** Boolean to note whether the Model is valid or not. */
    valid!: boolean;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsString()
    @IsOptional()
    /** Text string for the name of the application that performed the validation. This is typically either Honeybee or Dragonfly. */
    app_name?: string;
	
    @IsString()
    @IsOptional()
    /** A text string containing an exception if the Model failed to serialize. It will be an empty string if serialization was successful. */
    fatal_error?: string;
	
    @IsArray()
    @ValidateNested({ each: true })
    @IsOptional()
    /** A list of objects for each error that was discovered in the model. This will be an empty list or None if no errors were found. */
    errors?: ValidationError [];
	

    constructor() {
        this.type = "ValidationReport";
        this.app_name = "Honeybee";
        this.fatal_error = "";
    }


    init(_data?: any) {
        if (_data) {
            this.app_version = _data["app_version"];
            this.schema_version = _data["schema_version"];
            this.valid = _data["valid"];
            this.type = _data["type"] !== undefined ? _data["type"] : "ValidationReport";
            this.app_name = _data["app_name"] !== undefined ? _data["app_name"] : "Honeybee";
            this.fatal_error = _data["fatal_error"] !== undefined ? _data["fatal_error"] : "";
            this.errors = _data["errors"];
        }
    }


    static fromJS(data: any): ValidationReport {
        data = typeof data === 'object' ? data : {};

        let result = new ValidationReport();
        result.init(data);
        return result;
    }

	toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["app_version"] = this.app_version;
        data["schema_version"] = this.schema_version;
        data["valid"] = this.valid;
        data["type"] = this.type;
        data["app_name"] = this.app_name;
        data["fatal_error"] = this.fatal_error;
        data["errors"] = this.errors;
        return data;
    }

}
