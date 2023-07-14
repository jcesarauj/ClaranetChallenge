namespace claranet.newsletter.domain.Request
{
	public class AddNewsLetterRequest
	{
		public string Email { get; set; }
		public HeardAboutUs HeardAboutUs { get; set; }
		public string ReasonForSigningUp { get; set; }
	}
}