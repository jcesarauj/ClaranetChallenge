namespace claranet.newsletter.domain.Contracts.Repositories
{
	public interface IDeleteNewsLetterByIdRepository
	{
		Task<bool> ExecuteAsync(int newsLetterId);
	}
}
