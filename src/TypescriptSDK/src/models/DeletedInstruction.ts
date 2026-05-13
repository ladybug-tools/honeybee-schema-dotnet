import { IsString, IsOptional, Equals, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _DiffObjectBase } from "./_DiffObjectBase";

export class DeletedInstruction extends _DiffObjectBase {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("DeletedInstruction")
    @Expose({ name: "type" })
    /** type */
    type: string = "DeletedInstruction";
	

    constructor() {
        super();
        this.type = "DeletedInstruction";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(DeletedInstruction, _data);
            this.type = obj.type ?? "DeletedInstruction";
            this.elementType = obj.elementType;
            this.elementId = obj.elementId;
            this.elementName = obj.elementName;
        }
    }


    static override fromJS(data: any): DeletedInstruction {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new DeletedInstruction();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "DeletedInstruction";
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
