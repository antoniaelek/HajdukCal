using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

internal class StadionConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(Stadion) || t == typeof(Stadion?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        switch (value)
        {
            case "Doma":
                return Stadion.Doma;
            case "Gost":
                return Stadion.Gost;
        }
        throw new Exception("Cannot unmarshal type Stadion");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var value = (Stadion)untypedValue;
        switch (value)
        {
            case Stadion.Doma:
                serializer.Serialize(writer, "Doma");
                return;
            case Stadion.Gost:
                serializer.Serialize(writer, "Gost");
                return;
        }
        throw new Exception("Cannot marshal type Stadion");
    }

    public static readonly StadionConverter Singleton = new StadionConverter();
}