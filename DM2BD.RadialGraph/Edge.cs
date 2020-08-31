using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace DM2BD.RadialGraph
{
    public enum EdgeArrows
    {
        to,
        from,
        [EnumMember(Value = "to,from")]
        to_from,
        [EnumMember(Value = "to,middle,from")]
        to_middle_from,
        [EnumMember(Value = "middle,from")]
        middle_from,

    }
    public class Edge
    {
        public virtual int id { get; set; }
        public virtual int from { get; set; }
        public virtual int to { get; set; } 
        public virtual int? value { get; set; }
        public virtual string title { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual EdgeArrows? arrows { get; set; }
    }
}
