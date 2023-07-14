namespace claranet.newsletter.domain.Contracts.Repositories
{
	public interface IVerifyIfNewsLetterExistRepository
	{
		Task<bool> ExecuteAsync(string emailAddress);
	}
}
