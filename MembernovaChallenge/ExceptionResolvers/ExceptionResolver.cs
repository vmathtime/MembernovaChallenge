using MembernovaChallenge.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MembernovaChallenge.ExceptionResolvers
{
    public class ExceptionResolver : IExceptionResolver<Exception>
    {
        private const string ERROR_MESSAGE = "Something went wrong";

        private readonly ILogger _logger;

        public ExceptionResolver(ILogger<ExceptionResolver> logger)
        {
            _logger = logger;
        }

        public bool TryHandleException(Exception exception, out IActionResult? response)
        {
            _logger.LogError(exception, ERROR_MESSAGE);
            var model = new ErrorResponse(ERROR_MESSAGE);
            response = new ObjectResult(model)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
            return true;
        }
    }
}
