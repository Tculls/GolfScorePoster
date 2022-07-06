
using System.ComponentModel.DataAnnotations;
public class PastDate : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext context)
    {
        DateTime datePlayed = Convert.ToDateTime(value);
        if (datePlayed.Date < DateTime.Now)
        {
            return ValidationResult.Success;
        }
        else
        {
            return new ValidationResult("must be a past date");
        }
    }
}