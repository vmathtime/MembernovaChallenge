namespace MembernovaChallenge.Services.Contracts.Models
{
    public record CountryNameDto
    {
        public string Official { get; init; }

        public CountryNameDto(string official)
        {
            Official = official;
        }
    }
}