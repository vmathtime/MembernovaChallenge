using MembernovaChallenge.ExceptionResolvers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MembernovaChallenge.Filters
{
    internal class ExceptionFilter : IExceptionFilter
    {
        private readonly IServiceProvider _serviceProvider;

        public ExceptionFilter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void OnException(ExceptionContext context)
        {
            var exceptionType = context.Exception.GetType();
            while (exceptionType != typeof(object) && exceptionType != null)
            {
                var genericResolverType = typeof(IExceptionResolver<>).MakeGenericType(exceptionType);
                var exceptionResolver = (IExceptionResolver?)_serviceProvider.GetService(genericResolverType);

                if (exceptionResolver != null && exceptionResolver.TryHandleException(context.Exception, out var response))
                {
                    context.Result = response;
                    context.ExceptionHandled = true;
                    return;
                }

                exceptionType = exceptionType.BaseType;
            }
        }
    }
}
