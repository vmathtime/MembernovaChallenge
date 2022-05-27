using Microsoft.AspNetCore.Mvc;

namespace MembernovaChallenge.ExceptionResolvers
{
    internal interface IExceptionResolver
    {
        bool TryHandleException(Exception exception, out IActionResult? response);
    }
}
