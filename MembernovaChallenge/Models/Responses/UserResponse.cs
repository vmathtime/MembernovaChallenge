namespace MembernovaChallenge.Models.Responses
{
    public record UserResponse
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string Region { get; init; }
        public string Country { get; init; }

        public UserResponse(string firstName, string lastName, string email, string region, string country)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Region = region;
            Country = country;
        }
    }
}
