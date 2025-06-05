import { IsEnum, IsOptional, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Vintages } from "./Vintages";
import { VRFEquipmentType } from "./VRFEquipmentType";

/** Variable Refrigerant Flow (VRF) heating/cooling system (with no ventilation).\n\nEach room/zone receives its own Variable Refrigerant Flow (VRF) terminal,\nwhich meets the heating and cooling loads of the space. All room/zone terminals\nare connected to the same outdoor unit, meaning that either all rooms must be\nin cooling or heating mode together. */
export class VRF extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "vintage" })
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage: Vintages = Vintages.ASHRAE_2019;
	
    @IsString()
    @IsOptional()
    @Matches(/^VRF$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "VRF";
	
    @IsEnum(VRFEquipmentType)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the VRFEquipmentType enumeration. */
    equipmentType: VRFEquipmentType = VRFEquipmentType.VRF;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.type = "VRF";
        this.equipmentType = VRFEquipmentType.VRF;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(VRF, _data, { enableImplicitConversion: true, exposeUnsetFields: false, exposeDefaultValues: true });
            this.vintage = obj.vintage ?? Vintages.ASHRAE_2019;
            this.type = obj.type ?? "VRF";
            this.equipmentType = obj.equipmentType ?? VRFEquipmentType.VRF;
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
        data["vintage"] = this.vintage ?? Vintages.ASHRAE_2019;
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
