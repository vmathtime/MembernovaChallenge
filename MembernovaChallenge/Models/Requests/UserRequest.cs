using System.ComponentModel.DataAnnotations;

namespace MembernovaChallenge.Models.Requests
{
    public record UserRequest
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; init; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; init; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; init; }

        [Required]
        public int? RegionId { get; init; }

        [Required]
        public string Country { get; init; }

        public UserRequest(string firstName, string lastName, string email, int? regionId, string country)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            RegionId = regionId;
            Country = country;
        }
    }
}