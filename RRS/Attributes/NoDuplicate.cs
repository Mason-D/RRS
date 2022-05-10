using System.ComponentModel.DataAnnotations;

namespace RRS.Attributes
{
    public class NoDuplicateName : ValidationAttribute
    {
        public NoDuplicateName(string name, NameType nameType)
        {
            Name = name;
            NameType = nameType;
        }

        public string Name { get; set; }
        public NameType NameType { get; set; }

        public string GetErrorMessage() => $"{Name} doesn't match {NameType} with exisiting email";

        //public override ValidationResult? IsValid(object? value)
        //{
        //    return ValidationResult.Success;
        //}
    }

    public enum NameType
    {
        FirstName,
        LastName
    }
}
