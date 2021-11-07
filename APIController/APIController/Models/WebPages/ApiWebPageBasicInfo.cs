using Newtonsoft.Json;
using System;

namespace APIController.Models.WebPages
{
    [Serializable]
    public class ApiWebPageBasicInfo
    {
        [JsonProperty("PageUrlId")]
        public Guid Id { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Url")]
        public string Url { get; set; }

        [JsonProperty("PageRankPonctuation")]
        public float PageRankPonctuation { get; set; }

        //[JsonProperty("PageUrlId")]
        //public DateTime? LastRanking { get; set; }

        //[JsonProperty("PageUrlId")]
        //public DateTime? LastIndexing { get; set; }
    }
}
