using claranet.newsletter.domain.Contracts.Application;
using claranet.newsletter.domain.Contracts.Repositories;
using claranet.newsletter.domain.Request;
using claranet.newsletter.domain.Response;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace claranet.newsletter.api.Controllers
{
	[ApiController]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiVersion("1.0")]
	public class NewsLetterController : ControllerBase
	{
		private readonly IAddNewsLetterApplication _addNewsLetterApplication;
		private readonly IVerifyIfNewsLetterExistApplication _verifyIfNewsLetterExistApplication;

		public NewsLetterController(IAddNewsLetterApplication addNewsLetterApplication,
			IVerifyIfNewsLetterExistApplication verifyIfNewsLetterExistApplication)
		{
			_addNewsLetterApplication = addNewsLetterApplication;
			_verifyIfNewsLetterExistApplication = verifyIfNewsLetterExistApplication;
		}

		[MapToApiVersion("1.0")]
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] AddNewsLetterRequest addNewsLetterRequest)
		{
			try
			{
				var newsLetterExists = await _verifyIfNewsLetterExistApplication.ExecuteAsync(addNewsLetterRequest.Email);

				if (newsLetterExists)
				{
					var alreadyNewsLetterExistenceResponse = new AlreadyNewsLetterExistenceResponse();
					alreadyNewsLetterExistenceResponse.SetError();
					alreadyNewsLetterExistenceResponse.AddError("User already has registration");
					return BadRequest(alreadyNewsLetterExistenceResponse);
				}

				await _addNewsLetterApplication.ExecuteAsync(addNewsLetterRequest);

				var newsLetterSuccessResponse = new NewsLetterSuccessResponse();
				newsLetterSuccessResponse.SetSuccess();

				return Ok(newsLetterSuccessResponse);
			}
			catch (Exception ex)
			{
				Log.Fatal(ex, "Host terminated unexpectedly");
				return StatusCode(500);
			}
		}
	}
}