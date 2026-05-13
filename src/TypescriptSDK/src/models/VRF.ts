import { IsString, IsOptional, Equals, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _HeatCoolBase } from "./_HeatCoolBase";
import { Vintages } from "./Vintages";
import { VRFEquipmentType } from "./VRFEquipmentType";

/** Variable Refrigerant Flow (VRF) heating/cooling system (with no ventilation).\n\nEach room/zone receives its own Variable Refrigerant Flow (VRF) terminal,\nwhich meets the heating and cooling loads of the space. All room/zone terminals\nare connected to the same outdoor unit, meaning that either all rooms must be\nin cooling or heating mode together. */
export class VRF extends _HeatCoolBase {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("VRF")
    @Expose({ name: "type" })
    /** type */
    type: string = "VRF";
	
    @Type(() => String)
    @IsEnum(VRFEquipmentType)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the VRFEquipmentType enumeration. */
    equipmentType: VRFEquipmentType = VRFEquipmentType.VRF;
	

    constructor() {
        super();
        this.type = "VRF";
        this.equipmentType = VRFEquipmentType.VRF;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(VRF, _data);
            this.type = obj.type ?? "VRF";
            this.equipmentType = obj.equipmentType ?? VRFEquipmentType.VRF;
            this.vintage = obj.vintage ?? Vintages.ASHRAE_2019;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static override fromJS(data: any): VRF {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new VRF();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "VRF";
        data["equipment_type"] = this.equipmentType ?? VRFEquipmentType.VRF;
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
