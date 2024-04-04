using Core.Entities.Bases;
using Core.Repositories.Bases;

namespace Core.Repositories
{
    public class UnitOfWork<TEntity> : UnitOfWorkBase<TEntity> where TEntity : Entity, new()
    {
        public UnitOfWork(RepoBase<TEntity> repo) : base(repo)
        {
        }
    }
}
