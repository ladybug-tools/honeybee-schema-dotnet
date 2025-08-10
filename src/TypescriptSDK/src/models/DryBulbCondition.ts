import { IsNumber, IsDefined, Min, Max, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, instanceToPlain, Expose, Transform } from 'class-transformer';
import { deepTransform } from '../deepTransform';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Used to specify dry bulb conditions on a design day. */
export class DryBulbCondition extends _OpenAPIGenBaseModel {
    @IsNumber()
    @IsDefined()
    @Min(-90)
    @Max(70)
    @Expose({ name: "dry_bulb_max" })
    /** The maximum dry bulb temperature on the design day [C]. */
    dryBulbMax!: number;
	
    @IsNumber()
    @IsDefined()
    @Min(0)
    @Expose({ name: "dry_bulb_range" })
    /** The difference between min and max temperatures on the design day [C]. */
    dryBulbRange!: number;
	
    @IsString()
    @IsOptional()
    @Matches(/^DryBulbCondition$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "DryBulbCondition";
	

    constructor() {
        super();
        this.type = "DryBulbCondition";
    }


    override init(_data?: any) {

        if (_data) {
            const obj = deepTransform(DryBulbCondition, _data);
            this.dryBulbMax = obj.dryBulbMax;
            this.dryBulbRange = obj.dryBulbRange;
            this.type = obj.type ?? "DryBulbCondition";
        }
    }


    static override fromJS(data: any): DryBulbCondition {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new DryBulbCondition();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["dry_bulb_max"] = this.dryBulbMax;
        data["dry_bulb_range"] = this.dryBulbRange;
        data["type"] = this.type ?? "DryBulbCondition";
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
