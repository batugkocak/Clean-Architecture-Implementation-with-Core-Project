using System.Text.Json;
using Microsoft.AspNetCore.Mvc;


namespace Core.CrossCuttingConcerns.Exceptions.Extensions;

public static class ProblemDetailsExtensions
{
    public static string AsJson<TProblemDetail>(this TProblemDetail detail)
        where TProblemDetail : ProblemDetails => JsonSerializer.Serialize(detail);
}