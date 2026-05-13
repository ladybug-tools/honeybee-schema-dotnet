import { IsString, IsOptional, Equals, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _DiffObjectBase } from "./_DiffObjectBase";

export class AddedInstruction extends _DiffObjectBase {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("AddedInstruction")
    @Expose({ name: "type" })
    /** type */
    type: string = "AddedInstruction";
	

    constructor() {
        super();
        this.type = "AddedInstruction";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(AddedInstruction, _data);
            this.type = obj.type ?? "AddedInstruction";
            this.elementType = obj.elementType;
            this.elementId = obj.elementId;
            this.elementName = obj.elementName;
        }
    }


    static override fromJS(data: any): AddedInstruction {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new AddedInstruction();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "AddedInstruction";
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
