namespace HoneybeeSchema
{
    public partial class AirBoundaryConstruction
    {
        public double VisibleTransmittance => 1;

        public Energy.IConstruction GenReversedConstruction() => this.DuplicateAirBoundaryConstruction();
    }

}
;