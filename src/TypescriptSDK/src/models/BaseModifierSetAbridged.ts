import { IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Base class for the abridged modifier sets assigned to Faces. */
export class BaseModifierSetAbridged extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Expose({ name: "exterior_modifier" })
    /** Identifier for a radiance modifier object for faces with an  Outdoors boundary condition. */
    exteriorModifier?: string;
	
    @IsString()
    @IsOptional()
    @Expose({ name: "interior_modifier" })
    /** Identifier for a radiance modifier object for faces with a boundary condition other than Outdoors. */
    interiorModifier?: string;
	
    @IsString()
    @IsOptional()
    @Matches(/^BaseModifierSetAbridged$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "BaseModifierSetAbridged";
	

    constructor() {
        super();
        this.type = "BaseModifierSetAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(BaseModifierSetAbridged, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.exteriorModifier = obj.exteriorModifier;
            this.interiorModifier = obj.interiorModifier;
            this.type = obj.type ?? "BaseModifierSetAbridged";
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
        data["exterior_modifier"] = this.exteriorModifier;
        data["interior_modifier"] = this.interiorModifier;
        data["type"] = this.type ?? "BaseModifierSetAbridged";
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
