using System.Text.Json;
using System.Text.Json.Serialization;

namespace DndEncounter.Gear
{
    public class Weapon : Equipment
    {
        public string? Name { get; set; }
        public string? Proficiency { get; set; }
        public bool? Ranged { get; set; }
        public int? MinRange { get; set; }
        public int? MaxRange { get; set; }
        public int? DamageDiceAmount { get; set; }
        public int? DamageDiceType { get; set; }
        public string? DamageType { get; set; }
        public float? Weight { get; set; }
        public List<string>? Properties { get; set; }
    }
}