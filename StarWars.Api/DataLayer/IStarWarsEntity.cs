using Common;
using Common.DataLayer;

namespace StarWars.Api.DataLayer
{
    public interface IStarWarsEntity
    {
    }

    public static class StarWarcContextExtensions
    {
        public static IQueryable<TEntity> Get<TEntity>(this IHave<IReadDbContext<IStarWarsEntity>> context)
            where TEntity : class, IStarWarsEntity
        {
            return context.Tool.Get<TEntity>();
        }

        public static void Add<TEntity>(this IHave<IWriteDbContext<IStarWarsEntity>> context, TEntity entity)
            where TEntity: class, IStarWarsEntity
        {
            context.Tool.Add(entity);
        }

        public static void Delete<TEntity>(this IHave<IWriteDbContext<IStarWarsEntity>> context, TEntity entity)
            where TEntity: class, IStarWarsEntity
        {
            context.Tool.Delete(entity);
        }

        public static void Attach<TEntity>(this IHave<IWriteDbContext<IStarWarsEntity>> context, TEntity entity)
            where TEntity : class, IStarWarsEntity
        {
            context.Tool.Attach(entity);
        }
    }
}
