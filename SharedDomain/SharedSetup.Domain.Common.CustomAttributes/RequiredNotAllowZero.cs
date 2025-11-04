using System.ComponentModel.DataAnnotations;

namespace SharedSetup.Domain.Common.CustomAttributes
{
	public class RequiredNotAllowZero : ValidationAttribute
	{
		public RequiredNotAllowZero(string errorMessage = "")
		{
			ErrorMessage = errorMessage;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value == null)
			{
				return new ValidationResult(validationContext.MemberName + " is required");
			}
			decimal result = 0m;
			if (decimal.TryParse(value.ToString(), out result) && result <= 0m)
			{
				return (!string.IsNullOrEmpty(ErrorMessage)) ? new ValidationResult(ErrorMessage) : new ValidationResult(validationContext.MemberName + " is required");
			}
			return ValidationResult.Success;
		}
	}
}
