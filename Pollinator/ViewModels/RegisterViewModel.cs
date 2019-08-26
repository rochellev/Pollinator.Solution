using System.ComponentModel.DataAnnotations;
namespace Pollinator.ViewModels
{
public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email {get; set;}
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password {get; set;}
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation do not match")]
    public string ConfirmPassword {get; set;}
 }
}
