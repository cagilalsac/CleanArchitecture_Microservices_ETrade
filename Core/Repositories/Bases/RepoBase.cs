using Core.Contexts.Bases;
using Core.Entities.Bases;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories.Bases
{
    public abstract class RepoBase<TEntity> : IDisposable where TEntity : Entity, new()
	{
		internal IDb Db { get; }

		protected RepoBase(IDb db)
		{
			Db = db;
		}

		public virtual IQueryable<TEntity> Query(bool isNoTracking = false) 
		{
			var query = Db.Set<TEntity>().Where(q => !q.IsDeleted);
			return isNoTracking ? query.AsNoTracking() : query;
		}

		public virtual void Create(TEntity entity)
		{
			Db.Set<TEntity>().Add(entity);
		}

		public virtual void Update(TEntity entity)
		{
			Db.Set<TEntity>().Update(entity);
		}

		public virtual void Delete(int id)
		{
			var entity = Query().SingleOrDefault(e => e.Id == id);
			if (entity is not null)
				Db.Set<TEntity>().Remove(entity);
		}

		public virtual void SoftDelete(int id)
		{
			var entity = Query().SingleOrDefault(e => e.Id == id);
			if (entity is not null)
			{
				entity.IsDeleted = true;
				Update(entity);
			}
		}

		public void Dispose()
		{
			Db?.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
