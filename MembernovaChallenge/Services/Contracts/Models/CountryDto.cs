namespace MembernovaChallenge.Services.Contracts.Models
{
    public record CountryDto
    {
        public CountryNameDto Name { get; init; }

        public CountryDto(CountryNameDto name)
        {
            Name = name;
        }
    }
}
