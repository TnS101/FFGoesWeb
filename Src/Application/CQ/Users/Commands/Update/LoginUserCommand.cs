namespace Application.CQ.Users.Commands.Update
{
    using MediatR;

    public class LoginUserCommand : IRequest<string>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
