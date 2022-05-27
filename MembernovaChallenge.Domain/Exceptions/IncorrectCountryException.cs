using System;

namespace MembernovaChallenge.Domain.Exceptions
{
    public class IncorrectCountryException : Exception
    {
        public string Country { get; }

        public IncorrectCountryException(string country) : base($"Country: '{country}' is incorrect")
        {
            Country = country;
        }
    }
}
