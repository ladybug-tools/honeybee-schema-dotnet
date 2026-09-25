import { IsString, IsDefined, IsEnum, IsArray, IsInstance, ValidateNested, IsOptional, Equals, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { FixCommand } from "./FixCommand";
import { Platforms } from "./Platforms";

export class SuggestedFix {
    @Type(() => String)
    @IsString()
    @IsDefined()
    @Expose({ name: "name" })
    /** Text string for name of the suggested fix. */
    name!: string;
	
    @Type(() => String)
    @IsString()
    @IsDefined()
    @Expose({ name: "message" })
    /** Text for the suggested fix with a detailed description of what exactly the suggested fix does. */
    message!: string;
	
    @Type(() => String)
    @IsEnum(Platforms)
    @IsDefined()
    @Expose({ name: "platform" })
    /** Text string for the platform on which the command can be run to fix the error. */
    platform!: Platforms;
	
    @IsArray()
    @Type(() => FixCommand)
    @IsInstance(FixCommand, { each: true })
    @ValidateNested({ each: true })
    @IsDefined()
    @Expose({ name: "commands" })
    /** A list of FixCommand objects with recommendations for how to fix the error. The list can contain a single command or canhave multiple commands to be executed in a sequence. */
    commands!: FixCommand[];
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("SuggestedFix")
    @Expose({ name: "type" })
    /** type */
    type: string = "SuggestedFix";
	

    constructor() {
        this.type = "SuggestedFix";
    }


    init(_data?: any) {

        if (_data) {
            const obj = deepTransform(SuggestedFix, _data);
            this.name = obj.name;
            this.message = obj.message;
            this.platform = obj.platform;
            this.commands = obj.commands;
            this.type = obj.type ?? "SuggestedFix";
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
        data["name"] = this.name;
        data["message"] = this.message;
        data["platform"] = this.platform;
        data["commands"] = this.commands;
        data["type"] = this.type ?? "SuggestedFix";
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
