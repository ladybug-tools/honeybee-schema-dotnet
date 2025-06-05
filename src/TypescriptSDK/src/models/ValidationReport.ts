import { IsString, IsDefined, Matches, IsBoolean, IsOptional, IsArray, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { ValidationError } from "./ValidationError";

export class ValidationReport {
    @IsString()
    @IsDefined()
    @Matches(/([0-9]+)\.([0-9]+)\.([0-9]+)/)
    @Expose({ name: "app_version" })
    /** Text string for the version of honeybee-core or dragonfly-core that performed the validation. */
    appVersion!: string;
	
    @IsString()
    @IsDefined()
    @Matches(/([0-9]+)\.([0-9]+)\.([0-9]+)/)
    @Expose({ name: "schema_version" })
    /** Text string for the version of honeybee-schema or dragonfly-schema that performed the validation. */
    schemaVersion!: string;
	
    @IsBoolean()
    @IsDefined()
    @Expose({ name: "valid" })
    /** Boolean to note whether the Model is valid or not. */
    valid!: boolean;
	
    @IsString()
    @IsOptional()
    @Matches(/^ValidationReport$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "ValidationReport";
	
    @IsString()
    @IsOptional()
    @Expose({ name: "app_name" })
    /** Text string for the name of the application that performed the validation. This is typically either Honeybee or Dragonfly. */
    appName: string = "Honeybee";
	
    @IsString()
    @IsOptional()
    @Expose({ name: "fatal_error" })
    /** A text string containing an exception if the Model failed to serialize. It will be an empty string if serialization was successful. */
    fatalError: string = "";
	
    @IsArray()
    @IsInstance(ValidationError, { each: true })
    @Type(() => ValidationError)
    @ValidateNested({ each: true })
    @IsOptional()
    @Expose({ name: "errors" })
    /** A list of objects for each error that was discovered in the model. This will be an empty list or None if no errors were found. */
    errors?: ValidationError[];
	

    constructor() {
        this.type = "ValidationReport";
        this.appName = "Honeybee";
        this.fatalError = "";
    }


    init(_data?: any) {
        if (_data) {
            const obj = plainToClass(ValidationReport, _data, { enableImplicitConversion: true });
            this.appVersion = obj.appVersion;
            this.schemaVersion = obj.schemaVersion;
            this.valid = obj.valid;
            this.type = obj.type;
            this.appName = obj.appName;
            this.fatalError = obj.fatalError;
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
        data["app_version"] = this.appVersion;
        data["schema_version"] = this.schemaVersion;
        data["valid"] = this.valid;
        data["type"] = this.type;
        data["app_name"] = this.appName;
        data["fatal_error"] = this.fatalError;
        data["errors"] = this.errors;
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
