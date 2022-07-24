using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

internal class TipUtakmiceEngConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(TipUtakmiceEng) || t == typeof(TipUtakmiceEng?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        switch (value)
        {
            case "CUP":
                return TipUtakmiceEng.Cup;
            case "EUR":
                return TipUtakmiceEng.Eur;
            case "LGE":
                return TipUtakmiceEng.Lge;
            case "SC":
                return TipUtakmiceEng.Sc;
        }

        throw new Exception("Cannot unmarshal type TipUtakmiceEng");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }

        var value = (TipUtakmiceEng) untypedValue;
        switch (value)
        {
            case TipUtakmiceEng.Cup:
                serializer.Serialize(writer, "CUP");
                return;
            case TipUtakmiceEng.Eur:
                serializer.Serialize(writer, "EUR");
                return;
            case TipUtakmiceEng.Lge:
                serializer.Serialize(writer, "LGE");
                return;
            case TipUtakmiceEng.Sc:
                serializer.Serialize(writer, "SC");
                return;
        }

        throw new Exception("Cannot marshal type TipUtakmiceEng");
    }

    public static readonly TipUtakmiceEngConverter Singleton = new TipUtakmiceEngConverter();
}