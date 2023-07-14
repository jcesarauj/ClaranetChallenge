using claranet.newsletter.domain.Contracts.Repositories;
using claranet.newsletter.domain.Entity;
using FluentAssertions;
using Teleperformance.TpLogger.Tests.Fixtures;
using Xunit.Abstractions;
using Xunit.Microsoft.DependencyInjection.Abstracts;

namespace claranet.newsletter.application.test
{
	public class NewsLetterRepositoryTest : TestBed<RepositoryTestFixture>
	{
		public NewsLetterRepositoryTest(ITestOutputHelper testOutputHelper, RepositoryTestFixture fixture)
		   : base(testOutputHelper, fixture)
		{
		}

		[Fact(DisplayName = "Add a new newsletter")]
		public async Task AddNewsLetterExecute_AddNewNewsLetter_ShouldBeReturnSuccess()
		{
			//arrange
			var newLetter = new NewsLetter("claranetrepository@claranet.com.br", domain.HeardAboutUs.Other, "");

			var addNewsLetterRepository = _fixture.GetService<IAddNewsLetterRepository>(_testOutputHelper);
			var deleteNewsLetterByIdRepository = _fixture.GetService<IDeleteNewsLetterByIdRepository>(_testOutputHelper);

			//act
			await addNewsLetterRepository.ExecuteAsync(newLetter);
			await deleteNewsLetterByIdRepository.ExecuteAsync(newLetter.Id);

			//assert
			newLetter.Id.Should().BeGreaterThan(0);
		}

		[Fact(DisplayName = "Try to add a new newsletter twice")]
		public async Task AddNewsLetterExecute_AddNewNewsLetterTwice_ShouldBeReturnIndexError()
		{
			//arrange
			var newLetter = new NewsLetter("claranetrepository@claranet.com.br", domain.HeardAboutUs.Other, "");

			var addNewsLetterRepository = _fixture.GetService<IAddNewsLetterRepository>(_testOutputHelper);
			var deleteNewsLetterByIdRepository = _fixture.GetService<IDeleteNewsLetterByIdRepository>(_testOutputHelper);

			//act
			await addNewsLetterRepository.ExecuteAsync(newLetter);
			Func<Task> act = async () => await addNewsLetterRepository.ExecuteAsync(newLetter);

			//assert
			act.Should().ThrowExactlyAsync<Exception>()
				.WithMessage("Violation of UNIQUE KEY constraint 'AK_Email'. Cannot insert duplicate key in object 'dbo.NewsLetter'. The duplicate key value is (claranet@claranet.com.br).");

			newLetter.Id.Should().BeGreaterThan(0);

			await deleteNewsLetterByIdRepository.ExecuteAsync(newLetter.Id);
		}

		[Fact(DisplayName = "Should be return non existent newsletter")]
		public async Task VerifyIfNewsLetterExistExecute_VerifyIfNewsLetterExist_ShouldBeReturnNonExistentNewsLetter()
		{
			//arrange
			var newLetter = new NewsLetter("claranetrepository@claranet.com.br", domain.HeardAboutUs.Other, "");

			var verifyIfNewsLetterExistRepository = _fixture.GetService<IVerifyIfNewsLetterExistRepository>(_testOutputHelper);

			//act
			var existentNewsLetter = await verifyIfNewsLetterExistRepository.ExecuteAsync(newLetter.Email);

			//assert
			existentNewsLetter.Should().BeFalse();
		}

		[Fact(DisplayName = "Should be return existent newsletter")]
		public async Task VerifyIfNewsLetterExistExecute_VerifyIfNewsLetterExist_ShouldBeReturnExistentNewsLetter()
		{
			//arrange
			var newLetter = new NewsLetter("claranetrepository@claranet.com.br", domain.HeardAboutUs.Other, "");

			var addNewsLetterRepository = _fixture.GetService<IAddNewsLetterRepository>(_testOutputHelper);
			var verifyIfNewsLetterExistRepository = _fixture.GetService<IVerifyIfNewsLetterExistRepository>(_testOutputHelper);
			var deleteNewsLetterByIdRepository = _fixture.GetService<IDeleteNewsLetterByIdRepository>(_testOutputHelper);

			//act
			await addNewsLetterRepository.ExecuteAsync(newLetter);
			var existentNewsLetter = await verifyIfNewsLetterExistRepository.ExecuteAsync(newLetter.Email);
			await deleteNewsLetterByIdRepository.ExecuteAsync(newLetter.Id);

			//assert
			existentNewsLetter.Should().BeTrue();
		}

		[Fact(DisplayName = "Delete a existent newsletter")]
		public async Task DeleteNewsLetterByIdExecute_DeleteAExistentNewsLetter_ShouldBeReturnFalseWhenVerifyIfExist()
		{
			//arrange
			var newLetter = new NewsLetter("claranetrepository@claranet.com.br", domain.HeardAboutUs.Other, "");

			var addNewsLetterRepository = _fixture.GetService<IAddNewsLetterRepository>(_testOutputHelper);
			var deleteNewsLetterByIdRepository = _fixture.GetService<IDeleteNewsLetterByIdRepository>(_testOutputHelper);
			var verifyIfNewsLetterExistRepository = _fixture.GetService<IVerifyIfNewsLetterExistRepository>(_testOutputHelper);

			//act
			await addNewsLetterRepository.ExecuteAsync(newLetter);
			await deleteNewsLetterByIdRepository.ExecuteAsync(newLetter.Id);
			var existentNewsLetter = await verifyIfNewsLetterExistRepository.ExecuteAsync(newLetter.Email);

			//assert
			existentNewsLetter.Should().BeFalse();
		}
	}
}