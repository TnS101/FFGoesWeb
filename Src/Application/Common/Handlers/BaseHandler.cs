namespace Application.Common.Handlers
{
    using Application.Common.Interfaces;

    public abstract class BaseHandler
    {
        public BaseHandler(IFFDbContext context)
        {
            this.Context = context;
        }

        protected IFFDbContext Context { get; }
    }
}
