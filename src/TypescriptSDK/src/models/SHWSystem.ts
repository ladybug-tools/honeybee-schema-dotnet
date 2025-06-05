import { IsString, IsOptional, Matches, IsEnum, IsNumber, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { Autocalculate } from "./Autocalculate";
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";
import { SHWEquipmentType } from "./SHWEquipmentType";

/** Provides a model for a Service Hot Water system. */
export class SHWSystem extends IDdEnergyBaseModel {
    @IsString()
    @IsOptional()
    @Matches(/^SHWSystem$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "SHWSystem";
	
    @IsEnum(SHWEquipmentType)
    @Type(() => String)
    @IsOptional()
    @Expose({ name: "equipment_type" })
    /** Text to indicate the type of air-side economizer used on the ideal air system. Economizers will mix in a greater amount of outdoor air to cool the zone (rather than running the cooling system) when the zone needs cooling and the outdoor air is cooler than the zone. */
    equipmentType: SHWEquipmentType = SHWEquipmentType.Gas_WaterHeater;
	
    @IsOptional()
    @Expose({ name: "heater_efficiency" })
    /** A number for the efficiency of the heater within the system. For Gas systems, this is the efficiency of the burner. For HeatPump systems, this is the rated COP of the system. For electric systems, this should usually be set to 1. If set to Autocalculate, this value will automatically be set based on the equipment_type. Gas_WaterHeater - 0.8, Electric_WaterHeater - 1.0, HeatPump_WaterHeater - 3.5, Gas_TanklessHeater - 0.8, Electric_TanklessHeater - 1.0. */
    heaterEfficiency: (number | Autocalculate) = new Autocalculate();
	
    @IsOptional()
    @Expose({ name: "ambient_condition" })
    /** A number for the ambient temperature in which the hot water tank is located [C]. This can also be the identifier of a Room in which the tank is located. */
    ambientCondition: (number | string) = 22;
	
    @IsNumber()
    @IsOptional()
    @Expose({ name: "ambient_loss_coefficient" })
    /** A number for the loss of heat from the water heater tank to the surrounding ambient conditions [W/K]. */
    ambientLossCoefficient: number = 6;
	

    constructor() {
        super();
        this.type = "SHWSystem";
        this.equipmentType = SHWEquipmentType.Gas_WaterHeater;
        this.heaterEfficiency = new Autocalculate();
        this.ambientCondition = 22;
        this.ambientLossCoefficient = 6;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(SHWSystem, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.type = obj.type ?? "SHWSystem";
            this.equipmentType = obj.equipmentType ?? SHWEquipmentType.Gas_WaterHeater;
            this.heaterEfficiency = obj.heaterEfficiency ?? new Autocalculate();
            this.ambientCondition = obj.ambientCondition ?? 22;
            this.ambientLossCoefficient = obj.ambientLossCoefficient ?? 6;
        }
    }


    static override fromJS(data: any): SHWSystem {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new SHWSystem();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type ?? "SHWSystem";
        data["equipment_type"] = this.equipmentType ?? SHWEquipmentType.Gas_WaterHeater;
        data["heater_efficiency"] = this.heaterEfficiency ?? new Autocalculate();
        data["ambient_condition"] = this.ambientCondition ?? 22;
        data["ambient_loss_coefficient"] = this.ambientLossCoefficient ?? 6;
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
