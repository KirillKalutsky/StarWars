namespace Common.DataLayer
{
    public interface IReadDbContext<TIEntity>
    {
        IQueryable<TEntity> Get<TEntity>() where TEntity : class, TIEntity;
    }
}
