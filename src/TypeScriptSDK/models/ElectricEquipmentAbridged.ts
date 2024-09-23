import { IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { _EquipmentBase } from "./_EquipmentBase";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class ElectricEquipmentAbridged extends _EquipmentBase {
    @IsString()
    @IsOptional()
    @Matches(/^ElectricEquipmentAbridged$/)
    type?: string;
	

    constructor() {
        super();
        this.type = "ElectricEquipmentAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ElectricEquipmentAbridged, _data, { enableImplicitConversion: true });
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): ElectricEquipmentAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new ElectricEquipmentAbridged();
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

