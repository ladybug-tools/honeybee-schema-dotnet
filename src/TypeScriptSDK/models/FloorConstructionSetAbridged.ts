import { IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { _FaceSubSetAbridged } from "./_FaceSubSetAbridged";

/** A set of constructions for floor assemblies. */
export class FloorConstructionSetAbridged extends _FaceSubSetAbridged {
    @IsString()
    @IsOptional()
    @Matches(/^FloorConstructionSetAbridged$/)
    type?: string;
	

    constructor() {
        super();
        this.type = "FloorConstructionSetAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(FloorConstructionSetAbridged, _data);
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): FloorConstructionSetAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new FloorConstructionSetAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data = super.toJSON(data);
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

