using Customers.Application.Common.Mappers.Bases;
using Core.Entities.Bases;
using Core.Handlers.Bases;
using Core.Records.Bases;
using Core.Repositories.Bases;

namespace Customers.Application.Common.Handlers.Bases
{
    public abstract class AppHandler<TEntity, TResponse> : Handler<TEntity> where TEntity : Entity, new() where TResponse : IRecord, new()
    {
        protected readonly AppMapperBase<TEntity, TResponse> _appMapper;

        protected AppHandler(UnitOfWorkBase<TEntity> unitOfWork, AppMapperBase<TEntity, TResponse> appMapper) : base(unitOfWork)
        {
            _appMapper = appMapper;
        }
    }
}
