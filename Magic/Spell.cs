using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace DndEncounter.Magic
{
    public class Spell
    {
        public string Name { get; set; }
        public List<string>? Tags { get; set; }
        public int Level { get; set; }
        public string MagicSchool { get; set; }
        public string CastingTime { get; set; }
        public string Duration { get; set; }
        public string Range { get; set; }
        public string Area { get; set; }
        public string AttackType { get; set; }
        public string SaveStat { get; set; }
        public string DamageType { get; set; }
        public bool Ritual { get; set; }
        public bool Concentration { get; set; }
        public bool Verbal { get; set; }
        public bool Somatic { get; set; }
        public bool Material { get; set; }
        public List<string>? Components { get; set; }
        public string Description { get; set; }

        public Spell GetSpell(string spellName, List<Spell> SpellList)
        {
            return SpellList.Single(a => a.Name == spellName);
        }
    }
}
