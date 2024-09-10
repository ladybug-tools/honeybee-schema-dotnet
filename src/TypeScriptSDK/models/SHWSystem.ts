import { IsString, IsOptional, Matches, IsEnum, IsNumber, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass } from 'class-transformer';
import { Autocalculate } from "./Autocalculate";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { SHWEquipmentType } from "./SHWEquipmentType";

/** Provides a model for a Service Hot Water system. */
export class SHWSystem extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^SHWSystem$/)
    type?: string;
	
    @IsEnum(SHWEquipmentType)
    @Type(() => String)
    @IsOptional()
    /** Text to indicate the type of air-side economizer used on the ideal air system. Economizers will mix in a greater amount of outdoor air to cool the zone (rather than running the cooling system) when the zone needs cooling and the outdoor air is cooler than the zone. */
    equipment_type?: SHWEquipmentType;
	
    @IsOptional()
    /** A number for the efficiency of the heater within the system. For Gas systems, this is the efficiency of the burner. For HeatPump systems, this is the rated COP of the system. For electric systems, this should usually be set to 1. If set to Autocalculate, this value will automatically be set based on the equipment_type. Gas_WaterHeater - 0.8, Electric_WaterHeater - 1.0, HeatPump_WaterHeater - 3.5, Gas_TanklessHeater - 0.8, Electric_TanklessHeater - 1.0. */
    heater_efficiency?: (number | Autocalculate);
	
    @IsOptional()
    /** A number for the ambient temperature in which the hot water tank is located [C]. This can also be the identifier of a Room in which the tank is located. */
    ambient_condition?: (number | string);
	
    @IsNumber()
    @IsOptional()
    /** A number for the loss of heat from the water heater tank to the surrounding ambient conditions [W/K]. */
    ambient_loss_coefficient?: number;
	

    constructor() {
        super();
        this.type = "SHWSystem";
        this.equipment_type = SHWEquipmentType.Gas_WaterHeater;
        this.heater_efficiency = new Autocalculate();
        this.ambient_condition = 22;
        this.ambient_loss_coefficient = 6;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(SHWSystem, _data);
            this.type = obj.type;
            this.equipment_type = obj.equipment_type;
            this.heater_efficiency = obj.heater_efficiency;
            this.ambient_condition = obj.ambient_condition;
            this.ambient_loss_coefficient = obj.ambient_loss_coefficient;
        }
    }


    static override fromJS(data: any): SHWSystem {
        data = typeof data === 'object' ? data : {};

        let result = new SHWSystem();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["type"] = this.type;
        data["equipment_type"] = this.equipment_type;
        data["heater_efficiency"] = this.heater_efficiency;
        data["ambient_condition"] = this.ambient_condition;
        data["ambient_loss_coefficient"] = this.ambient_loss_coefficient;
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
