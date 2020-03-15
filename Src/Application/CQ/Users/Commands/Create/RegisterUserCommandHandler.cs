namespace Application.CQ.Users.Commands.Create
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand,string>
    {
        private readonly IFFDbContext context;
        public RegisterUserCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }
        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            if (request.Password.Length < 8 || request.Password.Length > 30)
            {
                return "Password Length must be between 8 and 30 characters";
            }
            if (request.Username.Length < 5 || request.Username.Length > 20)
            {
                return "Username length must be between 5 and 20 characters";
            }
            if (this.context.Users.Any(u => u.Username == request.Username))
            {
                return "Username is already taken, please choose another email address";
            }
            if (this.context.Users.Any(u => u.Email == request.Email))
            {
                return "Email address is in use, please choose another email address";
            }
            else
            {
                await this.context.SaveChangesAsync(cancellationToken);
                return "Succsefuly registered! Redirecting to the login page.";
            }
        }
    }
}
