namespace Persistence
{
    using Application.Common.Interfaces;

    public class Connection : IConnection
    {
        public string String { get; set; } = @"Server=.;Database=FFDb;Integrated Security=True;MultipleActiveResultSets=true;";
    }
}
