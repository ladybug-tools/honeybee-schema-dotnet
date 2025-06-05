import { IsNumber, IsDefined, Max, IsString, IsOptional, Matches, Min, validate, ValidationError as TsValidationError } from 'class-validator';
import { Type, plainToClass, instanceToPlain, Expose, Transform } from 'class-transformer';
import { IDdEnergyBaseModel } from "./IDdEnergyBaseModel";

/** Opaque material representing a layer within an opaque construction. */
export class EnergyWindowFrame extends IDdEnergyBaseModel {
    @IsNumber()
    @IsDefined()
    @Max(1)
    @Expose({ name: "width" })
    /** Number for the width of frame in plane of window [m]. The frame width is assumed to be the same on all sides of window.. */
    width!: number;
	
    @IsNumber()
    @IsDefined()
    @Expose({ name: "conductance" })
    /** Number for the thermal conductance of the frame material measured from inside to outside of the frame surface (no air films) and taking 2D conduction effects into account [W/m2-K]. */
    conductance!: number;
	
    @IsString()
    @IsOptional()
    @Matches(/^EnergyWindowFrame$/)
    @Expose({ name: "type" })
    /** type */
    type: string = "EnergyWindowFrame";
	
    @IsNumber()
    @IsOptional()
    @Max(4)
    @Expose({ name: "edge_to_center_ratio" })
    /** Number between 0 and 4 for the ratio of the glass conductance near the frame (excluding air films) divided by the glass conductance at the center of the glazing (excluding air films). This is used only for multi-pane glazing constructions. This ratio should usually be greater than 1.0 since the spacer material that separates the glass panes is usually more conductive than the gap between panes. A value of 1 effectively indicates no spacer. Values should usually be obtained from the LBNL WINDOW program so that the unique characteristics of the window construction can be accounted for. */
    edgeToCenterRatio: number = 1;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(0.5)
    @Expose({ name: "outside_projection" })
    /** Number for the distance that the frame projects outward from the outside face of the glazing [m]. This is used to calculate shadowing of frame onto glass, solar absorbed by the frame, IR emitted and absorbed by the frame, and convection from frame. */
    outsideProjection: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(0.5)
    @Expose({ name: "inside_projection" })
    /** Number for the distance that the frame projects inward from the inside face of the glazing [m]. This is used to calculate solar absorbed by the frame, IR emitted and absorbed by the frame, and convection from frame. */
    insideProjection: number = 0;
	
    @IsNumber()
    @IsOptional()
    @Max(0.99999)
    @Expose({ name: "thermal_absorptance" })
    /** Fraction of incident long wavelength radiation that is absorbed by the frame material. */
    thermalAbsorptance: number = 0.9;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "solar_absorptance" })
    /** Fraction of incident solar radiation absorbed by the frame material. */
    solarAbsorptance: number = 0.7;
	
    @IsNumber()
    @IsOptional()
    @Min(0)
    @Max(1)
    @Expose({ name: "visible_absorptance" })
    /** Fraction of incident visible wavelength radiation absorbed by the frame material. */
    visibleAbsorptance: number = 0.7;
	

    constructor() {
        super();
        this.type = "EnergyWindowFrame";
        this.edgeToCenterRatio = 1;
        this.outsideProjection = 0;
        this.insideProjection = 0;
        this.thermalAbsorptance = 0.9;
        this.solarAbsorptance = 0.7;
        this.visibleAbsorptance = 0.7;
    }


    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            const obj = plainToClass(EnergyWindowFrame, _data, { enableImplicitConversion: true, exposeUnsetFields: false });
            this.width = obj.width;
            this.conductance = obj.conductance;
            this.type = obj.type ?? "EnergyWindowFrame";
            this.edgeToCenterRatio = obj.edgeToCenterRatio ?? 1;
            this.outsideProjection = obj.outsideProjection ?? 0;
            this.insideProjection = obj.insideProjection ?? 0;
            this.thermalAbsorptance = obj.thermalAbsorptance ?? 0.9;
            this.solarAbsorptance = obj.solarAbsorptance ?? 0.7;
            this.visibleAbsorptance = obj.visibleAbsorptance ?? 0.7;
        }
    }


    static override fromJS(data: any): EnergyWindowFrame {
        data = typeof data === 'object' ? data : {};

        if (Array.isArray(data)) {
            const obj:any = {};
            for (var property in data) {
                obj[property] = data[property];
            }
            data = obj;
        }
        let result = new EnergyWindowFrame();
        result.init(data);
        return result;
    }

	override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["width"] = this.width;
        data["conductance"] = this.conductance;
        data["type"] = this.type ?? "EnergyWindowFrame";
        data["edge_to_center_ratio"] = this.edgeToCenterRatio ?? 1;
        data["outside_projection"] = this.outsideProjection ?? 0;
        data["inside_projection"] = this.insideProjection ?? 0;
        data["thermal_absorptance"] = this.thermalAbsorptance ?? 0.9;
        data["solar_absorptance"] = this.solarAbsorptance ?? 0.7;
        data["visible_absorptance"] = this.visibleAbsorptance ?? 0.7;
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
