namespace HoneybeeSchema
{
    public partial class WindowConstructionDynamic
    {
        public double VisibleTransmittance { get; private set; } = -999;

        public Energy.IConstruction GenReversedConstruction() => null;
    }
}
;