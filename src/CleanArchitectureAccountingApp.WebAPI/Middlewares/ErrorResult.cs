using System.Text.Json;

namespace CleanArchitectureAccountingApp.WebAPI.Middlewares;

public class ErrorResult: ErrorStatusCode
{
    public string Message { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}

public class ErrorStatusCode
{
    public int StatusCode { get; set; }
}

public class ValidationErrorDetails : ErrorStatusCode
{
    public IEnumerable<string>? Errors { get; set; }
}