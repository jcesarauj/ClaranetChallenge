using claranet.newsletter.domain.Contracts.Repositories;
using claranet.newsletter.infra.Context;
using Microsoft.EntityFrameworkCore;

namespace claranet.newsletter.infra.Repositories
{
	public class VerifyIfNewsLetterExistRepository : IVerifyIfNewsLetterExistRepository
	{
		private readonly NewsLetterContext _context;

		public VerifyIfNewsLetterExistRepository(NewsLetterContext context)
		{
			_context = context;
		}

		public async Task<bool> ExecuteAsync(string emailAddress) => await _context.NewsLetter
			.AnyAsync(x => x.Email == emailAddress);
	}
}