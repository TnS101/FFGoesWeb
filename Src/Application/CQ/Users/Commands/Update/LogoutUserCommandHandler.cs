namespace Application.CQ.Users.Commands.Update
{
    using Domain.Entities.Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using System.Threading;
    using System.Threading.Tasks;

    public class LogoutUserCommandHandler : IRequestHandler<LogoutUserCommand,string>
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        public LogoutUserCommandHandler (SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public async Task<string> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
        {
            await this.signInManager.SignOutAsync();
            return "/";
        }
    }
}
