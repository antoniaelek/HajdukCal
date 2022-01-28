using Newtonsoft.Json;

namespace HajdukCal.Service.OpenStreetMap;

internal class OsmTypeConverter : JsonConverter
{
    public override bool CanConvert(Type t) => t == typeof(OsmType) || t == typeof(OsmType?);

    public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null) return null;
        var value = serializer.Deserialize<string>(reader);
        switch (value)
        {
            case "node":
                return OsmType.Node;
            case "relation":
                return OsmType.Relation;
            case "way":
                return OsmType.Way;
        }
        throw new Exception("Cannot unmarshal type OsmType");
    }

    public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    {
        if (untypedValue == null)
        {
            serializer.Serialize(writer, null);
            return;
        }
        var value = (OsmType)untypedValue;
        switch (value)
        {
            case OsmType.Node:
                serializer.Serialize(writer, "node");
                return;
            case OsmType.Relation:
                serializer.Serialize(writer, "relation");
                return;
            case OsmType.Way:
                serializer.Serialize(writer, "way");
                return;
        }
        throw new Exception("Cannot marshal type OsmType");
    }

    public static readonly OsmTypeConverter Singleton = new OsmTypeConverter();
}