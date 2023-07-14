using claranet.newsletter.ioc.Containers;
using Microsoft.Extensions.DependencyInjection;

namespace claranet.newsletter.ioc
{
	public static class NativeInjectorConfigTest
	{
		public static void RegisterDependencyTest(this IServiceCollection services, string connectionString)
		{
			ApplicationContainerTest.AddDependency(services);
			DbContextContainerTest.AddDependency(services, connectionString);
			RepositoriesContainerTest.AddDependency(services);
		}
	}
}
