using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

internal class NatjecanjeConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(Natjecanje) || t == typeof(Natjecanje?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        switch (value)
        {
            case "KUP":
                return Natjecanje.Kup;
            case "PRV":
                return Natjecanje.Prv;
        }
        throw new Exception("Cannot unmarshal type Natjecanje");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var value = (Natjecanje)untypedValue;
        switch (value)
        {
            case Natjecanje.Kup:
                serializer.Serialize(writer, "KUP");
                return;
            case Natjecanje.Prv:
                serializer.Serialize(writer, "PRV");
                return;
        }
        throw new Exception("Cannot marshal type Natjecanje");
    }

    public static readonly NatjecanjeConverter Singleton = new NatjecanjeConverter();
}