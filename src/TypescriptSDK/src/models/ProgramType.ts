import { IsString, IsOptional, Equals, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { ProgramTypeAbridged } from "./ProgramTypeAbridged";

export class ProgramType extends ProgramTypeAbridged {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("ProgramType")
    @Expose({ name: "type" })
    /** type */
    type: string = "ProgramType";
	

    constructor() {
        super();
        this.type = "ProgramType";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(ProgramType, _data);
            this.type = obj.type ?? "ProgramType";
            this.people = obj.people;
            this.lighting = obj.lighting;
            this.electricEquipment = obj.electricEquipment;
            this.gasEquipment = obj.gasEquipment;
            this.serviceHotWater = obj.serviceHotWater;
            this.infiltration = obj.infiltration;
            this.ventilation = obj.ventilation;
            this.setpoint = obj.setpoint;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static override fromJS(data: any): ProgramType {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new ProgramType();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "ProgramType";
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
