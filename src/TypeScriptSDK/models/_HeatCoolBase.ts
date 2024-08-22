import { IsEnum, ValidateNested, IsOptional, IsString, validate, ValidationError as TsValidationError } from 'class-validator';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { Vintages } from "./Vintages";

/** Base class for all heating/cooling systems without any ventilation.\n\nThese systems are only designed to satisfy heating + cooling demand and they\ncannot meet any minimum ventilation requirements.\n\nAs such, these systems tend to be used in residential or storage settings where\nmeeting minimum ventilation requirements may not be required or the density\nof occupancy is so low that infiltration is enough to meet fresh air demand. */
export class _HeatCoolBase extends IDdEnergyBaseModel {
    @IsEnum(Vintages)
    @ValidateNested()
    @IsOptional()
    /** Text for the vintage of the template system. This will be used to set efficiencies for various pieces of equipment within the system. Further information about these defaults can be found in the version of ASHRAE 90.1 corresponding to the selected vintage. Read-only versions of the standard can be found at: https://www.ashrae.org/technical-resources/standards-and-guidelines/read-only-versions-of-ashrae-standards */
    vintage?: Vintages;
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.vintage = Vintages.ASHRAE_2019;
        this.type = "_HeatCoolBase";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.vintage = _data["vintage"] !== undefined ? _data["vintage"] : Vintages.ASHRAE_2019;
            this.type = _data["type"] !== undefined ? _data["type"] : "_HeatCoolBase";
        }
    }


    static override fromJS(data: any): _HeatCoolBase {
        data = typeof data === 'object' ? data : {};

        let result = new _HeatCoolBase();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["vintage"] = this.vintage;
        data["type"] = this.type;
        super.toJSON(data);
        return data;
    }

	async validate(): Promise<boolean> {
        const errors = await validate(this);
        if (errors.length > 0){
			const errorMessages = errors.map((error: TsValidationError) => Object.values(error.constraints || {}).join(', ')).join('; ');
      		throw new Error(`Validation failed: ${errorMessages}`);
		}
        return true;
    }
}
