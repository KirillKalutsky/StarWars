using Common.DataLayer;
using StarWars.Api.DataLayer;
using Common;

namespace StarWars.Api.Contexts
{
    public class AppRequestContext : 
        IHave<IReadDbContext<IStarWarsEntity>>,
        IHave<IWriteDbContext<IStarWarsEntity>>
    {
        private readonly IReadDbContext<IStarWarsEntity> readStarWars;
        private readonly IWriteDbContext<IStarWarsEntity> writeStarWars;

        public AppRequestContext(IReadDbContext<IStarWarsEntity> readStarWars,
            IWriteDbContext<IStarWarsEntity> writeStarWars)
        {
            this.readStarWars = readStarWars;
            this.writeStarWars = writeStarWars;
        }

        public Task SaveChangesAsync()
        {
            return Task.WhenAll(
                writeStarWars.SaveChangesAsync()
                );
        }

        IReadDbContext<IStarWarsEntity> IHave<IReadDbContext<IStarWarsEntity>>.Tool => readStarWars;
        IWriteDbContext<IStarWarsEntity> IHave<IWriteDbContext<IStarWarsEntity>>.Tool => writeStarWars;
    }
}
