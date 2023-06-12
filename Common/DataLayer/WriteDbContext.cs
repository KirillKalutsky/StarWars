using Microsoft.EntityFrameworkCore;

namespace Common.DataLayer
{
    public class WriteDbContext<TIEntity> : IWriteDbContext<TIEntity>
    {
        private readonly DbContext context;

        public WriteDbContext(DbContext context)
        {
            this.context = context;
        }

        public void Add<TEntity>(TEntity item) where TEntity : class, TIEntity
        {
            context.Set<TEntity>().Add(item);
        }

        public void Delete<TEntity>(TEntity item) where TEntity : class, TIEntity
        {
            context.Set<TEntity>().Attach(item);
        }

        public void Attach<TEntity>(TEntity item) where TEntity : class, TIEntity
        {
            context.Set<TEntity>().Remove(item);
        }

        public Task SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}
