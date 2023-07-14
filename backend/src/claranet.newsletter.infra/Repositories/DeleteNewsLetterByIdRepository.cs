using claranet.newsletter.domain.Contracts.Repositories;
using claranet.newsletter.domain.Entity;
using claranet.newsletter.infra.Context;

namespace claranet.newsletter.infra.Repositories
{
	public class DeleteNewsLetterByIdRepository : IDeleteNewsLetterByIdRepository
	{
		private readonly NewsLetterContext _context;

		public DeleteNewsLetterByIdRepository(NewsLetterContext context)
		{
			_context = context;
		}

		public async Task<bool> ExecuteAsync(int newsLetterId)
		{
			var newsLetter = new NewsLetter();
			newsLetter.SetId(newsLetterId);
			_context.NewsLetter.Remove(newsLetter);
			await _context.SaveChangesAsync();
			return true;
		}
	}
}