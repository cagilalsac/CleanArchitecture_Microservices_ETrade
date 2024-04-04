using Core.Entities.Bases;

namespace Core.Repositories.Bases
{
    public abstract class UnitOfWorkBase<TEntity> : IDisposable where TEntity : Entity, new()
    {
        public RepoBase<TEntity> Repo { get; }

        protected UnitOfWorkBase(RepoBase<TEntity> repo)
        {
            Repo = repo;
        }

        public virtual async Task<int> SaveAsync(CancellationToken cancellationToken = default)
        {
            return await Repo.Db.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Repo.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
