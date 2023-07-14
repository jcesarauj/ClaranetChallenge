using claranet.newsletter.domain.Request;

namespace claranet.newsletter.domain.Contracts.Application
{
	public interface IAddNewsLetterApplication
	{
		Task<int> ExecuteAsync(AddNewsLetterRequest addNewsLetterRequest);
	}
}
