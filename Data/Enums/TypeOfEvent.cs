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
    public enum TypeOfEvent 
    {
        [EnumMember(Value = "Goal")]
        Goal,
        [EnumMember(Value = "goal-own")]
        GoalOwn,
        [EnumMember(Value = "goal-penalty")]
        GoalPenalty,
        [EnumMember(Value = "red-card")]
        RedCard,
        [EnumMember(Value = "substitution-in")]
        SubstitutionIn,
        [EnumMember(Value = "substitution-out")]
        SubstitutionOut,
        [EnumMember(Value = "yellow-card")]
        YellowCard,
        [EnumMember(Value = "yellow-card-second")]
        YellowCardSecond,
        
    };
}
