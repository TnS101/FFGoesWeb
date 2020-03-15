namespace Application.CQ.Users.Commands.Create
{
    using MediatR;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class RegisterUserCommand : IRequest<string>
    {
        [DisplayName("User Name")]
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"[A-Za-z]+\d*", ErrorMessage = "Username must contain only letters or digits and must be at least 5 characters long")]
        public string Username { get; set;}

        [DisplayName("Password")]
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"[A-Z][A-za-z]+\d+", ErrorMessage = "Password must contain at least one uppercase letter, one digit and must be at least 8 characters long")]
        public string Password { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "This field is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }
    }
}
