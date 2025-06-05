import { IsString, IsDefined, MinLength, MaxLength, IsNumber, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class InternalMassAbridged extends IDdEnergyBaseModel {
    @IsString()
    @IsDefined()
    @MinLength(1)
    @MaxLength(100)
    @Expose({ name: "construction" })
    /** Identifier for an OpaqueConstruction that represents the material that the internal thermal mass is composed of. */
    construction!: string;
	
    @IsNumber()
    @IsDefined()
    @Expose({ name: "area" })
    /** A number representing the surface area of the internal mass that is exposed to the Room air. This value should always be in square meters regardless of what units system the parent model is a part of. */
    area!: number;
	
    @IsString()
    @IsOptional()
    @Matches(/^InternalMassAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "InternalMassAbridged";
	

    constructor() {
        super();
        this.type = "InternalMassAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(InternalMassAbridged, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.construction = obj.construction;
            this.area = obj.area;
            this.type = obj.type ?? "InternalMassAbridged";
        }
    }


    static override fromJS(data: any): InternalMassAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new InternalMassAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["construction"] = this.construction;
        data["area"] = this.area;
        data["type"] = this.type ?? "InternalMassAbridged";
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
