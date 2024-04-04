using AutoMapper.QueryableExtensions;
using Core.Records.Bases;
using Core.Repositories.Bases;
using Customers.Application.Common.Handlers.Bases;
using Customers.Application.Common.Mappers.Bases;
using Customers.Application.Mappers;
using Customers.Domain.Entities;
using MediatR;

namespace Customers.Application.Features.Customers
{
	public record ReadCustomerRequest : Record, IRequest<IQueryable<ReadCustomerResponse>>;
	public record ReadCustomerResponse : Record
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
        public string FullName { get; set; }
    }

    public class ReadCustomerHandler : AppHandler<Customer, ReadCustomerResponse>, IRequestHandler<ReadCustomerRequest, IQueryable<ReadCustomerResponse>>
	{
        public ReadCustomerHandler(UnitOfWorkBase<Customer> unitOfWork, AppMapperBase<Customer, ReadCustomerResponse> appMapper) : base(unitOfWork, appMapper)
        {
        }

        public Task<IQueryable<ReadCustomerResponse>> Handle(ReadCustomerRequest request, CancellationToken cancellationToken)
		{
			_appMapper.AddProfiles(new CustomerProfile());
            return Task.FromResult(_query.OrderBy(c => c.Name).ThenBy(c => c.Surname).ProjectTo<ReadCustomerResponse>(_appMapper.Configuration));
		}
	}
}
