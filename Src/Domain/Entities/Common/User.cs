namespace FinalFantasyTryoutGoesWeb.Domain.Entities.Common
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities.Game;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class User
    {
        public User()
        {
            Units = new HashSet<Unit>();
        }

        public int Id { get; set; }
        [DisplayName("User Name")]
        public string Username { get; set; }

        public string Password { get; set; }

        public ICollection<Unit> Units { get; set; }
    }
}
