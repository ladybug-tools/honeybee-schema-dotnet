import { IsEnum, IsDefined, IsString, IsOptional, Equals, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { Platforms } from "./Platforms";

export class SuggestedFix {
    @Type(() => String)
    @IsEnum(Platforms)
    @IsDefined()
    @Expose({ name: "platform" })
    /** Text string for the platform on which the command can be run to fix the error. */
    platform!: Platforms;
	
    @Type(() => String)
    @IsString()
    @IsDefined()
    @Expose({ name: "command" })
    /** Text string for name of the command to be used as a suggested fix. */
    command!: string;
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("SuggestedFix")
    @Expose({ name: "type" })
    /** type */
    type: string = "SuggestedFix";
	
    @IsOptional()
    @Expose({ name: "inputs" })
    /** Dictionary containing inputs for the command to enable it to fix the ValidationError. The keys of this dictionary should correspond to the name of the input and the values should be the recommended input value. When None, the assumption is that all command defaults are used. */
    inputs?: Object;
	

    constructor() {
        this.type = "SuggestedFix";
    }


    init(_data?: any) {

        if (_data) {
            const obj = deepTransform(SuggestedFix, _data);
            this.platform = obj.platform;
            this.command = obj.command;
            this.type = obj.type ?? "SuggestedFix";
            this.inputs = obj.inputs;
        }
    }


    static fromJS(data: any): SuggestedFix {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new SuggestedFix();
        result.init(data);
        return result;
    }

	toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["platform"] = this.platform;
        data["command"] = this.command;
        data["type"] = this.type ?? "SuggestedFix";
        data["inputs"] = this.inputs;
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
