using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KugorganeHammerHandler.Data_Types
{
    public class Move
    {
        [JsonProperty("InstanceId")]
        public string InstanceId { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("OwnerId")]
        public int OwnerId { get; set; }
        [JsonProperty("Owner")]
        public string Owner { get; set; }
        [JsonProperty("HitboxActive")]
        public string HitboxActive { get; set; }
        [JsonProperty("FirstActionableFrame")]
        public string FirstActionableFrame { get; set; }
        [JsonProperty("BaseDamage")]
        public string BaseDamage { get; set; }
        [JsonProperty("Angle")]
        public string Angle { get; set; }

        [JsonProperty("BaseKnockBackSetKnockback")]
        public string BaseKockbackSetKnockback { get; set; }
        [JsonProperty("LandingLag")]
        public string LandingLag { get; set; }
        [JsonProperty("AutoCancel")]
        public string AutoCancel { get; set; }
        [JsonProperty("KnockbackGrowth")]
        public string KnockbackGrowth { get; set; }

        [JsonProperty("MoveType")]
        public string MoveType { get; set; }
        [JsonProperty("IsWeightDependent")]
        public bool IsWeightDependent { get; set; }
        [JsonProperty("Links")]
        public List<Dictionary<string, string>> Links { get; set; }
    }
}
