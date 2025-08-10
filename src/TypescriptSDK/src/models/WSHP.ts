import { IsEnum, IsOptional, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Vintages } from "./Vintages";
import { WSHPEquipmentType } from "./WSHPEquipmentType";

/** Water Source Heat Pump (WSHP) heating/cooling system (with no ventilation).\n\nEach room/zone receives its own Water Source Heat Pump (WSHP), which meets\nthe heating and cooling loads of the space. All WSHPs are connected to the\nsame water condenser loop, which has its temperature maintained by the\nequipment_type (eg. Boiler with Cooling Tower). */
export class WSHP extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "vintage" })
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage: Vintages = Vintages.ASHRAE_2019;
	
    @IsString()
    @IsOptional()
    @Matches(/^WSHP$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "WSHP";
	
    @IsEnum(WSHPEquipmentType)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the WSHPEquipmentType enumeration. */
    equipmentType: WSHPEquipmentType = WSHPEquipmentType.WSHP_FluidCooler_Boiler;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.type = "WSHP";
        this.equipmentType = WSHPEquipmentType.WSHP_FluidCooler_Boiler;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(WSHP, _data);
            this.vintage = obj.vintage ?? Vintages.ASHRAE_2019;
            this.type = obj.type ?? "WSHP";
            this.equipmentType = obj.equipmentType ?? WSHPEquipmentType.WSHP_FluidCooler_Boiler;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static override fromJS(data: any): WSHP {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new WSHP();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["vintage"] = this.vintage ?? Vintages.ASHRAE_2019;
        data["type"] = this.type ?? "WSHP";
        data["equipment_type"] = this.equipmentType ?? WSHPEquipmentType.WSHP_FluidCooler_Boiler;
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
