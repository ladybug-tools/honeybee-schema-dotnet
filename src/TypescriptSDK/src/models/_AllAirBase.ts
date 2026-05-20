import { IsEnum, IsOptional, IsNumber, Min, Max, IsBoolean, IsString, Matches, IsDefined, MinLength, MaxLength, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { AllAirEconomizerType } from "./AllAirEconomizerType";
import { Vintages } from "./Vintages";

/** Base class for all-air systems.\n\nAll-air systems provide both ventilation and heating + cooling demand with\nthe same stream of warm/cool air. As such, they often grant tight control\nover zone humidity. However, because such systems often involve the\ncooling of air only to reheat it again, they are often more energy intensive\nthan systems that separate ventilation from the meeting of thermal loads. */
export class _AllAirBase {
    @Type(() => String)
    @IsEnum(AllAirEconomizerType)
    @IsOptional()
    @Expose({ name: "economizer_type" })
    /** Text to indicate the type of air-side economizer used on the system (from the AllAirEconomizerType enumeration). */
    economizerType: AllAirEconomizerType = AllAirEconomizerType.NoEconomizer;
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "sensible_heat_recovery" })
    /** A number between 0 and 1 for the effectiveness of sensible heat recovery within the system. */
    sensibleHeatRecovery: number = 0;
	
    @Type(() => Number)
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "latent_heat_recovery" })
    /** A number between 0 and 1 for the effectiveness of latent heat recovery within the system. */
    latentHeatRecovery: number = 0;
	
    @Type(() => Boolean)
    @IsBoolean()
    @IsOptional()
    @Expose({ name: "demand_controlled_ventilation" })
    /** Boolean to note whether demand controlled ventilation should be used on the system, which will vary the amount of ventilation air according to the occupancy schedule of the Rooms. */
    demandControlledVentilation: boolean = false;
	
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Matches(/^_AllAirBase$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "_AllAirBase";
	
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
        this.economizerType = AllAirEconomizerType.NoEconomizer;
        this.sensibleHeatRecovery = 0;
        this.latentHeatRecovery = 0;
        this.demandControlledVentilation = false;
        this.type = "_AllAirBase";
        this.vintage = Vintages.ASHRAE_2019;
    }


    init(_data?: any) {

        if (_data) {
            const obj = deepTransform(_AllAirBase, _data);
            this.economizerType = obj.economizerType ?? AllAirEconomizerType.NoEconomizer;
            this.sensibleHeatRecovery = obj.sensibleHeatRecovery ?? 0;
            this.latentHeatRecovery = obj.latentHeatRecovery ?? 0;
            this.demandControlledVentilation = obj.demandControlledVentilation ?? false;
            this.type = obj.type ?? "_AllAirBase";
            this.vintage = obj.vintage ?? Vintages.ASHRAE_2019;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static fromJS(data: any): _AllAirBase {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new _AllAirBase();
        result.init(data);
        return result;
    }

	toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["economizer_type"] = this.economizerType ?? AllAirEconomizerType.NoEconomizer;
        data["sensible_heat_recovery"] = this.sensibleHeatRecovery ?? 0;
        data["latent_heat_recovery"] = this.latentHeatRecovery ?? 0;
        data["demand_controlled_ventilation"] = this.demandControlledVentilation ?? false;
        data["type"] = this.type ?? "_AllAirBase";
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
