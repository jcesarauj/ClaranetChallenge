﻿using claranet.newsletter.infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace claranet.newsletter.ioc.Containers
{
	public static class DbContextContainerTest
	{
		public static void AddDependency(IServiceCollection services, string connectionString)
		{
			services.AddDbContext<NewsLetterContext>(opt => opt.UseSqlServer(connectionString), ServiceLifetime.Transient);
		}
	}
}
