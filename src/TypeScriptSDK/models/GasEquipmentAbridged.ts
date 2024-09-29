import { IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { _EquipmentBase } from "./_EquipmentBase";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class GasEquipmentAbridged extends _EquipmentBase {
    @IsString()
    @IsOptional()
    @Matches(/^GasEquipmentAbridged$/)
    type?: string;
	

    constructor() {
        super();
        this.type = "GasEquipmentAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(GasEquipmentAbridged, _data, { enableImplicitConversion: true });
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): GasEquipmentAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new GasEquipmentAbridged();
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

