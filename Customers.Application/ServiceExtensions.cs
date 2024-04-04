using Customers.Application.Common.Mappers;
using Customers.Application.Common.Mappers.Bases;
using Customers.Application.Repositories;
using Customers.Domain.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Core.Repositories;
using Core.Repositories.Bases;
using System.Reflection;

namespace Customers.Application
{
	public static class ServiceExtensions
	{
		public static void ConfigureApplication(this IServiceCollection services)
		{
			services.AddScoped(typeof(UnitOfWorkBase<>), typeof(UnitOfWork<>));
			services.AddScoped(typeof(RepoBase<Customer>), typeof(CustomerRepo));

			services.AddScoped(typeof(AppMapperBase<,>), typeof(AppMapper<,>));

			services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

			services.AddFluentValidationAutoValidation(config => config.DisableDataAnnotationsValidation = true);
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
