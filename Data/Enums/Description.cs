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
    public enum Description 
    {
        [EnumMember(Value = "Clear Night")]
        ClearNight,
        [EnumMember(Value = "Cloudy")]
        Cloudy,
        [EnumMember(Value = "Cloudy Night")]
        CloudyNight,
        [EnumMember(Value = "Partly Cloudy")] 
        PartlyCloudy,
        [EnumMember(Value = "Partly Cloudy Night")] 
        PartlyCloudyNight,
        [EnumMember(Value = "Sunny")] 
        Sunny 
    };
}
