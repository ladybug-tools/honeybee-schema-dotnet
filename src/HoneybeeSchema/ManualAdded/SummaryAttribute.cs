using System;

namespace HoneybeeSchema
{
    public class SummaryAttribute : Attribute
    {
        private string _summary;
        public SummaryAttribute(string summary)
        {
            this._summary = summary;
        }
    }
}
