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
    public enum StageName 
    {
        [EnumMember(Value = "Final")]
        Final,
        [EnumMember(Value = "First Stage")]
        FirstStage,
        [EnumMember(Value = "Play-off for third place")]
        PlayOffForThirdPlace,
        [EnumMember(Value = "Match for third place")]
        MatchForThirdPlace,
        [EnumMember(Value = "Quarter-final")]
        QuarterFinal,
        [EnumMember(Value = "Quarter-finals")]
        QuarterFinals,
        [EnumMember(Value = "Round of 16")]
        RoundOf16,
        [EnumMember(Value = "Semi-finals")]
        SemiFinals,
        [EnumMember(Value = "Semi-final")]
        SemiFinal
    };

}
