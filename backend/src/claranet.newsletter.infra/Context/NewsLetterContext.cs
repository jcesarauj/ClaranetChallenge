using claranet.newsletter.domain.Entity;
using claranet.newsletter.infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace claranet.newsletter.infra.Context
{
	public class NewsLetterContext : DbContext
	{
		public NewsLetterContext(DbContextOptions<NewsLetterContext> options) : base(options)
		{ }

		public DbSet<NewsLetter> NewsLetter { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new NewsLetterConfiguration());
		}
	}
}
