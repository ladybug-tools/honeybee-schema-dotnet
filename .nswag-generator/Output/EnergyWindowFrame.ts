﻿import { IsNumber, IsDefined, IsString, IsOptional, validate, ValidationError as TsValidationError } from 'class-validator';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Opaque material representing a layer within an opaque construction. */
export class EnergyWindowFrame extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    /** Number for the width of frame in plane of window [m]. The frame width is assumed to be the same on all sides of window.. */
    width!: number;
	
    @IsNumber()
    @IsDefined()
    /** Number for the thermal conductance of the frame material measured from inside to outside of the frame surface (no air films) and taking 2D conduction effects into account [W/m2-K]. */
    conductance!: number;
	
    @IsString()
    @IsOptional()
    type?: string;
	
    @IsNumber()
    @IsOptional()
    /** Number between 0 and 4 for the ratio of the glass conductance near the frame (excluding air films) divided by the glass conductance at the center of the glazing (excluding air films). This is used only for multi-pane glazing constructions. This ratio should usually be greater than 1.0 since the spacer material that separates the glass panes is usually more conductive than the gap between panes. A value of 1 effectively indicates no spacer. Values should usually be obtained from the LBNL WINDOW program so that the unique characteristics of the window construction can be accounted for. */
    edge_to_center_ratio?: number;
	
    @IsNumber()
    @IsOptional()
    /** Number for the distance that the frame projects outward from the outside face of the glazing [m]. This is used to calculate shadowing of frame onto glass, solar absorbed by the frame, IR emitted and absorbed by the frame, and convection from frame. */
    outside_projection?: number;
	
    @IsNumber()
    @IsOptional()
    /** Number for the distance that the frame projects inward from the inside face of the glazing [m]. This is used to calculate solar absorbed by the frame, IR emitted and absorbed by the frame, and convection from frame. */
    inside_projection?: number;
	
    @IsNumber()
    @IsOptional()
    /** Fraction of incident long wavelength radiation that is absorbed by the frame material. */
    thermal_absorptance?: number;
	
    @IsNumber()
    @IsOptional()
    /** Fraction of incident solar radiation absorbed by the frame material. */
    solar_absorptance?: number;
	
    @IsNumber()
    @IsOptional()
    /** Fraction of incident visible wavelength radiation absorbed by the frame material. */
    visible_absorptance?: number;
	

    constructor() {
        super();
        this.type = "EnergyWindowFrame";
        this.edge_to_center_ratio = 1;
        this.outside_projection = 0;
        this.inside_projection = 0;
        this.thermal_absorptance = 0.9;
        this.solar_absorptance = 0.7;
        this.visible_absorptance = 0.7;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.width = _data["width"];
            this.conductance = _data["conductance"];
            this.type = _data["type"] !== undefined ? _data["type"] : "EnergyWindowFrame";
            this.edge_to_center_ratio = _data["edge_to_center_ratio"] !== undefined ? _data["edge_to_center_ratio"] : 1;
            this.outside_projection = _data["outside_projection"] !== undefined ? _data["outside_projection"] : 0;
            this.inside_projection = _data["inside_projection"] !== undefined ? _data["inside_projection"] : 0;
            this.thermal_absorptance = _data["thermal_absorptance"] !== undefined ? _data["thermal_absorptance"] : 0.9;
            this.solar_absorptance = _data["solar_absorptance"] !== undefined ? _data["solar_absorptance"] : 0.7;
            this.visible_absorptance = _data["visible_absorptance"] !== undefined ? _data["visible_absorptance"] : 0.7;
        }
    }


    static override fromJS(data: any): EnergyWindowFrame {
        data = typeof data === 'object' ? data : {};

        let result = new EnergyWindowFrame();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        for (var property in this) {
            if (this.hasOwnProperty(property))
                data[property] = this[property];
        }

        data["width"] = this.width;
        data["conductance"] = this.conductance;
        data["type"] = this.type;
        data["edge_to_center_ratio"] = this.edge_to_center_ratio;
        data["outside_projection"] = this.outside_projection;
        data["inside_projection"] = this.inside_projection;
        data["thermal_absorptance"] = this.thermal_absorptance;
        data["solar_absorptance"] = this.solar_absorptance;
        data["visible_absorptance"] = this.visible_absorptance;
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
