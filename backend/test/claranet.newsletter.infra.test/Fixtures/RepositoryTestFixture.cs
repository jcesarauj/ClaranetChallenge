using claranet.newsletter.ioc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using Xunit.Microsoft.DependencyInjection;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace Teleperformance.TpLogger.Tests.Fixtures
{
	public class RepositoryTestFixture : TestBedFixture
	{
		protected override void AddServices(IServiceCollection services, IConfiguration? configuration)
		{
			string aplicationPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

			string connectionString = string.Format(configuration.GetConnectionString("NewsLetterConnectionTest"), $"{aplicationPath}\\Data");

			services.RegisterDependencyTest(connectionString);
		}

		protected override ValueTask DisposeAsyncCore()
		{
			return new();
		}

		protected override IEnumerable<TestAppSettings> GetTestAppSettings()
		{
			return new List<TestAppSettings> { new TestAppSettings() { Filename = "appsettings.json", IsOptional = true } };
		}
	}
}
