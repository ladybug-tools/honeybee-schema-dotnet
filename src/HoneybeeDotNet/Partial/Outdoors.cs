namespace HoneybeeDotNet
{
    public partial class Outdoors
    {
        /// <summary>
        /// Initialize a default Outdoor instance with default autocalculated view factor.
        /// </summary>
        public Outdoors():this(viewFactor: new Autocalculate())
        {
        }
    }
}
