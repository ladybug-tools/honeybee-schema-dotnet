import { IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _EquipmentBase } from "./_EquipmentBase";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class GasEquipmentAbridged extends _EquipmentBase {
    @IsString()
    @IsOptional()
    @Matches(/^GasEquipmentAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "GasEquipmentAbridged";
	

    constructor() {
        super();
        this.type = "GasEquipmentAbridged";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(GasEquipmentAbridged, _data);
            this.type = obj.type ?? "GasEquipmentAbridged";
            this.wattsPerArea = obj.wattsPerArea;
            this.schedule = obj.schedule;
            this.radiantFraction = obj.radiantFraction ?? 0;
            this.latentFraction = obj.latentFraction ?? 0;
            this.lostFraction = obj.lostFraction ?? 0;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
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
        data["type"] = this.type ?? "GasEquipmentAbridged";
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
