using System.Text.Json.Serialization;

namespace first.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))] //enumeration values to form strings
    public enum RpgClass
    {
        Venkat = 1,

        Ashok = 2,

        Hari = 3
    }
}
