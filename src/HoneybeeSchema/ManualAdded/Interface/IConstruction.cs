
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
}

namespace HoneybeeSchema
{
   
    //public partial class AirBoundaryConstruction : HoneybeeSchema.Energy.IConstruction { }
    //public partial class AirBoundaryConstructionAbridged : HoneybeeSchema.Energy.IConstruction { }
    public partial class OpaqueConstruction : HoneybeeSchema.Energy.IOpaqueConstruction { }
    public partial class OpaqueConstructionAbridged : HoneybeeSchema.Energy.IOpaqueConstruction { }
    //public partial class ShadeConstruction : HoneybeeSchema.Energy.IConstruction { }

    public partial class WindowConstruction : HoneybeeSchema.Energy.IWindowConstruction { }
    public partial class WindowConstructionAbridged : HoneybeeSchema.Energy.IWindowConstruction { }
    public partial class WindowConstructionDynamic : HoneybeeSchema.Energy.IWindowConstruction { }
    public partial class WindowConstructionDynamicAbridged : HoneybeeSchema.Energy.IWindowConstruction { }
    public partial class WindowConstructionShade : HoneybeeSchema.Energy.IWindowConstruction { }
    public partial class WindowConstructionShadeAbridged : HoneybeeSchema.Energy.IWindowConstruction { }
}
