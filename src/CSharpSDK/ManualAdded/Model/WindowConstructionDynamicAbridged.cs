namespace HoneybeeSchema
{
    public partial class WindowConstructionDynamicAbridged
    {
        public double VisibleTransmittance { get; private set; } = -999;
        public Energy.IConstruction GenReversedConstruction() => this.DuplicateWindowConstructionDynamicAbridged();
    }
}
;