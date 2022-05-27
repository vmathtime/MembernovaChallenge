using System.Text.Json.Serialization;

namespace MembernovaChallenge.CountriesApi.Models.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RegionEnumDto
    {
        Africa = 1,
        Americas,
        Asia,
        Europe,
        Oceania
    }
}
