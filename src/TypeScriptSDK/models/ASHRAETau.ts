import { IsNumber, IsDefined, Min, Max, IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { _SkyCondition } from "./_SkyCondition";

/** Used to specify sky conditions on a design day. */
export class ASHRAETau extends _SkyCondition {
    @IsNumber()
    @IsDefined()
    @Min(0)
    @Max(1.2)
    /** Value for the beam optical depth. Typically found in .stat files. */
    tau_b!: number;
	
    @IsNumber()
    @IsDefined()
    @Min(0)
    @Max(3)
    /** Value for the diffuse optical depth. Typically found in .stat files. */
    tau_d!: number;
	
    @IsString()
    @IsOptional()
    @Matches(/^ASHRAETau$/)
    type?: string;
	

    constructor() {
        super();
        this.type = "ASHRAETau";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(ASHRAETau, _data);
            this.tau_b = obj.tau_b;
            this.tau_d = obj.tau_d;
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): ASHRAETau {
        data = typeof data === 'object' ? data : {};

        let result = new ASHRAETau();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["tau_b"] = this.tau_b;
        data["tau_d"] = this.tau_d;
        data["type"] = this.type;
        super.toJSON(data);
        return data;
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
