namespace DndEncounter.Gear
{
    public enum ArmorStyle
    {
        Light,
        Medium,
        Heavy,
        Shield
    }
    public enum ArmorType
    {
        Padded,
        Leather,
        StuddedLeather,
        Hide,
        ChainShirt,
        ScaleMail,
        Breastplate,
        HalfPlate,
        RingMail,
        ChainMail,
        Splint,
        Plate,
        Shield
    }

    public class Armor : Equipment
    {
        public ArmorType ArmorType;
        public ArmorStyle ArmorStyle;
        public int AC;
        public int? MaxDex;
        public int? minimumStrength;
        public bool stealthDisadvantage;
        public int Weight;

        public Armor(ArmorType armor)
        {
            this.ArmorType = armor;
            switch (armor) 
            {
                case ArmorType.Padded:
                    this.ArmorStyle = ArmorStyle.Light;
                    this.AC = 11;
                    this.MaxDex = null;
                    this.minimumStrength = null;
                    this.stealthDisadvantage = true;
                    this.Weight = 8;
                    break;
                case ArmorType.Leather:
                    this.ArmorStyle = ArmorStyle.Light;
                    this.AC = 11;
                    this.MaxDex = null;
                    this.minimumStrength = null;
                    this.stealthDisadvantage = false;
                    this.Weight = 10;
                    break;
                case ArmorType.StuddedLeather:
                    this.ArmorStyle = ArmorStyle.Light;
                    this.AC = 12;
                    this.MaxDex = null;
                    this.minimumStrength = null;
                    this.stealthDisadvantage = false;
                    this.Weight = 13;
                    break;
                case ArmorType.Hide:
                    this.ArmorStyle = ArmorStyle.Medium;
                    this.AC = 12;
                    this.MaxDex = 2;
                    this.minimumStrength = null;
                    this.stealthDisadvantage = false;
                    this.Weight = 12;
                    break;
                case ArmorType.ChainShirt:
                    this.ArmorStyle = ArmorStyle.Medium;
                    this.AC = 13;
                    this.MaxDex = 2;
                    this.minimumStrength = null;
                    this.stealthDisadvantage = false;
                    this.Weight = 20;
                    break;
                case ArmorType.ScaleMail:
                    this.ArmorStyle = ArmorStyle.Medium;
                    this.AC = 14;
                    this.MaxDex = 2;
                    this.minimumStrength = null;
                    this.stealthDisadvantage = true;
                    this.Weight = 45;
                    break;
                case ArmorType.Breastplate:
                    this.ArmorStyle = ArmorStyle.Medium;
                    this.AC = 14;
                    this.MaxDex = 2;
                    this.minimumStrength = null;
                    this.stealthDisadvantage = false;
                    this.Weight = 20;
                    break;
                case ArmorType.HalfPlate:
                    this.ArmorStyle = ArmorStyle.Medium;
                    this.AC = 15;
                    this.MaxDex = 2;
                    this.minimumStrength = null;
                    this.stealthDisadvantage = true;
                    this.Weight = 40;
                    break;
                case ArmorType.RingMail:
                    this.ArmorStyle = ArmorStyle.Heavy;
                    this.AC = 14;
                    this.MaxDex = 0;
                    this.minimumStrength = null;
                    this.stealthDisadvantage = true;
                    this.Weight = 40;
                    break;
                case ArmorType.ChainMail:
                    this.ArmorStyle = ArmorStyle.Heavy;
                    this.AC = 16;
                    this.MaxDex = 0;
                    this.minimumStrength = 13;
                    this.stealthDisadvantage = true;
                    this.Weight = 55;
                    break;
                case ArmorType.Splint:
                    this.ArmorStyle = ArmorStyle.Heavy;
                    this.AC = 17;
                    this.MaxDex = 0;
                    this.minimumStrength = 15;
                    this.stealthDisadvantage = true;
                    this.Weight = 60;
                    break;
                case ArmorType.Plate:
                    this.ArmorStyle = ArmorStyle.Heavy;
                    this.AC = 18;
                    this.MaxDex = 0;
                    this.minimumStrength = 15;
                    this.stealthDisadvantage = true;
                    this.Weight = 65;
                    break;
                case ArmorType.Shield:
                    this.ArmorStyle = ArmorStyle.Shield;
                    this.AC = 2;
                    this.MaxDex = null;
                    this.minimumStrength = null;
                    this.stealthDisadvantage = false;
                    this.Weight = 6;
                    break;
            }
        }
    }
}