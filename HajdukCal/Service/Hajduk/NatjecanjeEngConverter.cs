using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

internal class NatjecanjeEngConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(NatjecanjeEng) || t == typeof(NatjecanjeEng?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        switch (value)
        {
            case "CHA":
                return NatjecanjeEng.Cha;
            case "CUP":
                return NatjecanjeEng.Cup;
            case "EUR":
                return NatjecanjeEng.Eur;
            default:
                return NatjecanjeEng.Unk;
        }
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var value = (NatjecanjeEng)untypedValue;
        switch (value)
        {
            case NatjecanjeEng.Cha:
                serializer.Serialize(writer, "CHA");
                return;
            case NatjecanjeEng.Cup:
                serializer.Serialize(writer, "CUP");
                return;
            case NatjecanjeEng.Eur:
                serializer.Serialize(writer, "EUR");
                return;
            default:
                serializer.Serialize(writer, "UNK");
                return;
        }
    }

    public static readonly NatjecanjeEngConverter Singleton = new NatjecanjeEngConverter();
}