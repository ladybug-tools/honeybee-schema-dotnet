import { IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for the abridged modifier sets assigned to Faces. */
export class BaseModifierSetAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    /** Identifier for a radiance modifier object for faces with an  Outdoors boundary condition. */
    exterior_modifier?: string;
	
    @IsString()
    @IsOptional()
    /** Identifier for a radiance modifier object for faces with a boundary condition other than Outdoors. */
    interior_modifier?: string;
	
    @IsString()
    @IsOptional()
    @Matches(/^BaseModifierSetAbridged$/)
    type?: string;
	

    constructor() {
        super();
        this.type = "BaseModifierSetAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(BaseModifierSetAbridged, _data, { enableImplicitConversion: true });
            this.exterior_modifier = obj.exterior_modifier;
            this.interior_modifier = obj.interior_modifier;
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): BaseModifierSetAbridged {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new BaseModifierSetAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["exterior_modifier"] = this.exterior_modifier;
        data["interior_modifier"] = this.interior_modifier;
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

