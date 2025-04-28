namespace HoneybeeSchema
{
    public partial class ShadeConstruction
    {
        public double VisibleTransmittance => 0;
        public Energy.IConstruction GenReversedConstruction() => this.DuplicateShadeConstruction();
    }

}
;