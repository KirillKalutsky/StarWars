namespace Common.DataLayer
{
    public interface IWriteDbContext<TIEntity>
    {
        void Add<TEntity>(TEntity item) where TEntity : class, TIEntity;
        void Attach<TEntity>(TEntity item) where TEntity : class, TIEntity;
        void Delete<TEntity>(TEntity item) where TEntity : class, TIEntity;
        Task SaveChangesAsync();
    }
}
