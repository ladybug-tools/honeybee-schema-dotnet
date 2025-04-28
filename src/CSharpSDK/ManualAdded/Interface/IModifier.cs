
namespace HoneybeeSchema.Radiance
{
    public partial interface IModifier
	{
		double Reflectance { get; }
		double Transmittance { get; }
		double Emittance { get; }

		/// <summary>
		/// Calculate average visual values, after which you can get values from properties: Reflectance, Transmittance, Emittance.
		/// </summary>
		/// <returns></returns>
		bool CalVisualValues();
	}
}
