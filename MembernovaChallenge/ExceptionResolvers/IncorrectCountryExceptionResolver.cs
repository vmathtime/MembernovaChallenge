using MembernovaChallenge.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MembernovaChallenge.ExceptionResolvers
{
    public class IncorrectCountryExceptionResolver : IExceptionResolver<IncorrectCountryException>
    {
        public bool TryHandleException(IncorrectCountryException exception, out IActionResult? response)
        {
            var modelStateDictionary = new ModelStateDictionary();
            modelStateDictionary.AddModelError("country", "Incorrect country");
            response = new BadRequestObjectResult(modelStateDictionary);
            return true;
        }

        public bool TryHandleException(Exception exception, out IActionResult? response)
        {
            response = null;
            if (exception is IncorrectCountryException incorrectCountryException)
            {
                return TryHandleException(incorrectCountryException, out response);
            }

            return false;
        }
    }
}
