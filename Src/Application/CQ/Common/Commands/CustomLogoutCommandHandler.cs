namespace Application.CQ.Common.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities.Common;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;

    public class CustomLogoutCommandHandler : IRequestHandler<CustomLogoutCommand, string>
    {
        // private readonly SignInManager<AppUser> signInManager;
        public CustomLogoutCommandHandler() // To be fixed
        {
            // this.signInManager = signInManager;
        }

        public async Task<string> Handle(CustomLogoutCommand request, CancellationToken cancellationToken)
        {
            // await this.signInManager.SignOutAsync();
            return GConst.HomeRedirect;
        }
    }
}
