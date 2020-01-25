namespace HoneybeeDotNet.Model
{
    public partial class Door
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Door" /> with minimum outdoor type parameters.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="geometry"></param>
        public Door(string name, Face3D geometry) :this(name, geometry, new Outdoors(),new DoorPropertiesAbridged())
        {

        }
    }
}
