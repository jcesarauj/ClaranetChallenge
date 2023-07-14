using claranet.newsletter.domain.Contracts.Repositories;
using claranet.newsletter.infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace claranet.newsletter.ioc.Containers
{
	public static class RepositoriesContainer
	{
		public static void AddDependency(IServiceCollection services)
		{
			services.AddScoped<IAddNewsLetterRepository, AddNewsLetterRepository>();
			services.AddScoped<IVerifyIfNewsLetterExistRepository, VerifyIfNewsLetterExistRepository>();
			services.AddScoped<IDeleteNewsLetterByIdRepository, DeleteNewsLetterByIdRepository>();
		}
	}
}