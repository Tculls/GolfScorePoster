#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[NotMapped]
public class LoginUser
{
    [Required(ErrorMessage = "is required.")]
    [EmailAddress]
    [Display(Name = "Email")]
    public string LoginEmail {get ; set; }

    [Required(ErrorMessage = "is required")]
    [MinLength(8, ErrorMessage = "Invalid Email & Password Combination")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string LoginPassword { get; set; }
}