using claranet.newsletter.domain.Contracts.Repositories;

namespace claranet.newsletter.application
{
	public class VerifyIfNewsLetterExistApplication : IVerifyIfNewsLetterExistApplication
	{
        private readonly IVerifyIfNewsLetterExistRepository _verifyIfNewsLetterExistRepository;

        public VerifyIfNewsLetterExistApplication(IVerifyIfNewsLetterExistRepository verifyIfNewsLetterExistRepository)
        {
            _verifyIfNewsLetterExistRepository = verifyIfNewsLetterExistRepository;
		}
        public async Task<bool> ExecuteAsync(string emailAddress) =>
			await _verifyIfNewsLetterExistRepository.ExecuteAsync(emailAddress);
        
	}
}
