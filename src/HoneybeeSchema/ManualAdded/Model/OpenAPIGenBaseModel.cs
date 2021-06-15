using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
namespace HoneybeeSchema
{
    public partial class OpenAPIGenBaseModel : HoneybeeObject
    {
        public bool IsValid(bool throwException = false)
        {
            var isValid = !this.Validate().Any();
            if (isValid)
                return true;

            if (throwException)
                throw new ArgumentException("This is an invalid object, please use Validate() to check details!");
            else
                return false;
        }

        public IEnumerable<ValidationResult> Validate()
        {
            var vResults = new List<ValidationResult>();

            var vc = new ValidationContext(
                instance: this,
                serviceProvider: null,
                items: null);

            var isValid = Validator.TryValidateObject(
                instance: vc.ObjectInstance,
                validationContext: vc,
                validationResults: vResults,
                validateAllProperties: true);


            if (!isValid)
            {
                foreach (var validationResult in vResults)
                {
                    // skip Type
                    if (validationResult.MemberNames.Contains("Type") && validationResult.ErrorMessage.StartsWith("Invalid value for Type, must match a pattern of"))
                        continue;
                    yield return validationResult;
                }
            }

            yield break;
        }
    }


}