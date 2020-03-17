namespace Domain.Entities.Common
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities.Game;
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Units = new HashSet<Unit>();
            this.Id = Guid.NewGuid().ToString();
            
        }

        public override string Id { get; set; }

        public override string UserName { get; set; }

        public string Password { get; set; }

        public override string Email { get; set; }

        public ICollection<Unit> Units { get; set; }
    }
}
