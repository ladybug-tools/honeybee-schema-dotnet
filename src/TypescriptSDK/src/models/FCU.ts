import { IsString, IsOptional, Equals, IsEnum, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _HeatCoolBase } from "./_HeatCoolBase";
import { FCUEquipmentType } from "./FCUEquipmentType";
import { Vintages } from "./Vintages";

/** Fan Coil Unit (FCU) heating/cooling system (with no ventilation).\n\nEach room/zone receives its own Fan Coil Unit (FCU), which meets the heating\nand cooling loads of the space. The cooling coil in the FCU is always chilled\nwater cooling coil, which is connected to a chilled water loop operating\nat 6.7C (44F). The heating coil is a hot water coil except when when electric\nbaseboards or gas heaters are specified. Hot water temperature is 82C (180F) for\nboiler/district heating and 49C (120F) when ASHP is used. */
export class FCU extends _HeatCoolBase {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("FCU")
    @Expose({ name: "type" })
    /** type */
    type: string = "FCU";
	
    @Type(() => String)
    @IsEnum(FCUEquipmentType)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the FCUEquipmentType enumeration. */
    equipmentType: FCUEquipmentType = FCUEquipmentType.FCU_Chiller_Boiler;
	

    constructor() {
        super();
        this.type = "FCU";
        this.equipmentType = FCUEquipmentType.FCU_Chiller_Boiler;
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(FCU, _data);
            this.type = obj.type ?? "FCU";
            this.equipmentType = obj.equipmentType ?? FCUEquipmentType.FCU_Chiller_Boiler;
            this.vintage = obj.vintage ?? Vintages.ASHRAE_2019;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static override fromJS(data: any): FCU {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new FCU();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "FCU";
        data["equipment_type"] = this.equipmentType ?? FCUEquipmentType.FCU_Chiller_Boiler;
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
