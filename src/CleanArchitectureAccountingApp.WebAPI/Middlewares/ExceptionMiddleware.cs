using FluentValidation;

namespace CleanArchitectureAccountingApp.WebAPI.Middlewares;

public class ExceptionMiddleware: IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)StatusCodes.Status500InternalServerError;

        if (exception.GetType() == typeof(ValidationException))
        {
            await context.Response.WriteAsync(new ValidationErrorDetails
            {
                Errors = ((ValidationException)exception).Errors.Select(s => s.PropertyName),
                StatusCode = context.Response.StatusCode
            }.ToString() ?? string.Empty);
            return;
        }
        
        await context.Response.WriteAsync(new ErrorResult
        {
            Message = exception.Message,
            StatusCode = context.Response.StatusCode
        }.ToString());
    }
}