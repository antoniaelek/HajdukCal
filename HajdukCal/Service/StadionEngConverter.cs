using Newtonsoft.Json;

namespace HajdukCal.Service;

internal class StadionEngConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(StadionEng) || t == typeof(StadionEng?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        switch (value)
        {
            case "Away":
                return StadionEng.Away;
            case "Home":
                return StadionEng.Home;
        }
        throw new Exception("Cannot unmarshal type StadionEng");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var value = (StadionEng)untypedValue;
        switch (value)
        {
            case StadionEng.Away:
                serializer.Serialize(writer, "Away");
                return;
            case StadionEng.Home:
                serializer.Serialize(writer, "Home");
                return;
        }
        throw new Exception("Cannot marshal type StadionEng");
    }

    public static readonly StadionEngConverter Singleton = new StadionEngConverter();
}