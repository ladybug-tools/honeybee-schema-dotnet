import { IsEnum, IsOptional, IsString, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { FCUEquipmentType } from "./FCUEquipmentType";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Vintages } from "./Vintages";

/** Fan Coil Unit (FCU) heating/cooling system (with no ventilation).\n\nEach room/zone receives its own Fan Coil Unit (FCU), which meets the heating\nand cooling loads of the space. The cooling coil in the FCU is always chilled\nwater cooling coil, which is connected to a chilled water loop operating\nat 6.7C (44F). The heating coil is a hot water coil except when when electric\nbaseboards or gas heaters are specified. Hot water temperature is 82C (180F) for\nboiler/district heating and 49C (120F) when ASHP is used. */
export class FCU extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "vintage" })
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage: Vintages = Vintages.ASHRAE_2019;
	
    @IsString()
    @IsOptional()
    @Matches(/^FCU$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "FCU";
	
    @IsEnum(FCUEquipmentType)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the FCUEquipmentType enumeration. */
    equipmentType: FCUEquipmentType = FCUEquipmentType.FCU_Chiller_Boiler;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.type = "FCU";
        this.equipmentType = FCUEquipmentType.FCU_Chiller_Boiler;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(FCU, _data, { enableImplicitConversion: true });
            this.vintage = obj.vintage;
            this.type = obj.type;
            this.equipmentType = obj.equipmentType;
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
        data["vintage"] = this.vintage;
        data["type"] = this.type;
        data["equipment_type"] = this.equipmentType;
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
