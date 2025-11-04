using System;
using System.ComponentModel.DataAnnotations;

namespace SharedSetup.Domain.Common.CustomAttributes
{
	public class RequiredDateTime : ValidationAttribute
	{
		public RequiredDateTime(string errorMessage = "")
		{
			ErrorMessage = errorMessage;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value == null)
			{
				return new ValidationResult(validationContext.MemberName + " is required");
			}
			DateTime result = default(DateTime);
			if (DateTime.TryParse(value.ToString(), out result) && result.Year <= 1900)
			{
				return (!string.IsNullOrEmpty(ErrorMessage)) ? new ValidationResult(ErrorMessage) : new ValidationResult(validationContext.MemberName + " is required");
			}
			return ValidationResult.Success;
		}
	}
}
