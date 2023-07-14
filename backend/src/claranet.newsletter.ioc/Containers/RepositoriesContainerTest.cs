using claranet.newsletter.domain.Contracts.Repositories;
using claranet.newsletter.infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace claranet.newsletter.ioc.Containers
{
	public static class RepositoriesContainerTest
	{
		public static void AddDependency(IServiceCollection services)
		{
			services.AddTransient<IAddNewsLetterRepository, AddNewsLetterRepository>();
			services.AddTransient<IVerifyIfNewsLetterExistRepository, VerifyIfNewsLetterExistRepository>();
			services.AddTransient<IDeleteNewsLetterByIdRepository, DeleteNewsLetterByIdRepository>();
		}
	}
}
