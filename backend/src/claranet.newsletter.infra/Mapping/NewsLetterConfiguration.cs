using claranet.newsletter.domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace claranet.newsletter.infra.Mapping
{
	public class NewsLetterConfiguration : IEntityTypeConfiguration<NewsLetter>
	{
		public void Configure(EntityTypeBuilder<NewsLetter> builder)
		{
			builder.ToTable("NewsLetter", "dbo");

			builder.HasKey(e => new { e.Id });

			builder.Property(e => e.Id).ValueGeneratedOnAdd();
			builder.Property(x => x.Email)
				.HasMaxLength(255).IsRequired();
			builder.HasIndex(x => x.Email).IsUnique(true);
			builder.Property(x => x.HeardAboutUs).IsRequired();
			builder.Property(x => x.ReasonForSigningUp)
					.HasMaxLength(255).IsRequired(false);
		}
	}
}