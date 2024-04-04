using Customers.Application.Contexts.Bases;
using Customers.Domain.Entities;
using Core.Repositories.Bases;

namespace Customers.Application.Repositories
{
	public class CustomerRepo : RepoBase<Customer>
	{
		public CustomerRepo(ICustomerDb db) : base(db)
		{
		}
	}
}
