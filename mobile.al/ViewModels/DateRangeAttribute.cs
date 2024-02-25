using System.ComponentModel.DataAnnotations;

namespace mobile.al.ViewModels
{
    public class DateRangeAttribute : ValidationAttribute
    {
        private readonly DateTime _minDate;
        private readonly DateTime _maxDate;

        public DateRangeAttribute(int minYear)
        {
            _minDate = new DateTime(minYear, 1, 1);
            _maxDate = DateTime.UtcNow;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateValue)
            {
                if (dateValue < _maxDate || dateValue > _minDate)
                {
                    return new ValidationResult($"The field {validationContext.DisplayName} must be between {_minDate.ToShortDateString()} and {_maxDate.ToShortDateString()}.");
                }
            }

            return ValidationResult.Success;
        }
    }
}