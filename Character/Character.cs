using DndEncounter.Gear;
using DndEncounter.Magic;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace DndEncounter.Character
{
    public enum CharacterClass
    {
        Artificer,
        Barbarian,
        Bard,
        Cleric,
        Druid,
        Fighter,
        Monk,
        Paladin,
        Ranger,
        Rogue,
        Sorcerer,
        Warlock,
        Wizard
    }
    public enum Background
    {
        Acolyte,
        Charlatan,
        Criminal,
        Entertainer,
        FolkHero,
        GuildArtisan,
        Hermit,
        Noble,
        Outlander,
        Sage,
        Sailor,
        Soldier,
        Urchin
    }
    public enum Race
    {
        Dwarf,
        Elf,
        Halfling,
        Human,
        Dragonborn,
        Gnome,
        HalfElf,
        HalfOrc,
        Tiefling
    }
    public enum AlignmentNiceness
    {
        Good,
        Neutral,
        Evil
    }
    public enum AlignmentChaoticness
    {
        Lawful,
        Neutral,
        Chaotic
    }
    public enum AbilityStats
    {
        Strength,
        Dexterity,
        Constitution,
        Intelligence,
        Wisdom,
        Charisma
    }
    public class Character
    {
        public string PlayerName;
        public string Name;
        public CharacterClass CharacterClass;
        public int Level;
        public bool Spellcaster;
        public Background Background;
        public Race Race;
        public Enum[] Alignment;
        public string Size;
        public int XP;
        public int Strength;
        public int Dexterity;
        public int Constituion;
        public int Intelligence;
        public int Wisdom;
        public int Charisma;
        public int Proficiency;
        public List<AbilityStats> SavingThrows;
        public Skills[] SkillList;
        public int PassiveWisdom;
        public List<Weapon> Weapons;
        public Armor? equippedArmor;
        public Equipment? LeftArmEquipment;
        public int ArmorClass;
        public int Speed;
        public int HP;
        public int MaxHP;
        public int TempHP;
        public string HitDice;
        public string HitDiceMax;
        public int PP = 0;
        public int GP = 0;
        public int EP = 0;
        public int SP = 0;
        public int CP = 0;
        public List<string> Proficiencies = new List<string>();
        public List<string> Languages = new List<string>();
        public List<string> Equipment = new List<string>();
        public List<string> Features = new List<string>();
        public List<string> PersonalityTraits = new List<string>();
        public List<string> Ideals = new List<string>();
        public List<string> Bonds = new List<string>();
        public List<string> Flaws = new List<string>();
        public List<string> Notes = new List<string>();
        public AbilityStats? SpellcastingAbility;
        public int? SpellSaveDC;
        public int? SpellAttackBonus;
        public List<Spell>? SpellsKnown;

        public Character(string playerName, string name, CharacterClass characterClass, List<Weapon> weaponList, List<Spell> spellList, int strength = 0, int dexterity = 0, int constituion = 0, int intelligence = 0, int wisdom = 0, int charisma = 0, int rolledMaxHp = 0)
        {
            PlayerName = playerName;
            Name = name;
            CharacterClass = characterClass;
            Level = 1;
            Alignment = new Enum[2] { AlignmentChaoticness.Neutral, AlignmentNiceness.Neutral };
            Proficiency = 2;
            SavingThrows = new List<AbilityStats> { };
            SkillList = GenerateSkillList();
            Weapons = new List<Weapon>();

            bool optimalPointBuy = true;
            if (strength != 0 || dexterity != 0 || constituion != 0 || intelligence != 0 || wisdom != 0 || charisma != 0)
            {
                optimalPointBuy = false;
                Strength = strength;
                Dexterity = dexterity;
                Constituion = constituion;
                Intelligence = intelligence;
                Wisdom = wisdom;
                Charisma = charisma;
            }
            bool optimalHP = true;
            if (rolledMaxHp != 0)
            {
                optimalHP = false;
                MaxHP = rolledMaxHp;
                HP = MaxHP;
            }

            switch (characterClass)
            {
                case CharacterClass.Artificer:
                    //TODO: Not today
                    //Assign stats
                    //Set Race and Background stats
                    //Set Hit Dice
                    //Add Armor Proficiencies
                    //Add Weapon Proficiencies
                    //Add Tool Proficiencies
                    //Set Class Saving Throws
                    //Select Skill Proficiencies
                    //Equip Weapons
                    //Equip Armor
                    //Add Starting Equipment
                    //Add Class Features
                    break;
                case CharacterClass.Barbarian:
                    //Assign Stats
                    if (optimalPointBuy)
                    {
                        Strength = 15;
                        Dexterity = 14;
                        Constituion = 15;
                        Intelligence = 8;
                        Wisdom = 10;
                        Charisma = 8;
                    }

                    //Set Race and Background stats
                    SetRace(Race.Dwarf, "Mountain");
                    SetBackground(Background.Criminal);

                    //Set Hit Dice
                    HitDiceMax = "1d12";

                    //Add Armor Proficiencies
                    AddProficiency("Light Armor");
                    AddProficiency("Medium Armor");
                    AddProficiency("Shields");

                    //Add Weapon Proficiencies
                    AddProficiency("Simple Weapons");
                    AddProficiency("Martial Weapons");

                    //Add Tool Proficiencies
                    //None

                    //Set Class Saving Throws
                    SavingThrows.Add(AbilityStats.Strength);
                    SavingThrows.Add(AbilityStats.Constitution);

                    //Select Skill Proficiencies
                    AddSkillProficiency(SkillName.Athletics);
                    AddSkillProficiency(SkillName.Perception);

                    //Equip Weapons
                    AddWeapon("Greataxe", weaponList);
                    AddWeapon("Handaxe", weaponList);
                    AddWeapon("Javelin", weaponList);

                    //Equip Armor
                    //None

                    //Add Starting Equipment
                    Equipment.Add("Greataxe");
                    Equipment.Add("Handaxe x2");
                    Equipment.Add("Javelin x4");
                    Equipment.Add("Explorer's Pack");

                    //Add Class Features
                    Features.Add("Rage");
                    Features.Add("Unarmored Defense");
                    break;

                case CharacterClass.Bard:
                    //Assign stats
                    if (optimalPointBuy)
                    {
                        Strength = 8;
                        Dexterity = 14;
                        Constituion = 12;
                        Intelligence = 11;
                        Wisdom = 12;
                        Charisma = 15;
                    }

                    //Set Race and Background stats
                    SetRace(Race.Tiefling);
                    SetBackground(Background.Entertainer);

                    //Set Hit Dice
                    HitDiceMax = "1d8";

                    //Add Armor Proficiencies
                    AddProficiency("Light Armor");

                    //Add Weapon Proficiencies
                    AddProficiency("Simple Weapons");
                    AddProficiency("Hand Crossbow");
                    AddProficiency("Longsword");
                    AddProficiency("Rapier");
                    AddProficiency("Shortsword");

                    //Add Tool Proficiencies
                    AddProficiency("Lute");
                    AddProficiency("Flute");
                    AddProficiency("Pan Flute");

                    //Set Class Saving Throws
                    SavingThrows.Add(AbilityStats.Dexterity);
                    SavingThrows.Add(AbilityStats.Charisma);

                    //Select Skill Proficiencies
                    AddSkillProficiency(SkillName.Insight);
                    AddSkillProficiency(SkillName.Persuasion);
                    AddSkillProficiency(SkillName.Stealth);

                    //Equip Weapons
                    AddWeapon("Light Crossbow", weaponList);
                    AddWeapon("Dagger", weaponList);

                    //Equip Armor
                    AddArmor(new Armor(ArmorType.Leather));

                    //Add Starting Equipment
                    AddEquipment("Light Crossbow");
                    AddEquipment("Entertainer's Pack");
                    AddEquipment("Lute");
                    AddEquipment("Dagger");

                    //Add Class Features
                    AddFeature("Spellcasting");
                    AddFeature("Bardic Inspiration d6");

                    //Spells

                    break;
                case CharacterClass.Cleric:
                    //Assign stats
                    if (optimalPointBuy)
                    {
                        Strength = 14;
                        Dexterity = 12;
                        Constituion = 14;
                        Intelligence = 8;
                        Wisdom = 15;
                        Charisma = 8;
                    }

                    //Set Race and Background stats
                    SetRace(Race.Dwarf, "Hill");
                    SetBackground(Background.Acolyte);

                    //Set Hit Dice
                    HitDiceMax = "1d8";

                    //Add Armor Proficiencies
                    AddProficiency("Light Armor");
                    AddProficiency("Medium Armor");
                    AddProficiency("Shields");

                    //Add Weapon Proficiencies
                    AddProficiency("Simple Weapons");

                    //Add Tool Proficiencies
                    //None

                    //Set Class Saving Throws
                    SavingThrows.Add(AbilityStats.Wisdom);
                    SavingThrows.Add(AbilityStats.Charisma);

                    //Select Skill Proficiencies
                    AddSkillProficiency(SkillName.History);
                    AddSkillProficiency(SkillName.Medicine);

                    //Equip Weapons
                    AddWeapon("Warhammer", weaponList);
                    AddWeapon("Light Crossbow", weaponList);

                    //Equip Armor
                    AddArmor(new Armor(ArmorType.ChainMail));
                    LeftArmEquipment = new Armor(ArmorType.Shield);

                    //Add Starting Equipment
                    AddEquipment("Warhammer");
                    AddEquipment("Chain Mail");
                    AddEquipment("Light Crossbow");
                    AddEquipment("Bolt x20");
                    AddEquipment("Priest's Pack");
                    AddEquipment("Shield");
                    AddEquipment("Holy Symbol");

                    //Add Class Features
                    AddFeature("Spellcasting");
                    AddFeature("Divine Domain: Life");
                    AddFeature("Disciple Of Life");

                    //Spells

                    break;
                case CharacterClass.Druid:
                    //Assign stats
                    if (optimalPointBuy)
                    {
                        Strength = 10;
                        Dexterity = 13;
                        Constituion = 14;
                        Intelligence = 10;
                        Wisdom = 15;
                        Charisma = 10;
                    }

                    //Set Race and Background stats
                    SetRace(Race.Elf, "Wood");
                    SetBackground(Background.Outlander);

                    //Set Hit Dice
                    HitDiceMax = "1d8";

                    //Add Armor Proficiencies
                    AddProficiency("Light Armor");
                    AddProficiency("Medium Armor");
                    AddProficiency("Shields");

                    //Add Weapon Proficiencies
                    AddProficiency("Club");
                    AddProficiency("Dagger");
                    AddProficiency("Dart");
                    AddProficiency("Javelin");
                    AddProficiency("Mace");
                    AddProficiency("Quaterstaff");
                    AddProficiency("Scimitar");
                    AddProficiency("Sickle");
                    AddProficiency("Sling");
                    AddProficiency("Spear");

                    //Add Tool Proficiencies
                    AddProficiency("Herbalism Kit");

                    //Set Class Saving Throws
                    SavingThrows.Add(AbilityStats.Intelligence);
                    SavingThrows.Add(AbilityStats.Wisdom);

                    //Select Skill Proficiencies
                    AddSkillProficiency(SkillName.AnimalHandling);
                    AddSkillProficiency(SkillName.Nature);

                    //Equip Weapons
                    AddWeapon("Quarterstaff", weaponList);

                    //Equip Armor
                    AddArmor(new Armor(ArmorType.Leather));
                    LeftArmEquipment = new Armor(ArmorType.Shield);

                    //Add Starting Equipment
                    AddEquipment("Shield");
                    AddEquipment("Quarterstaff");
                    AddEquipment("Leather Armor");
                    AddEquipment("Explorer's Pack");
                    AddEquipment("Druidic Focus");

                    //Add Class Features
                    AddLanguage("Druidic");
                    AddFeature("Spellcasting");

                    //Spells

                    break;
                case CharacterClass.Fighter:
                    //Assign stats
                    if (optimalPointBuy)
                    {
                        Strength = 14;
                        Dexterity = 14;
                        Constituion = 15;
                        Intelligence = 8;
                        Wisdom = 12;
                        Charisma = 8;
                    }

                    //Set Race and Background stats
                    SetRace(Race.HalfOrc);
                    SetBackground(Background.Soldier);

                    //Set Hit Dice
                    HitDiceMax = "1d10";

                    //Add Armor Proficiencies
                    AddProficiency("Light Armor");
                    AddProficiency("Medium Armor");
                    AddProficiency("Heavy Armor");
                    AddProficiency("Shields");

                    //Add Weapon Proficiencies
                    AddProficiency("Simple Weapons");
                    AddProficiency("Martial Weapons");

                    //Add Tool Proficiencies
                    //None

                    //Set Class Saving Throws
                    SavingThrows.Add(AbilityStats.Strength);
                    SavingThrows.Add(AbilityStats.Constitution);

                    //Select Skill Proficiencies
                    AddSkillProficiency(SkillName.AnimalHandling);
                    AddSkillProficiency(SkillName.Perception);

                    //Equip Weapons
                    AddWeapon("Longbow", weaponList);
                    AddWeapon("Halberd", weaponList);
                    AddWeapon("Longsword", weaponList);
                    AddWeapon("Handaxe", weaponList);

                    //Equip Armor
                    AddArmor(new Armor(ArmorType.ChainMail));

                    //Add Starting Equipment
                    AddEquipment("Chain Mail");
                    AddEquipment("Longbow");
                    AddEquipment("Arrow x20");
                    AddEquipment("Halberd");
                    AddEquipment("Longsword");
                    AddEquipment("Handaxe x2");
                    AddEquipment("Explorer's Pack");

                    //Add Class Features
                    AddFeature("Great Weapon Fighting Style");
                    AddFeature("Second Wind");

                    break;
                case CharacterClass.Monk:
                    //Assign stats
                    if (optimalPointBuy)
                    {
                        Strength = 8;
                        Dexterity = 15;
                        Constituion = 15;
                        Intelligence = 8;
                        Wisdom = 15;
                        Charisma = 8;
                    }

                    //Set Race and Background stats
                    SetRace(Race.Halfling, "Stout");
                    SetBackground(Background.Sailor);

                    //Set Hit Dice
                    HitDiceMax = "1d8";

                    //Add Armor Proficiencies
                    //None

                    //Add Weapon Proficiencies
                    AddProficiency("Simple Weapons");
                    AddProficiency("Shortsword");

                    //Add Tool Proficiencies
                    AddProficiency("Woodcarver's Tools");

                    //Set Class Saving Throws
                    SavingThrows.Add(AbilityStats.Strength);
                    SavingThrows.Add(AbilityStats.Dexterity);

                    //Select Skill Proficiencies
                    AddSkillProficiency(SkillName.Acrobatics);
                    AddSkillProficiency(SkillName.Stealth);

                    //Equip Weapons
                    AddWeapon("Quarterstaff", weaponList);
                    AddWeapon("Dart", weaponList);

                    //Add Starting Equipment
                    AddEquipment("Quarterstaff");
                    AddEquipment("Explorer's Pack");
                    AddEquipment("Dart x10");

                    //Add Class Features
                    AddFeature("Unarmored Defense");
                    AddFeature("Martial Arts");

                    break;
                case CharacterClass.Paladin:
                    //Assign stats
                    if (optimalPointBuy)
                    {
                        Strength = 15;
                        Dexterity = 10;
                        Constituion = 15;
                        Intelligence = 8;
                        Wisdom = 8;
                        Charisma = 14;
                    }

                    //Set Race and Background stats
                    SetRace(Race.HalfElf);
                    SetBackground(Background.Noble);

                    //Set Hit Dice
                    HitDiceMax = "1d10";

                    //Add Armor Proficiencies
                    AddProficiency("Light Armor");
                    AddProficiency("Medium Armor");
                    AddProficiency("Heavy Armor");
                    AddProficiency("Shields");

                    //Add Weapon Proficiencies
                    AddProficiency("Simple Weapons");
                    AddProficiency("Martial Weapons");

                    //Add Tool Proficiencies
                    //None

                    //Set Class Saving Throws
                    SavingThrows.Add(AbilityStats.Wisdom);
                    SavingThrows.Add(AbilityStats.Charisma);

                    //Select Skill Proficiencies
                    AddSkillProficiency(SkillName.Athletics);
                    AddSkillProficiency(SkillName.Religion);

                    //Equip Weapons
                    AddWeapon("Warhammer", weaponList);
                    AddWeapon("Javelin", weaponList);

                    //Equip Armor
                    AddArmor(new Armor(ArmorType.ChainMail));
                    LeftArmEquipment = new Armor(ArmorType.Shield);

                    //Add Starting Equipment
                    AddEquipment("Warhammer");
                    AddEquipment("Shield");
                    AddEquipment("Javelin x5");
                    AddEquipment("Explorer's Pack");
                    AddEquipment("Chain Mail");
                    AddEquipment("Holy Symbol");

                    //Add Class Features
                    AddFeature("Divine Sense");
                    AddFeature("Lay On Hands");

                    break;
                case CharacterClass.Ranger:
                    //Assign stats
                    if (optimalPointBuy)
                    {
                        Strength = 10;
                        Dexterity = 15;
                        Constituion = 13;
                        Intelligence = 12;
                        Wisdom = 14;
                        Charisma = 8;
                    }

                    //Set Race and Background stats
                    SetRace(Race.Human, "Variant");
                    AddFeature("Medium Armor Master"); //TODO:* Varient human picks a feat and need to implement feats
                    SetBackground(Background.Hermit);

                    //Set Hit Dice
                    HitDiceMax = "1d10";

                    //Add Armor Proficiencies
                    AddProficiency("Light Armor");
                    AddProficiency("Medium Armor");
                    AddProficiency("Shields");

                    //Add Weapon Proficiencies
                    AddProficiency("Simple Weapons");
                    AddProficiency("Martial Weapons");

                    //Add Tool Proficiencies
                    //None

                    //Set Class Saving Throws
                    SavingThrows.Add(AbilityStats.Strength);
                    SavingThrows.Add(AbilityStats.Dexterity);

                    //Select Skill Proficiencies
                    AddSkillProficiency(SkillName.Nature);
                    AddSkillProficiency(SkillName.Perception);
                    AddSkillProficiency(SkillName.Survival);

                    //Equip Weapons
                    AddWeapon("Shortsword", weaponList);
                    AddWeapon("Longbow", weaponList);

                    //Equip Armor
                    AddArmor(new Armor(ArmorType.ScaleMail));

                    //Add Starting Equipment
                    AddEquipment("Scale Mail");
                    AddEquipment("Shortsword x2");
                    AddEquipment("Explorer's Pack");
                    AddEquipment("Longbow");
                    AddEquipment("Arrow x20");

                    //Add Class Features
                    AddFeature("Favored Enemy: Giants");
                    AddFeature("Natural Explorer");

                    break;
                case CharacterClass.Rogue:
                    //Assign stats
                    if (optimalPointBuy)
                    {
                        Strength = 10;
                        Dexterity = 15;
                        Constituion = 12;
                        Intelligence = 12;
                        Wisdom = 12;
                        Charisma = 12;
                    }

                    //Set Race and Background stats
                    SetRace(Race.Gnome, "Forest");
                    SetBackground(Background.Urchin);

                    //Set Hit Dice
                    HitDiceMax = "1d8";

                    //Add Armor Proficiencies
                    AddProficiency("Light Armor");

                    //Add Weapon Proficiencies
                    AddProficiency("Simple Weapons");
                    AddProficiency("Hand Crossbow");
                    AddProficiency("Longsword");
                    AddProficiency("Rapier");
                    AddProficiency("Shortsword");

                    //Add Tool Proficiencies
                    AddProficiency("Thieves' Tools");

                    //Set Class Saving Throws
                    SavingThrows.Add(AbilityStats.Dexterity);
                    SavingThrows.Add(AbilityStats.Intelligence);

                    //Select Skill Proficiencies
                    AddSkillProficiency(SkillName.Acrobatics);
                    AddSkillProficiency(SkillName.Deception);
                    AddSkillProficiency(SkillName.Investigation);
                    AddSkillProficiency(SkillName.Perception);

                    //Equip Weapons
                    AddWeapon("Rapier", weaponList);
                    AddWeapon("Shortbow", weaponList);
                    AddWeapon("Dagger", weaponList);

                    //Equip Armor
                    AddArmor(new Armor(ArmorType.Leather));

                    //Add Starting Equipment
                    AddEquipment("Rapier");
                    AddEquipment("Shortbow");
                    AddEquipment("Arrow x20");
                    AddEquipment("Burglar's Pack");
                    AddEquipment("Leather Armor");
                    AddEquipment("Dagger x2");
                    AddEquipment("Thieves' Tools");

                    //Add Class Features
                    AddFeature("Expertise");
                    AddSkillProficiency(SkillName.Deception, ProficiencyLevel.Expert);
                    AddSkillProficiency(SkillName.Stealth, ProficiencyLevel.Expert);
                    AddFeature("Sneak Attack 1d6");
                    AddFeature("Thieves' Cant");
                    AddLanguage("Thieves' Cant");

                    break;
                case CharacterClass.Sorcerer:
                    //Assign stats
                    if (optimalPointBuy)
                    {
                        Strength = 10;
                        Dexterity = 14;
                        Constituion = 14;
                        Intelligence = 8;
                        Wisdom = 10;
                        Charisma = 15;
                    }

                    //Set Race and Background stats
                    SetRace(Race.Dragonborn, subType: "Red");
                    SetBackground(Background.Sage);

                    //Set Hit Dice
                    HitDiceMax = "1d6";

                    //Add Armor Proficiencies
                    //None

                    //Add Weapon Proficiencies
                    AddProficiency("Dagger");
                    AddProficiency("Dart");
                    AddProficiency("Sling");
                    AddProficiency("Quarterstaff");
                    AddProficiency("Light Crossbow");

                    //Add Tool Proficiencies
                    //None

                    //Set Class Saving Throws
                    SavingThrows.Add(AbilityStats.Constitution);
                    SavingThrows.Add(AbilityStats.Charisma);

                    //Select Skill Proficiencies
                    AddSkillProficiency(SkillName.Intimidation);
                    AddSkillProficiency(SkillName.Persuasion);

                    //Equip Weapons
                    AddWeapon("Light Crossbow", weaponList);
                    AddWeapon("Dagger", weaponList);

                    //Add Starting Equipment
                    AddEquipment("Light Crossbow");
                    AddEquipment("Bolt x20");
                    AddEquipment("Arcane Focus");
                    AddEquipment("Explorer's Pack");
                    AddEquipment("Dagger x2");

                    //Add Class Features
                    AddFeature("Spellcasting");
                    AddFeature("Sorcerous Origin: Draconic Bloodline");
                    AddFeature("Dragon Ancestor: Silver");
                    AddFeature("Draconic Resilience");

                    //Spells

                    break;
                case CharacterClass.Warlock:
                    //Assign stats TODO: This isn't right because of Half Elf fuckery
                    if (optimalPointBuy)
                    {
                        Strength = 9;
                        Dexterity = 15;
                        Constituion = 13;
                        Intelligence = 10;
                        Wisdom = 10;
                        Charisma = 15;
                    }

                    //Set Race and Background stats
                    SetRace(Race.HalfElf);
                    SetBackground(Background.Charlatan);

                    //Set Hit Dice
                    HitDiceMax = "1d8";

                    //Add Armor Proficiencies
                    AddProficiency("Light Armor");

                    //Add Weapon Proficiencies
                    AddProficiency("Simple Weapons");

                    //Add Tool Proficiencies
                    //None

                    //Set Class Saving Throws
                    SavingThrows.Add(AbilityStats.Wisdom);
                    SavingThrows.Add(AbilityStats.Charisma);

                    //Select Skill Proficiencies TODO: More fuckery from half elf
                    AddSkillProficiency(SkillName.Arcana);
                    AddSkillProficiency(SkillName.Religion);

                    //Equip Weapons
                    AddWeapon("Light Crossbow", weaponList);
                    AddWeapon("Spear", weaponList);
                    AddWeapon("Dagger", weaponList);

                    //Equip Armor
                    AddArmor(new Armor(ArmorType.Leather));

                    //Add Starting Equipment
                    AddEquipment("Light Crossbow");
                    AddEquipment("Bolt x20");
                    AddEquipment("Arcane Focus");
                    AddEquipment("Dungeoneer's Pack");
                    AddEquipment("Leather Armor");
                    AddEquipment("Spear");
                    AddEquipment("Dagger x2");

                    //Add Class Features
                    AddFeature("Otherworldly Patron: The Fiend");
                    //TODO: Expanded spell list
                    AddFeature("Dark One's Blessing");
                    AddFeature("Pact Magic");

                    break;
                case CharacterClass.Wizard:
                    //Assign stats
                    if (optimalPointBuy)
                    {
                        Strength = 8;
                        Dexterity = 14;
                        Constituion = 15;
                        Intelligence = 15;
                        Wisdom = 10;
                        Charisma = 8;
                    }

                    //Set Race and Background stats
                    SetRace(Race.Gnome, "Rock");
                    SetBackground(Background.GuildArtisan);

                    //Set Hit Dice
                    HitDiceMax = "1d6";

                    //Add Armor Proficiencies
                    //None

                    //Add Weapon Proficiencies
                    AddProficiency("Dagger");
                    AddProficiency("Dart");
                    AddProficiency("Sling");
                    AddProficiency("Quarterstaff");
                    AddProficiency("Light Crossbow");

                    //Add Tool Proficiencies
                    //None

                    //Set Class Saving Throws
                    SavingThrows.Add(AbilityStats.Intelligence);
                    SavingThrows.Add(AbilityStats.Wisdom);

                    //Select Skill Proficiencies
                    AddSkillProficiency(SkillName.Arcana);
                    AddSkillProficiency(SkillName.Investigation);

                    //Equip Weapons
                    AddWeapon("Dagger", weaponList);

                    //Add Starting Equipment
                    AddEquipment("Dagger");
                    AddEquipment("Arcane Focus");
                    AddEquipment("Explorer's Pack");
                    AddEquipment("Spellbook");

                    //Add Class Features
                    AddFeature("Spellcasting");
                    AddFeature("Arcane Recovery");

                    //Spells

                    break;
            }

            //Finalize all remaining stats
            UpdateSkillListModifiers();
            SetArmorClass();
            if (optimalHP) SetOptimalMaxHP(); //TODO: Add rolled max hp
            HP = MaxHP;
            HitDice = HitDiceMax;
        }

        public int CalculateStatModifier(int statScore)
        {
            int modifier = statScore - 10;
            if (statScore < 10)
            {
                modifier--;
            }
            modifier = modifier / 2;
            if (statScore > 30) modifier = 10;

            return modifier;
        }
        public bool CheckForLegitimatePointBuy()
        {
            bool legitamate = true;
            int buyingPoints = 0;
            int[] stats = { Strength, Dexterity, Constituion, Intelligence, Wisdom, Charisma };

            foreach (int stat in stats)
            {
                switch (stat)
                {
                    case 8:
                        buyingPoints += 0;
                        break;
                    case 9:
                        buyingPoints += 1;
                        break;
                    case 10:
                        buyingPoints += 2;
                        break;
                    case 11:
                        buyingPoints += 3;
                        break;
                    case 12:
                        buyingPoints += 4;
                        break;
                    case 13:
                        buyingPoints += 5;
                        break;
                    case 14:
                        buyingPoints += 7;
                        break;
                    case 15:
                        buyingPoints += 9;
                        break;
                    default:
                        legitamate = false;
                        break;
                }
            }
            if (buyingPoints != 27) legitamate = false;
            return legitamate;
        }
        public void SetArmorClass()
        {
            int AC;
            int dexStat = CalculateStatModifier(Dexterity);
            if (equippedArmor == null)
            {
                if (Features.Contains("Unarmored Defense"))
                {
                    if (CharacterClass == CharacterClass.Barbarian)
                    {
                        AC = 10 + dexStat + CalculateStatModifier(Constituion);
                    }
                    else if (CharacterClass == CharacterClass.Monk)
                    {
                        AC = 10 + dexStat + CalculateStatModifier(Wisdom);
                    }
                    else
                    {
                        AC = 10 + dexStat;
                    }
                }
                else if (Features.Contains("Draconic Resilience"))
                {
                    AC = 13 + dexStat;
                }
                else
                {
                    AC = 10 + dexStat;
                }
            }
            else
            {
                AC = equippedArmor.AC;
                if (equippedArmor.MaxDex == null)
                {
                    AC += dexStat;
                }
                else if (equippedArmor.MaxDex > 0)
                {
                    if (dexStat > equippedArmor.MaxDex)
                    {
                        AC += (int)equippedArmor.MaxDex;
                    }
                    else
                    {
                        AC += dexStat;
                    }
                }
            }
            //TODO: Boooo
            if (LeftArmEquipment != null)
            {
                AC += 2;
            }
            ArmorClass = AC;
        }
        public void AddWeapon(string weaponName, List<Weapon> weaponList)
        {
            Weapons.Add(weaponList.Single(a => a.Name == weaponName));
        }
        public void AddEquipment(string equipItem)
        {
            Equipment.Add(equipItem);
        }
        public void AddArmor(Armor equipArmor)
        {
            equippedArmor = equipArmor;
        }
        public void AddSkillProficiency(SkillName skill, ProficiencyLevel proficiencyLevel = ProficiencyLevel.Proficient)
        {
            if (SkillList[(int)skill].proficiency < proficiencyLevel)
            {
                SkillList[(int)skill].SetSkillProficiency(proficiencyLevel);
            }
        }
        public void AddProficiency(string proficiencyName)
        {
            if (!Proficiencies.Contains(proficiencyName))
            {
                Proficiencies.Add(proficiencyName);
            }
        }
        public void AddFeature(string featureName)
        {
            if (!Features.Contains(featureName))
            {
                Features.Add(featureName);
            }
        }
        public void AddLanguage(string languageName)
        {
            if (!Languages.Contains(languageName))
            {
                Languages.Add(languageName);
            }
        }
        public void SetOptimalMaxHP()
        {
            int levelOneHP = int.Parse(HitDiceMax.Split('d')[1]);
            levelOneHP += CalculateStatModifier(Constituion);
            if (Features.Contains("Dwarven Toughness"))
            {
                levelOneHP += 1;
            }
            if (Features.Contains("Draconic Resilience"))
            {
                levelOneHP += 1;
            }

            MaxHP = levelOneHP;
        }
        public void CheckForXPLevelUp()
        {
            if (XP >= 300) ; //Level up to 2
            if (XP >= 900) ; //Level up to 3
            if (XP >= 2700) ; //Level up to 4
            if (XP >= 6500) ; //Level up to 5
            if (XP >= 14000) ; //Level up to 6
            if (XP >= 23000) ; //Level up to 7
            if (XP >= 34000) ; //Level up to 8
            if (XP >= 48000) ; //Level up to 9
            if (XP >= 64000) ; //Level up to 10
            if (XP >= 85000) ; //Level up to 11
            if (XP >= 100000) ; //Level up to 12
            if (XP >= 120000) ; //Level up to 13
            if (XP >= 140000) ; //Level up to 14
            if (XP >= 165000) ; //Level up to 15
            if (XP >= 195000) ; //Level up to 16
            if (XP >= 225000) ; //Level up to 17
            if (XP >= 265000) ; //Level up to 18
            if (XP >= 305000) ; //Level up to 19
            if (XP >= 355000) ; //Level up to 20
        }
        public Skills[] GenerateSkillList()
        {
            Skills[] skillList = new Skills[18];
            foreach (SkillName s in (SkillName[])Enum.GetValues(typeof(SkillName)))
            {
                skillList[(int)s] = new Skills(s);
            }
            return skillList;
        }
        public void UpdateSkillListModifiers()
        {
            foreach (Skills s in SkillList)
            {
                int modifier = 0;
                switch (s.associatedStat)
                {
                    case AbilityStats.Strength:
                        modifier += CalculateStatModifier(Strength);
                        break;
                    case AbilityStats.Dexterity:
                        modifier += CalculateStatModifier(Dexterity);
                        break;
                    case AbilityStats.Constitution:
                        modifier += CalculateStatModifier(Constituion);
                        break;
                    case AbilityStats.Intelligence:
                        modifier += CalculateStatModifier(Intelligence);
                        break;
                    case AbilityStats.Wisdom:
                        modifier += CalculateStatModifier(Wisdom);
                        break;
                    case AbilityStats.Charisma:
                        modifier += CalculateStatModifier(Charisma);
                        break;
                }
                switch (s.proficiency)
                {
                    case ProficiencyLevel.JackofAllTrades:
                        modifier += Proficiency / 2;
                        break;
                    case ProficiencyLevel.Proficient:
                        modifier += Proficiency;
                        break;
                    case ProficiencyLevel.Expert:
                        modifier += Proficiency * 2;
                        break;
                }
                s.UpdateSkillModifier(modifier);
            }
        }
        public void SetRace(Race race, string? subType = null)
        {
            Race = race;

            switch (race)
            {
                case Race.Dwarf:
                    Constituion += 2;
                    Size = "Medium";
                    Speed = 25;
                    AddFeature("Darkvision");
                    AddFeature("Dwarven Resilience");
                    AddFeature("Dwarven Combat Training");
                    AddProficiency("Battleaxe");
                    AddProficiency("Handaxe");
                    AddProficiency("Light Hammer");
                    AddProficiency("Warhammer");
                    AddProficiency("Smith's Tools"); //TODO: Could also be Brewer's Supplies or Mason's Tools
                    AddFeature("Stonecunning");
                    AddLanguage("Common");
                    AddLanguage("Dwarvish");

                    if (subType == "Hill")
                    {
                        Wisdom += 1;
                        AddFeature("Dwarven Toughness");
                    }
                    else if (subType == "Mountain" || subType == null)
                    {
                        Strength += 2;
                        AddProficiency("Light Armor");
                        AddProficiency("Medium Armor");
                    }

                    break;
                case Race.Elf: //TODO: Check in on these guys this is kinda fuckered
                    Dexterity += 2;
                    Size = "Medium";
                    Speed = 30;
                    AddFeature("Darkvision");
                    AddFeature("Keen Senses");
                    AddSkillProficiency(SkillName.Perception);
                    AddFeature("Fey Ancestry");
                    AddFeature("Trance");
                    AddLanguage("Common");
                    AddLanguage("Elvish");

                    if (subType == "High")
                    {
                        Intelligence += 1;
                        AddFeature("Elf Weapon Training");
                        AddProficiency("Longsword");
                        AddProficiency("Shortsword");
                        AddProficiency("Shortbow");
                        AddProficiency("Longbow");
                        //TODO: Add 1 Cantrip
                        AddLanguage("Draconic"); //TODO: This can be any language
                    }
                    else if (subType == "Wood" || subType == null)
                    {
                        Wisdom += 1;
                        AddFeature("Elf Weapon Training");
                        AddProficiency("Longsword");
                        AddProficiency("Shortsword");
                        AddProficiency("Shortbow");
                        AddProficiency("Longbow");
                        AddFeature("Fleet of Foot");
                        Speed = 35;
                        AddFeature("Mask Of The Wild");
                    }
                    else if (subType == "Dark")
                    {
                        Charisma += 1;
                        AddProficiency("Superior Darkvision");
                        AddFeature("Sunlight Sensitivity");
                        AddFeature("Drow Magic");
                        //TODO: Add Dancing Lights cantrip
                        AddFeature("Drow Weapon Training");
                        AddProficiency("Rapier");
                        AddProficiency("Shortsword");
                        AddProficiency("Hand Crossbow");
                    }

                    break;

                case Race.Halfling:
                    Dexterity += 2;
                    Size = "Small";
                    Speed = 25;
                    AddFeature("Lucky");
                    AddFeature("Brave");
                    AddFeature("Halfling Nimbleness");
                    AddLanguage("Common");
                    AddLanguage("Halfling");

                    if (subType == "Lightfoot" || subType == null)
                    {
                        Charisma += 1;
                        AddFeature("Naturally Stealthy");
                    }
                    else if (subType == "Stout")
                    {
                        Constituion += 1;
                        AddFeature("Stout Resilience");
                    }

                    break;

                case Race.Human:
                    Size = "Medium";
                    Speed = 30;
                    AddLanguage("Common");
                    AddLanguage("Elvish"); //TODO: This can be any langauge

                    if (subType == null)
                    {
                        Strength += 1;
                        Dexterity += 1;
                        Constituion += 1;
                        Intelligence += 1;
                        Wisdom += 1;
                        Charisma += 1;
                    }
                    else if (subType == "Variant")
                    {
                        //TODO: These can be any two traits
                        Dexterity += 1;
                        Constituion += 1;
                        AddSkillProficiency(SkillName.Acrobatics); //TODO: This can be any skill
                        AddFeature("Medium Armor Master"); //TODO: This can be any feat
                    }

                    break;

                case Race.Dragonborn:
                    Strength += 2;
                    Charisma += 1;
                    Size = "Medium";
                    Speed = 30;

                    //TODO: This can be any Draconic ancestry
                    if (subType == null) subType = "Red";
                    AddFeature(subType + " Dragon Ancestry");
                    AddFeature("Fire Breath Weapon");
                    AddFeature("Fire Damage Resistance");
                    AddLanguage("Common");
                    AddLanguage("Draconic");

                    break;

                case Race.Gnome:
                    Intelligence += 2;
                    Size = "Small";
                    Speed = 25;
                    AddFeature("Darkvision");
                    AddFeature("Gnome Cunning");
                    AddLanguage("Common");
                    AddLanguage("Gnomish");

                    if (subType == "Forest")
                    {
                        Dexterity += 1;
                        AddFeature("Natural Illusionist");
                        //TODO: Add spell minor illusion
                        AddFeature("Speak With Small Beasts");
                    }
                    else if (subType == "Rock" || subType == null)
                    {
                        Constituion += 1;
                        AddFeature("Artificer's Lore");
                        AddFeature("Tinker");
                    }

                    break;

                case Race.HalfElf:
                    Charisma += 2;
                    //TODO: The next two stats could be any two stats
                    Strength += 1;
                    Constituion += 1;
                    Size = "Medium";
                    Speed = 30;
                    AddFeature("Darkvision");
                    AddFeature("Fey Ancestry");
                    AddFeature("Skill Versatility");
                    //TODO: The next two skill proficiencies can be any skills
                    AddSkillProficiency(SkillName.Insight);
                    AddSkillProficiency(SkillName.Intimidation);
                    AddLanguage("Common");
                    AddLanguage("Elvish");
                    AddLanguage("Dwarvish"); //TODO: This langauge can be any langauge

                    break;

                case Race.HalfOrc:
                    Strength += 2;
                    Constituion += 1;
                    Size = "Medium";
                    Speed = 30;
                    AddFeature("Darkvision");
                    AddFeature("Menacing");
                    AddSkillProficiency(SkillName.Intimidation);
                    AddFeature("Relentless Endurance");
                    AddFeature("Savage Attacks");
                    AddLanguage("Common");
                    AddLanguage("Orc");

                    break;

                case Race.Tiefling:
                    Intelligence += 1;
                    Charisma += 2;
                    Size = "Medium";
                    Speed = 30;
                    AddFeature("Darkvision");
                    AddFeature("Hellish Resistance");
                    AddFeature("Infernal Legacy");
                    //TODO: Add thaumaturgy cantrip
                    AddLanguage("Common");
                    AddLanguage("Infernal");
                    break;
            }
        }
        public void SetBackground(Background background)
        {
            Background = background;
            switch (background)
            {
                case Background.Acolyte:
                    //Skill Proficiencies
                    AddSkillProficiency(SkillName.Insight);
                    AddSkillProficiency(SkillName.Religion);

                    //Langauges TODO: This can be any two

                    //Equipment
                    AddEquipment("Holy Symbol");
                    AddEquipment("Prayer Book"); //Or prayer wheel
                    AddEquipment("Incense Stick x5");
                    AddEquipment("Vestments");
                    AddEquipment("Set Of Common Clothes");
                    GP += 15;

                    //Feature
                    AddFeature("Shelter Of The Faithful");
                    break;
                case Background.Charlatan:
                    //Skill Proficiencies
                    AddSkillProficiency(SkillName.Deception);
                    AddSkillProficiency(SkillName.SleightOfHand);

                    //Tool Proficiencies
                    AddProficiency("Disguise Kit");
                    AddProficiency("Forgery Kit");

                    //Equipment
                    AddEquipment("Set Of Fine Clothes");
                    AddEquipment("Disguise Kit");
                    AddEquipment("Weighted Dice"); //TODO: Can be any tools of the con
                    GP += 15;

                    //Feature
                    AddFeature("False Identity");
                    break;
                case Background.Criminal:
                    //Skill Proficiencies
                    AddSkillProficiency(SkillName.Deception);
                    AddSkillProficiency(SkillName.Stealth);

                    //Tool Proficiencies
                    AddProficiency("Deck Of Cards"); //TODO: Can be any gaming set proficiency
                    AddProficiency("Thieves' Tools");

                    //Equipment
                    AddEquipment("Crowbar");
                    AddEquipment("Set Of Common Clothes");
                    GP += 15;

                    //Feature
                    AddFeature("Criminal Contact");

                    //TODO: Add Varient Spy
                    break;
                case Background.Entertainer:
                    //Skill Proficiencies
                    AddSkillProficiency(SkillName.Acrobatics);
                    AddSkillProficiency(SkillName.Performance);

                    //Tool Proficiencies
                    AddProficiency("Disguise Kit");
                    AddProficiency("Lute"); //TODO: This can be any instrument

                    //Equipment
                    AddEquipment("Lute"); //TODO: Can be any instrument
                    AddEquipment("Favor From An Admirer");
                    AddEquipment("Costume");
                    GP += 15;

                    //Feature
                    AddFeature("By Popular Demand");

                    //TODO: Add Varient Gladiator
                    break;
                case Background.FolkHero:
                    //Skill Proficiencies
                    AddSkillProficiency(SkillName.AnimalHandling);
                    AddSkillProficiency(SkillName.Survival);

                    //Tool Proficiencies
                    AddProficiency("Artisan's Tools"); //TODO: This can be any specific set of artisan's tools
                    AddProficiency("Land Vehicles");

                    //Equipment
                    AddEquipment("Artisan's Tools");
                    AddEquipment("Shovel");
                    AddEquipment("Iron Pot");
                    AddEquipment("Set Of Common Clothes");
                    GP += 10;

                    //Feature
                    AddFeature("Rustic Hospitality");
                    break;
                case Background.GuildArtisan:
                    //Skill Proficiencies
                    AddSkillProficiency(SkillName.Insight);
                    AddSkillProficiency(SkillName.Persuasion);

                    //Tool Proficiencies
                    AddProficiency("Artisan's Tools"); //TODO: This can be any specific artisan's tools

                    //Langauges
                    AddLanguage("Elvish"); //TODO: This can be any specific language

                    //Equipment
                    AddEquipment("Artisan's Tools"); //TODO: This can be any specific artisan's tools
                    AddEquipment("Letter Of Introduction");
                    AddEquipment("Set Of Traveler's Clothes");
                    GP += 15;

                    //Feature
                    AddFeature("Guild Membership");

                    //TODO: Add Varient Guild Merchant
                    break;
                case Background.Hermit:
                    //Skill Proficiency
                    AddSkillProficiency(SkillName.Medicine);
                    AddSkillProficiency(SkillName.Religion);

                    //Tool Proficiency
                    AddProficiency("Herbalism Kit");

                    //Languages
                    AddLanguage("Elvish"); //TODO: This could be any language

                    //Equipment
                    AddEquipment("Scroll Case Of Notes");
                    AddEquipment("Winter Blanket");
                    AddEquipment("Set Of Common Clothes");
                    AddEquipment("Herbalism Kit");
                    GP += 5;

                    //Feature
                    AddFeature("Discovery");
                    break;
                case Background.Noble:
                    //Skill Proficiencies
                    AddSkillProficiency(SkillName.History);
                    AddSkillProficiency(SkillName.Persuasion);

                    //Tool Proficiencies
                    AddProficiency("Deck Of Cards"); //TODO: This can be any gaming set

                    //Languages
                    AddLanguage("Sylvan"); //TODO: This can be any language

                    //Equipment
                    AddEquipment("Set Of Fine Clothes");
                    AddEquipment("Signet Ring");
                    AddEquipment("Scroll Of Pedigree");
                    GP += 25;

                    //Feature
                    AddFeature("Position Of Privilege");

                    //TODO: Add Varient Knight
                    break;
                case Background.Outlander:
                    //Skill Proficiencies
                    AddSkillProficiency(SkillName.Athletics);
                    AddSkillProficiency(SkillName.Survival);

                    //Tool Proficiency 
                    AddProficiency("Lute"); //TODO: This can be any musical instrument

                    //Languages
                    AddLanguage("Elvish"); //TODO: This can be any language

                    //Equipment
                    AddEquipment("Staff");
                    AddEquipment("Hunting Trap");
                    AddEquipment("Hunting Trophy");
                    AddEquipment("Set Of Traveler's Clothes");
                    GP += 10;

                    //Feature
                    AddFeature("Wanderer");
                    break;
                case Background.Sage:
                    //Skill Proficiencies
                    AddSkillProficiency(SkillName.Arcana);
                    AddSkillProficiency(SkillName.History);

                    //Langauges TODO: This can be any two langauges
                    AddLanguage("Elvish");
                    AddLanguage("Draconic");

                    //Equipment
                    AddEquipment("Bottle Of Black Ink");
                    AddEquipment("Quill");
                    AddEquipment("Knife");
                    AddEquipment("Letter From Dead Colleague");
                    AddEquipment("Set Of Common Clothes");
                    GP += 10;

                    //Feature
                    AddFeature("Researcher");
                    break;
                case Background.Sailor:
                    //Skill Proficiencies
                    AddSkillProficiency(SkillName.Athletics);
                    AddSkillProficiency(SkillName.Perception);

                    //Tool Proficiencies
                    AddProficiency("Navigator's Tools");
                    AddProficiency("Water Vehicles");

                    //Equipment
                    AddEquipment("Belaying Pin");
                    AddEquipment("Silk Rope x 50 ft");
                    AddEquipment("Lucky Charm");
                    AddEquipment("Set Of Common Clothes");
                    GP += 10;

                    //Feature
                    AddFeature("Ship's Passage");

                    //TODO: Add Varient Pirate
                    break;
                case Background.Soldier:
                    //Skill Proficiencies
                    AddSkillProficiency(SkillName.Athletics);
                    AddSkillProficiency(SkillName.Intimidation);

                    //Tool Proficiencies
                    AddProficiency("Deck Of Cards"); //TODO: This can be any gaming set proficiency
                    AddProficiency("Land Vehicles");

                    //Equipment
                    AddEquipment("Insignia Of Rank");
                    AddEquipment("Trophy From An Enemy");
                    AddEquipment("Deck Of Cards"); //TODO: This can also be bone dice
                    AddEquipment("Set Of Common Clothes");
                    GP += 10;

                    //Feature
                    AddFeature("Military Rank");
                    break;
                case Background.Urchin:
                    //Skill Proficiencies
                    AddSkillProficiency(SkillName.SleightOfHand);
                    AddSkillProficiency(SkillName.Stealth);

                    //Tool Proficiencies
                    AddProficiency("Disguise Kit");
                    AddProficiency("Thieves' Tools");

                    //Equipment
                    AddEquipment("Knife");
                    AddEquipment("Map Of City Of Origin");
                    AddEquipment("Pet Mouse");
                    AddEquipment("Token To Remember Parents");
                    AddEquipment("Set Of Common Clothes");
                    GP += 10;

                    //Feature
                    AddFeature("City Secrets");
                    break;
            }
        }
    }
}