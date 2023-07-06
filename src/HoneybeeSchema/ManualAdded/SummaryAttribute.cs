using System;

namespace HoneybeeSchema
{
    public class SummaryAttribute : Attribute
    {
        private string _summary;

        public string Summary
        {
            get => _summary;
            //set => _summary = value;
        }

        public SummaryAttribute(string summary)
        {
            this._summary = summary;
        }

        public static string GetSummary(Type t)
        {
            try
            {
                var att = (SummaryAttribute)Attribute.GetCustomAttribute(t, typeof(SummaryAttribute));
                return att?.Summary;
            }
            catch (Exception)
            {
                return string.Empty;
            }
           
        }

        public static string GetSummary(Type t, string property)
        {
            try
            {
                var prop = t.GetProperty(property);
                var att = (SummaryAttribute)Attribute.GetCustomAttribute(prop, typeof(SummaryAttribute));
                return att?.Summary;
            }
            catch (Exception)
            {
                return string.Empty;
            }
           
        }
    }
}
