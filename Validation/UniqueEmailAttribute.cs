using System.ComponentModel.DataAnnotations;
using D424.Data;

namespace D424.Validation
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var dbContext = (D424Context?)validationContext.GetService(typeof(D424Context));

            var email = (string?)value;

            var existingUser = dbContext?.User.FirstOrDefault(u  => u.Email == email);

            if (existingUser != null)
            {
                return new ValidationResult("Email is taken.");
            }
            else
            {
                return ValidationResult.Success!;
            }
        }
    }
}
