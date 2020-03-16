namespace Domain.Entities.Common
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities.Game;
    using System;
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            Units = new HashSet<Unit>();
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public ICollection<Unit> Units { get; set; }
    }
}
