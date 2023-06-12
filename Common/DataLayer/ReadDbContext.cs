using Microsoft.EntityFrameworkCore;

namespace Common.DataLayer
{
    public class ReadDbContext<TIEntity> : IReadDbContext<TIEntity>
    {
        private readonly DbContext context;
        public ReadDbContext(DbContext context)
        {
            this.context = context;
        }

        public IQueryable<TEntity> Get<TEntity>() where TEntity : class, TIEntity
        {
            return context.Set<TEntity>();
        }
    }
}
