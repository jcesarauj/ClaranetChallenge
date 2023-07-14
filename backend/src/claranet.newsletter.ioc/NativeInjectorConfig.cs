using claranet.newsletter.ioc.Containers;
using Microsoft.Extensions.DependencyInjection;

namespace claranet.newsletter.ioc
{
	public static class NativeInjectorConfig
	{
		public static void RegisterDependency(this IServiceCollection services, string connectionString)
		{
			ApplicationContainer.AddDependency(services);
			DbContextContainer.AddDependency(services, connectionString);
			RepositoriesContainer.AddDependency(services);
		}
	}
}
