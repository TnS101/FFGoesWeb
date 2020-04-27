namespace Application.Tests.Infrastructure
{
    using Persistence.Context;
    using System;

    public class CommandTestBase : IDisposable
    {
        protected readonly FFDbContext context;

        public CommandTestBase()
        {
            this.context = FFDbContextFactory.Create();
        }

        public void Dispose()
        {
            FFDbContextFactory.Delete(this.context);
        }
    }
}
