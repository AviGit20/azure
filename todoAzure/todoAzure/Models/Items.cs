using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoAzure.Models
{
    using Newtonsoft.Json;
    public class Items
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "isComplete")]
        public bool Completed { get; set; }
    }
}
