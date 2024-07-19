using System.Text.Json;

namespace SFFilter.Common.Helpers
{
    public static class JSONSerializer
    {
        public static JsonSerializerOptions Options => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            AllowTrailingCommas = true,
            Converters =
            {
                new System.Text.Json.Serialization.JsonStringEnumConverter()
            },
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            ReadCommentHandling = JsonCommentHandling.Skip
        };

        /// <summary>
        /// Deserializes the JSON string into a proper object.
        /// </summary>
        /// <param name="content">HTTP body (e.g. string, JSON).</param>
        /// <returns>Object representation of the JSON string.</returns>
        public static DTO? Deserialize<DTO>(string content) where DTO : class
        {
            return JsonSerializer.Deserialize<DTO>(content, Options);
        }

        /// <summary>
        /// Serialize an object into JSON string.
        /// </summary>
        /// <param name="dataObject">Object.</param>
        /// <returns>JSON string.</returns>
        public static string Serialize(object dataObject)
        {
            return dataObject != null ? JsonSerializer.Serialize(dataObject, Options) : null;
        }
    }
}