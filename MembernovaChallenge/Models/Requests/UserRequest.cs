using MembernovaChallenge.Attributes;
using MembernovaChallenge.Services.Contracts.Models;
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

        [EnumRequired(typeof(Region))]
        public string Region { get; init; }

        [Required]
        public string Country { get; init; }

        public UserRequest(string firstName, string lastName, string email, string region, string country)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Region = region;
            Country = country;
        }
    }
}
