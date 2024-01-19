using ApiBooking.Domain.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiBooking.Domain.Exceptions.Filters;

public class CustomExceptionFilter : IAsyncExceptionFilter
{
    public Task OnExceptionAsync(ExceptionContext context)
    {
        switch (context.Exception)
        {
            case CheckInDtInvalidException exception:
                SetBadRequest(context, exception.Message);
                break;

            case CheckOutDtInvalidException exception:
                SetBadRequest(context, exception.Message);
                break;

            case HotelIdInvalidException exception:
                SetBadRequest(context, exception.Message);
                break;

            case UserIdInvalidException exception:
                SetBadRequest(context, exception.Message);
                break;

            default:
                SetInternalServerError(context);
                break;
        }

        context.ExceptionHandled = true;
        return Task.CompletedTask;
    }

    private void SetBadRequest(ExceptionContext context, string errorMessage)
    {
        context.Result = new BadRequestObjectResult(new ResponseModel<string>(errorMessage));
    }

    private void SetInternalServerError(ExceptionContext context)
    {
        context.Result = new ObjectResult(new ResponseModel<string>("Internal Server Error."));
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
    }
}
