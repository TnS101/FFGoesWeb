namespace FinalFantasyTryoutGoesWeb.Persistence
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;

    public class Connection : IConnection
    {
        public string String { get; set; } = @"Server=.;Database=FFDb;Integrated Security=True";
    }
}
