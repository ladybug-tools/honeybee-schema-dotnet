namespace HoneybeeSchema
{
    public partial class AirBoundaryConstructionAbridged
    {
        public double VisibleTransmittance => 1;

        public Energy.IConstruction GenReversedConstruction() => this.DuplicateAirBoundaryConstructionAbridged();
    }

}
;