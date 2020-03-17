namespace Application.CQ.Users.Commands.Create
{
    using global::Common;
    using MediatR;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class RegisterUserCommand : IRequest<string[]>
    {
        [DisplayName(GConst.Username)]
        [Required(ErrorMessage = GConst.RequiredField)]
        [StringLength(20, MinimumLength = 5)]
        [RegularExpression(@"[A-Za-z]+\d*", ErrorMessage = GConst.UsernameError)]
        public string Username { get; set;}

        [DisplayName(GConst.Password)]
        [Required(ErrorMessage = GConst.RequiredField)]
        [StringLength(30, MinimumLength = 8)]
        [RegularExpression(@"[A-Z][A-za-z]+\d+", ErrorMessage = GConst.PasswordError)]
        public string Password { get; set; }

        [DisplayName(GConst.Email)]
        [Required(ErrorMessage = GConst.RequiredField)]
        [EmailAddress(ErrorMessage = GConst.EmailError)]
        public string Email { get; set; }

        [Compare(nameof(Password), ErrorMessage = GConst.ConfirmPasswordError)]
        public string ConfirmPassword { get; set; }
    }
}
