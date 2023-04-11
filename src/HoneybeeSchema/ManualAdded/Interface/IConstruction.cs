
namespace HoneybeeSchema.Energy
{
    public partial interface IConstruction 
	{
		double VisibleTransmittance { get; }

		IConstruction GenReversedConstruction();
	}

    public partial interface IOpaqueConstruction
    {
    }

    public partial interface IWindowConstruction
    {
    }

    public partial interface IAirBoundaryConstruction
    {
    }
    public partial interface IShadeConstruction
    {
    }
}

namespace HoneybeeSchema
{

    public partial class AirBoundaryConstruction : HoneybeeSchema.Energy.IAirBoundaryConstruction { }
    public partial class AirBoundaryConstructionAbridged : HoneybeeSchema.Energy.IAirBoundaryConstruction { }

    public partial class OpaqueConstruction : HoneybeeSchema.Energy.IOpaqueConstruction { }
    public partial class OpaqueConstructionAbridged : HoneybeeSchema.Energy.IOpaqueConstruction { }
    public partial class ShadeConstruction : HoneybeeSchema.Energy.IShadeConstruction { }

    public partial class WindowConstruction : HoneybeeSchema.Energy.IWindowConstruction { }
    public partial class WindowConstructionAbridged : HoneybeeSchema.Energy.IWindowConstruction { }
    public partial class WindowConstructionDynamic : HoneybeeSchema.Energy.IWindowConstruction { }
    public partial class WindowConstructionDynamicAbridged : HoneybeeSchema.Energy.IWindowConstruction { }
    public partial class WindowConstructionShade : HoneybeeSchema.Energy.IWindowConstruction { }
    public partial class WindowConstructionShadeAbridged : HoneybeeSchema.Energy.IWindowConstruction { }
}
