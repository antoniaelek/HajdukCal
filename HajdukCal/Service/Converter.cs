using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HajdukCal.Service;

internal static class Converter
{
    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    {
        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
        DateParseHandling = DateParseHandling.None,
        Converters =
        {
            NatjecanjeConverter.Singleton,
            NatjecanjeEngConverter.Singleton,
            StadionConverter.Singleton,
            StadionEngConverter.Singleton,
            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
        },
    };
}