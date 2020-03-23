namespace Application.CQ.Common.Commands
{
    using Domain.Entities.Common;
    using global::Common;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using System.Threading;
    using System.Threading.Tasks;

    public class CustomLogoutCommandHandler : IRequestHandler<CustomLogoutCommand, string>
    {
        //private readonly SignInManager<ApplicationUser> signInManager;

        public CustomLogoutCommandHandler()//To be fixed
        {
            //this.signInManager = signInManager;
        }
        public async Task<string> Handle(CustomLogoutCommand request, CancellationToken cancellationToken)
        {
            //await this.signInManager.SignOutAsync();

            return GConst.HomeRedirect;
        }
    }
}
