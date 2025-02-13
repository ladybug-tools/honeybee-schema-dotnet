import { IsString, IsOptional, Matches, IsInstance, ValidateNested, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";
import { DoorEnergyPropertiesAbridged } from "./DoorEnergyPropertiesAbridged";
import { DoorRadiancePropertiesAbridged } from "./DoorRadiancePropertiesAbridged";

export class DoorPropertiesAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^DoorPropertiesAbridged$/)
    /** Type */
    type?: string;
	
    @IsInstance(DoorEnergyPropertiesAbridged)
    @Type(() => DoorEnergyPropertiesAbridged)
    @ValidateNested()
    @IsOptional()
    /** Energy */
    energy?: DoorEnergyPropertiesAbridged;
	
    @IsInstance(DoorRadiancePropertiesAbridged)
    @Type(() => DoorRadiancePropertiesAbridged)
    @ValidateNested()
    @IsOptional()
    /** Radiance */
    radiance?: DoorRadiancePropertiesAbridged;
	

    constructor() {
        super();
        this.type = "DoorPropertiesAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(DoorPropertiesAbridged, _data, { enableImplicitConversion: true });
            this.type = obj.type;
            this.energy = obj.energy;
            this.radiance = obj.radiance;
        }
    }


    static override fromJS(data: any): DoorPropertiesAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new DoorPropertiesAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["energy"] = this.energy;
        data["radiance"] = this.radiance;
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

