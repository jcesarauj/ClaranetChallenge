using claranet.newsletter.domain.Entity;

namespace claranet.newsletter.domain.Contracts.Repositories
{
	public interface IAddNewsLetterRepository
	{
		Task ExecuteAsync(NewsLetter newsLetter);
	}
}
