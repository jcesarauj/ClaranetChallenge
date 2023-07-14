using claranet.newsletter.domain.Entity;
using claranet.newsletter.domain.Request;
using FluentValidation;

namespace claranet.newsletter.api.Validators
{
	public class NewsLetterRequestValidator : AbstractValidator<AddNewsLetterRequest>
	{
		public NewsLetterRequestValidator()
		{
			RuleFor(newsLetter => newsLetter.Email)
				.NotNull().NotEmpty().WithMessage("Please fill a email")
				.EmailAddress().WithMessage("A valid email is required");

			RuleFor(newsLetter => newsLetter.HeardAboutUs)
				.NotNull().NotEmpty().WithMessage("Please fill a heard about us");
		}
	}
}
