using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

internal class TipUtakmiceConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(TipUtakmice) || t == typeof(TipUtakmice?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        switch (value)
        {
            case "EUR":
                return TipUtakmice.Eur;
            case "KUP":
                return TipUtakmice.Kup;
            case "PRV":
                return TipUtakmice.Prv;
            case "SPK":
                return TipUtakmice.Spk;
        }

        throw new Exception("Cannot unmarshal type TipUtakmice");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }

        var value = (TipUtakmice) untypedValue;
        switch (value)
        {
            case TipUtakmice.Eur:
                serializer.Serialize(writer, "EUR");
                return;
            case TipUtakmice.Kup:
                serializer.Serialize(writer, "KUP");
                return;
            case TipUtakmice.Prv:
                serializer.Serialize(writer, "PRV");
                return;
            case TipUtakmice.Spk:
                serializer.Serialize(writer, "SPK");
                return;
        }

        throw new Exception("Cannot marshal type TipUtakmice");
    }

    public static readonly TipUtakmiceConverter Singleton = new TipUtakmiceConverter();
}