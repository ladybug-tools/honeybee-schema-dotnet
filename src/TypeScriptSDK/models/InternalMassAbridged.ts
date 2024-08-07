﻿import { IsString, IsDefined, IsNumber, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Base class for all objects requiring an EnergyPlus identifier and user_data. */
export class InternalMassAbridged extends IDdEnergyBaseModel {
    @IsString()
    @IsDefined()
    /** Identifier for an OpaqueConstruction that represents the material that the internal thermal mass is composed of. */
    construction!: string;
	
    @IsNumber()
    @IsDefined()
    /** A number representing the surface area of the internal mass that is exposed to the Room air. This value should always be in square meters regardless of what units system the parent model is a part of. */
    area!: number;
	
    @IsString()
    @IsOptional()
    type?: string;
	

    constructor() {
        super();
        this.type = "InternalMassAbridged";
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.construction = _data["construction"];
            this.area = _data["area"];
            this.type = _data["type"] !== undefined ? _data["type"] : "InternalMassAbridged";
        }
    }


    static override fromJS(data: any): InternalMassAbridged {
        data = typeof data === 'object' ? data : {};

        let result = new InternalMassAbridged();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["construction"] = this.construction;
        data["area"] = this.area;
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
