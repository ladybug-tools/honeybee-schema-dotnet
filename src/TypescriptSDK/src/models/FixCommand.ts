import { IsString, IsDefined, IsOptional, Equals, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';

export class FixCommand {
    @Type(() => String)
    @IsString()
    @IsDefined()
    @Expose({ name: "name" })
    /** Text string for name of the command to be used as a suggested fix. */
    name!: string;
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("FixCommand")
    @Expose({ name: "type" })
    /** type */
    type: string = "FixCommand";
	
    @IsOptional()
    @Expose({ name: "inputs" })
    /** Dictionary containing inputs for the command to enable it to fix the ValidationError. The keys of this dictionary should correspond to the name of the input and the values should be the recommended input value. When None, the assumption is that all command defaults are used. */
    inputs?: Object;
	

    constructor() {
        this.type = "FixCommand";
    }


    init(_data?: any) {

        if (_data) {
            const obj = deepTransform(FixCommand, _data);
            this.name = obj.name;
            this.type = obj.type ?? "FixCommand";
            this.inputs = obj.inputs;
        }
    }


    static fromJS(data: any): FixCommand {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new FixCommand();
        result.init(data);
        return result;
    }

	toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["name"] = this.name;
        data["type"] = this.type ?? "FixCommand";
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
