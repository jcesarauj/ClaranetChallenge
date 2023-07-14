using claranet.newsletter.domain.Contracts.Repositories;
using claranet.newsletter.domain.Entity;
using claranet.newsletter.infra.Context;

namespace claranet.newsletter.infra.Repositories
{
	public class AddNewsLetterRepository : IAddNewsLetterRepository
	{
		private readonly NewsLetterContext _context;

		public AddNewsLetterRepository(NewsLetterContext context)
		{
			_context = context;
		}

		public async Task ExecuteAsync(NewsLetter newsLetter)
		{
			_context.NewsLetter.Add(newsLetter);
			await _context.SaveChangesAsync();
		}
	}
}