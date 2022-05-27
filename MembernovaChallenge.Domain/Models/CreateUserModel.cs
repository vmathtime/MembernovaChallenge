namespace MembernovaChallenge.Domain.Models
{
    public record CreateUserModel(string FirstName, string LastName, string Email, int RegionId, string Country);
}
