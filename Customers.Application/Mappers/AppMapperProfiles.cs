using AutoMapper;
using Customers.Application.Features.Customers;
using Customers.Domain.Entities;

namespace Customers.Application.Mappers
{
	public class CustomerProfile : Profile
	{
        public CustomerProfile()
        {
            CreateMap<Customer, ReadCustomerResponse>()
                .ForMember(c => c.FullName, o => o.MapFrom(s => s.Name + " " + s.Surname));
        }
    }
}
