namespace claranet.newsletter.domain.Contracts.Application
{
	public interface IDeleteNewsLetterByIdApplication
	{
		Task<bool> ExecuteAsync(int newsLetterId);
	}
}
