namespace claranet.newsletter.domain.Contracts.Repositories
{
	public interface IVerifyIfNewsLetterExistApplication
	{
		Task<bool> ExecuteAsync(string emailAddress);
	}
}
