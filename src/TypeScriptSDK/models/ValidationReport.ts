import { IsString, IsDefined, Matches, IsBoolean, IsOptional, IsArray, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { ValidationError } from "./ValidationError.ts";

export class ValidationReport {
    @IsString()
    @IsDefined()
    @Matches(/([0-9]+)\.([0-9]+)\.([0-9]+)/)
    /** Text string for the version of honeybee-core or dragonfly-core that performed the validation. */
    app_version!: string;
	
    @IsString()
    @IsDefined()
    @Matches(/([0-9]+)\.([0-9]+)\.([0-9]+)/)
    /** Text string for the version of honeybee-schema or dragonfly-schema that performed the validation. */
    schema_version!: string;
	
    @IsBoolean()
    @IsDefined()
    /** Boolean to note whether the Model is valid or not. */
    valid!: boolean;
	
    @IsString()
    @IsOptional()
    @Matches(/^ValidationReport$/)
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
    @IsInstance(ValidationError, { each: true })
    @Type(() => ValidationError)
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
            const obj = plainToClass(ValidationReport, _data, { enableImplicitConversion: true });
            this.app_version = obj.app_version;
            this.schema_version = obj.schema_version;
            this.valid = obj.valid;
            this.type = obj.type;
            this.app_name = obj.app_name;
            this.fatal_error = obj.fatal_error;
            this.errors = obj.errors;
        }
    }


    static fromJS(data: any): ValidationReport {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ValidationReport();
        result.init(data);
        return result;
    }

	toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["app_version"] = this.app_version;
        data["schema_version"] = this.schema_version;
        data["valid"] = this.valid;
        data["type"] = this.type;
        data["app_name"] = this.app_name;
        data["fatal_error"] = this.fatal_error;
        data["errors"] = this.errors;
        return removeUndefinedProperties(data);
    }

}

function removeUndefinedProperties(obj: any): any {
    if (Array.isArray(obj)) {
        return obj.map(removeUndefinedProperties);
    } else if (obj !== null && typeof obj === 'object') {
        return Object.entries(obj)
        .filter(([_, value]) => value !== undefined)
        .reduce((acc, [key, value]) => {
            acc[key] = removeUndefinedProperties(value);
            return acc;
        }, {} as any);
    }
    return obj;
}
