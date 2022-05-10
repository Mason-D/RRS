using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using System.ComponentModel.DataAnnotations;
using static Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal.ExternalLoginModel;

namespace RRS.Attributes
{
    public class RequiredWhenPersonDoesNotExist : ValidationAttribute
    {
        public string GetErrorMessage() => $"This field is required";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //var registerModel = (RegisterModel) (InputModel) validationContext.ObjectInstance;
            //registerModel.
            //if (!(bool)registerModel.ViewData["PersonExists"])
            //{
            //    return null;
            //}
            return ValidationResult.Success;
        }
    }
}
