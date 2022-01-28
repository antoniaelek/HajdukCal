using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

internal class Rezultat4Converter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(Rezultat4) || t == typeof(Rezultat4?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        switch (value)
        {
            case "(1)":
                return Rezultat4.The1;
            case "-":
                return Rezultat4.Empty;
        }

        throw new Exception("Cannot unmarshal type Rezultat4");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }

        var value = (Rezultat4) untypedValue;
        switch (value)
        {
            case Rezultat4.The1:
                serializer.Serialize(writer, "(1)");
                return;
            case Rezultat4.Empty:
                serializer.Serialize(writer, "-");
                return;
        }

        throw new Exception("Cannot marshal type Rezultat4");
    }

    public static readonly Rezultat4Converter Singleton = new Rezultat4Converter();
}