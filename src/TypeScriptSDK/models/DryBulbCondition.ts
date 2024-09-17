import { IsNumber, IsDefined, Min, Max, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Used to specify dry bulb conditions on a design day. */
export class DryBulbCondition extends _OpenAPIGenBaseModel {
    @IsNumber()
    @IsDefined()
    @Min(-90)
    @Max(70)
    /** The maximum dry bulb temperature on the design day [C]. */
    dry_bulb_max!: number;
	
    @IsNumber()
    @IsDefined()
    @Min(0)
    /** The difference between min and max temperatures on the design day [C]. */
    dry_bulb_range!: number;
	
    @IsString()
    @IsOptional()
    @Matches(/^DryBulbCondition$/)
    type?: string;
	

    constructor() {
        super();
        this.type = "DryBulbCondition";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(DryBulbCondition, _data);
            this.dry_bulb_max = obj.dry_bulb_max;
            this.dry_bulb_range = obj.dry_bulb_range;
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): DryBulbCondition {
        data = typeof data === 'object' ? data : {};

        let result = new DryBulbCondition();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["dry_bulb_max"] = this.dry_bulb_max;
        data["dry_bulb_range"] = this.dry_bulb_range;
        data["type"] = this.type;
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
