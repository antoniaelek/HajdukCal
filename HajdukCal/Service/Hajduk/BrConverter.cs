using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

internal class BrConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(Br) || t == typeof(Br?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        switch (reader.TokenType)
        {
            case JsonToken.String:
            case JsonToken.Date:
                var stringValue = serializer.Deserialize<string>(reader);
                switch (stringValue)
                {
                    case "(1)":
                        return new Br {Enum = Rezultat4.The1};
                    case "-":
                        return new Br {Enum = Rezultat4.Empty};
                }

                long l;
                if (Int64.TryParse(stringValue, out l))
                {
                    return new Br {Integer = l};
                }

                break;
        }

        throw new Exception("Cannot unmarshal type Br");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        var value = (Br) untypedValue;
        if (value.Enum != null)
        {
            switch (value.Enum)
            {
                case Rezultat4.The1:
                    serializer.Serialize(writer, "(1)");
                    return;
                case Rezultat4.Empty:
                    serializer.Serialize(writer, "-");
                    return;
            }
        }

        if (value.Integer != null)
        {
            serializer.Serialize(writer, value.Integer.Value.ToString());
            return;
        }

        throw new Exception("Cannot marshal type Br");
    }

    public static readonly BrConverter Singleton = new BrConverter();
}