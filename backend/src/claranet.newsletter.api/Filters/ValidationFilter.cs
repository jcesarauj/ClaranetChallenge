using claranet.newsletter.domain.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace claranet.newsletter.api.Filters
{
	public class ValidationFilter : IAsyncActionFilter
	{
		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			if (!context.ModelState.IsValid)
			{
				var response = new DefaultResponse();

				var messages = context.ModelState.Values
				.Where(x => x.ValidationState == ModelValidationState.Invalid)
				.SelectMany(x => x.Errors)
				.Select(x => x.ErrorMessage)
				.ToList();

				response.SetError();
				messages.ForEach(x => response.AddError(x));
				context.Result = new BadRequestObjectResult(response);
				return;
			}

			await next();
		}
	}
}
