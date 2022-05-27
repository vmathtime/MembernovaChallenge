using MembernovaChallenge.Domain.Exceptions;
using MembernovaChallenge.ExceptionResolvers;

namespace MembernovaChallenge.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void AddExceptionResolvers(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IExceptionResolver<Exception>, ExceptionResolver>();
            serviceCollection.AddScoped<IExceptionResolver<IncorrectCountryException>, IncorrectCountryExceptionResolver>();
        }
    }
}
