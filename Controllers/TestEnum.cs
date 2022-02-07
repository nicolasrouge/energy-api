using System.Text.Json.Serialization;

namespace dotnetEnsekTechChallenge.Controllers
{
    [JsonConverter(typeof(JsonStringEnumConverter))]//for swagger
    public enum TestEnum
    {
        Gaz,
        Elec
    }
}
