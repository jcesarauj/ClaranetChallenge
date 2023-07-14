using claranet.newsletter.domain.Contracts.Application;
using claranet.newsletter.domain.Contracts.Repositories;
using claranet.newsletter.domain.Entity;
using claranet.newsletter.domain.Request;

namespace claranet.newsletter.application
{
	public class AddNewsLetterApplication : IAddNewsLetterApplication
	{
		private readonly IAddNewsLetterRepository _addNewsLetterRepository;
		public AddNewsLetterApplication(IAddNewsLetterRepository addNewsLetterRepository)
		{
			_addNewsLetterRepository = addNewsLetterRepository;
		}
		public async Task<int> ExecuteAsync(AddNewsLetterRequest addNewsLetterRequest)
		{
			var newLetter = new NewsLetter(addNewsLetterRequest.Email,
				addNewsLetterRequest.HeardAboutUs, addNewsLetterRequest.ReasonForSigningUp);

			await _addNewsLetterRepository.ExecuteAsync(newLetter);

			return newLetter.Id;
		}
	}
}
