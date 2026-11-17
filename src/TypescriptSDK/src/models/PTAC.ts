import { IsString, IsOptional, Equals, IsEnum, IsNumber, Min, Max, IsDefined, Matches, MinLength, MaxLength, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { PTACEquipmentType } from "./PTACEquipmentType";
import { Vintages } from "./Vintages";

/** Packaged Terminal Air Conditioning (PTAC/HP) HVAC system. (aka. System 1 or 2). Each room/zone receives its own packaged unit that supplies heating, cooling and ventilation. Cooling is always done via a single-speed direct expansion (DX) cooling coil. Heating can be done via a heating coil in the unit or via an external baseboard. Fans are constant volume. PTAC/HP systems are the traditional baseline system for residential buildings. */
export class PTAC {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Equals("PTAC")
    @Expose({ name: "type" })
    /** type */
    type: string = "PTAC";
	
    @Type(() => String)
    @IsEnum(PTACEquipmentType)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text for the specific type of system equipment from the PTACEquipmentType enumeration. */
    equipmentType: PTACEquipmentType = PTACEquipmentType.PTAC_ElectricBaseboard;
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "sensible_heat_recovery" })
    /** A number between 0 and 1 for the effectiveness of sensible heat recovery within the system. When this is not zero, heat recovery is modeled using an ERV connected to the PTAC. */
    sensibleHeatRecovery: number = 0;
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "latent_heat_recovery" })
    /** A number between 0 and 1 for the effectiveness of latent heat recovery within the system. When this is not zero, heat recovery is modeled using an ERV connected to the PTAC. */
    latentHeatRecovery: number = 0;
	
    @Type(() => String)
    @IsEnum(Vintages)
    @IsOptional()
    @Expose({ name: "vintage" })
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage: Vintages = Vintages.ASHRAE_2019;
	
    @IsOptional()
    @Expose({ name: "user_data" })
    /** Optional dictionary of user data associated with the object.All keys and values of this dictionary should be of a standard data type to ensure correct serialization of the object (eg. str, float, int, list). */
    userData?: Object;
	
    @Type(() => String)
    @IsString()
    @IsDefined()
    @Matches(/^[^,;!\n\t]+$/)
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "identifier" })
    /** Text string for a unique object ID. This identifier remains constant as the object is mutated, copied, and serialized to different formats (eg. dict, idf, osm). This identifier is also used to reference the object across a Model. It must be < 100 characters, use only ASCII characters and exclude (, ; ! \n \t). */
    identifier!: string;
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Expose({ name: "display_name" })
    /** Display name of the object with no character restrictions. */
    displayName?: string;
	

    constructor() {
        this.type = "PTAC";
        this.equipmentType = PTACEquipmentType.PTAC_ElectricBaseboard;
        this.sensibleHeatRecovery = 0;
        this.latentHeatRecovery = 0;
        this.vintage = Vintages.ASHRAE_2019;
    }


    init(_data?: any) {

        if (_data) {
            const obj = deepTransform(PTAC, _data);
            this.type = obj.type ?? "PTAC";
            this.equipmentType = obj.equipmentType ?? PTACEquipmentType.PTAC_ElectricBaseboard;
            this.sensibleHeatRecovery = obj.sensibleHeatRecovery ?? 0;
            this.latentHeatRecovery = obj.latentHeatRecovery ?? 0;
            this.vintage = obj.vintage ?? Vintages.ASHRAE_2019;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static fromJS(data: any): PTAC {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new PTAC();
        result.init(data);
        return result;
    }

	toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "PTAC";
        data["equipment_type"] = this.equipmentType ?? PTACEquipmentType.PTAC_ElectricBaseboard;
        data["sensible_heat_recovery"] = this.sensibleHeatRecovery ?? 0;
        data["latent_heat_recovery"] = this.latentHeatRecovery ?? 0;
        data["vintage"] = this.vintage ?? Vintages.ASHRAE_2019;
        data["user_data"] = this.userData;
        data["identifier"] = this.identifier;
        data["display_name"] = this.displayName;
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
