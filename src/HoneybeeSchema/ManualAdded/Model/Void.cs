namespace HoneybeeSchema
{
    public partial class Void
    {
        // add placeholder here for void fullfilling the requirement of interface IModifier,
        // following will never be used or serialized/de-serialized

        public string Identifier { get; set; } = "void";
        public string DisplayName { get; set; } = "void";
    }
}
