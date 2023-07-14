using claranet.newsletter.domain.Contracts.Application;
using claranet.newsletter.domain.Contracts.Repositories;
using claranet.newsletter.domain.Request;
using FluentAssertions;
using Teleperformance.TpLogger.Tests.Fixtures;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace claranet.newsletter.application.test
{
	public class NewsLetterApplicationTest : TestBed<ApplicationTestFixture>
	{
		public NewsLetterApplicationTest(ITestOutputHelper testOutputHelper, ApplicationTestFixture fixture)
		   : base(testOutputHelper, fixture)
		{
		}

		[Fact(DisplayName = "Add a new news letter with success")]
		public async Task AddNewsLetterExecute_AddNewNewsLetter_ShouldBeReturnSuccess()
		{
			//arrange
			var addNewsLetterRequest = new AddNewsLetterRequest()
			{
				Email = "claranet@claranet.com.br",
				HeardAboutUs = domain.HeardAboutUs.Other,
				ReasonForSigningUp = ""
			};

			var verifyIfNewsLetterExistApplication = _fixture.GetService<IVerifyIfNewsLetterExistApplication>(_testOutputHelper);
			var addNewsLetterApplication = _fixture.GetService<IAddNewsLetterApplication>(_testOutputHelper);
			var deleteNewsLetterApplication = _fixture.GetService<IDeleteNewsLetterByIdApplication>(_testOutputHelper);

			//act
			var resultIfEmailExist = await verifyIfNewsLetterExistApplication.ExecuteAsync(addNewsLetterRequest.Email);
			var resultOfNewsLetterAddedId = await addNewsLetterApplication.ExecuteAsync(addNewsLetterRequest);
			await deleteNewsLetterApplication.ExecuteAsync(resultOfNewsLetterAddedId);

			//assert
			resultIfEmailExist.Should().BeFalse();
			resultOfNewsLetterAddedId.Should().BeGreaterThan(0);
		}

		[Fact(DisplayName = "Try to add a existent news letter")]
		public async Task AddNewsLetterExecute_AddAExistentNewsLetter_ShouldBeReturnNewsLetterAlreadyExists()
		{
			//arrange
			var addNewsLetterRequest = new AddNewsLetterRequest()
			{
				Email = "claranet@claranet.com.br",
				HeardAboutUs = domain.HeardAboutUs.Other,
				ReasonForSigningUp = ""
			};

			var verifyIfNewsLetterExistApplication = _fixture.GetService<IVerifyIfNewsLetterExistApplication>(_testOutputHelper);
			var addNewsLetterApplication = _fixture.GetService<IAddNewsLetterApplication>(_testOutputHelper);
			var deleteNewsLetterApplication = _fixture.GetService<IDeleteNewsLetterByIdApplication>(_testOutputHelper);

			//act
			var newLetterAddedId = await addNewsLetterApplication.ExecuteAsync(addNewsLetterRequest);
			var resultIfEmailExist = await verifyIfNewsLetterExistApplication.ExecuteAsync(addNewsLetterRequest.Email);
			Func<Task> act = async () => await addNewsLetterApplication.ExecuteAsync(addNewsLetterRequest);

			//assert
			resultIfEmailExist.Should().BeTrue();
			act.Should().ThrowExactlyAsync<Exception>()
				.WithMessage("Violation of UNIQUE KEY constraint 'AK_Email'. Cannot insert duplicate key in object 'dbo.NewsLetter'. The duplicate key value is (claranet@claranet.com.br).");

			await deleteNewsLetterApplication.ExecuteAsync(newLetterAddedId);
		}
	}
}