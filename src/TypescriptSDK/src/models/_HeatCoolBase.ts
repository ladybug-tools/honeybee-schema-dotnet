import { IsString, IsOptional, Matches, IsEnum, IsDefined, MinLength, MaxLength, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { Vintages } from "./Vintages";

/** Base class for all heating/cooling systems without any ventilation.\n\nThese systems are only designed to satisfy heating + cooling demand and they\ncannot meet any minimum ventilation requirements.\n\nAs such, these systems tend to be used in residential or storage settings where\nmeeting minimum ventilation requirements may not be required or the density\nof occupancy is so low that infiltration is enough to meet fresh air demand. */
export class _HeatCoolBase {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Matches(/^_HeatCoolBase$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "_HeatCoolBase";
	
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
        this.type = "_HeatCoolBase";
        this.vintage = Vintages.ASHRAE_2019;
    }


    init(_data?: any) {

        if (_data) {
            const obj = deepTransform(_HeatCoolBase, _data);
            this.type = obj.type ?? "_HeatCoolBase";
            this.vintage = obj.vintage ?? Vintages.ASHRAE_2019;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static fromJS(data: any): _HeatCoolBase {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new _HeatCoolBase();
        result.init(data);
        return result;
    }

	toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "_HeatCoolBase";
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
