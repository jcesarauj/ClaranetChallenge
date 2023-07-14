using claranet.newsletter.domain.Contracts.Application;
using claranet.newsletter.domain.Contracts.Repositories;

namespace claranet.newsletter.application
{
	public class DeleteNewsLetterByIdApplication : IDeleteNewsLetterByIdApplication
	{
		private readonly IDeleteNewsLetterByIdRepository _deleteNewsLetterByIdRepository;
		public DeleteNewsLetterByIdApplication(IDeleteNewsLetterByIdRepository deleteNewsLetterByIdRepository)
		{
			_deleteNewsLetterByIdRepository = deleteNewsLetterByIdRepository;
		}
		public async Task<bool> ExecuteAsync(int newsLetterId)
		{
			return await _deleteNewsLetterByIdRepository.ExecuteAsync(newsLetterId);
		}
	}
}
