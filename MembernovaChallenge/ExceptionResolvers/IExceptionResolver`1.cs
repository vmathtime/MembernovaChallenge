using Microsoft.AspNetCore.Mvc;

namespace MembernovaChallenge.ExceptionResolvers
{
    internal interface IExceptionResolver<in T> : IExceptionResolver where T : Exception
    {
        bool TryHandleException(T exception, out IActionResult? response);
    }
}
