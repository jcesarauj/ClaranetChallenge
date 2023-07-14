using claranet.newsletter.application;
using claranet.newsletter.domain.Contracts.Application;
using claranet.newsletter.domain.Contracts.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace claranet.newsletter.ioc.Containers
{
	public static class ApplicationContainerTest
	{
		public static void AddDependency(IServiceCollection services)
		{
			services.AddTransient<IAddNewsLetterApplication, AddNewsLetterApplication>();
			services.AddTransient<IVerifyIfNewsLetterExistApplication, VerifyIfNewsLetterExistApplication>();
			services.AddTransient<IDeleteNewsLetterByIdApplication, DeleteNewsLetterByIdApplication>();
		}
	}
}