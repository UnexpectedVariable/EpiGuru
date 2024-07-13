using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Location
{
    internal class GeoJSON
    {
        //[JsonProperty("status")]
        public string status { get; set; }

        //[JsonProperty("country")]
        public string country { get; set; }

        //[JsonProperty("query")]
        public string query { get; set; }
    }
}
