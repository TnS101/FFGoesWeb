namespace Application.CQ.Users.Commands.Update
{
    using Domain.Entities.Common;
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand,string>
    {
        private readonly IFFDbContext context;
        private readonly SignInManager<ApplicationUser> signInManager;
        public LoginUserCommandHandler(IFFDbContext context, SignInManager<ApplicationUser> signInManager)
        {
            this.context = context;
            this.signInManager = signInManager;
        }
        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = this.context.Users.FirstOrDefault(u => u.UserName == request.Username);

            var status = await this.signInManager.PasswordSignInAsync(user.UserName, user.UserName, true, false);

            if (status.Succeeded)
            {
                await signInManager.SignInAsync(user, true);
                return "/";
            }
            else
            {
                return @"\LoginError";
            }
        }
    }
}
