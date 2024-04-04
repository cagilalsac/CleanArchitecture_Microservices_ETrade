using Core.Entities.Bases;
using Core.Repositories.Bases;

namespace Core.Handlers.Bases
{
    public abstract class Handler<TEntity> : IDisposable where TEntity : Entity, new()
	{
        protected readonly UnitOfWorkBase<TEntity> _unitOfWork;
        protected readonly RepoBase<TEntity> _repo;
		protected IQueryable<TEntity> _query;
        
        protected Handler(UnitOfWorkBase<TEntity> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repo = _unitOfWork.Repo;
            _query = _repo.Query();
        }

        public void Dispose()
		{
            _unitOfWork.Dispose();
            GC.SuppressFinalize(this);
		}
	}
}
