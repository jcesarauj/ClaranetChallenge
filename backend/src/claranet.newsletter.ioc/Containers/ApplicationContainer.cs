using claranet.newsletter.application;
using claranet.newsletter.domain.Contracts.Application;
using claranet.newsletter.domain.Contracts.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace claranet.newsletter.ioc.Containers
{
	public static class ApplicationContainer
	{
		public static void AddDependency(IServiceCollection services)
		{
			services.AddScoped<IAddNewsLetterApplication, AddNewsLetterApplication>();
			services.AddScoped<IVerifyIfNewsLetterExistApplication, VerifyIfNewsLetterExistApplication>();
			services.AddScoped<IDeleteNewsLetterByIdApplication, DeleteNewsLetterByIdApplication>();
		}
	}
}