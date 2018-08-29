using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AXADemo.Models
{
    /// <summary>
    /// Client register
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Client Identificator 
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Client Name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Client EMail
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string EMail { get; set; }

        /// <summary>
        /// Client Role
        /// </summary>
        [JsonProperty(PropertyName = "role")]
        public string Role { get; set; }
    }
}