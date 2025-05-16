using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data.Enums
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Time 
    {
        [EnumMember(Value = "full-time")]
        FullTime 
    };
}
