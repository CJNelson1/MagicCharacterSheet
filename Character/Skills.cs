using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DndEncounter.Character
{
    public enum SkillName
    {
        Acrobatics,
        AnimalHandling,
        Arcana,
        Athletics,
        Deception,
        History,
        Insight,
        Intimidation,
        Investigation,
        Medicine,
        Nature,
        Perception,
        Performance,
        Persuasion,
        Religion,
        SleightOfHand,
        Stealth,
        Survival
    }
    public enum ProficiencyLevel
    {
        None,
        JackofAllTrades,
        Proficient,
        Expert
    }
    public class Skills
    {
        public SkillName Name;
        public int modifier;
        public ProficiencyLevel proficiency;
        public AbilityStats associatedStat;
        public Skills(SkillName name, ProficiencyLevel level = ProficiencyLevel.None)
        {
            Name = name;
            if (name == SkillName.Athletics)
            {
                associatedStat = AbilityStats.Strength;
            }
            else if (name == SkillName.Acrobatics || name == SkillName.SleightOfHand || name == SkillName.Stealth)
            {
                associatedStat = AbilityStats.Dexterity;
            }
            else if (name == SkillName.Arcana || name == SkillName.History || name == SkillName.Investigation || name == SkillName.Nature
                || name == SkillName.Religion)
            {
                associatedStat = AbilityStats.Intelligence;
            }
            else if (name == SkillName.AnimalHandling || name == SkillName.Insight || name == SkillName.Medicine
                || name == SkillName.Perception || name == SkillName.Survival)
            {
                associatedStat = AbilityStats.Wisdom;
            }
            else if (name == SkillName.Deception || name == SkillName.Intimidation || name == SkillName.Performance
                || name == SkillName.Persuasion)
            {
                associatedStat = AbilityStats.Charisma;
            }
            SetSkillProficiency(level);
        }
        public void SetSkillProficiency(ProficiencyLevel level)
        {
            proficiency = level;
        }
        public void UpdateSkillModifier(int modifier)
        {
            this.modifier = modifier;
        }
    }
}
