extern alias LBTNewtonSoft; using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace HoneybeeSchema
{
    public partial class OpenAPIGenBaseModel : HoneybeeObject
    {
        public override string GetType => this.Type;

        //public bool IsValid(bool throwException = false)
        //{
        //    var res = this.Validate();
        //    var isValid = !res.Any();
        //    if (isValid)
        //        return true;

        //    var resMsgs = string.Join( "; ", res.Select(_ => _.ErrorMessage));
        //    if (throwException)
        //        throw new ArgumentException($"This is an invalid {this.Type} object! Error: {resMsgs}");
        //    else
        //        return false;
        //}

        //public IEnumerable<ValidationResult> Validate()
        //{
        //    var vResults = new List<ValidationResult>();

        //    var vc = new ValidationContext(instance: this, serviceProvider: null, items: null);

        //    var isValid = Validator.TryValidateObject(instance: vc.ObjectInstance, validationContext: vc, validationResults: vResults, validateAllProperties: true);
        //    if (!isValid)
        //    {
        //        foreach (var validationResult in vResults)
        //        {
        //            // skip Type
        //            if (validationResult.MemberNames.Contains("Type") && validationResult.ErrorMessage.StartsWith("Invalid value for Type, must match a pattern of"))
        //                continue;
        //            yield return validationResult;
        //        }
        //    }

        //    yield break;
        //}
    }


}