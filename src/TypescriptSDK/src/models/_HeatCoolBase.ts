import { IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _TemplateSystem } from "./_TemplateSystem";
import { Vintages } from "./Vintages";

/** Base class for all heating/cooling systems without any ventilation.\n\nThese systems are only designed to satisfy heating + cooling demand and they\ncannot meet any minimum ventilation requirements.\n\nAs such, these systems tend to be used in residential or storage settings where\nmeeting minimum ventilation requirements may not be required or the density\nof occupancy is so low that infiltration is enough to meet fresh air demand. */
export class _HeatCoolBase extends _TemplateSystem {
    @Type(() => String)
    @IsString()
    @IsOptional()
    @Matches(/^_HeatCoolBase$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "_HeatCoolBase";
	

    constructor() {
        super();
        this.type = "_HeatCoolBase";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(_HeatCoolBase, _data);
            this.type = obj.type ?? "_HeatCoolBase";
            this.vintage = obj.vintage ?? Vintages.ASHRAE_2019;
            this.userData = obj.userData;
            this.identifier = obj.identifier;
            this.displayName = obj.displayName;
        }
    }


    static override fromJS(data: any): _HeatCoolBase {
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

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "_HeatCoolBase";
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
