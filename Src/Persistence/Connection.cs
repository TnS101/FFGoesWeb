namespace Persistence
{
    Application.Common.Interfaces;

    public class Connection : IConnection
    {
        public string String { get; set; } = @"Server=.;Database=FFDb;Integrated Security=True";
    }
}
