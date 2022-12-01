using System.Text.Json.Serialization;

namespace StudentManagement.Core.Entities
{
    public abstract class IDocument
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        public abstract string PartitionKey();

        [JsonPropertyName("_etag")]
        public string ETag { get; set; }
    }
}
