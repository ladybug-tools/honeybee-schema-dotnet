﻿import { IsString, IsOptional, Matches, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain } from 'class-transformer';
import { _OpenAPIGenBaseModel } from "./_OpenAPIGenBaseModel";

/** Void modifier */
export class Void extends _OpenAPIGenBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^Void$/)
    type?: string;
	

    constructor() {
        super();
        this.type = "Void";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(Void, _data, { enableImplicitConversion: true });
            this.type = obj.type;
        }
    }


    static override fromJS(data: any): Void {
        data = typeof data === 'object' ? data : {};

        let result = new Void();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
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

