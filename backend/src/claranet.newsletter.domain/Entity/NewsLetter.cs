namespace claranet.newsletter.domain.Entity
{
	public class NewsLetter : EntityBase<int>
	{
		public NewsLetter()
		{
		}
		public NewsLetter(string email, HeardAboutUs heardAboutUs, string reasonForSigningUp)
		{
			Email = email;
			HeardAboutUs = heardAboutUs;
			ReasonForSigningUp = reasonForSigningUp;
		}

		public string Email { get; private set; }
		public HeardAboutUs HeardAboutUs { get; private set; }
		public string ReasonForSigningUp { get; private set; }

		public void SetId(int id) => Id = id;
	}
}