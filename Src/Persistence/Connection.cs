using Application.Common.Interfaces;

namespace FinalFantasyTryoutGoesWeb.Persistence
{
    public class Connection : IConnection
    {
        public string String { get; set; } = @"Server=.;Database=FFDb;Integrated Security=True";
    }
}
