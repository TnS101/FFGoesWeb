namespace Application.CQ.Users.Commands.Create
{
    using global::Common;
    using MediatR;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class RegisterUserCommand : IRequest<string>
    {
        [DisplayName(GC.Username)]
        [Required(ErrorMessage = GC.RequiredField)]
        [RegularExpression(@"[A-Za-z]+\d*", ErrorMessage = GC.UsernameError)]
        public string Username { get; set;}

        [DisplayName(GC.Password)]
        [Required(ErrorMessage = GC.RequiredField)]
        [RegularExpression(@"[A-Z][A-za-z]+\d+", ErrorMessage = GC.PasswordError)]
        public string Password { get; set; }

        [DisplayName(GC.Email)]
        [Required(ErrorMessage = GC.RequiredField)]
        [EmailAddress(ErrorMessage = GC.EmailError)]
        public string Email { get; set; }

        [Compare(nameof(Password), ErrorMessage = GC.ConfirmPasswordError)]
        public string ConfirmPassword { get; set; }
    }
}
